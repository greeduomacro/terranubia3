using System;
using Server;
using Server.Nubia;

namespace Server.Items
{
	public class PlantePutralide : BasePlante
	{
		public override EnumPlanteTerrain Terrain { get{return EnumPlanteTerrain.Cadavre; }}
		public override bool CanEat { get{return false; }} //Savoir si on peu directement manger la récolte
		public override int DD { get{return 70; }}

		[Constructable]
		public PlantePutralide() : base( EnumPlante.Putralide )
		{
			Hue = 1443;
		}
		[Constructable]
		public PlantePutralide( Serial serial ) : base( serial )
		{
			Hue = 1443;
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
