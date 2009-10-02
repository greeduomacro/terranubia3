using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an eagle corpse" )]
	public class Eagle : NubiaCreature
	{
		[Constructable]
		public Eagle() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "an eagle";
			Body = 5;
			BaseSoundID = 0x2EE;

            this.VirtualArmor = 13;

            this.ConfigureCreature(2, ClasseType.Barbare);
            CreatureType = MobileType.Animal;


            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;
		}

		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 36; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Eagle(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}