using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Nubia;
using Server.Items;
using Server.Spells;
using Server.Commands;

namespace Server.XmlFactions
{
	public class XMLFactionCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register( "XMLFaction", AccessLevel.GameMaster, new CommandEventHandler( XMLFaction_OnCommand ) );
			CommandSystem.Register( "CreateXMLFaction", AccessLevel.Administrator, new CommandEventHandler( CreateXMLFaction_OnCommand ) );
		}
		public static void XMLFaction_OnCommand( CommandEventArgs e )
		{
			if( e.Mobile is NubiaPlayer )
			{
				NubiaPlayer player = e.Mobile as NubiaPlayer;
				player.SendGump( new GumpAdminXMLFaction( player,0 ) );
			}
		}

		public static void CreateXMLFaction_OnCommand( CommandEventArgs e )
		{
			if( e.Mobile is NubiaPlayer )
			{
				NubiaPlayer player = e.Mobile as NubiaPlayer;
				if( e.ArgString == "" || e.ArgString == null )
					player.SendMessage("Utilisation: .CreateXMLFaction Nom de la faction");
				else
					new XMLFaction( e.ArgString, player );
			}
		}
	}
}
