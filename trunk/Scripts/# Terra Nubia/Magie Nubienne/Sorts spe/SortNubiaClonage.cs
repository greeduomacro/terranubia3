using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;
using Server.Items;

namespace Server.Spells
{
	public class SortNubiaClonage : SortNubia
	{
		public override int GetCercle()
		{
				return (int)5;
		}

        public override SortDomaine Domaine { get { return SortDomaine.Chimere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return false;}}
		public override bool isUnique{ get{return true;}}

		private Timer m_timer = null;
		private ArrayList m_clones = new ArrayList();

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
		public SortNubiaClonage() : base ("Les milles clones")
		{
			distance = 6;
			Delay = 120.0;
			TimeToCast = 6.0;
		}
		[Constructable]
		public SortNubiaClonage( Serial serial ) : base (serial)
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
			foreach (KonohaClone clone in m_clones)
			{
				if(clone != null)
					clone.Delete();
			}
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			double time = (int)(Owner.Niveau/3)*(Maitrise/2.0);
            double dnumber = Owner.Niveau * 0.80;
            distance = (Owner.Niveau / 2);
			if(distance > 10)
				distance = 10;
			time *= getRatio();
			dnumber *= getRatio();
			int number = (int)dnumber;
			bool asMove = false;

			for (int i = 0; i < number ; i++)
			{
				int offset = Utility.Random( 8 ) * 2;

				Map map = Owner.Map;

				for ( int c = 0; c < m_Offsets().Length; c += 2 )
				{
					int x = Owner.X + m_Offsets()[( offset + c ) % m_Offsets().Length];
					int y = Owner.Y + m_Offsets()[( offset + c + 1 ) % m_Offsets().Length];

					if ( map.CanSpawnMobile( x, y, Owner.Z ) && Owner.Location != new Point3D(x,y,Owner.Z) )
					{
						KonohaClone clone = new KonohaClone(Owner, Owner.X-x, Owner.Y-y, time+ (Utility.RandomDouble()*2.0));
						if( !asMove && Owner.CanSee( new Point3D(x, y, Owner.Z) ) )
						{
							int oldx = x;
							int oldy = y;
							x = Owner.X;
							y = Owner.Y;
							Owner.MoveToWorld(new Point3D(oldx, oldy, Owner.Z), Owner.Map);
							asMove = true;
							if(Owner.Combatant != null)
							{
								clone.Combatant = Owner.Combatant;
								clone.Combatant.Combatant = clone;
								Owner.Combatant = null;
							}
						}
						//if(clone.Location == Owner.Location)
						
						clone.MoveToWorld( new Point3D( x, y, Owner.Z ), Owner.Map );
						m_clones.Add(clone);
						break;
					}
					else
					{
						if(Owner.Location == new Point3D(x,y,Owner.Z))
						{
							x += Utility.RandomMinMax(-2,2);
							y += Utility.RandomMinMax(-2,2);
						}
						int z = map.GetAverageZ( x, y );

						KonohaClone clone = new KonohaClone(Owner, Owner.X-x, Owner.Y-y, time+ (Utility.RandomDouble()*2.0));

						if ( map.CanSpawnMobile( x, y, z ) )
						{
							
							clone.MoveToWorld( new Point3D( x, y, z ), Owner.Map );
							m_clones.Add(clone);
							break;
						//return true;
						}
					}
											
				}
				/*int x = Owner.X-Utility.RandomMinMax(1,distance);
				int y = Owner.Y-Utility.RandomMinMax(1,distance);
				Point3D p = new Point3D(x, y, Owner.Z);
				if( !asMove && Owner.CanSee( p ) )
				{
					Owner.MoveToWorld(p, Owner.Map);
					asMove = true;
				}
				KonohaClone clone = new KonohaClone(Owner, x,y, time+ (Utility.RandomDouble()*2.0));
				clone.MoveToWorld(p, Owner.Map);
				m_clones.Add(clone);*/
			}
			m_timer = new InternalTimer(this, time+2.0);
			m_timer.Start();
			return true;
		}

		private int[] m_Offsets()
		{
				int[] retour = new int[16] {-Utility.RandomMinMax(1, distance), -Utility.RandomMinMax(1, distance),
				-Utility.RandomMinMax(1, distance),  0,
				-Utility.RandomMinMax(1, distance),  Utility.RandomMinMax(1, distance),
				0, -Utility.RandomMinMax(1, distance),
				0,  Utility.RandomMinMax(1, distance),
				Utility.RandomMinMax(1, distance), -Utility.RandomMinMax(1, distance),
				Utility.RandomMinMax(1, distance),  0,
				Utility.RandomMinMax(1, distance),  Utility.RandomMinMax(1, distance)};
				return retour;
		}
		
		/*-------------------------------------------------
		Ici le timer est juste là pour faire un EndSortNubia()
		synchronisé avec les invocations. Ce qui permet de
		savoir si la tech est active ou non pour en faire 
		un SortNubia "père".
		-------------------------------------------------*/

		private class InternalTimer : Timer
		{
			private SortNubiaClonage m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaClonage item, double t ) : base( TimeSpan.FromSeconds( t ) )
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
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_clones.Count );
			for(int i = 0; i < m_clones.Count; i++)
			{
				writer.Write((Mobile)m_clones[i]);
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			m_clones = new ArrayList();
			int count = reader.ReadInt();
			for(int i = 0; i < count; i++)
			{
				m_clones.Add((KonohaClone)reader.ReadMobile());
			}
		}		
	}

}