using System;
using Server;

namespace Server.Items
{
	public class MetalShield : BaseShield
	{
		[Constructable]
		public MetalShield() : base( 0x1B7B )
		{
            BType = BouclierType.Targe;
			Weight = 6.0;
		}

		public MetalShield( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
