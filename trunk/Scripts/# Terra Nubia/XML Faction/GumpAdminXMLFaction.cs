using System;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Server;
using Server.Items;
using Server.Prompts;
using Server.Network;
using Server.Accounting;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.XmlFactions
{
	public class GumpAdminXMLFaction : Gump
	{
		private NubiaPlayer m_owner;
		private ArrayList m_List;
		private int m_page = 0;

		public GumpAdminXMLFaction( NubiaPlayer _owner, int page ) : base( 50, 50 )
		{
			m_owner = _owner;
			int largeur = 500;
			int hauteur = 400;
			int _x = 50;
			int _y = 50;
			int colG = _x+40;
			int colG2 = colG+70;
			int colorG = 2168;
			int colorG2 = 2120;
			int HColor = 2161;
			m_page = page;

			int colCompetence = 375+_x;

			AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x2422 );
			AddImageTiled( _x, _y,  _x+largeur,18, 0x280A );
			
			
			
			//AddAlphaRegion( _x+25, _y+25, _x+largeur-35,_y+hauteur-30 );
			//AddImage( 0,40, 0x28C8 );
			//AddImage( largeur+70,40, 0x28C9 );

			AddImage( (largeur/2)-10,_y-3, 0x988 );
			AddLabel( (largeur/2)+18, _y-2, 2123, "-= Admin XML Factions =-");
		
			int y = _y+40;
			int x = _x+35;
			int line = 0;
			int scale = 35;
			int decal = 5;
			
			/*AddHtml( _x+35, _y+35, largeur-35 , hauteur-50, "<center>Bienvenue sur Terra Nubia</center>"+
					"<p>Votre account doit être validé pour que vous puissiez jouer.<br>"+
					"Pour ce faire, vous devrez répondre à quelques petites questions. Vos réponses seront ensuite examiné par les Administrateurs qui validerons ou non votre Account.</p>", true, true );
			*/
			//AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x2454 );

			
			m_List = new ArrayList( (ICollection)XMLFactions.GetFactions() );
				//m_List.Sort( AccountComparer.Instance );
			int LabelHue = 0;
			int GreenHue = 75;
			int RedHue = 133;
			int BlueHue = 5;

			if( m_List == null )
			{
				AddLabelCropped( x, 90, 120, 20, RedHue, "Les factions n'existe pas ?!? Putain, appellez l'Nexam !" );
				return;
			}
			if( m_List.Count == 0 )
			{
				AddLabelCropped( x, 90, 120, 20, GreenHue, "Aucune faction n'est encore crée" );
				return;
			}
			else
			{
				AddLabelCropped( x, 90, 120, 20, LabelHue, "Name" );
				AddLabelCropped( x+75, 90, 120, 20, LabelHue, "Owner" );
				AddLabelCropped( x+150, 90, 120, 20, LabelHue, "Players?" );
				AddLabelCropped( x+225, 90, 120, 20, LabelHue, "Nbr" );
				AddLabelCropped( x+300, 90, 120, 20, LabelHue, "AccessLevel" );
			}
			

			//AddAccountHeader();

			int width = largeur - 70;
			int height = 40;
		
			//TODO: Tourner les pages :)


			int index = 0;
			for ( int i = m_page*10; i < m_List.Count; ++i )
			{
				XMLFaction faction = m_List[i] as XMLFaction;
				if( faction == null )
					continue;
			

				int offset = y + ( (index+1) * scale);
				AddAlphaRegion( x-2, offset-2, width, 25 );

				
				AddLabelCropped( x, offset, 120, 20, LabelHue, faction.Name );

				if ( faction.Owner != null )
					AddLabelCropped( x+75, offset, 120, 20, GreenHue, faction.Owner.Name );
				else
					AddLabelCropped( x+75, offset, 120, 20, RedHue, "Inexistant" );
					
				if( faction.PlayerFaction )
					AddLabelCropped( x+150, offset, 120, 20, GreenHue, "Oui" );
				else
					AddLabelCropped( x+150, offset, 120, 20, RedHue, "Non" );

				AddLabelCropped( x+225, offset, 120, 20, BlueHue, faction.Count.ToString() );

				if( faction.Access > m_owner.AccessLevel )
					AddLabelCropped( x+300, offset, 120, 20, RedHue, faction.Access.ToString() );
				else
					AddLabelCropped( x+300, offset, 120, 20, GreenHue, faction.Access.ToString() );
					
				//AddButton( x+380 , offset, 0xFA5, 0xFA7, 100+i, GumpButtonType.Reply, 0 );
				if( m_owner.AccessLevel >= faction.Access || m_owner == faction.Owner )
					AddButton( x+420 , offset, 0xFAB, 0xFAD, 500+i, GumpButtonType.Reply, 0 );
				index++;

				if( index > 10 )
					return;
			}
			//if( m_owner.AccessLevel >= AccessLevel.Administrator )
			//	AddButtonLabeled( x, 350, 1, "Créer une faction");
			
		}

		public void AddButtonLabeled( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, text, false, false );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
			NubiaPlayer from = f as NubiaPlayer;
			if( info.ButtonID >= 100 && info.ButtonID < 500 )
			{
				return;
			}

			if( info.ButtonID >= 500 && info.ButtonID < 800 ) //Propriété & Détail d'une faction
			{
				try
				{
					XMLFaction faction = m_List[info.ButtonID-500] as XMLFaction;
					from.SendGump( new GumpAdminXMLFactionInfo(from, faction));
				}
				catch (Exception ex)
				{
					from.SendMessage("Index de list non valide");
				}
				

				return;
			}
		}

	}

	public class GumpAdminXMLFactionInfo : Gump
	{
		private NubiaPlayer m_owner;
		private XMLFaction m_faction;

		public GumpAdminXMLFactionInfo( NubiaPlayer _owner, XMLFaction _faction ) : base( 50, 50 )
		{
			m_owner = _owner;
			int largeur = 300;
			int hauteur = 200;
			int _x = 50;
			int _y = 50;
			
			m_faction = _faction;

			AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x2422 );
			AddImageTiled( _x, _y,  _x+largeur,18, 0x280A );
			AddAlphaRegion( _x+10, _y+10, largeur-10, hauteur-10 );
			
			
			
			//AddAlphaRegion( _x+25, _y+25, _x+largeur-35,_y+hauteur-30 );
			//AddImage( 0,40, 0x28C8 );
			//AddImage( largeur+70,40, 0x28C9 );

			AddImage( (largeur/2)-10,_y-3, 0x988 );
			AddLabel( (largeur/2)+18, _y-2, 2123, "-= Admin XML Factions =-");
		
			int y = _y+40;
			int x = _x+35;
			int line = 0;
			int scale = 35;
			int decal = 5;
			
			int LabelHue = 0;
			int GreenHue = 75;
			int RedHue = 133;
			int BlueHue = 5;

			if( m_faction == null )
			{
				AddLabel( x, 90, RedHue, "La faction n'existe plus" );
				return;
			}
			
			

			//AddAccountHeader();

			int width = largeur - 70;
			int height = 40;
		
			//TODO: Tourner les pages :)

			if( m_owner.AccessLevel >= AccessLevel.Administrator )
				AddButtonLabeled( x, y, 1, "Propriétées");


			string listPlayer = "";
			string listOther = "";
			foreach( object o in m_faction.Members )
			{
				if( o is PlayerMobile )
					listPlayer += ((PlayerMobile)o).Name+"<br>";
				else if( o is Item )
					listOther += ((Item)o).Name+"<br>";
				else if( o is Mobile )
					listOther += ((Mobile)o).Name+"<br>";
				else
					listOther += o.GetType().ToString()+"<br>";
			}
			AddHtml( x,y+30,200 ,150, "<center>Liste des (joueurs)</center>"+listPlayer, true, true );
			AddHtml( x,y+230,200 ,150, "<center>Liste des (Autre)</center>"+listOther, true, true );
			
		}

		public void AddButtonLabeled( int x, int y, int buttonID, string text )
		{
			AddButton( x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0 );
			AddHtml( x + 35, y, 240, 20, text, false, false );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
			NubiaPlayer from = f as NubiaPlayer;
			if( info.ButtonID == 1  )
			{
				if( m_faction != null )
					from.SendGump( new PropertiesGump(from, m_faction));
				return;
			}
			if( info.ButtonID == 0 ) //Close
			{
				from.SendGump( new GumpAdminXMLFaction(from, 0) );
			}
		}

	}
}
