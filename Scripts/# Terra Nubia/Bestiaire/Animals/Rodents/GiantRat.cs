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

            mMonsterHits = DndHelper.rollDe(De.huit, 1) + 1;
            mMonsterCA = 15;
            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 0;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 4 };

            mMonsterReflexe = 5;
            mMonsterVigueur = 3;
            mMonsterVolonte = 3;
            RawStr = 10;
            RawDex = 17;
            RawCons = 15;
            RawInt = 1;
            RawSag = 12;
            RawCha = 6;
            mMonsterNiveau = 2;
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