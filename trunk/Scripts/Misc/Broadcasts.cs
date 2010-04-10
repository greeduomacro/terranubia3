using System;
using Server;

namespace Server.Misc
{
	public class Broadcasts
	{
		public static void Initialize()
		{
			EventSink.Crashed += new CrashedEventHandler( EventSink_Crashed );
			EventSink.Shutdown += new ShutdownEventHandler( EventSink_Shutdown );
		}

		public static void EventSink_Crashed( CrashedEventArgs e )
		{
			try
			{
				World.Broadcast( 0x35, true, "Le serveur a crasher (Repportez le bug sur le forum)." );
			}
			catch
			{
			}
		}

		public static void EventSink_Shutdown( ShutdownEventArgs e )
		{
			try
			{
				World.Broadcast( 0x35, true, "Le serveur s'éteind." );
			}
			catch
			{
			}
		}
	}
}