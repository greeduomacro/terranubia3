using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;


namespace Server.Gumps
{
	public class enseignementSortAccept : Gump
	{
		private SortNubia m_owner;
        private NubiaPlayer m_maitre;
		private NubiaPlayer m_eleve;

        public enseignementSortAccept(SortNubia _owner, NubiaPlayer Maitre, NubiaPlayer Eleve)
            : base(50, 50)
		{
			m_owner = _owner;
			m_maitre = Maitre;
			m_eleve = Eleve;

			if(m_owner == null || m_maitre == null || m_eleve == null)
				return;

			int largeur = 300;
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
			
			AddLabel( col, (line*scale), 0, m_owner.Owner.Name+" Souhaite vous enseigner une technique:");
			line++;
			
			AddLabel( col, (line*scale), 2128, m_owner.Nom);
			line++;
			line++;
			AddLabel( col, (line*scale), 0, "Coût de l'apprentissage: "+m_owner.GetCercle()+" points");
			line++;
			AddLabel( col, (line*scale), 0, "Disponible: "+m_eleve.pointApprentissage+" points");
			line++;
			line++;

			AddButton( col, (line*scale), 0xFAB, 0xFAC, 5, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( col+40, line*scale, 2117, "Accepter" );
			line++;
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 6, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( col+40, line*scale, 0, "Refuser" );
			line++;
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
			if(info.ButtonID == 6) //refus
			{
				m_maitre.SendMessage("Votre élève refuse votre proposition d'apprentissage");
				m_eleve.SendMessage("Vous refusez l'apprentissage");
				return;
			}
			if(info.ButtonID == 5) //Accept
			{
				m_maitre.SendMessage("Votre élève accepte votre proposition d'apprentissage");
				m_eleve.SendMessage("Vous acceptez l'apprentissage");
				SortEnergie[] cp = enseignementHelper.getAdaptedComp(m_owner, m_eleve);
				if( cp == null)
					m_eleve.SendMessage("Vous ne trouvez aucun moyen d'adapter cette technique");
				else
				{
					from.SendGump( new enseignementSortChoixComp( m_owner, m_maitre, m_eleve, cp ) );
				}
				return;
			}
			//from.CloseGump(typeof( SortNubiaListGump ) );
			//from.SendGump( new SortNubiaListGump( from, false ) );
		}

	}
}