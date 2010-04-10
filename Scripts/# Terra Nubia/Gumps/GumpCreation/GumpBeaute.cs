using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
	public class GumpBeaute : GumpNubia
	{
        private NubiaPlayer m_owner;
		int choix = 0;


        public GumpBeaute(NubiaPlayer _owner, int _choix)
            : base("Choix de votre apparence...", 260, 300)
		{
			m_owner = _owner;
			choix = _choix;
            //Closable = false;

			int y = YBase;
			int x = XBase;
			int line = 0;
			int scale = 30;
			int decal = 5;


            AddButtonTrueFalse(x, y + (line * scale), 1, (choix == 1), NubiaPlayer.GetBeaute(Apparence.Monstrueux, m_owner.Female));
			line++;

            AddButtonTrueFalse(x, y + (line * scale), 2, (choix == 2), NubiaPlayer.GetBeaute(Apparence.Hideux, m_owner.Female));
            line++;
			
            AddButtonTrueFalse(x, y + (line * scale), 3, (choix == 3), NubiaPlayer.GetBeaute(Apparence.Repoussant, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 4, (choix == 4), NubiaPlayer.GetBeaute(Apparence.Affreux, m_owner.Female));
            line++;
			
            AddButtonTrueFalse(x, y + (line * scale), 5, (choix == 5), NubiaPlayer.GetBeaute(Apparence.Moche, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 6, (choix == 6), NubiaPlayer.GetBeaute(Apparence.Banal, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 7, (choix == 7), NubiaPlayer.GetBeaute(Apparence.Elegant, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 8, (choix == 8), NubiaPlayer.GetBeaute(Apparence.Seduisant, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 9, (choix == 9), NubiaPlayer.GetBeaute(Apparence.Envoutant, m_owner.Female));
            line++;

            AddButtonTrueFalse(x, y + (line * scale), 10, (choix == 10), NubiaPlayer.GetBeaute(Apparence.Eblouissant, m_owner.Female));
            line++;
			
			
			//line++;
			if( choix > 0 ){
				//AddLabel( _x, y, 0, "Continuer");
				AddButton( x , y+(line*scale), 0x850, 0x851,99, GumpButtonType.Reply, 0 );
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
			if( info.ButtonID == 99 )
			{
				from.Beaute = (Apparence)choix;

				//from.CloseGump( typeof( GumpCreation ) );
                from.SendGump(new GumpMenuCreation(from));
				return;
			}
			int newChoix = info.ButtonID;
		//	from.CloseGump( typeof( GumpCreation ) );
			from.SendGump( new GumpBeaute( m_owner, newChoix ) );
		}

	}
}
