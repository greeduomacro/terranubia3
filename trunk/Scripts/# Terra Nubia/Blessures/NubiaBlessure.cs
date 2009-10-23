using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Nubia;
using Server.Items;

namespace Server.Mobiles
{
	public class NubiaBlessure
	{
        public static NubiaBlessure getRandomBlessure()
        {
            NubiaBlessure blessure = null;
            blessure = new NubiaBlessure(Utility.RandomBool(), (BlessureGravite)Utility.Random(5),
                        (BlessureType)Utility.Random(4), Utility.Random(5));
            return blessure;
        }
		//base
		private bool m_hemoragie = false;
		private BlessureGravite m_gravite = BlessureGravite.Normal;
		private BlessureType m_type = BlessureType.Hemoragie;
        private BlessureLocalisation m_localisation = BlessureLocalisation.BrasDroit;
		private int m_soinStatut = 0;
		//# Gestion sur le temps
		private int m_hemoragieCourante = 0;
		private DateTime m_timeEnd = DateTime.Now + TimeSpan.FromHours( 1 );

		public DateTime TimeEnd{get{return m_timeEnd;}}
		public BlessureType BType {get{return m_type;}}
		public BlessureGravite BGravite {get{return m_gravite;} set{m_gravite = value;}}
		public bool Hemo{ get{ return m_hemoragie;}}
		public int CurrentHemo{get{return m_hemoragieCourante;}}
		public int SoinStatut{get{return m_soinStatut;} set{m_soinStatut = value;}}
        public BlessureLocalisation Localisation { get { return m_localisation; } set { m_localisation = value; } }

        public void StopHemo()
        {
            m_hemoragie = false;
        }

        public string GetStringLocalisation()
        {
            switch (m_localisation)
            {
                case BlessureLocalisation.Bassin: return "bassin";
                case BlessureLocalisation.BrasDroit: return "bras droit";
                case BlessureLocalisation.BrasGauche: return "bras gauche";
                case BlessureLocalisation.EpauleDroite: return "épaule droite";
                case BlessureLocalisation.EpauleGauche: return "épaule gauche";
                case BlessureLocalisation.JambeDroite: return "jambe droite";
                case BlessureLocalisation.JambeGauche: return "jambe gauche";
                case BlessureLocalisation.Tete: return "tête";
                case BlessureLocalisation.Torse: return "torse";
                case BlessureLocalisation.Ventre: return "ventre";
            }
            return "inconnue";
        }
        
		public string GetStringGravite()
		{
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return "Légère"; 
				case BlessureGravite.Normal: return "Normale"; 
				case BlessureGravite.Grave: return "Grave"; 
				case BlessureGravite.TresGrave: return "Très grave"; 
				case BlessureGravite.ExtremeGrave: return "Extrêmement grave"; 
				case BlessureGravite.DivinGrave: return "Catastrophique"; 
			}
			return "Inconnue";
		}
        
		public NubiaBlessure( bool _hemo, BlessureGravite _grav, BlessureType _type, int _hemoC )
		{
            m_type = _type;
			if(_hemo)
				m_type = BlessureType.Hemoragie;
			m_hemoragie = _hemo;
			m_gravite = _grav;
			m_timeEnd = getTimeEnd();
            m_localisation = (BlessureLocalisation)Utility.Random(9);
		}

		public NubiaBlessure( bool _hemo, BlessureGravite _grav, BlessureType _type )
            : this(_hemo, _grav, _type, 0 )
		{
		
		}

        public void setTimeEnd(DateTime time)
        {
            m_timeEnd = time;
        }
        public void setLocalisation(BlessureLocalisation loc)
        {
            m_localisation = loc;
        }

		public virtual void OnTurn(NubiaMobile mob)
		{
			if( m_hemoragie && m_hemoragieCourante < getHemoMax()){
				mob.Damage( getHemo(), null );
				m_hemoragieCourante += getHemo();
					
				new BloodNubia(mob).MoveToWorld( mob.Location, mob.Map );
			}
			else if( m_hemoragie && m_hemoragieCourante >= getHemoMax()){
                StopHemo();
                mob.SendMessage("L'hémoragie s'arrête");
			}
			if( m_soinStatut >= 100 )
				m_timeEnd = DateTime.Now;
		}

		public DateTime getTimeEnd()
		{
			if(m_hemoragie)
				return DateTime.Now + TimeSpan.FromMinutes( 60 );
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return DateTime.Now + TimeSpan.FromHours( 4 ); break;
				case BlessureGravite.Normal: return DateTime.Now + TimeSpan.FromHours( 24 );; break;
				case BlessureGravite.Grave: return DateTime.Now + TimeSpan.FromHours( 48 );; break;
				case BlessureGravite.TresGrave: return DateTime.Now + TimeSpan.FromHours( 80 );; break;
				case BlessureGravite.ExtremeGrave: return DateTime.Now + TimeSpan.FromHours( 120 );; break;
				case BlessureGravite.DivinGrave: return DateTime.Now + TimeSpan.FromHours( 350 );; break;
			}
			return DateTime.Now + TimeSpan.FromMinutes( 1 );
		}

		public int getMalusVie()
		{
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return 3;
				case BlessureGravite.Normal: return 6; 
				case BlessureGravite.Grave: return 12; 
				case BlessureGravite.TresGrave: return 24; 
				case BlessureGravite.ExtremeGrave: return 40; 
				case BlessureGravite.DivinGrave: return 80; 
			}
			return 0;
		}
		public int getMalusComp()
		{
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return 0;
				case BlessureGravite.Normal: return 1; 
				case BlessureGravite.Grave: return 2; 
				case BlessureGravite.TresGrave: return 4; 	
                case BlessureGravite.ExtremeGrave: return 6; 
				case BlessureGravite.DivinGrave: return 8; 
			}
			return 0;
		}

		public int getHemo()
		{
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return 1; break;
				case BlessureGravite.Normal: return 3; break;
				case BlessureGravite.Grave: return 5; break;
				case BlessureGravite.TresGrave: return 10; break;
				case BlessureGravite.ExtremeGrave: return 15; break;
				case BlessureGravite.DivinGrave: return 25; break;
			}
			return 0;
		}
		public int getHemoMax()
		{
			switch(m_gravite)
			{
                case BlessureGravite.Legere: return 10; break;
				case BlessureGravite.Normal: return 30; break;
				case BlessureGravite.Grave: return 60; break;
				case BlessureGravite.TresGrave: return 80; break;
				case BlessureGravite.ExtremeGrave: return 100; break;
				case BlessureGravite.DivinGrave: return 120; break;
			}
			return 0;
		}
        public int DD
        {
            get
            {
                switch (m_gravite)
                {
                    case BlessureGravite.Legere: return 10; 
                    case BlessureGravite.Normal: return 12;
                    case BlessureGravite.Grave: return 15;
                    case BlessureGravite.TresGrave: return 20;
                    case BlessureGravite.ExtremeGrave: return 25;
                    case BlessureGravite.DivinGrave: return 30;
                }
                return 10;
            }
        }
	}
}