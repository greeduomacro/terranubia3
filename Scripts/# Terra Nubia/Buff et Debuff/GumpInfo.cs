using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
	public class GumpInfo : Gump
	{

		public GumpInfo( int icone, string description, string titre ) : base( 50, 50 )
		{
			Closable = true;
			
			int largeur = 300;
			int hauteur = 190;
			int _x = 50;
			int _y = 50;

			AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x2422 );
			AddImageTiled( _x, _y,  _x+largeur,18, 0x280A );
			AddImage( (largeur/2)+45,_y+32, icone );
			AddImage( (largeur/2)-10,_y-3, 0x988 );
			AddLabel( (largeur/2)+18, _y-2, 2123, "-= Description =-");
			
			AddHtml( _x+35, _y+85, largeur-20, 130, "<center>"+titre+"</center><p>"+description+"</p>", true, true );

		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
			NubiaPlayer from = f as NubiaPlayer;
		}

	}
}
