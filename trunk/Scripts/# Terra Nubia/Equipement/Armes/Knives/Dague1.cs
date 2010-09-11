using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class Dague1 : BaseKnife
	{
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public Dague1() : base( 0x2BEF )
		{
            Name = "Dague assassine";
			Weight = 1.0;
		}

		public Dague1( Serial serial ) : base( serial )
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