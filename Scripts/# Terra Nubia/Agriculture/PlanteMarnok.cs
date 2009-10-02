using System;
using Server;
using Server.Nubia;

namespace Server.Items
{
	public class PlanteMarnok : BasePlante
	{
		public override EnumPlanteTerrain Terrain { get{return EnumPlanteTerrain.Marais; }}
		public override bool CanEat { get{return true; }} //Savoir si on peu directement manger la récolte
		public override int DD { get{return 30; }}

		[Constructable]
		public PlanteMarnok() : base( EnumPlante.Marnok )
		{
			Hue = 2118;
		}
		[Constructable]
		public PlanteMarnok( Serial serial ) : base( serial )
		{
			Hue = 2118;
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
