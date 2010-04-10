using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class SortNubiaSoin : SortNubia
	{
		public override int GetCercle()
		{
				int niveau = (m_minDegat+m_maxDegat)/2; //Moyenne de degat
				niveau /= 4; //Un niveau tout les 4 dégats
				niveau += (m_number-1);
				if(distance > 5)
					niveau += distance*3;
				else
					niveau += distance;
				if(m_canCible)
					niveau += 1;
				return (int)niveau;
		}

        public override string DefaultName { get { return "Soin"; } }
        public override SortDomaine Domaine { get { return SortDomaine.Soin; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return true;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return false;}}

		public override SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[] 
				{
					SortEnergie.Vie
				};
			}
		}

		//DESTRUCTION
		private int m_minDegat = 5;
		private int m_maxDegat = 10;
		private int m_number = 1;
		private bool m_canCible = true;
	
		[Constructable]
		public SortNubiaSoin() : base ("Soin No SortNubia")
		{
			distance = 1;
			Delay = 30.0;
			TimeToCast = 4.0;
		}
		[Constructable]
		public SortNubiaSoin( Serial serial ) : base (serial)
		{
		}

		public override void StartCast()
		{
			base.StartCast();
		}

		public override bool canCast(NubiaPlayer from)
		{
			return base.canCast(from);
		}
		public override void EndSortNubia()
		{
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;
			
			if(m_canCible)
				Owner.Target = new InternalTarget( this );
			else
				FinishSequence(Owner);
			return true;
		}
		public void FinishSequence(Mobile cible)
		{
			Owner.Animate( 13, 7, 1, true, false, 0 );
			double Ddamage = (int)((Owner.Niveau+Utility.RandomMinMax(minDegat,maxDegat))*(Maitrise/100.0));
			
			Ddamage *= getRatio();
			int damage = (int)Ddamage;

			damage /= m_number; //Donc en fait le minMax correspond au global !!
			
			if(Owner.CanBeBeneficial( cible ))
				cible.Heal( damage );

			//if(cible.Combatant == null && cible != Owner)
			//	cible.Combatant = Owner;

			SortNubiaHelper.MakeEffect( Owner, cible, this, false, false );

			int i = 0;
			ArrayList targets = new ArrayList();
			foreach ( Mobile m in cible.GetMobilesInRange( 5 ) )
			{
				if( m == cible || m == Owner.Combatant || !(Owner.CanBeBeneficial( m )) )
					continue;
				i++;
				if( i >= m_number )
					break;

				SortNubiaHelper.MakeEffect( Owner, cible, this, false, false );

				if(m.Combatant == null)
					m.Combatant = Owner;

				//m.Damage( damage , Owner );
				targets.Add(m);
			}
			int count = targets.Count;
			for(int t = 0; t < count; t++)
			{
				Mobile mob = targets[t] as Mobile;
				mob.Heal( damage );
			}
			EndSortNubia(); //important ;)
		}

		private class InternalTarget : Target
		{
			private SortNubiaSoin m_Owner;

			public InternalTarget( SortNubiaSoin owner ) : base( owner.distance, false, TargetFlags.Beneficial )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.FinishSequence( (Mobile)o );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_minDegat);
			writer.Write( (int) m_maxDegat);
			writer.Write( (int) m_number );
			writer.Write( (bool) m_canCible );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_minDegat  = reader.ReadInt();
			m_maxDegat  = reader.ReadInt();
			m_number = reader.ReadInt();
			m_canCible = reader.ReadBool();				
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool canCible
		{
			get{ return m_canCible; }
			set{ m_canCible = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int number
		{
			get{ return m_number; }
			set{ if(value < 1)
					value = 1;
				m_number = value; InvalidateProperties(); }
		}
		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int minDegat
		{
			get{ return m_minDegat; }
			set{ m_minDegat = value;InvalidateProperties();}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public int maxDegat
		{
			get{ return m_maxDegat; }
			set{ m_maxDegat = value; InvalidateProperties();}
		}
		
	}

}