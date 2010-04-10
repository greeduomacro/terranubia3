using System;
using System.Collections;
using Server;
using Knives.Utils;
using Server.Items;
using Server.Multis;

namespace Knives.TownHouses
{
	public class TownHouse : BaseHouse
	{
		private static ArrayList s_TownHouses = new ArrayList();

		public static ArrayList AllTownHouses{ get{ return s_TownHouses; } }

		private TownHouseSign c_Sign;
		private ArrayList c_Blocks = new ArrayList();
		private Item c_Hanger;
        private ArrayList c_Sectors = new ArrayList();

        public ArrayList Blocks { get { return c_Blocks; } }

		public TownHouseSign ForSaleSign
		{
			get
			{
				if ( c_Sign == null && !(c_Sign is RentalContract) )
					RecreateSign();

				return c_Sign;
			}
		}

		public Item Hanger
		{
			get
			{
				if ( c_Hanger == null )
				{
					c_Hanger = new Item( 0xB98 );
					c_Hanger.Movable = false;
					c_Hanger.Location = Sign.Location;
					c_Hanger.Map = Sign.Map;
				}

				return c_Hanger;
			}
			set{ c_Hanger = value; }
		}

		public TownHouse( Mobile m, TownHouseSign sign, ArrayList list, int locks, int secures ) : base( 0x1DD8 | 0x4000, m, locks, secures )
		{
			c_Sign = sign;
			c_Blocks = list;

			SetSign( 0, 0, 0 );

			s_TownHouses.Add( this );
		}

		private void RecreateSign()
		{
			c_Sign = new TownHouseSign();
			c_Sign.Map = Map;
			c_Sign.Location = Sign.Location;
			c_Sign.Z = Sign.Z-5;
			c_Sign.Price = Price;
			c_Sign.Blocks = new ArrayList( c_Blocks );
			c_Sign.House = this;
			c_Sign.MinZ = Region.MinZ;
			c_Sign.MaxZ = Region.MaxZ;
			c_Sign.Locks = MaxLockDowns;
			c_Sign.Secures = MaxSecures;
			c_Sign.BanLoc = Region.GoLocation;
			c_Sign.SignLoc = Sign.Location;

			if ( Owner != null )
				Errors.Report( String.Format( "A Town House Setup sign has been generated for {0}'s TownHouse.  This is not normal, as the sign should never had been deleted.  Some properties of their home may not be the same intended.", Owner.Name ) );
		}

		public void InitSectorDefinition()
		{
            if (c_Sign == null || c_Sign.Blocks.Count == 0)
                return;

			int minX = ((Rectangle2D)c_Sign.Blocks[0]).Start.X;
			int minY = ((Rectangle2D)c_Sign.Blocks[0]).Start.Y;
			int maxX = ((Rectangle2D)c_Sign.Blocks[0]).End.X;
			int maxY = ((Rectangle2D)c_Sign.Blocks[0]).End.Y;

			foreach( Rectangle2D rect in c_Sign.Blocks )
			{
				if ( rect.Start.X < minX )
					minX = rect.Start.X;
				if ( rect.Start.Y < minY )
					minY = rect.Start.Y;
				if ( rect.End.X > maxX )
					maxX = rect.End.X;
				if ( rect.End.Y > maxY )
					maxY = rect.End.Y;
			}

            foreach (Sector sector in c_Sectors)
                sector.OnMultiLeave(this);

            c_Sectors.Clear();
            for (int x = minX; x < maxX; ++x)
                for (int y = minY; y < maxY; ++y)
                    c_Sectors.Add(Map.GetSector(new Point2D(x, y)));

            foreach (Sector sector in c_Sectors)
                sector.OnMultiEnter(this);

            //Components.Resize( maxX-minX, maxY-minY );
            //Components.Add(0x520, Components.Width - 1, Components.Height - 1, -5);
            //RefreshComponents();
        }

        public override void UpdateRegion()
		{
            base.UpdateRegion();

            if (c_Sign == null)
                return;

            Rectangle3D[] rects = Region.Area;
            Rectangle2D rect;

            for (int i = 0; i < rects.Length && i < ForSaleSign.Blocks.Count; ++i)
            {
                rect = (Rectangle2D)ForSaleSign.Blocks[i];
                rects[i] = new Rectangle3D(new Point3D(rect.Start.X, rect.Start.Y, ForSaleSign.MinZ), new Point3D(rect.End.X, rect.End.Y, ForSaleSign.MaxZ));
            }
            
            Region.Unregister();
            Region.Register();
		}

		public override Rectangle2D[] Area
        {
            get
            {
                return new Rectangle2D[c_Sign == null ? 100 : c_Sign.Blocks.Count];
            }
        }

        public override Point3D BaseBanLocation { get { return Point3D.Zero; } }

		public override bool IsInside( Point3D p, int height )
		{
			if ( Map == null || Region == null )
			{
				Delete();
				return false;
			}

			Sector sector = null;

			try{

			if ( ForSaleSign is RentalContract && Region.Contains( p ) )
				return true;

			sector = Map.GetSector( p );

			foreach( BaseMulti m in sector.Multis )
			{
				if ( m != this
				&& m is TownHouse
				&& ((TownHouse)m).ForSaleSign is RentalContract
				&& ((TownHouse)m).IsInside( p, height ) )
					return false;
			}

			return Region.Contains( p );

		}catch{ Errors.Report( String.Format( "TownHouse-> IsInside()-> 1:{0} 2:{1} 3:{2} 4:", Map, sector, Region, sector != null ? "" + sector.Multis : "**" ) ); return false; } }

		public override int GetNewVendorSystemMaxVendors()
		{
			return 50;
		}

		public override int GetAosMaxSecures()
		{
			return MaxSecures;
		}

		public override int GetAosMaxLockdowns()
		{
			return MaxLockDowns;
		}

		public override void OnMapChange()
		{
			base.OnMapChange();

			if ( c_Hanger != null )
				c_Hanger.Map = Map;
		}

		public override void OnLocationChange( Point3D oldLocation )
		{
			base.OnLocationChange( oldLocation );

			if ( c_Hanger != null )
				c_Hanger.Location = Sign.Location;
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( e.Mobile != Owner || !IsInside( e.Mobile ) )
				return;

			if ( e.Speech.ToLower() == "check house rent" )
				ForSaleSign.CheckRentTimer();
		}

		public override void OnDelete()
		{
			if ( c_Hanger != null )
				c_Hanger.Delete();

			foreach( Item item in Sign.GetItemsInRange( 0 ) )
				if ( item != Sign )
					item.Visible = true;

			base.OnDelete();

			s_TownHouses.Remove( this );
		}

		public override void OnAfterDelete()
		{try{

			ForSaleSign.ClearHouse();

			Doors.Clear();

			base.OnAfterDelete();

		}catch{ Errors.Report( String.Format( "TownHouse-> OnAfterDelete()-> {0}", Owner ) ); } }

		public TownHouse( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( 3 );

			// Version 2

			writer.Write( c_Hanger );

			// Version 1

			writer.Write( c_Sign );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version >= 2 )
				c_Hanger = reader.ReadItem();

			c_Sign = (TownHouseSign)reader.ReadItem();

            if (version <= 2)
            {
                c_Blocks = new ArrayList();
                int count = reader.ReadInt();
                for (int i = 0; i < count; ++i)
                    c_Blocks.Add(TownHouseSetupGump.FixRect(reader.ReadRect2D()));
            }

			InitSectorDefinition();

			if( Price == 0 )
				Price = 1;

			s_TownHouses.Add( this );
        }
	}
}