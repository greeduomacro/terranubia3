using System;
using System.Collections;
using Server;
using Server.Spells;
using Server.Spells.Necromancy;
using Server.Mobiles;
using Server.Items;
using Server.Spells.Ninjitsu;

namespace Server.Spells
{
	public class KonohaClone : BaseCreature
	{
		private Mobile m_Caster;
		private Mobile m_substitute = null;
		private Item m_subItem = null;

		[CommandProperty( AccessLevel.GameMaster )]
		public Item subItem
		{
			get{ return m_subItem; }
			set{ m_subItem = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile substitute
		{
			get{ return m_substitute; }
			set{ m_substitute = value; InvalidateProperties(); }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Caster {get{return m_Caster;}}

		public int m_decalX = 0;
		public int m_decalY = 0;


		/*public KonohaClone( Mobile caster): base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			KonohaClone( caster, 1,1, 15.0 );
		}*/

		public KonohaClone( Mobile caster, int decalageX, int decalageY, double _time ) : base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			m_Caster = caster;

			m_decalX = decalageX;
			m_decalY = decalageY;

			Body = caster.Body;

			Hue = caster.Hue;
			Female = caster.Female;

			//Location = caster.Location;

			Name = caster.Name;
			NameHue = caster.NameHue;

			Title = caster.Title;
			Kills = caster.Kills;

			HairItemID = caster.HairItemID;
			HairHue = caster.HairHue;

			SpeechHue = caster.SpeechHue;
			EmoteHue = caster.EmoteHue;

			FacialHairItemID = caster.FacialHairItemID;
			FacialHairHue = caster.FacialHairHue;

			for ( int i = 0; i < caster.Skills.Length; ++i )
			{
				Skills[i].Base = caster.Skills[i].Base;
				Skills[i].Cap = caster.Skills[i].Cap;
			}

			for( int i = 0; i < caster.Items.Count; i++ )
			{
				AddItem( CloneItem( caster.Items[i] ) );
			}

			Warmode = caster.Warmode;

			Summoned = true;
			SummonMaster = caster;

			ControlOrder = OrderType.Stay;
			ControlTarget = caster;

			TimeSpan duration = TimeSpan.FromSeconds( _time );

			new UnsummonTimer( caster, this, duration ).Start();
			SummonEnd = DateTime.Now + duration;

			Location = caster.Location;
			Map = caster.Map;

			MirrorImage.AddClone( m_Caster );
		}

		protected override BaseAI ForcedAI { get { return new KonohaCloneAI( this ); } }

		public override bool IsHumanInTown() { return false; }

		private Item CloneItem( Item item )
		{
			Item newItem = new Item( item.ItemID );
			newItem.Hue = item.Hue;
			newItem.Layer = item.Layer;
			
			return newItem;
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{			
			Delete();
		}

		public override bool DeleteCorpseOnDeath { get { return true; } }

		public override void OnDelete()
		{
			if(m_substitute != null) // on substitu
			{
				Effects.SendLocationParticles( EffectItem.Create( m_substitute.Location, m_substitute.Map, EffectItem.DefaultDuration ), 0x3728, 10, 15, 5042 );
				m_substitute.MoveToWorld(Location,Map);
				//Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3728, 10, 15, 5042 );
				//sub.SummonEnd = DateTime.Now + duration;
				if(Combatant != null)
				{
					if(Combatant.Combatant == this)
						Combatant.Combatant = m_substitute;
				}
				m_substitute.Say("?!!");
			}
			if(m_subItem != null) // on substitu
			{
				Effects.SendLocationParticles( EffectItem.Create( m_subItem.Location, m_subItem.Map, EffectItem.DefaultDuration ), 0x3728, 10, 15, 5042 );
				m_subItem.MoveToWorld(Location,Map);
				m_subItem.Movable = true;
			}

			Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3728, 10, 15, 5042 );
			base.OnDelete();
		}

		public override void OnAfterDelete()
		{
			MirrorImage.RemoveClone( m_Caster );
			base.OnAfterDelete();
		}

		public override bool IsDispellable { get { return false; } }
		public override bool Commandable { get { return false; } }

		public KonohaClone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( m_Caster );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Caster = reader.ReadMobile();

			//MirrorImage.AddClone( m_Caster );
		}
	}
}


namespace Server.Spells
{
	public class KonohaCloneAI : BaseAI
	{
		private KonohaClone m_clone;
		public KonohaCloneAI( KonohaClone m ) : base ( m )
		{
			m.CurrentSpeed = m.ActiveSpeed;
			m_clone = m;
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if( e.Mobile == m_Mobile.SummonMaster )
			{
				m_Mobile.Say(e.Speech);
				/*if (e.Speech.ToLower() == "dissiper")
				{
					m_Mobile.Delete();
				}*/
			}
		}

		public override bool Think()
		{
			// Clones only follow their owners
			Mobile master = m_Mobile.SummonMaster;

			//Attaque la cible du Caster

			if ( master != null && master.Map == m_Mobile.Map && master.InRange( m_Mobile, m_Mobile.RangePerception ) )
			{
				
				if(m_clone.substitute != null)
					return true;
				if(m_clone.subItem != null)
					return true;
				
				//int iCurrDist = (int)m_Mobile.GetDistanceToSqrt( master );
				//				bool bRun = (iCurrDist > 3);

				m_Mobile.Warmode = master.Warmode;

				m_Mobile.Combatant = master.Combatant;

				if (m_Mobile.X == master.X-m_clone.m_decalX && m_Mobile.Y == master.Y-m_clone.m_decalY && m_Mobile.Combatant == null)
				{
					m_Mobile.Direction = master.Direction;
					return true;
				}

				//WalkMobileRange( master, 2, bRun, 0, 1 );
				if(m_Mobile.Combatant == null)
				{
					DoMove(m_Mobile.GetDirectionTo( new Point2D(master.X-m_clone.m_decalX, master.Y-m_clone.m_decalY ) ));
					m_Mobile.Direction = master.Direction;
				}
				else
					WalkMobileRange( m_Mobile.Combatant, 2, ( m_Mobile.GetDistanceToSqrt( m_Mobile.Combatant ) > 2 ), 0, 1 );
				//m_Mobile.

				
			}
			/*else
				m_Mobile.Delete();*/

			return true;
		}
	}
}
