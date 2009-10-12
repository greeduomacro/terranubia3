using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
	public class GumpDebuff : Gump
	{
		private NubiaPlayer m_owner;

		public GumpDebuff( NubiaPlayer _owner ) : base( 50, 50 )
		{
			m_owner = _owner;
			
			Closable = false;
			
			int largeur = 300;
			int hauteur = 150;
			int _x = 50;
			int _y = 50;


			int y = 75+_y;
			int colonne = 0;
			int scaley = 48;

			AddImage( _x+45,_y+2, 0x2C7E, 36 );
			for( int i = 0 ; i < m_owner.DebuffList.Count; i++)
			{
				AbstractBaseBuff buff = m_owner.DebuffList[i] as AbstractBaseBuff;
				//AddImage( _x-50, y+(colonne*scaley), buff.Icone );
				AddButton(  _x+55+(colonne*scaley), _y, buff.Icone,  buff.Icone, 50+i, GumpButtonType.Reply, 0 );
				colonne++;
			}
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
			NubiaPlayer from = f as NubiaPlayer;
			if( info.ButtonID >= 50 && info.ButtonID < 200 )
			{
				AbstractBaseBuff buff = m_owner.DebuffList[info.ButtonID-50] as AbstractBaseBuff;
				from.CloseGump( typeof( GumpInfo ) );
				from.CloseGump( typeof( GumpDebuff ) );
				from.SendGump( new GumpInfo( buff.Icone, buff.Descrip , buff.Name ) );
				from.SendGump( new GumpDebuff( m_owner) );
			}
		}

	}
}
