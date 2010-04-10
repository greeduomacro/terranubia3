using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;
using Server.Items;


namespace Server.Gumps
{
	public class enseignementSortChoixComp : Gump
	{
		private SortNubia m_owner;
		private NubiaPlayer m_maitre;
        private NubiaPlayer m_eleve;
		private SortEnergie[] m_cp;

        public enseignementSortChoixComp(SortNubia _owner, NubiaPlayer Maitre, NubiaPlayer Eleve, SortEnergie[] cp)
            : base(50, 50)
		{
			m_owner = _owner;
			m_maitre = Maitre;
			m_eleve = Eleve;
			m_cp = cp;

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
			AddLabel( col, (line*scale), 0, "Choix de la competence");
			line++;

			for(int i = 0; i < m_cp.Length; i++) //10+
			{
				AddButton( col, (line*scale), 0xFAB, 0xFAC, 10+i, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( col+40, line*scale, 0, /*KonohaCompHelper.getNameComp((CompType)m_cp[i])*/ m_cp[i].ToString() );
				line++;
			}
			/*AddLabel( col, (line*scale), 0, "Disponible: "+m_eleve.pointApprentissage+" points");
			line++;
			line++;

			AddButton( col, (line*scale), 0xFAB, 0xFAC, 5, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( col+40, line*scale, 2117, "Accepter" );
			line++;*/
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
			if(info.ButtonID >= 10) //Choix
			{
				SortNubia newSortNubia;
				newSortNubia = (SortNubia)NubiaHelper.CopyItem(m_owner);
				newSortNubia.energie = (SortEnergie)m_cp[info.ButtonID-10];
			//	newSortNubia.skill = KonohaCompHelper.getSkillFromCat(newSortNubia.categorie);
				if(!newSortNubia.canCast(m_eleve, false))
				{
					m_eleve.SendMessage("Vous n'arrivez pas à adapter ces connaissances pour ce SortNubia");
					m_eleve.SendGump(new  enseignementSortChoixComp( m_owner, m_maitre, m_eleve, m_cp) );
					
				}
				else
				{
					m_eleve.SendMessage("Vous arrivez à adapter ces connaissances pour ce SortNubia !");
					m_maitre.SendMessage("Votre élève s'en sort plutôt bien et adapte votre technique");
					if(newSortNubia.couleur == MagieColor.Chakra && ( newSortNubia.energie != SortEnergie.Mental && newSortNubia.energie != SortEnergie.Terre) )
						newSortNubia.couleur = MagieColor.Connaissance;
					newSortNubia.Maitrise = 0.0;
					newSortNubia.Owner = m_eleve;
					
					if(newSortNubia is SortNubiaTransformation)
					{
						m_eleve.Target = new InternalTransformationTarget((SortNubiaTransformation)newSortNubia, m_maitre, m_eleve);
					}
					else
					{
						if(!newSortNubia.isUnique)
							m_eleve.SendGump( new enseignementSortPerso( newSortNubia, m_maitre, m_eleve ) );
						else
						{
							from.SendMessage("Nouveau SortNubia '"+newSortNubia.Nom+"' appris. Félicitation !");
							from.SendGump(new SortCreationConfirm(m_eleve, newSortNubia, false ) );
						}
					}
				}
				return;
			}
		}
		private class InternalTransformationTarget : Target
		{
			private SortNubiaTransformation m_Owner;
			private NubiaPlayer m_maitre;
            private NubiaPlayer m_eleve;

            public InternalTransformationTarget(SortNubiaTransformation owner, NubiaPlayer maitre, NubiaPlayer eleve)
                : base(owner.distance, false, TargetFlags.None)
			{
				m_Owner = owner;
				m_maitre = maitre;
				m_eleve = eleve;
				m_maitre.SendMessage("Veuillez cibler une rune de vie");
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is RuneVie )
				{
					RuneVie rune = o as RuneVie;
					if(rune.creature == null)
					{
						m_eleve.SendMessage("Cette rune est vide");
					}
					else
					{
						/*if(m_Owner.toClone.competenceLie == m_Owner.competence)
						{
							m_Owner.toClone = KonohaHelper.CopyCreature(rune.creature);
							rune.Delete();
							if(!m_Owner.isUnique)
								m_eleve.SendGump( new enseignementSortNubiaPerso( m_Owner, m_maitre, m_eleve ) );
							else
							{
								from.SendMessage("Nouveau SortNubia '"+m_Owner.Nom+"' appris. Félicitation !");
								from.SendGump(new SortNubiaCreationConfirm(m_eleve, m_Owner, false ) );
							}
						}
						else*/
						{
							m_eleve.SendMessage("Cette rune ne correspond pas a vos connaissances");
							m_eleve.SendGump(new  enseignementSortChoixComp( m_Owner, m_maitre, m_eleve, enseignementHelper.getAdaptedComp(m_Owner, m_eleve)) );
						}

					}
				}
			}
		}
	}
}