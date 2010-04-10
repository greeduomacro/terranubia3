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
	public class enseignementSortPerso : Gump
	{
		private SortNubia m_owner;
        private NubiaPlayer m_maitre;
		private NubiaPlayer m_eleve;

        public enseignementSortPerso(SortNubia _owner, NubiaPlayer Maitre, NubiaPlayer Eleve)
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
			
			AddLabel( col, (line*scale), 0,"Personnalisation de la technique");
			line++;
			
			AddLabel( col, line*scale, 0, "Nom :" );
			AddTextEntry( col+40, line*scale, 250, 20, 0x480, 0, m_owner.Nom );
			line++;

			AddLabel( col, line*scale, 0, "Emote (Sans les '*') :" );
			AddTextEntry( col+145, line*scale, 250, 20, 0x480, 1, m_owner.Emote );
			line++;

			if(m_owner is SortNubiaInvocationArme)
			{
				AddLabel( col, line*scale, 0, "Nom de l'arme:" );
				AddTextEntry( col+135, line*scale, 250, 20, 0x480, 2, "Arme invoquée" );
				line++;
			}

			AddButton( col, (line*scale), 0xFAB, 0xFAC, 1000, GumpButtonType.Reply, 0 ); //Voir
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

			TextRelay tName = info.GetTextEntry( 0 );
			m_owner.Nom = (tName == null) ? "Konoha No SortNubia" : tName.Text;

			TextRelay tEmote = info.GetTextEntry( 1 );
			m_owner.Emote = (tEmote == null) ? "" : tEmote.Text;

			if(m_owner is SortNubiaInvocationArme)
			{
				SortNubiaInvocationArme iv = m_owner as SortNubiaInvocationArme;
				TextRelay twNom = info.GetTextEntry( 2 );
				iv.wNom = (twNom == null) ? "" : twNom.Text;
			}

			if(info.ButtonID == 6) //refus
			{
				m_maitre.SendMessage("Votre élève refuse votre proposition d'apprentissage");
				m_eleve.SendMessage("Vous refusez l'apprentissage");
				return;
			}
			if ( info.ButtonID == 1000 )
			{
				bool GM = ( from.AccessLevel >= AccessLevel.GameMaster );
			//	m_owner.skill = KonohaCompHelper.getSkillFromCat(m_owner.categorie);
				//GM = false; //pour test
				if(GM)
				{
					//from.CloseGump(typeof(justuCreationGump));
					from.SendGump(new SortCreationConfirm(m_eleve, m_owner, false ) );
					return;
				}
				else
				{
					if( m_owner.GetCercle() > m_eleve.Niveau )
					{
						from.SendMessage("Vous ne pouvez pas apprendre un SortNubia aussi puissant");
						//Maj(from, info);
						return;
					}
					else if ( !m_owner.canCast(m_eleve) )
					{
						from.SendMessage("Il vous manque des connaissances ou de le puissance pour ce SortNubia");
						return;
					}
					else
					{
						from.SendMessage("Nouveau SortNubia '"+m_owner.Nom+"' appris. Félicitation !");
						from.SendGump(new SortCreationConfirm(m_eleve, m_owner, false ) );
						
					}
				}
			}
			//from.CloseGump(typeof( SortNubiaListGump ) );
			//from.SendGump( new SortNubiaListGump( from, false ) );
		}

	}
}