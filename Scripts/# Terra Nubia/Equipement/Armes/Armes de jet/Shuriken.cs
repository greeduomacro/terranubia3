using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class NubiaShuriken : BaseLancer
	{

		[Constructable]
		public NubiaShuriken() : base( 9046 )
		{

			ProjectilID = 9046;
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Name = "Shuriken";
			Hue = 1109;
		}

		public NubiaShuriken( Serial serial ) : base( serial )
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