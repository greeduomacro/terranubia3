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
	public class SortNubiaMur : SortNubia
	{
		public override int GetCercle()
		{
				//if(m_toClone == null)
				//	return 1;
				int niv = 1;
				if( m_block )
					niv = 12;
				niv += m_damageWalk/3;

				return (int)niv;
		}

        public override string DefaultName { get { return "Mur"; } }
        public override SortDomaine Domaine { get { return SortDomaine.InvocationMatiere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return true;}}

		private Timer m_timer = null;
		private ArrayList m_items = new ArrayList();
		private bool m_block = true;
		private int m_damageWalk = 0;

		[CommandProperty( AccessLevel.GameMaster )]	
		public int damageWalk 
		{
			get
			{
				return m_damageWalk;
			}
			set
			{
				m_damageWalk = value;
			}
		}
		[CommandProperty( AccessLevel.GameMaster )]	
		public bool block 
		{
			get
			{
				return m_block;
			}
			set
			{
				m_block = value;
			}
		}

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
		public SortNubiaMur() : base ("Mur no SortNubia")
		{
			distance = 20;
			Delay = 160.0;
			TimeToCast = 2.0;
		}
		[Constructable]
		public SortNubiaMur( Serial serial ) : base (serial)
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
			foreach(Item it in m_items)
			{
				//SortNubiaHelper.makeBigSmoke(it.Location, it.Map);
				it.Delete();
			}
			/*if(m_invoc != null)
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
			}*/

		
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			

			m_items = new ArrayList();

			Owner.Target = new InternalTarget(this);
			
			return true;
		}
		public void FinishSequence(IPoint3D p, bool carre)
		{
			if ( !Owner.CanSee( p ) )
			{
				Owner.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}

			double time = (int)(Owner.Niveau)*(Maitrise/10.0);
			time *= getRatio();

			m_timer = new InternalTimer(this, time);
			m_timer.Start();
			
			bool blok = ( m_damageWalk < 1 );
			int id = 0x93;

			if( !carre )
			{
				SpellHelper.GetSurfaceTop( ref p );

				int dx = Owner.Location.X - p.X;
				int dy = Owner.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

                int number = (int)((Owner.Niveau) * (Maitrise / 60.0));

				bool eastToWest;

				if ( rx >= 0 && ry >= 0 )
				{
					eastToWest = false;
				}
				else if ( rx >= 0 )
				{
					eastToWest = true;
				}
				else if ( ry >= 0 )
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound( p, Owner.Map, 0x1F6 );

				for ( int i = -(number/2); i < (number/2); ++i )
				{
					Point3D loc = new Point3D( eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z );
					bool canFit = SpellHelper.AdjustField( ref loc, Owner.Map, 22, true );

					//Effects.SendLocationParticles( EffectItem.Create( loc, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 5025 );

					if ( !canFit )
						continue;

					Item item = new InternalItem( loc, Owner.Map, Owner, SortNubiaHelper.getMur(energie), time, blok, m_damageWalk );
                    item.Hue = 0; // SortNubiaHelper.getCompColor(competence);

					m_items.Add(item);

					//Effects.SendLocationParticles( item, 0x3728, 9, 10, 5025 );
					SortNubiaHelper.makeBigSmoke(item.Location, item.Map);
					//new InternalItem( loc, Caster.Map, Caster );
				}
			}
			else
			{
				Point3D cp = (Point3D)p;
				int decal = 4;
				bool eastToWest = true;
				for( int u = 0; u < 4 ;  u++)
				{
					switch(u)
					{
						case 0: cp = (Point3D)p; cp.X += decal;eastToWest = false; break;
						case 1: cp = (Point3D)p; cp.X -= decal;eastToWest = false; break;
						case 2: cp = (Point3D)p; cp.Y += decal;eastToWest = true;break;
						case 3: cp = (Point3D)p; cp.Y -= decal;eastToWest = true; break;
					}

					for ( int i = -3; i <= 3; ++i )
					{
						Point3D loc = new Point3D( eastToWest ? cp.X + i : cp.X, eastToWest ? cp.Y : cp.Y + i, cp.Z );
						bool canFit = SpellHelper.AdjustField( ref loc, Owner.Map, 22, true );

						//Effects.SendLocationParticles( EffectItem.Create( loc, Caster.Map, EffectItem.DefaultDuration ), 0x376A, 9, 10, 5025 );

						if ( !canFit )
							continue;

                        Item item = new InternalItem(loc, Owner.Map, Owner, SortNubiaHelper.getMur(energie), time, blok, m_damageWalk);
						item.Hue = 2184;//ohaCompHelper.getCompColor(competence);
						m_items.Add(item);

						SortNubiaHelper.makeBigSmoke(item.Location, item.Map);

						//new InternalItem( loc, Caster.Map, Caster );
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private SortNubiaMur m_Owner;

			public InternalTarget( SortNubiaMur owner ) : base( owner.distance, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if( o is Mobile)
				{
					m_Owner.FinishSequence( ((Mobile)o).Location, true );
					return;
				}
				else if ( o is IPoint3D )
					m_Owner.FinishSequence( (IPoint3D)o, false );
			}
		}

		private class InternalTimer : Timer
		{
			private SortNubiaMur m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaMur item, double t ) : base( TimeSpan.FromSeconds( t ) )
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
		//[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private double m_time  = 5.0;
			private bool m_block = true;
			private int m_damage = 0;
			private Mobile m_Caster = null;
			public override bool BlocksFit{ get{ return m_block; } }

			public InternalItem( Point3D loc, Map map, Mobile caster, int id, double time, bool block, int damage ) : base( id )
			{
				Visible = false;
				Movable = false;
				m_block = block;
				m_time = time;
				m_damage = damage;
				m_Caster = caster;

				MoveToWorld( loc, map );

				if ( caster.InLOS( this ) )
					Visible = true;
				else
					Delete();

				if ( Deleted )
					return;

				m_Timer = new InternalTimer( this, TimeSpan.FromSeconds( time ) );
				m_Timer.Start();

				m_End = DateTime.Now + TimeSpan.FromSeconds( time );
			}

			public override bool OnMoveOver(Mobile from)
			{
				if(from == m_Caster)
					return true;
				if(m_damage > 0)
					from.Damage(m_damage);
				return m_block;
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );

				writer.Write( (int) 1 ); // version

				writer.WriteDeltaTime( m_End );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );

				int version = reader.ReadInt();

				switch ( version )
				{
					case 1:
					{
						m_End = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_End - DateTime.Now );
						m_Timer.Start();

						break;
					}
					case 0:
					{
						TimeSpan duration = TimeSpan.FromSeconds( 10.0 );

						m_Timer = new InternalTimer( this, duration );
						m_Timer.Start();

						m_End = DateTime.Now + duration;

						break;
					}
				}
			}

			public override void OnDelete()
			{
				SortNubiaHelper.makeBigSmoke(Location, Map);
				base.OnDelete();
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if ( m_Timer != null )
					m_Timer.Stop();
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer( InternalItem item, TimeSpan duration ) : base( duration )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 1 ); // version
			writer.Write( (int)m_damageWalk);
		//	writer.Write( (Mobile) m_toClone );
		//	writer.Write( (Mobile) m_invoc );

			writer.Write( (int)m_items.Count );
			for (int i = 0; i < m_items.Count ; i++ )
			{
				if( m_items is Item )
				{
					writer.Write( (Item) m_items[i] );
				}
			}
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_damageWalk = reader.ReadInt();
		//	m_toClone = (BaseCreature)reader.ReadMobile();
		//	m_invoc = (BaseCreature)reader.ReadMobile();

			m_items = new ArrayList();
			int count = reader.ReadInt();
			for( int i = 0; i < count ; i++ )
			{
				Item item = reader.ReadItem();
				m_items.Add(item);
			}
		}		
	}

}