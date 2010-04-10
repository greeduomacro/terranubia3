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
	public class SortNubiaDestruction : SortNubia
	{
		public override int GetCercle()
		{
            
				int niveau = (m_minDegat+m_maxDegat)/2; //Moyenne de degat
				niveau /= 4; //Un niveau tout les 4 dégats
				niveau += (m_number-1);
				if(distance < 10)
					niveau += (distance-10)/2;
				else
					niveau += (distance-10);
				if(m_canCible)
					niveau += 1;
				return (int)niveau;
		}

        public override string DefaultName { get { return "Destruction"; } }
        public override SortDomaine Domaine { get { return SortDomaine.Evocation; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return true;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return false;}}

		public override SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[] 
				{
					SortEnergie.All
				};
			}
		}

		//DESTRUCTION
		private int m_minDegat = 5;
		private int m_maxDegat = 10;
		private int m_number = 1;
		private bool m_canCible = true;
	
		[Constructable]
		public SortNubiaDestruction() : base ("Destruction No SortNubia")
		{
			distance = 10;
			Delay = 30.0;
			TimeToCast = 4.0;
		}
		[Constructable]
		public SortNubiaDestruction( Serial serial ) : base (serial)
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
			Owner.Animate( 17, 7, 1, true, false, 0 );
			bool mustExplose = false;
			double Ddamage = (int)((Owner.Niveau+Utility.RandomMinMax(minDegat,maxDegat))*(Maitrise/100.0));
			
			Ddamage *= getRatio();
			int damage = (int)Ddamage;
			if(damage > 40)
				mustExplose = true;
			damage /= m_number; //Donc en fait le minMax correspond au global !!
			
			if(cible != Owner && Owner.CanBeHarmful(cible))
				cible.Damage( damage , Owner );
			else
				m_number++;

			if(cible.Combatant == null && cible != Owner)
				cible.Combatant = Owner;

			SortNubiaHelper.MakeEffect( Owner, cible, this, true, mustExplose );

			int i = 0;
			ArrayList targets = new ArrayList();
			foreach ( Mobile m in cible.GetMobilesInRange( 5 ) )
			{
				if( m == Owner || m == cible || !(Owner.CanBeHarmful(m)) )
					continue;
				i++;
				if( i >= m_number )
					break;

				SortNubiaHelper.MakeEffect( Owner, m, this, true, mustExplose );

				if(m.Combatant == null)
					m.Combatant = Owner;

				//m.Damage( damage , Owner );
				targets.Add(m);
			}
			int count = targets.Count;
			for(int t = 0; t < count; t++)
			{
				Mobile mob = targets[t] as Mobile;
				mob.Damage( damage, Owner );
			}
			EndSortNubia(); //important ;)
		}

		private class InternalTarget : Target
		{
			private SortNubiaDestruction m_Owner;

			public InternalTarget( SortNubiaDestruction owner ) : base( owner.distance, false, TargetFlags.Harmful )
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