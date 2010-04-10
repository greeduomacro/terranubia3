using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;
using Server.Misc;


namespace Server.Gumps
{
	public class SortListGump : Gump
	{
		private NubiaPlayer m_owner;

        public SortListGump(NubiaPlayer _owner, bool Gm)
            : base(50, 50)
		{
			m_owner = _owner;

			int largeur = 550;
			int hauteur = 300;
			int _x = 50;
			int _y = 50;
			AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x13BE );
			AddBackground( _x+10, _y+10, _x+largeur-20,_y+hauteur-15, 0x0DAC );
			AddImage( 0,0, 0x28C8 );
			AddImage( largeur+70,0, 0x28C9 );
			AddImage( (largeur/2)-10,30, 0x28D4 );
		
			int y = 45+_y;
			int line = 4;
			int scale = 22;
			int col1 = 80+_x;
			
			AddLabel(col1-40, (line*scale), 2117, "Liste des Jutsus de " +m_owner.Name);
			line++;
			line++;
			//18lignes max ;)
            for (int i = 0; i < m_owner.Magie.sortList.Length; i++)
			{
				if(!Gm)
					AddButton( col1, (line*scale), 0xFA5, 0xFA7, 100+i, GumpButtonType.Reply, 0 ); //Lancer
				else
				{
					AddButton( col1, (line*scale), 0xFA8, 0xFA9, 300+i, GumpButtonType.Reply, 0 ); //Propriété
					AddButton( col1-80, (line*scale), 0xFA8, 0xFA9, 500+i, GumpButtonType.Reply, 0 ); //Extraction
				}
				AddButton( col1-40, (line*scale), 0xFAB, 0xFAC, 200+i, GumpButtonType.Reply, 0 ); //Voir
				
				int color = 2122;
				if( !m_owner.Magie.sortList[i].timeStateOk() )
					color = 2117;

                AddLabel(col1 + 45, (line * scale), color, "[" + i + "] " + m_owner.Magie.sortList[i].Nom);
				line++;
				if( line > 14 )
				{
					line = 6;
					col1 += 280;
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

			if ( info.ButtonID >= 100 && info.ButtonID < 200 ) //Jutsu Cast
			{
				from.Magie.executeSort(info.ButtonID-100);
			}
			if( info.ButtonID >= 200 && info.ButtonID < 300 )
			{
				from.CloseGump(typeof(SortInfoGump));
				from.SendGump(new SortInfoGump(m_owner.Magie.getSort(info.ButtonID-200) ));
			}
			if( info.ButtonID >= 300 && info.ButtonID < 500 )
			{
				from.CloseGump(typeof(SortInfoGump));
                from.SendGump(new PropertiesGump(from, m_owner.Magie.getSort(info.ButtonID - 300)));
			}
			if( info.ButtonID >= 500 ) //Extraire un parchemin
			{
				from.CloseGump(typeof(SortInfoGump));
                try
                {
                    SortNubia jutsu = (SortNubia)NubiaHelper.CopyItem(m_owner.Magie.getSort(info.ButtonID - 500));
				jutsu.MoveToWorld( from.Location, from.Map );
				from.SendMessage("Copy faite");}
				catch{from.SendMessage("Copy impossible!");}
				//from.SendGump(  new PropertiesGump( from, from.getJutsu(info.ButtonID-300) ) );
			}
		}

	}
}