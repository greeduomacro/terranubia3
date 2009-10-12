using System;
using Server;

namespace Server.Items
{
	public class Aegis : HeaterShield
	{
		public override int LabelNumber{ get{ return 1061602; } } // Ægis


		[Constructable]
		public Aegis()
		{
			Hue = 0x47E;
			
		}

		public Aegis( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
				PhysicalBonus = 0;
		}
	}
}