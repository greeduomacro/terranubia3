using System;
using Server.Network;
using Server.Items;
using Server.Nubia;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class NubiaFronde : BaseLancer
	{

		[Constructable]
		public NubiaFronde() : base( 9042 )
		{

			ProjectilID = 9039;
			Weight = 7.0;
			Name = "Fronde";
			Hue = 1109;
		}

		public NubiaFronde( Serial serial ) : base( serial )
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