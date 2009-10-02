using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Spells;

namespace Server.Commands
{
     public class HspeechCommand
     {
	public static void Initialize()
		{
			CommandSystem.Register( "dsay", AccessLevel.GameMaster, new CommandEventHandler( Hspeech_OnCommand ) );
			CommandSystem.Register( "demote", AccessLevel.GameMaster, new CommandEventHandler( Hemote_OnCommand ) );
		}
		
		[Usage( "demote" )]
		[Description( "Make a player demote the words you want." )]
		private static void Hemote_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

				from.SendMessage( "Target a player to emote something." );
				e.Mobile.Target = new HemoteTarget(e.ArgString);
		}
     
		private class HemoteTarget : Target
        {
			private string m_textstring;
            public HemoteTarget(string textstring) :  base ( -1, false, TargetFlags.None )
           	{
				m_textstring = textstring;
          	}

            protected override void OnTarget( Mobile from, object targeted )
           	{
				if (!(targeted is Mobile))
				{
					return;
				}
				Mobile pm = targeted as Mobile;
				
				pm.Emote("*"+m_textstring+"*");
			}
		}

		[Usage( "dsay" )]
		[Description( "Make a player dsay the words you want." )]
		private static void Hspeech_OnCommand( CommandEventArgs e )
		{
				Mobile from = e.Mobile;

				from.SendMessage( "Target a player to say something." );
				e.Mobile.Target = new HspeechTarget(e.ArgString);
		}
     
		private class HspeechTarget : Target
        {
			private string m_textstring;
            public HspeechTarget(string textstring) :  base ( -1, false, TargetFlags.None )
           	{
				m_textstring = textstring;
          	}

            protected override void OnTarget( Mobile from, object targeted )
           	{
				if (!(targeted is Mobile))
				{
					return;
				}
				Mobile pm = targeted as Mobile;
				
				pm.Say(m_textstring);
			}
		}
	}	
}