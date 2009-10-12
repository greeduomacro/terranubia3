using System;
using Server;

namespace Server.Items
{
	public class WoodenKiteShield : BaseShield
	{
		[Constructable]
		public WoodenKiteShield() : base( 0x1B79 )
		{
            BType = BouclierType.Pavois;
			Weight = 5.0;
		}

		public WoodenKiteShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 7.0 )
				Weight = 5.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
