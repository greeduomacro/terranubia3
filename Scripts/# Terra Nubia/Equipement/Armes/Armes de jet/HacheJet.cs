using System;
using Server.Network;
using Server.Items;
using Server.Nubia;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class NubiaHacheJet : BaseLancer
	{
		[Constructable]
		public NubiaHacheJet() : base( 9043 )
		{

			ProjectilID = 9043;
			Weight = 7.0;
			Name = "Hache de jet";
			Hue = 1109;
		}

		public NubiaHacheJet( Serial serial ) : base( serial )
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