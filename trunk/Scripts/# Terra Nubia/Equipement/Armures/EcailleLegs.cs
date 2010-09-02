using System;
using Server.Items;

namespace Server.Items
{
	//[FlipableAttribute( 13803 )]
	public class EcailleLegs : NubiaArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public EcailleLegs() : base( 13829 )
		{
            //Layer = Layer.MiddleTorso;
            Layer = Layer.MiddleTorso;
			Weight = 6.0;
			//m_capaNeed = 7;
			Name = "Pantalons d'écailles";
            ModelType = ArmorModelType.Maille;
		}

		public EcailleLegs( Serial serial ) : base( serial )
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