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
	public class SortCreationGump : GumpNubia
	{
		private NubiaPlayer m_owner;
		private SortNubia m_SortNubia;

        public SortCreationGump(NubiaPlayer _owner, SortNubia _SortNubia) : 
            base( "Tissage de sort", 400, 450 )
		{
			m_owner = _owner;
			m_SortNubia = _SortNubia;
			//m_SortNubia.Owner = m_owner;

			if( m_owner == null || m_SortNubia == null )
			{
				Console.WriteLine("GROS WARNING: justuCreationGump proprio ou SortNubia null");
				return;
			}
			int x = XBase;
			int y = YBase;

			int line = 0;
			int scale = 22;

			AddLabel( x, (y+line*scale), ColorTextYellow, "Tissage d'un nouveau sort");
			line++;
			AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 998, GumpButtonType.Reply, 0 ); //Voir
            AddLabel(x + 40, y + line * scale, 
                SortNubiaHelper.getHueForPercent((int)SortNubiaHelper.calculMaitriseDomaine(m_SortNubia.Domaine, m_owner.Domaine)),
                SortNubiaHelper.formatName(m_SortNubia) );
			line++;
			if( m_SortNubia is SortNubiaTransformation ) // 80+
			{
				SortNubiaTransformation SortNubia = m_SortNubia as SortNubiaTransformation;
			/*	if(SortNubia.toClone != null)
					AddLabel( x, y+line*scale, 2122, "Connaissance: "+ KonohaCompHelper.getNameComp(SortNubia.toClone.competenceLie) );
				else
					AddLabel( x, y+line*scale, 2122, "Connaissance: Aucune");*/
                AddLabel(x, y + line * scale, ColorTextRed, "TODO / TODO / TODO / ...");
				line++;
			}
			else if( m_SortNubia is SortNubiaInvocation ) // 80+
			{
				SortNubiaInvocation SortNubia = m_SortNubia as SortNubiaInvocation;
				/*if(SortNubia.toClone != null)
					AddLabel( x, y+line*scale, 2122, "Connaissance: "+ KonohaCompHelper.getNameComp(SortNubia.toClone.competenceLie) );
				else*/
				//	AddLabel( x, y+line*scale, 2122, "Connaissance: Aucune");
                AddLabel(x, y + line * scale, ColorTextRed, "TODO / TODO / TODO / ...");
				line++;
			}
			else
			{
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 997, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, SortNubiaHelper.getHueForPercent( (int)SortNubiaHelper.calculMaitriseEnergie(m_SortNubia.energie, m_owner.Energie) ), "Energie: "+ SortNubiaHelper.getEnergieString( m_SortNubia.energie)  );
				line++;
			}

			AddLabel( x, y+line*scale, ColorTextGreen, "Niveau : " + m_SortNubia.GetCercle() );
			line++;

			AddLabel( x, y+line*scale, ColorText, "Nom :" );
			AddTextEntry( x+40, y+line*scale, 250, 20, 0x480, 0, m_SortNubia.Nom );
			line++;



            AddLabel(x, y+ line * scale, ColorText, "Emote (Sans les '*') :");
			AddTextEntry( x+145, y+line*scale, 250, 20, 0x480, 1, m_SortNubia.Emote );
			line++;

			if( m_SortNubia is SortNubiaDestruction ) // 50+
			{
				SortNubiaDestruction SortNubia = m_SortNubia as SortNubiaDestruction;
                AddLabel(x, y+line * scale, ColorText, "Dégat Mini: ");
				AddTextEntry( x+80, y+line*scale, 250, 20, ColorTextLight, 50, SortNubia.minDegat.ToString() );
				line++;
                AddLabel(x, y+ line * scale, ColorText, "Dégat Maxi: ");
                AddTextEntry(x + 80, y + line * scale, 250, 20, ColorTextLight, 51, SortNubia.maxDegat.ToString());
				line++;
                AddLabel(x, y+ line * scale, ColorText, "Distance: ");
                AddTextEntry(x + 80, y + line * scale, 250, 20, ColorTextLight, 52, SortNubia.distance.ToString());
				line++;
                AddLabel(x, y+line * scale, ColorText, "Nombre de cible: ");
                AddTextEntry(x + 105, y + line * scale, 250, 20, ColorTextLight, 53, SortNubia.number.ToString());
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 54, GumpButtonType.Reply, 0 ); //Voir
                AddLabel(x + 40, y+line * scale, ColorText, "Ciblage: " + (SortNubia.canCible ? "Oui" : "Non"));
				line++;
			}
			if( m_SortNubia is SortNubiaSoin ) // 75+
			{
				SortNubiaSoin SortNubia = m_SortNubia as SortNubiaSoin;
                AddLabel(x, y+line * scale, ColorText, "Soin Mini: ");
                AddTextEntry(x + 80, y + line * scale, 250, 20, ColorTextLight, 75, SortNubia.minDegat.ToString());
				line++;
                AddLabel(x, y+line * scale, ColorText, "Soin Maxi: ");
                AddTextEntry(x + 80, y + line * scale, 250, 20, ColorTextLight, 76, SortNubia.maxDegat.ToString());
				line++;
                AddLabel(x, y+line * scale, ColorText, "Distance: ");
                AddTextEntry(x + 80, y + line * scale, 250, 20, ColorTextLight, 77, SortNubia.distance.ToString());
				line++;
                AddLabel(x, y+ line * scale, ColorText, "Nombre de cible: ");
                AddTextEntry(x + 105, y + line * scale, 250, 20, ColorTextLight, 78, SortNubia.number.ToString());
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 79, GumpButtonType.Reply, 0 ); //Voir
                AddLabel(x + 40, y+line * scale, ColorText, "Ciblage: " + (SortNubia.canCible ? "Oui" : "Non"));
				line++;
			}
			if( m_SortNubia is SortNubiaTransformation ) // 80+
			{
				SortNubiaTransformation SortNubia = m_SortNubia as SortNubiaTransformation;
				if(SortNubia.toClone == null)
				{
					AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 80, GumpButtonType.Reply, 0 );
					AddLabel( x+40, y+line*scale, ColorText, "Ajouter une rune de vie" );
					line++;
				}
				else
				{
					AddLabel( x, y+line*scale, ColorTextGreen, "Transformation: " + SortNubia.toClone.Name );
					line++;
					/*AddLabel( x, y+line*scale, 0, "Connaissance: " + SortNubia.toClone.competenceLie );
					line++;*/
				/*	SkillName[] sk = TransfoHelper.getSkillBonus(SortNubia.toClone.competenceLie);
					for(int i = 0; i < sk.Length; i++)
					{
						AddLabel( x, y+line*scale, 0, "Bonus sur: " + sk[i].ToString() );
						line++;
					}*/
					AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 80, GumpButtonType.Reply, 0 );
                    AddLabel(x + 40, y + line * scale, ColorTextGreen, "Modifier la rune de vie");
					line++;
					line++;
				}
			}
			if( m_SortNubia is SortNubiaInvocationArme ) // 90+
			{
				SortNubiaInvocationArme SortNubia = m_SortNubia as SortNubiaInvocationArme;
				AddLabel( x, y+line*scale, 0, "L'arme progressera avec vous");
				line++;

				double ratio = SortNubia.wSpeed/5.0;
				int MaxDamage =	(int)(100/ratio+(m_owner.Niveau/2));
                int MinDamage = (int)(90 / ratio + (m_owner.Niveau / 3));

						AddLabel( x, y+line*scale, 0, "Nom de l'arme: ");
					AddTextEntry( x+90, y+line*scale, 250, 20, 0x480, 93, SortNubia.wNom );
					line++;

					AddLabel( x, y+line*scale, 0, "Vitesse: ");
					AddTextEntry( x+55, y+line*scale, 250, 20, 0x480, 90, SortNubia.wSpeed.ToString() );
					line++;
					AddLabel( x, y+line*scale, 0, "Degats approximatifs:" );
					line++;
					AddLabel( x+40, y+line*scale, 0, "- Mini: "+MaxDamage );
					line++;
					AddLabel( x+40, y+line*scale, 0, "- Maxi: "+MinDamage );
					line++;
					/*AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 91, GumpButtonType.Reply, 0 );
					AddLabel( x+40, y+line*scale, 0, "Modifier la couleur" );
					line++;*/
					AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 92, GumpButtonType.Reply, 0 );
					AddLabel( x+40, y+line*scale, 0, "Modifier l'apparence" );
					line++;
					line++;

			}
			if( m_SortNubia is SortNubiaTao ) // 100+
			{
                SortNubiaTao SortNubia = m_SortNubia as SortNubiaTao;
				AddLabel( x, y+line*scale, 0, "Dégats bonus: " );
				AddTextEntry( x+90, y+line*scale, 250, 20, 0x480, 100, SortNubia.degats.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Nbrs de Tours: " );
				AddTextEntry( x+90, y+line*scale, 250, 20, 0x480, 101, SortNubia.turn.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Sonnage (en secondes x.x): " );
				AddTextEntry( x+140, y+line*scale, 250, 20, 0x480, 102, SortNubia.stun.ToString() );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 103, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Enchainement rapide: " + ( SortNubia.rapide ? "Oui":"Non" ) );
				line++;
			}

			if( m_SortNubia is SortNubiaParalyze ) // 110+
			{
				SortNubiaParalyze SortNubia = m_SortNubia as SortNubiaParalyze;
				AddLabel( x, y+line*scale, 0, "Temps Mini: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 110, SortNubia.minDegat.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Temps Maxi: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 111, SortNubia.maxDegat.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Distance: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 112, SortNubia.distance.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Nombre de cible: " );
				AddTextEntry( x+105, y+line*scale, 250, 20, 0x480, 113, SortNubia.number.ToString() );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 114, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Ciblage: " + ( SortNubia.canCible ? "Oui":"Non" ) );
				line++;
			}

			if( m_SortNubia is SortNubiaPoison ) // 120+
			{
				SortNubiaPoison SortNubia = m_SortNubia as SortNubiaPoison;
				AddLabel( x, y+line*scale, 0, "Note: Le niveau d'un poison va de 0 a 3" );
				line++;
				AddLabel( x, y+line*scale, 0, "Niveau du Poison: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 120, SortNubia.PoisonLevel.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Distance: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 121, SortNubia.distance.ToString() );
				line++;
				AddLabel( x, y+line*scale, 0, "Nombre de cible: " );
				AddTextEntry( x+105, y+line*scale, 250, 20, 0x480, 122, SortNubia.number.ToString() );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 123, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Ciblage: " + ( SortNubia.canCible ? "Oui":"Non" ) );
				line++;
			}

			if( m_SortNubia is SortNubiaInvocation ) // 130+
			{
				SortNubiaInvocation SortNubia = m_SortNubia as SortNubiaInvocation;
				if(SortNubia.toClone == null)
				{
					AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 130, GumpButtonType.Reply, 0 );
					AddLabel( x+40, y+line*scale, 0, "Ajouter une rune de vie" );
					line++;
				}
				else
				{
					AddLabel( x, y+line*scale, 0, "Invocation: " + SortNubia.toClone.Name );
					line++;
					/*AddLabel( x, y+line*scale, 0, "Connaissance: " + SortNubia.toClone.competenceLie );
					line++;*/
					/*SkillName[] sk = TransfoHelper.getSkillBonus(SortNubia.toClone.competenceLie);
					for(int i = 0; i < sk.Length; i++)
					{
						AddLabel( x, y+line*scale, 0, "Bonus sur: " + sk[i].ToString() );
						line++;
					}*/
					AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 130, GumpButtonType.Reply, 0 );
					AddLabel( x+40, y+line*scale, 0, "Modifier la rune de vie" );
					line++;
					line++;
				}
			}

			if( m_SortNubia is SortNubiaMur ) // 135++
			{
				SortNubiaMur SortNubia = m_SortNubia as SortNubiaMur;
				AddLabel( x, y+line*scale, 0, "Attention, un mur qui bloque ne fait pas de dégats" );
				line++;
				AddLabel( x, y+line*scale, 0, "Si vous activez le bloque, mettez les dégats à 0" );
				line++;
				AddLabel( x, y+line*scale, 0, "Degats: " );
				AddTextEntry( x+80, y+line*scale, 250, 20, 0x480, 135, SortNubia.damageWalk.ToString() );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 136, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Bloque: " + ( SortNubia.block ? "Oui":"Non" ) );
				line++;
			}

			if( m_SortNubia.playEffect )
			{
				AddLabel( x, y+line*scale, 2122, "Effet Visuel" );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 975, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Effet: "+ SortNubiaHelper.getNameEffect(m_SortNubia.effect) );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 976, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Couleur: "+ m_SortNubia.couleur.ToString() );
				line++;
				AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 977, GumpButtonType.Reply, 0 ); //Voir
				AddLabel( x+40, y+line*scale, 0, "Rendu: "+ m_SortNubia.render.ToString() );
				line++;
			}
			
			/*AddLabel( x, y+line*scale, 2122, "Bonus" );
			line++;
			AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 950, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( x+40, y+line*scale, 0, "Bonus 1" );
			line++;
			AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 951, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( x+40, y+line*scale, 0, "Bonus 2");
			line++;*/

			AddLabel( x, y+line*scale, 2122, "Condition" );
			line++;
			AddButton( x, (y+line*scale), 0xFAB, 0xFAC, 925, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( x+40, y+line*scale, ColorTextLight, m_SortNubia.condition.ToString());
			line++;
			if(m_SortNubia.ObjectToEquip != null)
                AddLabel(x + 40, y + line * scale, ColorTextLight, "Objet: " + (m_SortNubia.ObjectToEquip.Name == "" ? m_SortNubia.ObjectToEquip.GetType().ToString() : m_SortNubia.ObjectToEquip.Name));
			if(m_SortNubia.SortNubiaPere != null)
                AddLabel(x + 40, y + line * scale, ColorTextLight, "Pere: " + m_SortNubia.SortNubiaPere.Nom);
			line++;

            x += 160;
			AddButton( x, y + line *scale, 0xFA5, 0xFA7, 999, GumpButtonType.Reply, 0 ); //Voir
            AddLabel(x + 40, y + line * scale, ColorTextYellow, "Mise à jour");
            x += 120;
            AddButton(x, y + line * scale, 0xFA5, 0xFA7, 1000, GumpButtonType.Reply, 0); //Voir
            AddLabel(x + 40, y + line * scale, ColorTextRed, "Création");
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
			if ( info.ButtonID == 0 ) //Changer la connaissance
			{
				m_SortNubia.Owner = null;
				m_SortNubia = null;
			}

			if ( info.ButtonID == 997 ) //Changer la connaissance
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixEnergie(m_owner, m_SortNubia) );
			}
			if ( info.ButtonID == 998 ) //Changer le type
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixSort(m_owner, m_SortNubia) );
			}
			if ( info.ButtonID == 975 ) //Changer l'effet
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixEffet(m_owner, m_SortNubia) );
			}
			if ( info.ButtonID == 976 ) //Changer la couleur
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixCouleur(m_owner, m_SortNubia) );
			}
			if ( info.ButtonID == 977 ) //Changer le rendu
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixRender(m_owner, m_SortNubia) );
			}
			if ( info.ButtonID == 950 || info.ButtonID == 951 ) //Bonus
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationBonusGump(m_owner, m_SortNubia, (info.ButtonID-949) ) );
			}
			if ( info.ButtonID == 925 ) //Bonus
			{
				from.CloseGump(typeof(SortCreationGump));
				from.SendGump(new SortCreationChoixCondition(m_owner, m_SortNubia ) );
			}

			//DESTRUCTION (50+)
			if ( info.ButtonID == 54 ) //ciblage
			{
				SortNubiaDestruction newSortNubia = m_SortNubia as SortNubiaDestruction;
				newSortNubia.canCible = !newSortNubia.canCible;
				Maj(from, info);
			}
			//Soin (75+)
			if ( info.ButtonID == 79 ) //ciblage
			{
				SortNubiaSoin newSortNubia = m_SortNubia as SortNubiaSoin;
				newSortNubia.canCible = !newSortNubia.canCible;
				Maj(from, info);
			}
			//Transfo (80+)
			if ( info.ButtonID == 80 )
			{
				from.Target = new TransfoTarget((SortNubiaTransformation)m_SortNubia,from);
			}
			//Invoc Arme (90+)
			if ( info.ButtonID == 92 ) //cible d'arme model
			{
				from.Target = new ciblageArmeTarget((SortNubiaInvocationArme)m_SortNubia,from);
			}
			//TaiSortNubia
			if ( info.ButtonID == 103 ) //ciblage
			{
                SortNubiaTao newSortNubia = m_SortNubia as SortNubiaTao;
				newSortNubia.rapide = !newSortNubia.rapide;
				Maj(from, info);
			}
			//PARALYZE (110+)
			if ( info.ButtonID == 114 ) //ciblage
			{
				SortNubiaParalyze newSortNubia = m_SortNubia as SortNubiaParalyze;
				newSortNubia.canCible = !newSortNubia.canCible;
				Maj(from, info);
			}
			//PARALYZE (110+)
			if ( info.ButtonID == 123 ) //ciblage
			{
				SortNubiaPoison newSortNubia = m_SortNubia as SortNubiaPoison;
				newSortNubia.canCible = !newSortNubia.canCible;
				Maj(from, info);
			}
			//Invocation (130+)
			if ( info.ButtonID == 130 )
			{
				from.Target = new InvocTarget((SortNubiaInvocation)m_SortNubia,from);
			}
			//Mur (136+)
			if ( info.ButtonID == 136 ) //ciblage
			{
				SortNubiaMur newSortNubia = m_SortNubia as SortNubiaMur;
				newSortNubia.block = !newSortNubia.block;
				Maj(from, info);
			}
			//MAJ
			if ( info.ButtonID == 999 ) //maj
			{
				Maj(from, info);
			}
			//CREATION
			if ( info.ButtonID == 1000 )
			{
				bool GM = ( from.AccessLevel >= AccessLevel.GameMaster );
				//m_SortNubia.skill = KonohaCompHelper.getSkillFromCat(m_SortNubia.categorie);
				//GM = false; //pour test
				if(GM)
				{
					from.CloseGump(typeof(SortCreationGump));
					from.SendGump(new SortCreationConfirm(m_owner, m_SortNubia, true ) );
					return;
				}
				else
				{
					if( m_SortNubia.GetCercle() > from.Niveau )
					{
						from.SendMessage("Vous ne pouvez pas créer un sort aussi puissant");
						Maj(from, info);
						return;
					}
					else if ( !m_SortNubia.canCast(from) )
					{
						from.SendMessage("Il vous manque des connaissances ou de le puissance pour ce sort");
						Maj(from, info);
						return;
					}
					else
					{
						from.SendMessage("Nouveau SortNubia '"+m_SortNubia.Nom+"' élaboré. Félicitation !");

						from.CloseGump(typeof(SortCreationGump));
						from.SendGump(new SortCreationConfirm(m_owner, m_SortNubia, true ) );
						
					}
				}
			}
		}
		public void Maj(NubiaPlayer from, RelayInfo info )
		{
			TextRelay tName = info.GetTextEntry( 0 );
			m_SortNubia.Nom = (tName == null) ? "Sort nubien" : tName.Text;

			TextRelay tEmote = info.GetTextEntry( 1 );
			m_SortNubia.Emote = (tEmote == null) ? "incante" : tEmote.Text;
			
			if(m_SortNubia is SortNubiaDestruction)
			{
				SortNubiaDestruction newSortNubia = m_SortNubia as SortNubiaDestruction;
				TextRelay tminDeg = info.GetTextEntry( 50 );
				string min = (tminDeg == null) ? "0" : tminDeg.Text;
				try{newSortNubia.minDegat = Convert.ToInt32(min);}catch{}

				TextRelay tmaxDeg = info.GetTextEntry( 51 );
				string max = (tmaxDeg == null) ? "0" : tmaxDeg.Text;
				try{newSortNubia.maxDegat = Convert.ToInt32(max);}catch{}

				TextRelay tDistance = info.GetTextEntry( 52 );
				string dist = (tDistance == null) ? "0" : tDistance.Text;
				try{newSortNubia.distance = Convert.ToInt32(dist);}catch{}

				TextRelay tNumber = info.GetTextEntry( 53 );
				string num = (tNumber == null) ? "0" : tNumber.Text;
				try{newSortNubia.number = Convert.ToInt32(num);}catch{}
			}
			if(m_SortNubia is SortNubiaSoin)
			{
				SortNubiaSoin newSortNubia = m_SortNubia as SortNubiaSoin;
				TextRelay tminDeg = info.GetTextEntry( 75 );
				string min = (tminDeg == null) ? "0" : tminDeg.Text;
				try{newSortNubia.minDegat = Convert.ToInt32(min);}catch{}

				TextRelay tmaxDeg = info.GetTextEntry( 76 );
				string max = (tmaxDeg == null) ? "0" : tmaxDeg.Text;
				try{newSortNubia.maxDegat = Convert.ToInt32(max);}catch{}

				TextRelay tDistance = info.GetTextEntry( 77 );
				string dist = (tDistance == null) ? "0" :tDistance.Text;
				try{newSortNubia.distance = Convert.ToInt32(dist);}catch{}

				TextRelay tNumber = info.GetTextEntry( 78 );
				string num = (tNumber == null) ? "0" : tNumber.Text;
				try{newSortNubia.number = Convert.ToInt32(num);}catch{}
			}
			if(m_SortNubia is SortNubiaInvocationArme)
			{
				SortNubiaInvocationArme newSortNubia = m_SortNubia as SortNubiaInvocationArme;
				TextRelay tspeed = info.GetTextEntry( 90 );
				string speed = (tspeed == null) ? "0" : tspeed.Text;
				try{newSortNubia.wSpeed = Convert.ToInt32(speed);}catch{}

				TextRelay twName = info.GetTextEntry( 93 );
				string wname = (twName == null) ? "0" : twName.Text;
				try{newSortNubia.wNom = wname;}catch{}

			//	newSortNubia.color = KonohaCompHelper.getCompColor(newSortNubia.competence);
			}
			if(m_SortNubia is SortNubiaTao)
			{
                SortNubiaTao newSortNubia = m_SortNubia as SortNubiaTao;
				TextRelay tdegs = info.GetTextEntry( 100 );
				string degs = (tdegs == null) ? "0" : tdegs.Text;
				try{newSortNubia.degats = Convert.ToInt32(degs);}catch{}

				TextRelay tTurn = info.GetTextEntry( 101 );
				string tt = (tTurn == null) ? "0" : tTurn.Text;
				try{newSortNubia.turn = Convert.ToInt32(tt);}catch{}

				TextRelay tstun = info.GetTextEntry( 102 );
				string st = (tstun == null) ? "0" : tstun.Text;
				try{newSortNubia.stun =  Convert.ToDouble(st);}catch{}

				//newSortNubia.color = KonohaCompHelper.getCompColor(newSortNubia.competence);
			}
			if(m_SortNubia is SortNubiaParalyze)
			{
				SortNubiaParalyze newSortNubia = m_SortNubia as SortNubiaParalyze;
				TextRelay tminDeg = info.GetTextEntry( 110 );
				string min = (tminDeg == null) ? "0" : tminDeg.Text;
				try{newSortNubia.minDegat = Convert.ToInt32(min);}catch{}

				TextRelay tmaxDeg = info.GetTextEntry( 111 );
				string max = (tmaxDeg == null) ? "0" : tmaxDeg.Text;
				try{newSortNubia.maxDegat = Convert.ToInt32(max);}catch{}

				TextRelay tDistance = info.GetTextEntry( 112 );
				string dist = (tDistance == null) ? "0" : tDistance.Text;
				try{newSortNubia.distance = Convert.ToInt32(dist);}catch{}

				TextRelay tNumber = info.GetTextEntry( 113 );
				string num = (tNumber == null) ? "0" : tNumber.Text;
				try{newSortNubia.number = Convert.ToInt32(num);}catch{}
			}
			if(m_SortNubia is SortNubiaPoison)
			{
				SortNubiaPoison newSortNubia = m_SortNubia as SortNubiaPoison;
				TextRelay tminDeg = info.GetTextEntry( 120 );
				string min = (tminDeg == null) ? "0" : tminDeg.Text;
				int plev = 0;
				try{plev = Convert.ToInt32(min);}catch{}
				if( plev > 3 ) plev = 3;
				if( plev < 0 ) plev = 0;
				newSortNubia.PoisonLevel = plev;

				TextRelay tDistance = info.GetTextEntry( 121 );
				string dist = (tDistance == null) ? "0" : tDistance.Text;
				try{newSortNubia.distance = Convert.ToInt32(dist);}catch{}

				TextRelay tNumber = info.GetTextEntry( 122 );
				string num = (tNumber == null) ? "0" : tNumber.Text;
				try{newSortNubia.number = Convert.ToInt32(num);}catch{}
			}

			if(m_SortNubia is SortNubiaMur)
			{
				SortNubiaMur newSortNubia = m_SortNubia as SortNubiaMur;
				TextRelay tdegWalk = info.GetTextEntry( 135 );
				string dwalk = (tdegWalk == null) ? "0" : tdegWalk.Text;
				try{newSortNubia.damageWalk = Convert.ToInt32(dwalk);}catch{}
			}

			from.CloseGump(typeof(SortCreationGump));
			from.SendGump(new SortCreationGump(m_owner, m_SortNubia) );
		}
		private class ciblageArmeTarget : Target
		{
			private SortNubiaInvocationArme m_Owner;
			private NubiaPlayer player;

            public ciblageArmeTarget(SortNubiaInvocationArme owner, NubiaPlayer pl)
                : base(owner.distance, false, TargetFlags.None)
			{
				m_Owner = owner;
				player = pl;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is BaseWeapon )
				{
					BaseWeapon bw = o as BaseWeapon;
					m_Owner.wId = bw.ItemID;
					m_Owner.wSkill = bw.Skill;
					player.CloseGump(typeof(SortCreationGump));
					player.SendGump(new SortCreationGump(player, m_Owner) );

				}
			}
		}
		private class InvocTarget : Target
		{
			private SortNubiaInvocation m_Owner;
            private NubiaPlayer player;

            public InvocTarget(SortNubiaInvocation owner, NubiaPlayer pl)
                : base(owner.distance, false, TargetFlags.None)
			{
				m_Owner = owner;
				player = pl;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is RuneVie )
				{
					RuneVie rune = o as RuneVie;
					if(rune.creature == null)
					{
						player.SendMessage("Cette rune est vide");
					}
					else
					{
						m_Owner.toClone = NubiaHelper.CopyCreature(rune.creature);
					//	m_Owner.competence = rune.creature.competenceLie;
					}
					player.CloseGump(typeof(SortCreationGump));
					player.SendGump(new SortCreationGump(player, m_Owner) );

				}
			}
		}
		private class TransfoTarget : Target
		{
			private SortNubiaTransformation m_Owner;
            private NubiaPlayer player;

            public TransfoTarget(SortNubiaTransformation owner, NubiaPlayer pl)
                : base(owner.distance, false, TargetFlags.None)
			{
				m_Owner = owner;
				player = pl;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is RuneVie )
				{
					RuneVie rune = o as RuneVie;
					if(rune.creature == null)
					{
						player.SendMessage("Cette rune est vide");
					}
					else
					{
						m_Owner.toClone = NubiaHelper.CopyCreature(rune.creature);
					//	m_Owner.competence = rune.creature.competenceLie;
					}
					player.CloseGump(typeof(SortCreationGump));
					player.SendGump(new SortCreationGump(player, m_Owner) );

				}
			}
		}

	}
}