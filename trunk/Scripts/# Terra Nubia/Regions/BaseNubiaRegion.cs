using System;
using System.Collections;
using Server;
using Server.Regions;
using  Server.Items;

//new Point2D(2826,1360),new Point2D(2990,1530) (Chante Lune )
namespace Server.Regions
{
	public class initialNubiaRegion //Class pour initialiser nos régions
	{
		public static void Initialize()
		{
            new RegionMineRendsbourg();
		}
	}
	public class BaseNubiaRegion : Region
	{
		public virtual bool CanFoudre { get{ return true; } }
		public virtual bool DisplayEnterExit { get{ return true; } }
        public virtual bool CanAutoXP { get { return false; } }

        //Ressources spéciales des mines & co
        public virtual NubiaRessource[] Ressources { get { return new NubiaRessource[] { }; } }

        public BaseNubiaRegion(string name, int priority, Rectangle2D rec, Map map)
            : base(name, map, priority, new Rectangle2D[] { rec })
		{
			Console.WriteLine("CONSTRUCTION DE REGION: "+Name);
			Register();
		}

		public override void OnEnter( Mobile m )
		{
			if( DisplayEnterExit )
				m.SendMessage("Vous entrez dans "+Name);
		}

		public override void OnExit( Mobile m )
		{
			if( DisplayEnterExit )
				m.SendMessage("Vous sortez de "+Name);
		}

		public override void OnSpeech( SpeechEventArgs args )
		{
			base.OnSpeech( args );
		}

		public override void OnAggressed( Mobile aggressor, Mobile aggressed, bool criminal )
		{
			base.OnAggressed( aggressor, aggressed, criminal );
		}

		/*public override bool AllowHousing( Mobile from, Point3D p )
		{
			from.SendMessage("Les constructions sont prohibée sur le territoire de Chante-Lune");
			return false;
		}*/
	}

	
}