using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a grizzly bear corpse" )]
	[TypeAlias( "Server.Mobiles.Grizzlybear" )]
	public class GrizzlyBear : NubiaCreature
	{
		[Constructable]
		public GrizzlyBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Grizzly";
			Body = 212;
			BaseSoundID = 0xA3;


            this.ConfigureCreature(6, ClasseType.Barbare);
            CreatureType = MobileType.Animal;


            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public GrizzlyBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}