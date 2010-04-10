using System;
using Server;

namespace Server.Items
{
	public class MetalKiteShield : BaseShield, IDyable
	{
		
		[Constructable]
		public MetalKiteShield() : base( 0x1B74 )
		{
            BType = BouclierType.Pavois;
			Weight = 7.0;
		}

		public MetalKiteShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
