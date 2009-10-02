using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF61, 0xF60 )]
	public class Longsword : BaseSword
	{
		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		[Constructable]
		public Longsword() : base( 0xF61 )
		{
			Weight = 7.0;
		}

		public Longsword( Serial serial ) : base( serial )
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