using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giant rat corpse" )]
	[TypeAlias( "Server.Mobiles.Giantrat" )]
	public class GiantRat : NubiaCreature
	{
		[Constructable]
		public GiantRat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Rat sanguinaire";
			Body = 0xD7;
			BaseSoundID = 0x188;

            Faction = FactionEnum.Nature;

            NiveauCreature = 2;
            AddCompetence(CompType.Detection, 4);
            AddCompetence(CompType.PerceptionAuditive, 4);
            AddCompetence(CompType.DeplacementSilencieux, 4);
            AddCompetence(CompType.Discretion, 8);
            AddCompetence(CompType.Escalade, 11);
            Tamable = true;
            ControlSlots = 1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs; } }

		public GiantRat(Serial serial) : base(serial)
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