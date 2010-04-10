using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Gumps
{
    public class SortCreationConfirm : Gump
	{
		private NubiaPlayer m_owner;
		private SortNubia m_SortNubia;
		private bool m_creation;
        public SortCreationConfirm(NubiaPlayer _owner, SortNubia _SortNubia, bool creation)
            : base(50, 50)
		{
			m_owner = _owner;
			m_SortNubia = _SortNubia;
			m_creation = creation;

			int largeur = 280;
			int hauteur = 250;
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
			int col = 35+_y;
			//18lignes max ;)
			if(m_creation)
				AddLabel( col, (line*scale), 2224, "Création d'un nouveau SortNubia");
			else
				AddLabel( col, (line*scale), 2224, "Apprentissage d'un nouveau SortNubia");
			line++;
			//AddButton( col, (line*scale), 0xFAB, 0xFAC, 998, GumpButtonType.Reply, 0 );
			AddLabel( col, line*scale, 2116, "Confirmation ?" );
			line++;
			line++;

			AddLabel( col, (line*scale), 2224, "Vous allez obtenir un nouveau SortNubia");
			line++;
		 
			AddLabel( col+40, line*scale, 0, "Nom: "+m_SortNubia.Nom);
			line++;
			AddLabel( col+40, line*scale, 0, "Emote: "+m_SortNubia.Emote);
			line++;
			AddLabel( col+40, line*scale, 0, "Niveau: "+m_SortNubia.GetCercle());
			line++;
			line++;
			line++;
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 100, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 2116, "Confirmer" );
			line++;
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 103, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "Retour" );
			line++;
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

			if(info.ButtonID == 100) // Creation
			{
				bool GM = ( from.AccessLevel >= AccessLevel.GameMaster );

				if(m_creation && (from.pointCreation >= m_SortNubia.GetCercle() || GM ))
				{
					if(!GM)
						from.pointCreation -= m_SortNubia.GetCercle();
					//m_SortNubia.Owner = from;
					m_SortNubia.Createur = from.Name;
					from.Magie.addSort(m_SortNubia);
					return;
				}
				else if(!m_creation && (from.pointApprentissage >= m_SortNubia.GetCercle() || GM))
				{
					if(!GM)
						from.pointApprentissage -= m_SortNubia.GetCercle();
					//m_SortNubia.Owner = from;
					m_SortNubia.Createur = from.Name;
					from.Magie.addSort(m_SortNubia);
					return;
				}
				else
				{
					from.SendMessage("Vous n'avez pas assez de points...");
					m_SortNubia.Owner = null;
					m_SortNubia = null;
				}
						//m_SortNubia.condition = SortNubiaCondition.MainNue;
			}
			if(info.ButtonID != 100 )
			{	
				//from.CloseGump(typeof(SortNubiaCreationChoixCondition));
				from.SendGump(new SortCreationGump(m_owner, m_SortNubia) );
			}
		}
	}
}