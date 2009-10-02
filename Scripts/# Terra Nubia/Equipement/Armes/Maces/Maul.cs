using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x143B, 0x143A )]
	public class Maul : BaseBashing
	{
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Bash2H; } }

		[Constructable]
		public Maul() : base( 0x143B )
		{
            Layer = Layer.TwoHanded;
			Weight = 10.0;
		}

		public Maul( Serial serial ) : base( serial )
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

			if ( Weight == 14.0 )
				Weight = 10.0;
		}
	}
}