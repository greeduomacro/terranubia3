using System;
using Server;
using Server.Nubia;

namespace Server.Items
{
	public class PlanteBle : BasePlante
	{
		public override EnumPlanteTerrain Terrain { get{return EnumPlanteTerrain.Ferme; }}
		public override bool CanEat { get{return true; }} //Savoir si on peu directement manger la récolte
		public override int DD { get{return 40; }}

		[Constructable]
		public PlanteBle() : base( EnumPlante.Ble )
		{
		}
		[Constructable]
		public PlanteBle( Serial serial ) : base( serial )
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
