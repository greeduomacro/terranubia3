using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Baton4 : BaseStaff
	{
		[Constructable]
		public Baton4() : base( 0x3DD6 )
		{
			Weight = 6.0;
		}

		public Baton4( Serial serial ) : base( serial )
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