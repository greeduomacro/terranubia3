using System;
using Server.Network;
using Server.Items;
using Server.Engines.Craft;

namespace Server.Items
{
	public abstract class LockableContainer : TrapableContainer, ILockable, ILockpickable, ICraftable, IShipwreckedItem
	{
		private bool m_Locked;
        private SerrureQuality m_serrure = SerrureQuality.Simple;
        private int m_MaxLockLevel, m_MiniMaitrise;
		private uint m_KeyValue;
		private Mobile m_Picker;
		private bool m_TrapOnLockpick;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Picker
		{
			get
			{
				return m_Picker;
			}
			set
			{
				m_Picker = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MaxLockLevel
		{
			get
			{
				return m_MaxLockLevel;
			}
			set
			{
				m_MaxLockLevel = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
        public SerrureQuality Serrure
		{
			get
			{
				return m_serrure;
			}
			set
			{
                m_serrure = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
        public int MiniMaitrise
		{
			get
			{
				return m_MiniMaitrise;
			}
			set
			{
                m_MiniMaitrise = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual bool Locked
		{
			get
			{
				return m_Locked;
			}
			set
			{
				m_Locked = value;

				if ( m_Locked )
					m_Picker = null;

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public uint KeyValue
		{
			get
			{
				return m_KeyValue;
			}
			set
			{
				m_KeyValue = value;
			}
		}

		public override bool TrapOnOpen
		{
			get
			{
				return !m_TrapOnLockpick;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool TrapOnLockpick
		{
			get
			{
				return m_TrapOnLockpick;
			}
			set
			{
				m_TrapOnLockpick = value;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 6 ); // version

			writer.Write( m_IsShipwreckedItem );

			writer.Write( (bool) m_TrapOnLockpick );

			writer.Write( (int) m_MiniMaitrise );

			writer.Write( (int) m_MaxLockLevel );

			writer.Write( m_KeyValue );
			writer.Write( (int) m_serrure );
			writer.Write( (bool) m_Locked );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 6:
				{
					m_IsShipwreckedItem = reader.ReadBool();

					goto case 5;
				}
				case 5:
				{
					m_TrapOnLockpick = reader.ReadBool();

					goto case 4;
				}
				case 4:
				{
					m_MiniMaitrise = reader.ReadInt();

					goto case 3;
				}
				case 3:
				{
					m_MaxLockLevel = reader.ReadInt();

					goto case 2;
				}
				case 2:
				{
					m_KeyValue = reader.ReadUInt();

					goto case 1;
				}
				case 1:
				{
					m_serrure = (SerrureQuality)reader.ReadInt();

					goto case 0;
				}
				case 0:
				{
					if ( version < 3 )
						m_MaxLockLevel = 100;

					if ( version < 4 )
					{
						/*if ( (m_MaxLockLevel - m_LockLevel) == 40 )
						{
							m_RequiredSkill = m_LockLevel + 6;
							m_LockLevel = m_RequiredSkill - 10;
							m_MaxLockLevel = m_RequiredSkill + 39;
						}
						else
						{
							m_RequiredSkill = m_LockLevel;
						}*/
					}

					m_Locked = reader.ReadBool();

					break;
				}
			}
		}

		public LockableContainer( int itemID ) : base( itemID )
		{
			m_MaxLockLevel = 100;
		}

		public LockableContainer( Serial serial ) : base( serial )
		{
		}

		public override bool CheckContentDisplay( Mobile from )
		{
			return !m_Locked && base.CheckContentDisplay( from );
		}

		public override bool TryDropItem( Mobile from, Item dropped, bool sendFullMessage )
		{
			if ( from.AccessLevel < AccessLevel.GameMaster && m_Locked )
			{
				from.SendLocalizedMessage( 501747 ); // It appears to be locked.
				return false;
			}

			return base.TryDropItem( from, dropped, sendFullMessage );
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			if ( from.AccessLevel < AccessLevel.GameMaster && m_Locked )
			{
				from.SendLocalizedMessage( 501747 ); // It appears to be locked.
				return false;
			}

			return base.OnDragDropInto( from, item, p );
		}

		public override bool CheckLift( Mobile from, Item item, ref LRReason reject )
		{
			if ( !base.CheckLift( from, item, ref reject ) )
				return false;

			if ( item != this && from.AccessLevel < AccessLevel.GameMaster && m_Locked )
				return false;

			return true;
		}

		public override bool CheckItemUse( Mobile from, Item item )
		{
			if ( !base.CheckItemUse( from, item ) )
				return false;

			if ( item != this && from.AccessLevel < AccessLevel.GameMaster && m_Locked )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				return false;
			}

			return true;
		}

		public override bool DisplaysContent{ get{ return !m_Locked; } }

		public virtual bool CheckLocked( Mobile from )
		{
			bool inaccessible = false;

			if ( m_Locked )
			{
				int number;

				if ( from.AccessLevel >= AccessLevel.GameMaster )
				{
					number = 502502; // That is locked, but you open it with your godly powers.
				}
				else
				{
					number = 501747; // It appears to be locked.
					inaccessible = true;
				}

				from.Send( new MessageLocalized( Serial, ItemID, MessageType.Regular, 0x3B2, 3, number, "", "" ) );
			}

			return inaccessible;
		}

		public override void OnTelekinesis( Mobile from )
		{
			if ( CheckLocked( from ) )
			{
				Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
				Effects.PlaySound( Location, Map, 0x1F5 );
				return;
			}

			base.OnTelekinesis( from );
		}

		public override void OnDoubleClickSecureTrade( Mobile from )
		{
			if ( CheckLocked( from ) )
				return;

			base.OnDoubleClickSecureTrade( from );
		}

		public override void Open( Mobile from )
		{
			if ( CheckLocked( from ) )
				return;

			base.Open( from );
		}

		public override void OnSnoop( Mobile from )
		{
			if ( CheckLocked( from ) )
				return;

			base.OnSnoop( from );
		}

		public virtual void LockPick( Mobile from )
		{
			Locked = false;
			Picker = from;

			if ( this.TrapOnLockpick && ExecuteTrap( from ) )
			{
				this.TrapOnLockpick = false;
			}
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if ( m_IsShipwreckedItem )
				list.Add( 1041645 ); // recovered from a shipwreck
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			LabelTo( from, 1041645 );	//recovered from a shipwreck
		}

		#region ICraftable Members

		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			/*if ( from.CheckSkill( SkillName.Tinkering, -5.0, 15.0 ) )
			{
				from.SendLocalizedMessage( 500636 ); // Your tinker skill was sufficient to make the item lockable.

				Key key = new Key( KeyType.Copper, Key.RandomValue() );

				KeyValue = key.KeyValue;
				DropItem( key );

				double tinkering = from.Skills[SkillName.Tinkering].Value;
				int level = (int)(tinkering * 0.8);

				m_MiniMaitrise = level - 4;
				m_serrure = level - 14;
				MaxLockLevel = level + 35;

				if ( CrochetageDD == 0 )
					CrochetageDD = -1;
				else if ( CrochetageDD > 95 )
					CrochetageDD = 95;

				if ( RequiredSkill > 95 )
					RequiredSkill = 95;

				if ( MaxLockLevel > 95 )
					MaxLockLevel = 95;
			}
			else
			{
				from.SendLocalizedMessage( 500637 ); // Your tinker skill was insufficient to make the item lockable.
			}*/

			return 1;
		}

		#endregion

		#region IShipwreckedItem Members

		private bool m_IsShipwreckedItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsShipwreckedItem
		{
			get { return m_IsShipwreckedItem; }
			set { m_IsShipwreckedItem = value; }
		}
		#endregion

	}
}