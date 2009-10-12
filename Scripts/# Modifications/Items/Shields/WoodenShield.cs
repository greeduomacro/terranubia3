using System;
using Server;

namespace Server.Items
{
	public class WoodenShield : BaseShield
	{
		
		[Constructable]
		public WoodenShield() : base( 0x1B7A )
		{
            BType = BouclierType.Targe;
			Weight = 5.0;
		}

		public WoodenShield( Serial serial ) : base(serial)
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
