using System;
using Server;
using Knives.Utils;

namespace Knives.TownHouses
{
	public class ContractConfirmGump : GumpPlus
	{
		public static void SendTo( Mobile m, RentalContract rc )
		{
			new ContractConfirmGump( m, rc );
		}

		private RentalContract c_Contract;

		private const int Width = 300;
		private const int Height = 300;

		public ContractConfirmGump( Mobile m, RentalContract rc ) : base( m, 100, 100 )
		{
			m.CloseGump( typeof( ContractConfirmGump ) );

			Override = false;

			c_Contract = rc;

			NewGump();
		}

		protected override void BuildGump()
		{
			AddBackground( 0, 0, Width, Height, 0x24A4 );

			int y = 0;

			if ( c_Contract.RentalClient == null )
				AddHtml( 0, y+5, Width, 20, HTML.Black + "<CENTER>Rent this House?", false, false );
			else
				AddHtml( 0, y+5, Width, 20, HTML.Black + "<CENTER>Rental Agreement", false, false );

			string text = String.Format( "  I, {0}, agree to rent this property from {1} for the sum of {2} every {3}.  " +
				"The funds for this payment will be taken directly from my bank.  In the case where " +
				"I cannot pay this fee, the property will return to {1}.  I may cancel this agreement at any time by " +
				"demolishing the property.  {1} may also cancel this agreement at any time by either demolishing their " +
				"property or canceling the contract, in which case your security deposit will be returned.",
				c_Contract.RentalClient == null ? "_____" : c_Contract.RentalClient.Name,
				c_Contract.RentalMaster.Name,
				c_Contract.Free ? 0 : c_Contract.Price,
				c_Contract.PriceTypeShort.ToLower() );

			text += "<BR>   Here is some more info reguarding this property:<BR>";

			text += String.Format( "<CENTER>Lockdowns: {0}<BR>", c_Contract.Locks );
			text += String.Format( "Secures: {0}<BR>", c_Contract.Secures );
			text += String.Format( "Floors: {0}<BR>", (c_Contract.MaxZ-c_Contract.MinZ < 200) ? (c_Contract.MaxZ-c_Contract.MinZ)/20+1 : 1 );
			text += String.Format( "Space: {0} cubic units", c_Contract.CalcVolume() );

			y+=30;

			AddHtml( 40, y, Width-60, Height-y-40, HTML.Black + text, false, true );

			if ( c_Contract.RentalClient == null )
			{
				AddHtml( 60, Height-24, 60, 20, HTML.Black + "Preview", false, false );
				AddButton( 40, Height-21, 0x837, 0x838, "Preview", new TimerCallback( Preview ) );

				bool locsec = c_Contract.ValidateLocSec();

				if ( Owner != c_Contract.RentalMaster && locsec )
				{
					AddHtml( Width-100, Height-24, 60, 20, HTML.Black + "Accept", false, false );
					AddButton( Width-60, Height-29, 0x232C, 0x232D, "Accept", new TimerCallback( Accept ) );
				}
				else
					AddImage( Width-60, Height-29, 0x232C );

				if ( !locsec )
					Owner.SendMessage( (Owner == c_Contract.RentalMaster ? "You don't have the lockdowns or secures available for this contract." : "The owner of this contract cannot rent this property at this time.") );
			}
			else
			{
				if ( Owner == c_Contract.RentalMaster )
				{
					AddHtml( 60, Height-24, 100, 20, HTML.Black + "Cancel Contract", false, false );
					AddButton( 40, Height-21, 0x837, 0x838, "Cancel Contract", new TimerCallback( CancelContract ) );
				}

				AddImage( Width-60, Height-29, 0x232C );
			}
		}

		protected override void OnClose()
		{
			c_Contract.ClearPreview();
		}

		private void Preview()
		{
			if ( c_Contract.ParentHouse != null && !(c_Contract.ParentHouse is TownHouse) )
				c_Contract.ShowAreaPreview( c_Contract.MinZ );
			else
				c_Contract.ShowAreaPreview();

			NewGump();
		}

		private void CancelContract()
		{
			if ( Owner == c_Contract.RentalClient )
				c_Contract.House.Delete();
			else
				c_Contract.Delete();
		}

		private void Accept()
		{
			if ( !c_Contract.ValidateLocSec() )
			{
				Owner.SendMessage( "The owner of this contract cannot rent this property at this time." );
				return;
			}

			c_Contract.Purchase( Owner );

			if ( !c_Contract.Owned )
				return;

			c_Contract.Visible = true;
			c_Contract.RentalClient = Owner;
			c_Contract.RentalClient.AddToBackpack( new RentalContractCopy( c_Contract ) );
		}
	}
}