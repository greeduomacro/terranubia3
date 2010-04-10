using System;
using Server;
using Server.Nubia;
using System.Collections;

namespace Server.Items
{
	public class ImpactItem : Item
	{
		private ArrayList m_items = new ArrayList();
		
		[Constructable]
		public ImpactItem() : this( true )
		{
		}
		[Constructable]
		public ImpactItem(bool mustConstruct) : base( 0x11C5 )
		{
			Name = "Impact de la foudre";
			Movable = false;
			Hue = 1890;
			new InternalTimer( this ).Start();
			if(mustConstruct)
				new InternalTimer2( this ).Start();
			/*Console.WriteLine("Location Origine: "+Location);
			Construct();*/
		}

		public void Construct()
		{
			//Console.WriteLine("Construction de l'impact de foudre");
			Item ch = new Item(0x549);
			ch.Movable = false;
			ch.MoveToWorld( new Point3D(X-1,Y-1,Z) , Map);
			//Console.WriteLine("Ch construit: "+ch+"\n Location: "+ch.Location+" ; "+ch.Map);
			m_items.Add(ch);

			Item cb = new Item(0x540);
			cb.Movable = false;
			cb.MoveToWorld( new Point3D(X+1,Y+1,Z) , Map);
			m_items.Add(cb);

			Item cd = new Item();
			cd.ItemID = 0x548;
			cd.Movable = false;
			cd.MoveToWorld( new Point3D(X+1,Y-1,Z) , Map);
			m_items.Add(cd);

			Item cg = new Item();
			cg.ItemID = 0x547;
			cg.Movable = false;
			cg.MoveToWorld( new Point3D(X-1,Y+1,Z) , Map);
			m_items.Add(cg);

			Item n = new Item();
			n.ItemID = 0x54D;
			n.Movable = false;
			n.MoveToWorld( new Point3D(X,Y-1,Z) , Map);
			m_items.Add(n);

			Item s = new Item();
			s.ItemID = 0x541;
			s.Movable = false;
			s.MoveToWorld( new Point3D(X,Y+1,Z) , Map);
			m_items.Add(s);

			Item e = new Item();
			e.ItemID = 0x545;
			e.Movable = false;
			e.MoveToWorld( new Point3D(X+1,Y,Z) , Map);
			m_items.Add(e);

			Item w = new Item();
			w.ItemID = 0x54A;
			w.Movable = false;
			w.MoveToWorld( new Point3D(X-1,Y,Z) , Map);
			m_items.Add(w);

			foreach(Item it in m_items){
				it.Hue = 1890;
				Name = "Impact de foudre";
			}

			Item fire0 = new Item();
			fire0.ItemID = 0x19AB;
			fire0.Light = LightType.Circle225;
			fire0.Movable = false;
			fire0.MoveToWorld( new Point3D(X,Y,Z+2) , Map);
			m_items.Add(fire0);
			
			/*int nbr = Utility.RandomMinMax(1,3);
			for(int i = 0; i < nbr; i++)
			{
				Item fire = new Item();
				fire.ItemID = 0x19AB;
				fire.Light = LightType.Circle225;
				fire.Movable = false;
				fire.MoveToWorld( new Point3D(X+Utility.RandomMinMax(-2,2),Y+Utility.RandomMinMax(-2,2),Z) , Map);
				m_items.Add(fire);
			}*/
		}

		public override void OnDelete()
		{
			int nbr = m_items.Count;
			for(int i = 0; i < nbr; i++)
			{
				((Item)m_items[i]).Delete();
			}
		}

		[Constructable]
		public ImpactItem( Serial serial ) : base( serial )
		{
			new InternalTimer( this ).Start();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			int nbr = m_items.Count;
			writer.Write( (int)nbr );
			for(int i = 0; i < nbr; i++)
			{
				writer.Write( (Item)m_items[i] );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			int nbr = reader.ReadInt();
			m_items = new ArrayList();
			for(int i = 0; i < nbr; i++)
			{
				m_items.Add( reader.ReadItem() );
			}
		}

		private class InternalTimer : Timer
		{
			private Item m_Blood;

			public InternalTimer( Item blood ) : base( TimeSpan.FromMinutes( 5.0 ) )
			{
				Priority = TimerPriority.OneMinute;

				m_Blood = blood;
			}

			protected override void OnTick()
			{
				if(m_Blood != null)
					m_Blood.Delete();
			}
		}

		private class InternalTimer2 : Timer
		{
			private ImpactItem m_Blood;

			public InternalTimer2( ImpactItem blood ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				Priority = TimerPriority.OneSecond;

				m_Blood = blood;
			}

			protected override void OnTick()
			{
				if(m_Blood != null)
					m_Blood.Construct();
			}
		}
	}
}
