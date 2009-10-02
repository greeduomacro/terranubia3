using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13F6, 0x13F7 )]
	public class ButcherKnife : BaseKnife
	{
	

		[Constructable]
		public ButcherKnife() : base( 0x13F6 )
		{
			Weight = 1.0;
		}

		public ButcherKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}