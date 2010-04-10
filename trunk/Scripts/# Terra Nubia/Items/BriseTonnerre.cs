using System;
using Server;
using Server.Nubia;

namespace Server.Items
{
	public class BriseTonnerre : Item
	{
		[Constructable]
		public BriseTonnerre() : base( 3524 )
		{
			Weight = 255.0;
			Movable = false;
		}

		public BriseTonnerre( Serial serial ) : base( serial )
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
