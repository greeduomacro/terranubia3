using System;
using Server;
using Knives.Utils;

namespace Knives.TownHouses
{
	public class TownHouseConfirmGump : GumpPlus
	{
		public static void SendTo( Mobile m, TownHouseSign sign )
		{
			new TownHouseConfirmGump( m, sign );
		}

		private TownHouseSign c_Sign;
		private bool c_Items;

		private const int Width = 200;
		private const int Height = 140;

		public TownHouseConfirmGump( Mobile m, TownHouseSign sign ) : base( m, 100, 100 )
		{
			Override = false;

			c_Sign = sign;

			NewGump();
		}

		protected override void BuildGump()
		{
			AddBackground( 0, 0, Width, Height, 0x13BE );

			int y = 0;

			AddHtml( 0, y+=10, Width, 20, String.Format( "{0}<CENTER>{1} this House?", HTML.White, c_Sign.RentByTime == TimeSpan.Zero ? "Purchase" : "Rent" ), false, false );
			AddBackground( 50, y+=20, Width-100, 3, 0x13BE );

			if ( c_Sign.RentByTime == TimeSpan.Zero )
				AddHtml( 0, y+=5, Width, 20, String.Format( "{0}<CENTER>{1}: {2}", HTML.White, "Price", c_Sign.Free ? "Free" : "" + c_Sign.Price ), false, false );
			else if ( c_Sign.RecurRent )
				AddHtml( 0, y+=5, Width, 20, String.Format( "{0}<CENTER>{1}: {2}", HTML.White, "Recurring " + c_Sign.PriceType, c_Sign.Price ), false, false );
			else
				AddHtml( 0, y+=5, Width, 20, String.Format( "{0}<CENTER>{1}: {2}", HTML.White, "One " + c_Sign.PriceTypeShort, c_Sign.Price ), false, false );

			if ( c_Sign.KeepItems )
			{
				AddHtml( 0, y+=20, Width, 20, HTML.White + "<CENTER>Cost of Items: " + c_Sign.ItemsPrice, false, false );
				AddButton( 20, y, c_Items ? 0xD3 : 0xD2, c_Items ? 0xD3 : 0xD2, "Items", new TimerCallback( Items ) );
			}

			AddHtml( 0, y+=20, Width, 20, HTML.White + "<CENTER>Lockdowns: " + c_Sign.Locks, false, false );
			AddHtml( 0, y+=20, Width, 20, HTML.White + "<CENTER>Secures: " + c_Sign.Secures, false, false );

			AddButton( 10, Height-35, 0xFB1, 0xFB3, "Cancel", new TimerCallback( Cancel ) );
			AddButton( Width-40, Height-35, 0xFB7, 0xFB9, "Confirm", new TimerCallback( Confirm ) );
		}

		private void Items()
		{
			c_Items = !c_Items;

			NewGump();
		}

		private void Cancel()
		{
		}

		private void Confirm()
		{
			c_Sign.Purchase( Owner, c_Items );
		}
	}
}