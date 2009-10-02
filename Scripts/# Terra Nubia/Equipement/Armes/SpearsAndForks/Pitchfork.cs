using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xE87, 0xE88 )]
	public class Pitchfork : BaseSpear
	{
		
		[Constructable]
		public Pitchfork() : base( 0xE87 )
		{
			Weight = 11.0;
		}

		public Pitchfork( Serial serial ) : base( serial )
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

			if ( Weight == 10.0 )
				Weight = 11.0;
		}
	}
}