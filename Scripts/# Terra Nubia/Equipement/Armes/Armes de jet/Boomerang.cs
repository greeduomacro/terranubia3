using System;
using Server.Network;
using Server.Items;
using Server.Nubia;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class NubiaBoomerang : BaseLancer
	{

		[Constructable]
		public NubiaBoomerang() : base( 9040 )
		{

			ProjectilID = 9040;
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Name = "Boomerang acéré";
			Hue = 1109;
		}

		public NubiaBoomerang( Serial serial ) : base( serial )
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