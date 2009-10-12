using System;
using Server.Items;

namespace Server.Items
{
	//[FlipableAttribute( 13803 )]
	public class OrneHelm : NubiaArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public OrneHelm() : base( 13816 )
		{
			Weight = 6.0;
			//m_capaNeed = 14;
			Name = "Casque d'Orne";
            ModelType = ArmorModelType.Plaque;
		}

		public OrneHelm( Serial serial ) : base( serial )
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