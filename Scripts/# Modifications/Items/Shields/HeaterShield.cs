using System;
using Server;

namespace Server.Items
{
	public class HeaterShield : BaseShield
	{
		[Constructable]
		public HeaterShield() : base( 0x1B76 )
		{
            BType = BouclierType.GrandPavois;
			Weight = 8.0;
		}

		public HeaterShield( Serial serial ) : base(serial)
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
