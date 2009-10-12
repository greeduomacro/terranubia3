using System;
using Server;

namespace Server.Items
{
	public class BronzeShield : BaseShield
	{
		[Constructable]
		public BronzeShield() : base( 0x1B72 )
		{
            BType = BouclierType.Targe;
			Weight = 6.0;
		}

		public BronzeShield( Serial serial ) : base(serial)
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
