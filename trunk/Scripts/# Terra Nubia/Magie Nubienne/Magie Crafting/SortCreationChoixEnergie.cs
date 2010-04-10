using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;

namespace Server.Gumps
{
	public class SortCreationChoixEnergie : GumpNubia
	{
		private NubiaPlayer m_owner;
		private SortNubia m_SortNubia;

        public SortCreationChoixEnergie(NubiaPlayer _owner, SortNubia _SortNubia)
            : base("Tissage de sort", 270, 270)
		{
			m_owner = _owner;
			m_SortNubia = _SortNubia;


			bool GM = ( m_owner.AccessLevel >= AccessLevel.GameMaster );

			int largeur = 450;
			int hauteur = 450;
			int x = XBase;
			int y = YBase;
			
			int line = 0;
			int scale = 22;
			//18lignes max ;)
			AddLabel( x, (y+line*scale), ColorTextYellow, "Choix de l'energie");
			line++;
			//AddButton( col, (y+line*scale), 0xFAB, 0xFAC, 998, GumpButtonType.Reply, 0 );
			AddLabel( x, y+line*scale, ColorTextGreen, "Actuelle: "+ SortNubiaHelper.getEnergieString(m_SortNubia.energie) );
			line++;
			
			
			for(int i = (int)SortEnergie.All + 1; i < (int)SortEnergie.Maximum; i++) // 100+
			{
                SortEnergie energie = (SortEnergie)i;

                bool allowComp = SortNubiaHelper.calculMaitriseEnergie(energie, m_owner.Energie) > 0;
				if(!allowComp)
					continue;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 100+i, GumpButtonType.Reply, 0 ); 
				AddLabel( x+40, y+line*scale, ColorTextGreen, SortNubiaHelper.getEnergieString( energie ) );
				line++;

				
			}
            line++;
            AddButton(x, (y + line * scale), 0xFAB, 0xFAC, 999, GumpButtonType.Reply, 0);
            AddLabel(x + 40, y + line * scale, ColorTextRed, "Annuler");
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

			if(info.ButtonID >= 100 && info.ButtonID < 200)
			{
				m_SortNubia.energie = (SortEnergie)(info.ButtonID-100);
			}

			from.SendGump(new SortCreationGump(m_owner, m_SortNubia) );
		}

	}
}