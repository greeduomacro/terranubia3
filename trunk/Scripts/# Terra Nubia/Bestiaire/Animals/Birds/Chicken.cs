using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a chicken corpse" )]
	public class Chicken : BaseBestiole
	{
		[Constructable]
		public Chicken()
		{
			Name = "Poule";
			Body = 0xD0;
			BaseSoundID = 0x6E;

            if (Utility.RandomDouble() > 0.80)
            {
                Name = "Coq";
                Hue = 1888;
            }

		}

		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

		public override int Feathers{ get{ return 25; } }

		public Chicken(Serial serial) : base(serial)
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