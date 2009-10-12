using System;
using Server;

namespace Server.Items
{
	public class Buckler : BaseShield
	{
		[Constructable]
		public Buckler() : base( 0x1B73 )
		{
            BType = BouclierType.Targe;
			Weight = 5.0;
		}

		public Buckler( Serial serial ) : base(serial)
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
