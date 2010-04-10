using System;
using Server;
using Server.Nubia;
using Server.Targeting;

namespace Server.Items
{
	public class PlanteAqualide : BasePlante
	{
		public override EnumPlanteTerrain Terrain { get{return EnumPlanteTerrain.Ferme; }}
		public override bool CanEat { get{return false; }} //Savoir si on peu directement manger la récolte
		public override int DD { get{return 70; }}

		[Constructable]
		public PlanteAqualide() : base( EnumPlante.Aqualide )
		{
			Hue = 2120;
		}
		[Constructable]
		public PlanteAqualide( Serial serial ) : base( serial )
		{
			Hue = 2120;
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
