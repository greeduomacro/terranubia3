using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Nubia;
using Server.Targeting;

namespace Server.Engines
{
	public enum TissuEnum
	{
		None = -1,
		Lin = 0,
		Coton,
		Soie,
		Laine
	}
	public abstract class BaseTissu : BaseRessource
	{
		private TissuEnum m_tissu = TissuEnum.Lin;
		
		public TissuEnum Tissu {get{return m_tissu;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public override bool isRaffine{
			get
			{
				return m_isRaffine;
			}
			set
			{
				m_isRaffine = value;
				if( m_isRaffine ){
					ItemID = 0x1767;
				}
				else
					ItemID = 0xDF8;
			}
		}

		public BaseTissu(TissuEnum _tissu) : base( 0xDF8 )
		{
			m_tissu = _tissu;
            mRessource = (NubiaRessource)((int)_tissu + 2000);
			//Hue = GetHue();
			Name = "Tissu";
		}


		public static BaseTissu GetTissu(TissuEnum etissu)
		{
			BaseTissu tissu = null;
			switch(etissu){
				case TissuEnum.Lin: tissu = new TissuLin(); break;
				case TissuEnum.Coton: tissu = new TissuCoton(); break;
				case TissuEnum.Soie: tissu = new TissuSoie(); break;
				case TissuEnum.Laine: tissu = new TissuLaine(); break;
			}
			return tissu;
		}

		public static int GetDifficulty(TissuEnum tissu){ 
			int diff = 60;
			switch(tissu){
				case TissuEnum.Lin: diff = 60; break;
				case TissuEnum.Coton: diff = 60; break;
				case TissuEnum.Soie: diff = 75; break;
				case TissuEnum.Laine: diff = 65; break;
				
			}
			return diff;
		}

		public BaseTissu( Serial s ) : base( s )
		{
		}

		public override void OnSingleClick( Mobile from )
		{

			if( Amount <= 1 )
				LabelTo( from, ( m_isRaffine ? "Etoffe" : "Fil" ) );
			else
				LabelTo( from, Amount + ( m_isRaffine ? " Etoffes" : " Fils" ) );
			LabelTo( from, "["+m_tissu.ToString()+"]" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( isRaffine )
				return;
			/*if( BaseCompetence.MustWait(from) )
				return;*/
			else
				from.Target = new InternalPlancheTarget( from as NubiaPlayer, this );
		}
		private class InternalPlancheTarget : Target
		{
			private NubiaPlayer m_owner;
			private BaseTissu m_metal;

			public InternalPlancheTarget( NubiaPlayer owner, BaseTissu met ) : base( 1, true, TargetFlags.None )
			{
				m_owner = owner;
				m_metal = met;
				m_owner.SendMessage("Où voulez vous tisser ?");
			}

			protected override void OnTarget( Mobile from, object obj )
			{
				int itemID = 0;

					if ( obj is Item )
						itemID = ((Item)obj).ItemID;
					else if ( obj is StaticTarget )
						itemID = ((StaticTarget)obj).ItemID & 0x3FFF;

					bool canPlanche = ( (itemID >= 4117 && itemID <= 4126) || (itemID >= 4191 && itemID <= 4198) );

					
					if( canPlanche )
					{
						//BaseCompetence.Wait( m_owner, 7.0 );
						from.Emote("*Tisse*");
						from.SendMessage("Vous commencez à tisser");
						new DelayPlanche( m_owner, m_metal ).Start();
					}
					else
						from.SendMessage("Ceci n'est pas adapté");
					
			}
		}
		private class DelayPlanche : Timer
			{
				private NubiaPlayer m_owner;
				private BaseTissu m_metal;

				public DelayPlanche( NubiaPlayer _owner, BaseTissu _metal ) : base( TimeSpan.FromSeconds( 6.0 ) )
				{
					Priority = TimerPriority.OneSecond;
					m_owner = _owner;
					m_owner.Animate( 16, 30, 1, true, false, 0 );
					//m_mineur.PlaySound( 0x51D );
					m_metal = _metal;
					m_owner.Freeze( TimeSpan.FromSeconds( 6.0 ) );
				}

				protected override void OnTick()
				{
					//RollResult m_result = m_owner.RollCompetence(CompType.Couture, BaseTissu.GetDifficulty(m_metal.Tissu));
					if( m_owner.Competences[CompType.Couture].check(0) ){
						m_owner.SendMessage("Vous tissez avec succès");
						m_metal.isRaffine = true;
					}
					else if ( Utility.RandomBool() )
					{
						m_owner.SendMessage("Vous n'arrivez pas à tissez");
					}
					else{
						m_owner.SendMessage("Vous n'arrivez pas à tissez. Votre tentative rend le fil inexploitable");
						if( m_metal.Amount > 2 )
							m_metal.Amount /= 2;
						else
							m_metal.Delete();
					}
				}
			}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_tissu = (TissuEnum)reader.ReadInt();
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int)0 ); // version
			writer.Write( (int)m_tissu );

		}
	}
}
