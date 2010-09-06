using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class BrownBear : NubiaCreature
	{
		[Constructable]
        public BrownBear()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 0.4)
		{
			Name = "Ours brun";
			Body = 167;
			BaseSoundID = 0xA3;


            CreatureType = MobileType.Animal;
            Faction = FactionEnum.Nature;

            NiveauCreature = 4;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public BrownBear( Serial serial ) : base( serial )
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