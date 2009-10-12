using System;
using Server.Items;

namespace Server.Items
{
	//[FlipableAttribute( 13803 )]
	public class OrneChest : NubiaArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public OrneChest() : base( 13819 )
		{
			Weight = 6.0;
			//m_capaNeed = 15;
			Name = "Plastron d'Orne";
            ModelType = ArmorModelType.Plaque;
		}

		public OrneChest( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			if ( Weight == 1.0 )
				Weight = 6.0;
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}