using System;
using Server.Items;

namespace Server.Items
{
	//[FlipableAttribute( 13803 )]
	public class ChaosHelm : NubiaArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public ChaosHelm() : base( 13806 )
		{
			Weight = 6.0;
			//m_capaNeed = 14;
			Name = "Casque chaotique";
			ModelType = ArmorModelType.Plaque;
		}

		public ChaosHelm( Serial serial ) : base( serial )
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