using System;
using Server.Network;

namespace Server.Misc
{
	public class LoginStats
	{
		public static void Initialize()
		{
			// Register our event handler
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs args )
		{
			int userCount = NetState.Instances.Count;
			int itemCount = World.Items.Count;
			int mobileCount = World.Mobiles.Count;

			Mobile m = args.Mobile;

			m.SendMessage( "Bienvenue, {0}! Il y a actuellement {2} joueur{3} en jeu",
				args.Mobile.Name,
				userCount == 1 ? "is" : "are",
				userCount, 
                userCount == 1 ? "" : "s",
				itemCount, 
                itemCount == 1 ? "" : "s",
				mobileCount, 
                mobileCount == 1 ? "" : "s" );
		}
	}
}