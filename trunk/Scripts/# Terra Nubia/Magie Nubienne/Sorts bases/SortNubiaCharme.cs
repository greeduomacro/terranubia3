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
	public class SortNubiaCharme : SortNubia
	{
		public override int GetCercle()
		{
				int niv = 2;
				return (int)niv;
		}

        public override  string DefaultName { get { return "Charme"; } }
        public override SortDomaine Domaine { get { return SortDomaine.Chimere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return true;}}

		private Timer m_timer = null;
		//private BaseCreature m_toClone = null;
		private BaseCreature m_invoc = null;
		/*public BaseCreature toClone
		{
			get
			{
				return m_toClone;
			}
			set
			{
				m_toClone = (BaseCreature)value;
			}
		}*/

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

		[Constructable]
		public SortNubiaCharme() : base ("Charme no SortNubia")
		{
			distance = 6;
			Delay = 160.0;
			TimeToCast = 6.0;
		}
		[Constructable]
		public SortNubiaCharme( Serial serial ) : base (serial)
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
			if(m_invoc != null)
			{
				BaseCreature m = m_invoc as BaseCreature;
			
				m.Controlled = false;
				m.ControlMaster = null;

				m_invoc = null;

				Owner.PlaySound( 0x228 );
			}

		
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			double time = (int)(Owner.Niveau)*(Maitrise/15.0);
			time *= getRatio();

			/*if(m_toClone == null)
				return false;*/

			if(m_invoc != null)
			{
				//m_invoc.Delete();
				m_invoc.Controlled = false;
				m_invoc.ControlMaster = null;
				m_invoc = null;
			}
			
			bool charmed = false;

			foreach ( Mobile mob in Owner.GetMobilesInRange( 18 ) )
			{
				if(mob is BaseCreature)
				{
					BaseCreature m = mob as BaseCreature;
                    if (m.Niveau < Owner.Niveau)
					{
						//bool corres = false;
					/*	if(m.competenceLie == competence || competence == CompType.Son)
						{
							m_invoc = m;
							m_invoc.Controlled = true;
							m_invoc.ControlMaster = Owner;
							m_invoc.ControlOrder = OrderType.Guard;
							charmed = true;
						}*/
					}
				}
				if(charmed)
					break;
			}
			
			if(!charmed)
				Owner.SendMessage("Vous n'avez pu trouvez aucune créature Charmable");

			
			Owner.PlaySound( 0x228 );

			

			m_timer = new InternalTimer(this, time);
			m_timer.Start();
			return true;
		}

		private class InternalTimer : Timer
		{
			private SortNubiaCharme m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaCharme item, double t ) : base( TimeSpan.FromSeconds( t ) )
			{
				Priority = TimerPriority.OneSecond;
				m_Item = item;
				m_t = t;
			}

			protected override void OnTick()
			{
				if(m_Item == null)
					return;
				if(m_Item.state == MagieState.WaitEnd)
					m_Item.EndSortNubia();
				Stop();
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 1 ); // version
			//writer.Write( (Mobile) m_toClone );
			writer.Write( (Mobile) m_invoc );
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			//m_toClone = (BaseCreature)reader.ReadMobile();
			m_invoc = (BaseCreature)reader.ReadMobile();
		}		
	}

}