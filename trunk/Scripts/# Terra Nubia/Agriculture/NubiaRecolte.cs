using System;
using Server;
using Server.Nubia;
using Server.Mobiles;

namespace Server.Items
{
	public class NubiaRecolte : Item
	{
		private EnumPlante m_Plante = EnumPlante.Ble;
		private int m_rollResult = 0;
		private bool m_canEat = false;

		[Constructable]
		public NubiaRecolte(EnumPlante plante, int roll, bool caneat) : base( 8751 )
		{
			Stackable = true;
			m_canEat = caneat;
			m_Plante = plante;
			m_rollResult = roll;
			Name = AgriHelper.GetPlanteString(m_Plante);
			ItemID = AgriHelper.GetPlanteID( m_Plante, EnumPlanteState.Recolte );
		}
		[Constructable]
		public NubiaRecolte( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile f )
		{
			NubiaPlayer from = f as NubiaPlayer;
			if( !from.InRange( this.GetWorldLocation(), 1 ) ){
				from.SendMessage("C'est trop loin");
				return;
			}

			if( m_canEat )
			{
				from.PlaySound( Utility.Random( 0x3A, 3 ) );

				if ( from.Body.IsHuman && !from.Mounted )
					from.Animate( 34, 5, 1, true, false, 0 );

                if (m_rollResult < 10)
				{
					from.SendMessage("C'est à vomir et ça vous rend malade. C'est extrêmemnt peu nourrissant");
					from.Poison = Poison.Lesser;
					from.Hunger -= 50;
				}
				else if( m_rollResult < 15 )
				{
					from.SendMessage("Ceci est vraiment mauvais et peu nourrissant");
                    from.Hunger -= 100;
				}
				else if( m_rollResult < 20 )
				{
					from.SendMessage("Ceci est plutôt fade");
                    from.Hunger -= 200;
				}
                else if (m_rollResult < 24)
				{
					from.SendMessage("Ceci est assez bon");
                    from.Hunger -= 300;
				}
                else if (m_rollResult < 27)
				{
					from.SendMessage("Ceci est vraiment très bon");
                    from.Hunger -= 500;
				}
				else if( m_rollResult < 30 )
				{
					from.SendMessage("Ceci est réellement divin !!");
                    from.Hunger -= 750;
				}
			}
			else
				from.SendMessage("Vous ne pouvez pas le manger comme ça...");
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		
			writer.Write( (int)m_Plante );
			writer.Write( (int)m_rollResult );
			writer.Write( (bool)m_canEat );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Plante = (EnumPlante)reader.ReadInt();
			m_rollResult = reader.ReadInt();
			m_canEat = reader.ReadBool();
		}
	}
	
}
