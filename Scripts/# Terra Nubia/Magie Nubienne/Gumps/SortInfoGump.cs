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
	public class SortInfoGump : Gump
	{
		private SortNubia m_owner;

        public SortInfoGump(SortNubia _owner)
            : base(50, 50)
		{
			m_owner = _owner;

			if(m_owner == null)
				return;

			int largeur = 300;
			int hauteur = 360;
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

			
			AddLabel( col, (line*scale), 2128, m_owner.Nom);
			line++;
			//List général
			if( m_owner.Owner != null )
			{
				AddLabel( col, (line*scale), 0, "Lié à: "+m_owner.Owner.Name);
				line++;
			}
			if( m_owner.Createur != "")
			{
				AddLabel( col, (line*scale), 0, "Createur: "+m_owner.Createur);
				line++;
			}
			AddLabel( col, (line*scale), 0, "Niveau: "+m_owner.GetCercle());
			line++;
			AddLabel( col, (line*scale), 0, "Type: "+m_owner.Domaine);
			line++;
			AddLabel( col, (line*scale), 0, "Tps d'execution: "+m_owner.TimeToCast+" secondes");
			line++;
			AddLabel( col, (line*scale), 0, "Tps de chargement: "+m_owner.Delay+" secondes");
			line++;
			AddLabel( col, (line*scale), 0, "Maitrise actuelle: "+m_owner.Maitrise+" %");
			line++;
			if(m_owner.SortNubiaPere != null)
			{
				AddLabel( col, (line*scale), 0, "Fils de: "+m_owner.SortNubiaPere.Nom);
				line++;
			}
			//AddLabel( col1, (line*scale)+y, 0, "Créateur: "+ m_owner.Createur == null ? "Inconnu" : m_owner.Createur.Name );
			//line++;
			//if( m_owner.JutsuType == jutsuType.destruction || m_owner.JutsuType == jutsuType.aide )
			//{
				AddLabel( col, (line*scale), 0, "Portée: "+m_owner.distance);
				line++;
			//}
			line++;
			AddLabel( col, (line*scale), 2120, "Chakra nessecaire: "+m_owner.chakra);
			line++;
	       AddLabel(col, (line * scale), 2120, "Competence " +m_owner.energie.ToString() + ": " + m_owner.miniCompetence + " %");
			line++;
		/*	AddLabel( col, (line*scale), 2120, "Competence(uo) "+m_owner.skill.ToString()+ ": "+m_owner.miniSkill+" %");
			line++;*/

			if(m_owner.Owner.Niveau >= 10 && m_owner.Maitrise >= 100.0)
			{
				AddButton( col, (line*scale), 0xFAB, 0xFAC, 5, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( col+40, line*scale, 2117, "Enseigner la technique" );
				line++;
			}
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
			if(info.ButtonID == 5)
			{
				from.Target = new InternalTarget(m_owner, from);
				return;
			}
			from.CloseGump(typeof( SortListGump ) );
            from.SendGump(new SortListGump(from, false));
		}

		private class InternalTarget : Target
		{
			private SortNubia m_Owner;
			private NubiaPlayer m_maitre;

            public InternalTarget(SortNubia owner, NubiaPlayer maitre)
                : base(owner.distance, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
				m_maitre = maitre;
				m_maitre.SendMessage("Veuillez cibler votre élève");
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is NubiaPlayer )
				{
					m_maitre.CloseGump( typeof( SortInfoGump ) );
                    NubiaPlayer eleve = o as NubiaPlayer;
					eleve.SendGump( new enseignementSortAccept(m_Owner, m_maitre, eleve));
					m_maitre.SendMessage("Vous proposez l'apprentissage de '"+m_Owner.Nom+"' à "+eleve.Name);
					eleve.SendMessage(m_maitre.Name+" vous propose d'apprendre '"+m_Owner.Nom+"'");
					return;
				}
			}
		}


	}
}