using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "un corps de serpent" )]
	public class Snake : NubiaCreature
	{
		[Constructable]
		public Snake() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Serpent";
			Body = 52;
			Hue = Utility.RandomSnakeHue();
			BaseSoundID = 0xDB;

            Faction = FactionEnum.Nature;

            NiveauCreature = 3;
            AddCompetence(CompType.Detection, 7);
            AddCompetence(CompType.PerceptionAuditive, 7);
            AddCompetence(CompType.Discretion, 11);
            AddCompetence(CompType.Equilibre, 11);
            AddCompetence(CompType.Escalade, 11);
            Tamable = true;
            ControlSlots = 1;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Eggs; } }

		public Snake(Serial serial) : base(serial)
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