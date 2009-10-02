using System;
using System.Collections;
using Server;
using Server.Targeting;
using Knives.Utils;

namespace Knives.TownHouses
{
	public class TownHouseSetupGump : GumpPlus
	{
		public static void SendTo( Mobile m, TownHouseSign sign )
		{
			new TownHouseSetupGump( m, sign );
		}

		public static Rectangle2D FixRect( Rectangle2D rect )
		{

			Point3D pointOne = Point3D.Zero;
			Point3D pointTwo = Point3D.Zero;

			if ( rect.Start.X < rect.End.X )
			{
				pointOne.X = rect.Start.X;
				pointTwo.X = rect.End.X;
			}
			else
			{
				pointOne.X = rect.End.X;
				pointTwo.X = rect.Start.X;
			}

			if ( rect.Start.Y < rect.End.Y )
			{
				pointOne.Y = rect.Start.Y;
				pointTwo.Y = rect.End.Y;
			}
			else
			{
				pointOne.Y = rect.End.Y;
				pointTwo.Y = rect.Start.Y;
			}

			return new Rectangle2D( pointOne, pointTwo );
		}

		public enum Page { Welcome, Blocks, Floors, Sign, Ban, LocSec, Items, Length, Price, Skills, Other }
		public enum TargetType { BanLoc, SignLoc, MinZ, MaxZ, BlockOne, BlockTwo }

		private TownHouseSign c_Sign;
		private Page c_Page;

		private const int Width = 300;
		private const int Height = 300;

		public TownHouseSetupGump( Mobile m, TownHouseSign sign ) : base( m, 50, 50 )
		{
			m.CloseGump( typeof( TownHouseSetupGump ) );

			c_Sign = sign;

			if ( !c_Sign.Owned )
				c_Page = Page.Blocks;

			NewGump();
		}

		protected override void BuildGump()
		{
			if ( c_Sign == null )
				return;

			AddBackground( 0, 0, Width, Height, 0x13BE );

			switch( c_Page )
			{
				case Page.Welcome: WelcomePage(); break;
				case Page.Blocks: BlocksPage(); break;
				case Page.Floors: FloorsPage(); break;
				case Page.Sign: SignPage(); break;
				case Page.Ban: BanPage(); break;
				case Page.LocSec: LocSecPage(); break;
				case Page.Items: ItemsPage(); break;
				case Page.Length: LengthPage(); break;
				case Page.Price: PricePage(); break;
				case Page.Skills: SkillsPage(); break;
				case Page.Other: OtherPage(); break;
			}

			BuildTabs();
		}

		protected override void OnClose()
		{
			StoreFields();
			c_Sign.ClearPreview();
		}

		private void BuildTabs()
		{
			int x = 50;

			AddButton( x, Height-45, c_Page == Page.Blocks ? 0x939 : 0x93A, c_Page == Page.Blocks ? 0x939 : 0x93A, "Blocks Page", new TimerStateCallback( ChangePage ), 1 );

			if ( c_Sign.BlocksReady )
				AddButton( x+=20, Height-45, c_Page == Page.Floors ? 0x939 : 0x93A, c_Page == Page.Floors ? 0x939 : 0x93A, "Floors Page", new TimerStateCallback( ChangePage ), 2 );

			if ( c_Sign.FloorsReady )
				AddButton( x+=20, Height-45, c_Page == Page.Sign ? 0x939 : 0x93A, c_Page == Page.Sign ? 0x939 : 0x93A, "Sign Page", new TimerStateCallback( ChangePage ), 3 );

			if ( c_Sign.SignReady )
				AddButton( x+=20, Height-45, c_Page == Page.Ban ? 0x939 : 0x93A, c_Page == Page.Ban ? 0x939 : 0x93A, "Ban Page", new TimerStateCallback( ChangePage ), 4 );

			if ( c_Sign.BanReady )
				AddButton( x+=20, Height-45, c_Page == Page.LocSec ? 0x939 : 0x93A, c_Page == Page.LocSec ? 0x939 : 0x93A, "LocSec Page", new TimerStateCallback( ChangePage ), 5 );

			if ( c_Sign.LocSecReady )
			{
				AddButton( x+=20, Height-45, c_Page == Page.Items ? 0x939 : 0x93A, c_Page == Page.Items ? 0x939 : 0x93A, "Items Page", new TimerStateCallback( ChangePage ), 6 );

				if ( !c_Sign.Owned )
					AddButton( x+=20, Height-45, c_Page == Page.Length ? 0x939 : 0x93A, c_Page == Page.Length ? 0x939 : 0x93A, "Length Page", new TimerStateCallback( ChangePage ), 7 );
				else
					x+=20;

				AddButton( x+=20, Height-45, c_Page == Page.Price ? 0x939 : 0x93A, c_Page == Page.Price ? 0x939 : 0x93A, "Price Page", new TimerStateCallback( ChangePage ), 8 );
			}

			if ( c_Sign.PriceReady )
			{
				AddButton( x+=20, Height-45, c_Page == Page.Skills ? 0x939 : 0x93A, c_Page == Page.Skills ? 0x939 : 0x93A, "Skills Page", new TimerStateCallback( ChangePage ), 9 );
				AddButton( x+=20, Height-45, c_Page == Page.Other ? 0x939 : 0x93A, c_Page == Page.Other ? 0x939 : 0x93A, "Other Page", new TimerStateCallback( ChangePage ), 10 );

				if ( !c_Sign.Owned )
				{
					AddBackground( Width/2-50, Height, 100, 30, 0x13BE );
					AddHtml( Width/2-50+25, Height+5, 100, 20, HTML.White + "Claim Home", false, false );
					AddButton( Width/2-50+5, Height+10, 0x837, 0x838, "Claim", new TimerCallback( Claim ) );
				}
			}
		}

		private void WelcomePage()
		{
			if ( !c_Sign.Owned )
				return;

			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Welcome!", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			string helptext = String.Format( "  This home is owned by {0}, so be aware that changing anything " + 
				"through this menu will change the home itself!  You can add more area, change the ownership " +
				"rules, almost anything!  You cannot, however, change the rental status of the home, way too many " +
				"ways for things to go ill.  If you change the restrictions and the home owner no longer meets them, " +
				"they will receive the normal 24 hour demolish warning.", c_Sign.House.Owner.Name );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );
		}

		private void BlocksPage()
		{
			if ( c_Sign == null )
				return;

			c_Sign.ShowAreaPreview();

			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Create the Area", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 50, y+=10, 70, 20, HTML.White + "Add Area", false, false );
			AddButton( 120, y, 0x15E1, 0x15E5, "Add Area", new TimerCallback( AddBlock ) );

			AddHtml( 170, y, 70, 20, HTML.White + "Clear All", false, false );
			AddButton( 240, y, 0x15E1, 0x15E5, "Clear All", new TimerCallback( ClearBlocks ) );

			AddBackground( 40, y+=25, Width-80, 3, 0x13BE );

			string helptext = String.Format( "   Setup begins with defining the area you wish to sell or rent.  " + 
				"You can add as many boxes as you wish, and each time the preview will extend to show what " +
				"you've selected so far.  If you feel like starting over, just clear them away!  You must have " +
				"at least one block defined before continuing to the next step." );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			if ( c_Sign.BlocksReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void FloorsPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Floors", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 50, y+=10, 80, 20, HTML.White + "Base Floor", false, false );
			AddImageTiled( 120, y, 70, 20, 0xBBC );
			AddTextField( 120, y, 70, 20, 0x480, 6, c_Sign.MinZ.ToString() );
			AddButton( 200, y, 0x15E1, 0x15E5, "Base Floor", new TimerCallback( MinZSelect ) );

			AddHtml( 50, y+=25, 80, 20, HTML.White + "Top Floor", false, false );
			AddImageTiled( 120, y, 70, 20, 0xBBC );
			AddTextField( 120, y, 70, 20, 0x480, 7, c_Sign.MaxZ.ToString() );
			AddButton( 200, y, 0x15E1, 0x15E5, "Top Floor", new TimerCallback( MaxZSelect ) );

			AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
			AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );

			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			string helptext = String.Format( "   Now you will need to target the floors you wish to sell.  " + 
				"If you only want one floor, you can skip targeting the top floor.  Everything within the base " +
				"and highest floor will come with the home, and the more floors, the higher the cost later on.  " +
				"The fields show the Z levels of the floor, but you should only use those fields if you " +
				"understand what you are doing.  Use the submit button to finalize any text field changes." );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.FloorsReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void SignPage()
		{
			if ( c_Sign == null )
				return;

			c_Sign.ShowSignPreview();

			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Sign Location", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 40, y+=10, 80, 20, HTML.White + "Set Location:", false, false );
			AddImageTiled( 120, y, 30, 20, 0xBBC );
			AddTextField( 120, y, 30, 20, 0x480, 8, c_Sign.SignLoc.X.ToString() );
			AddImageTiled( 155, y, 30, 20, 0xBBC );
			AddTextField( 155, y, 30, 20, 0x480, 9, c_Sign.SignLoc.Y.ToString() );
			AddImageTiled( 190, y, 20, 20, 0xBBC );
			AddTextField( 190, y, 20, 20, 0x480, 10, c_Sign.SignLoc.Z.ToString() );
			AddButton( 230, y, 0x15E1, 0x15E5, "Sign Loc", new TimerCallback( SignLocSelect ) );

			AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
			AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );

			string helptext = String.Format( "   With this sign, the owner will have the same home owning rights " + 
				"as custom or classic homes.  If they use the sign to demolish the home, it will automatically " +
				"return to sale or rent.  Once again, you can change this location using the text fields, but " +
				"be sure you understand what you are doing.  Press the submit button to finalize any text field changes." );

			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.SignReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void BanPage()
		{
			if ( c_Sign == null )
				return;

			c_Sign.ShowBanPreview();

			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Ban Location", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 100, y+=10, 80, 20, HTML.White + "Set Location", false, false );
			AddButton( 180, y, 0x15E1, 0x15E5, "Ban Loc", new TimerCallback( BanLocSelect ) );

			string helptext = String.Format( "   The ban location determines where players are sent when ejected or " +
				"banned from a home.  If you never set this, they would appear at the most north western part of the " +
				"map!" );

			AddBackground( 40, y+=25, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.BanReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void LocSecPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Lockdowns and Secures", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 60, y+=10, 60, 20, HTML.White + "Secures", false, false );
			AddImageTiled( 120, y, 50, 20, 0xBBC );
			AddTextField( 120, y, 50, 20, 0x480, 2, c_Sign.Secures.ToString() );

			AddHtml( 60, y+=21, 60, 20, HTML.White + "Lockdowns", false, false );
			AddImageTiled( 120, y, 50, 20, 0xBBC );
			AddTextField( 120, y, 50, 20, 0x480, 3, c_Sign.Locks.ToString() );

			AddHtml( 210, y-10, 60, 20, HTML.White + "Suggest", false, false );
			AddButton( 190, y-5, 0x837, 0x838, "Suggest LocSec", new TimerCallback( SuggestLocSec ) );

			AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
			AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );

			string helptext = String.Format( "   With this step you'll set the amount of storage for the home, or let " + 
				"the system do so for you using the Suggest button.  In general, players get half the number of lockdowns " +
				"as secure storage.  Press the submit button to finalize any text field changes." );

			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.LocSecReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void ItemsPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Decoration Items", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 70, y+=10, 180, 20, HTML.White + "Give buyer items in home", false, false );
			AddButton( 40, y, c_Sign.KeepItems ? 0xD3 : 0xD2, c_Sign.KeepItems ? 0xD3 : 0xD2, "Keep Items", new TimerCallback( KeepItems ) );

			if ( c_Sign.KeepItems )
			{
				AddHtml( 80, y+=30, 100, 20, HTML.White + "At cost", false, false );
				AddImageTiled( 140, y, 70, 20, 0xBBC );
				AddTextField( 140, y, 70, 20, 0x480, 10, c_Sign.ItemsPrice.ToString() );

				AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
				AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );

				y-=5;
			}
			else
			{
				AddHtml( 70, y+=20, 180, 20, HTML.White + "Don't delete items", false, false );
				AddButton( 40, y, c_Sign.LeaveItems ? 0xD3 : 0xD2, c_Sign.LeaveItems ? 0xD3 : 0xD2, "Keep Items", new TimerCallback( LeaveItems ) );
			}

			string helptext = String.Format( "   By default, the system will delete all items non-static items already " + 
				"in the home at the time of purchase.  These items are commonly referred to as Decoration Items. " +
				"They do not include home addons, like forges and the like.  They do include containers.  You can " +
				"allow players to keep these items by saying so here, and you may also charge them to do so!  " +
				"Press the submit button to finalize any text field changes." );

			AddBackground( 40, y+=25, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.ItemsReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page + ( c_Sign.Owned ? 2: 1 ) );
			}
		}

		private void LengthPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Buy or Rent", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 120, y+=12, 50, 25, HTML.White + c_Sign.PriceType, false, false );
			AddButton( 170, y+8, 0x985, 0x985, "LengthUp", new TimerCallback( PriceUp ) );
			AddButton( 170, y-2, 0x983, 0x983, "LengthDown", new TimerCallback( PriceDown ) );

			if ( c_Sign.RentByTime != TimeSpan.Zero )
			{
				AddHtml( 100, y+=21, 90, 25, HTML.White + "Recurring Rent", false, false );
				AddButton( 70, y, c_Sign.RecurRent ? 0xD3 : 0xD2, c_Sign.RecurRent ? 0xD3 : 0xD2, "RecurRent", new TimerCallback( RecurRent ) );

				if ( c_Sign.RecurRent )
				{
					AddHtml( 100, y+=21, 90, 25, HTML.White + "Rent To Own", false, false );
					AddButton( 70, y, c_Sign.RentToOwn ? 0xD3 : 0xD2, c_Sign.RentToOwn ? 0xD3 : 0xD2, "RentToOwn", new TimerCallback( RentToOwn ) );
				}
			}

			string helptext = String.Format( "   Getting closer to completing the setup!  Now you get to specify whether " + 
				"this is a purchase or rental property.  Simply use the arrows until you have the setting you desire.  For " +
				"rental property, you can also make the purchase non-recuring, meaning after the time is up the player " +
				"gets the boot!  With recurring, if they have the money available they can continue to rent.  You can " +
				"also enable Rent To Own, allowing players to own the property after making two months worth of payments." );

			AddBackground( 40, y+=25, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.LengthReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void PricePage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Price", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 150, y+=10, 100, 20, HTML.White + "Free", false, false );
			AddButton( 120, y, c_Sign.Free ? 0xD3 : 0xD2, c_Sign.Free ? 0xD3 : 0xD2, "Free", new TimerCallback( Free ) );

			if ( !c_Sign.Free )
			{
				AddHtml( 40, y+=25, 80, 20, HTML.White + c_Sign.PriceType + " Price", false, false );
				AddImageTiled( 120, y, 70, 20, 0xBBC );
				AddTextField( 120, y, 70, 20, 0x480, 1, c_Sign.Price.ToString() );

				AddHtml( 220, y, 70, 20, HTML.White + "Suggest", false, false );
				AddButton( 200, y+5, 0x837, 0x838, "Suggest", new TimerCallback( SuggestPrice ) );

				AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
				AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );
			}

			string helptext = String.Format( "   Now you get to set the price for the home.  Remember, if this is a " + 
				"rental home, the system will charge them this amount for every period!  Luckily the Suggestion " +
				"takes this into account.  If you don't feel like guessing, let the system suggest a price for you.  " +
				"You can also give the home away with the Free option.  Press the submit button to finalize any text field changes." );

			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page - ( c_Sign.Owned ? 2 : 1 ) );

			if ( c_Sign.PriceReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void SkillsPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Skill Restictions", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 20, y+=10, 30, 20, HTML.White + "Skill", false, false );
			AddImageTiled( 50, y, 100, 20, 0xBBC );
			AddTextField( 50, y, 100, 20, 0x480, 4, c_Sign.Skill.ToString() );

			AddHtml( 170, y, 50, 20, HTML.White + "Amount", false, false );
			AddImageTiled( 220, y, 50, 20, 0xBBC );
			AddTextField( 220, y, 50, 20, 0x480, 5, c_Sign.SkillReq.ToString() );

			AddHtml( 10, y+=30, 70, 20, HTML.White + "Min Total", false, false );
			AddImageTiled( 80, y, 60, 20, 0xBBC );
			AddTextField( 80, y, 60, 20, 0x480, 8, c_Sign.MinTotalSkill.ToString() );

			AddHtml( 160, y, 70, 20, HTML.White + "Max Total", false, false );
			AddImageTiled( 230, y, 60, 20, 0xBBC );
			AddTextField( 230, y, 60, 20, 0x480, 9, c_Sign.MaxTotalSkill.ToString() );

			AddHtml( 140, y+=25, 60, 20, HTML.White + "Submit", false, false );
			AddButton( 120, y+5, 0x837, 0x838, "Submit", new TimerCallback( Submit ) );

			string helptext = String.Format( "   These settings are all optional.  If you want to restrict who can own " + 
				"this home by their skills, here's the place.  You can specify by the skill name and value, or by " +
				"player's total skills.  Press the submit button to finalize any text field changes." );

			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );

			if ( c_Sign.PriceReady )
			{
				AddHtml( Width-60, Height-30, 60, 20, HTML.White + "Next", false, false );
				AddButton( Width-30, Height-30, 0x15E1, 0x15E5, "Next", new TimerStateCallback( ChangePage ), (int)c_Page+1 );
			}
		}

		private void OtherPage()
		{
			int y = 0;

			AddHtml( 0, y+=10, Width, 20, HTML.White + "<CENTER>Other Options", false, false );
			AddBackground( 40, y+=20, Width-80, 3, 0x13BE );

			AddHtml( 100, y+=10, 90, 25, HTML.White + "Young Only", false, false );
			AddButton( 70, y, c_Sign.YoungOnly ? 0xD3 : 0xD2, c_Sign.YoungOnly ? 0xD3 : 0xD2, "Young Only", new TimerCallback( Young ) );

			if ( !c_Sign.YoungOnly )
			{
				AddHtml( 20, y+=21, 90, 25, HTML.White + "Murderers", false, false );
				AddHtml( 110, y, 90, 25, HTML.White + "Never", false, false );
				AddButton( 85, y, c_Sign.Murderers == Intu.No ? 0xD3 : 0xD2, c_Sign.Murderers == Intu.No ? 0xD3 : 0xD2, "No Murderers", new TimerStateCallback( Murderers ), Intu.No );
				AddHtml( 170, y, 90, 25, HTML.White + "Always", false, false );
				AddButton( 145, y, c_Sign.Murderers == Intu.Yes ? 0xD3 : 0xD2, c_Sign.Murderers == Intu.Yes ? 0xD3 : 0xD2, "Yes Murderers", new TimerStateCallback( Murderers ), Intu.Yes );
				AddHtml( 240, y, 90, 25, HTML.White + "Default", false, false );
				AddButton( 215, y, c_Sign.Murderers == Intu.Neither ? 0xD3 : 0xD2, c_Sign.Murderers == Intu.Neither ? 0xD3 : 0xD2, "Neither Murderers", new TimerStateCallback( Murderers ), Intu.Neither );
			}

			AddHtml( 100, y+=21, 150, 60, HTML.White + "Relock doors on demolish", false, false );
			AddButton( 70, y, c_Sign.Relock ? 0xD3 : 0xD2, c_Sign.Relock ? 0xD3 : 0xD2, "Relock", new TimerCallback( Relock ) );

			string helptext = String.Format( "   These options are also optional.  With the young setting, you can restrict " + 
				"who can buy the home to young players only.  Similarly, you can specify whether murderers or innocents are " +
				" allowed to own the home.  The last option specifies whether the doors within the " +
				"home are locked when the owner demolishes their property." );

			AddBackground( 40, y+=25, Width-80, 3, 0x13BE );

			y+=10;

			AddHtml( 10, y, Width-20, Height-y-50, HTML.White + helptext, false, true );

			AddHtml( 30, Height-30, 80, 20, HTML.White + "Previous", false, false );
			AddButton( 10, Height-30, 0x15E3, 0x15E7, "Previous", new TimerStateCallback( ChangePage ), (int)c_Page-1 );
		}

		private bool SkillNameExists( string text )
		{
			try
			{
				SkillName index = (SkillName)Enum.Parse( typeof( SkillName ), text, true );
				return true;
			}
			catch
			{
				Owner.SendMessage( "You provided an invalid skill name." );	
				return false;
			}
		}

		private void Submit()
		{
			StoreFields();

			NewGump();
		}

		private void StoreFields()
		{
			switch( c_Page )
			{
				case Page.Floors:
					c_Sign.MinZ = Utility.ToInt32( GetTextField( 6 ) );
					c_Sign.MaxZ = Utility.ToInt32( GetTextField( 7 ) );
					break;
				case Page.Sign:
					c_Sign.SignLoc = new Point3D( Utility.ToInt32( GetTextField( 8 ) ), Utility.ToInt32( GetTextField( 9 ) ), Utility.ToInt32( GetTextField( 10 ) ) );
					break;
				case Page.LocSec:
					c_Sign.Secures = Utility.ToInt32( GetTextField( 2 ) );
					c_Sign.Locks = Utility.ToInt32( GetTextField( 3 ) );
					break;
				case Page.Items:
					c_Sign.ItemsPrice = Utility.ToInt32( GetTextField( 10 ) );
					break;
				case Page.Price:
					if ( !c_Sign.Free )
						c_Sign.Price = Utility.ToInt32( GetTextField( 1 ) );
					break;
				case Page.Skills:
					if ( GetTextField( 4 ) != "" && SkillNameExists( GetTextField( 4 ) ) )
						c_Sign.Skill = GetTextField( 4 );
					else
						c_Sign.Skill = "";

					c_Sign.SkillReq = Utility.ToInt32( GetTextField( 5 ) );
					c_Sign.MinTotalSkill = Utility.ToInt32( GetTextField( 8 ) );
					c_Sign.MaxTotalSkill = Utility.ToInt32( GetTextField( 9 ) );
					break;
			}
		}

		private void ChangePage( object obj )
		{
			if ( c_Sign == null )
				return;

			StoreFields();

			if ( !(obj is int) )
				return;

			c_Page = (Page)(int)obj;

			c_Sign.ClearPreview();

			NewGump();
		}

		private void BanLocSelect()
		{
			Owner.SendMessage( "Target the ban location." );
			Owner.Target = new InternalTarget( this, c_Sign, TargetType.BanLoc );
		}

		private void SignLocSelect()
		{
			Owner.SendMessage( "Target the location for the home sign." );
			Owner.Target = new InternalTarget( this, c_Sign, TargetType.SignLoc );
		}

		private void MinZSelect()
		{
			StoreFields();

			Owner.SendMessage( "Target the base floor." );
			Owner.Target = new InternalTarget( this, c_Sign, TargetType.MinZ );
		}


		private void MaxZSelect()
		{
			StoreFields();

			Owner.SendMessage( "Target the highest floor." );
			Owner.Target = new InternalTarget( this, c_Sign, TargetType.MaxZ );
		}

		private void Young()
		{
			c_Sign.YoungOnly = !c_Sign.YoungOnly;

			NewGump();
		}

		private void Murderers( object obj )
		{
			if ( !(obj is Intu) )
				return;

			c_Sign.Murderers = (Intu)obj;

			NewGump();
		}

		private void Relock()
		{
			c_Sign.Relock = !c_Sign.Relock;

			NewGump();
		}

		private void KeepItems()
		{
			c_Sign.KeepItems = !c_Sign.KeepItems;

			NewGump();
		}

		private void LeaveItems()
		{
			c_Sign.LeaveItems = !c_Sign.LeaveItems;

			NewGump();
		}

		private void RecurRent()
		{
			c_Sign.RecurRent = !c_Sign.RecurRent;

			NewGump();
		}

		private void RentToOwn()
		{
			c_Sign.RentToOwn = !c_Sign.RentToOwn;

			NewGump();
		}

		private void Claim()
		{
			StoreFields();

			TownHouseConfirmGump.SendTo( Owner, c_Sign );

			OnClose();
		}

		private void SuggestLocSec()
		{
			int price = c_Sign.CalcVolume()*General.SuggestionFactor;
			c_Sign.Secures = price/75;
			c_Sign.Locks = c_Sign.Secures/2;

			NewGump();
		}

		private void SuggestPrice()
		{
			c_Sign.Price = c_Sign.CalcVolume()*General.SuggestionFactor;

			if ( c_Sign.RentByTime == TimeSpan.FromDays( 1 ) )
				c_Sign.Price /= 60;
			if ( c_Sign.RentByTime == TimeSpan.FromDays( 7 ) )
				c_Sign.Price = (int)((double)c_Sign.Price/8.57);
			if ( c_Sign.RentByTime == TimeSpan.FromDays( 30 ) )
				c_Sign.Price /= 2;

			NewGump();
		}

		private void Free()
		{
			c_Sign.Free = !c_Sign.Free;

			NewGump();
		}

		private void AddBlock()
		{
			if ( c_Sign == null )
				return;

			Owner.SendMessage( "Target the north western corner." );
			Owner.Target = new InternalTarget( this, c_Sign, TargetType.BlockOne );
		}

		private void ClearBlocks()
		{
			if ( c_Sign == null )
				return;

			c_Sign.Blocks.Clear();
			c_Sign.ClearPreview();
			c_Sign.UpdateBlocks();

			NewGump();
		}

		private void PriceUp()
		{
			c_Sign.NextPriceType();

			NewGump();
		}

		private void PriceDown()
		{
			c_Sign.PrevPriceType();

			NewGump();
		}


		private class InternalTarget : Target
		{
			private TownHouseSetupGump c_Gump;
			private TownHouseSign c_Sign;
			private TargetType  c_Type;
			private Point3D c_BoundOne;

			public InternalTarget( TownHouseSetupGump gump, TownHouseSign sign, TargetType type ) : this( gump, sign, type, Point3D.Zero ){}

			public InternalTarget( TownHouseSetupGump gump, TownHouseSign sign, TargetType type, Point3D point ) : base( 20, true, TargetFlags.None )
			{
				c_Gump = gump;
				c_Sign = sign;
				c_Type = type;
				c_BoundOne = point;
			}

			protected override void OnTarget( Mobile m, object o )
			{
				IPoint3D point = (IPoint3D)o;

				switch( c_Type )
				{
					case TargetType.BanLoc:
						c_Sign.BanLoc = new Point3D( point.X, point.Y, point.Z );
						c_Gump.NewGump();
						break;

					case TargetType.SignLoc:
						c_Sign.SignLoc = new Point3D( point.X, point.Y, point.Z );
						c_Sign.ShowSignPreview();
						c_Gump.NewGump();
						break;

					case TargetType.MinZ:
						c_Sign.MinZ = point.Z;

						if ( c_Sign.MaxZ < c_Sign.MinZ+19 )
							c_Sign.MaxZ = point.Z+19;

						if ( c_Sign.MaxZ == short.MaxValue )
							c_Sign.MaxZ = point.Z+19;

						c_Gump.NewGump();
						break;

					case TargetType.MaxZ:
						c_Sign.MaxZ = point.Z+19;

						if ( c_Sign.MinZ > c_Sign.MaxZ )
							c_Sign.MinZ = point.Z;

						c_Gump.NewGump();
						break;

					case TargetType.BlockOne:
						m.SendMessage( "Now target the south eastern corner." );
						m.Target = new InternalTarget( c_Gump, c_Sign, TargetType.BlockTwo, new Point3D( point.X, point.Y, point.Z ) );
						break;

					case TargetType.BlockTwo:
						c_Sign.Blocks.Add( FixRect( new Rectangle2D( c_BoundOne, new Point3D( point.X+1, point.Y+1, point.Z ) ) ) );
                        Console.WriteLine(c_Sign.Blocks.Count);
						c_Sign.UpdateBlocks();
                        Console.WriteLine(c_Sign.Blocks.Count);
                        c_Sign.ShowAreaPreview(m.Z);
						c_Gump.NewGump();
						break;
				}
			}

			protected override void OnTargetCancel( Mobile m, TargetCancelType cancelType )
			{
				c_Gump.NewGump();
			}
		}
	}
}