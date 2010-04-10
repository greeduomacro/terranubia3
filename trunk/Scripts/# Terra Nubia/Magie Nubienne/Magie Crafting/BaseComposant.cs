using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public abstract class BaseComposant : Item
	{
		//private int m_indicePuissance = 0; //de 0 a 30
		//private int m_indiceDuree = 0; //pareil
		protected Type[] m_interdit = new Type[0];
        private SortEnergie m_energie = SortEnergie.Mental;
		public virtual bool Primaire {get{return false;}}
		public virtual int Niveau {get{return 5;}}

        public SortEnergie energie
		{
			get
			{
				return m_energie;
			}
			set
			{
				m_energie = value;
			}
		}
		public Type[] interdit 
		{
			get
			{
				return m_interdit;
			}
		}

		public virtual ArrayList getInfo()
		{
			ArrayList inf = new ArrayList();
			string info = "Informations";
			inf.Add(info);
			return inf;
		}


		public BaseComposant() : base( 0x1422 )
		{
			Name = "Composant";
			Weight = 1.0;
			Hue = 0;
			int body = Utility.RandomMinMax( 6249,6256 );
			ItemID = body;
		}

		public virtual void Generation() //Sert a autoGénérer un compo ;)
		{
			Generation(Utility.RandomMinMax(3,15));
		}

		public virtual void Generation(int level) //Sert a autoGénérer un compo ;)
		{
			
		}
		public BaseComposant( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			list.Add(Name);
			string display = "Niveau: " + Niveau;
			/*if(Primaire)
				display += "\n [Primaire]";
			else
				display += "\n [Secondaire]";*/
			//display += "\n Connaissance: "+KonohaCompHelper.getNameComp(competence);
			for(int i = 0; i < getInfo().Count; i++)
			{
				display += "\n";
				display += getInfo()[i].ToString();
			}
			//if(Interdit != null)
			//	display += "\n Combinaison interdite avec "+Interdit.Name;
			list.Add(display);
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			
		}

		
	}

}