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
	public class SortNubiaInvocation : SortNubia
	{
		public override int GetCercle()
		{
				if(m_toClone == null)
					return 1;
                int niv = m_toClone.Niveau;// KonohaSkillHelper.getCreatureNiveau(m_toClone);
				return (int)niv;
		}

        public override string DefaultName { get { return "Invocation"; } }
        public override SortDomaine Domaine { get { return SortDomaine.InvocationVie; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return true;}}

		private Timer m_timer = null;
        private NubiaCreature m_toClone = null;
		private NubiaCreature m_invoc = null;
		public BaseCreature toClone
		{
			get
			{
				return m_toClone;
			}
			set
			{
				m_toClone = (NubiaCreature)value;
			}
		}

		public override SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[] 
				{
					SortEnergie.All
					//CompType.Son
				};
			}
		}

		[Constructable]
		public SortNubiaInvocation() : base ("Invocation no SortNubia")
		{
			distance = 6;
			Delay = 160.0;
			TimeToCast = 6.0;
		}
		[Constructable]
		public SortNubiaInvocation( Serial serial ) : base (serial)
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
			
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );

				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
				Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );
				
				m.Delete();
				m_invoc = null;

				Owner.PlaySound( 0x228 );
			}

		
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			double time = (int)(Owner.Niveau)*(Maitrise/10.0);
			time *= getRatio();

			if(m_toClone == null)
				return false;

			if(m_invoc != null)
			{
				m_invoc.Delete();
				m_invoc = null;
			}

			NubiaCreature m = NubiaHelper.CopyCreature(m_toClone);
			m_invoc = m;

			m_invoc.Summoned = true;
			m_invoc.ControlMaster = Owner;
			m_invoc.ControlOrder = OrderType.Guard;
			m_invoc.Controlled = true;

			m.MoveToWorld(Owner.Location, Owner.Map);
			
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );

			Owner.PlaySound( 0x228 );

			

			m_timer = new InternalTimer(this, time);
			m_timer.Start();
			return true;
		}

		private class InternalTimer : Timer
		{
			private SortNubiaInvocation m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaInvocation item, double t ) : base( TimeSpan.FromSeconds( t ) )
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
			writer.Write( (Mobile) m_toClone );
			writer.Write( (Mobile) m_invoc );
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			m_toClone = (NubiaCreature)reader.ReadMobile();
            m_invoc = (NubiaCreature)reader.ReadMobile();
		}		
	}

}