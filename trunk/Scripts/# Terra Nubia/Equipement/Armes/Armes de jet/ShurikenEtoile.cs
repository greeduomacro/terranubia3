using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class NubiaShurikenEtoile : BaseLancer
	{
		[Constructable]
		public NubiaShurikenEtoile() : base( 9047 )
		{

			ProjectilID = 9047;
			Weight = 7.0;
			Name = "Shuriken";
			Hue = 1109;
		}

		public NubiaShurikenEtoile( Serial serial ) : base( serial )
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