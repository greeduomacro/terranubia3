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

            CreatureType = MobileType.Animal;

            Server.Items.Fists Serres = new Server.Items.Fists();
            Serres.De = De.quatre;
            Serres.NbrLance = 1;
            Serres.BonusDegatStatic = 0;
            Serres.Movable = false;
            EquipItem(Serres);
            mMonsterAttaques = new int[] { 0,-4 };
            mMonsterCA = 14;
            mMonsterHits = DndHelper.rollDe(De.huit, 1) + 1;
            mMonsterReflexe = 4;
            mMonsterVigueur = 3;
            mMonsterVolonte = 2;
            RawStr = 10;
            RawDex = 15;
            RawCons = 12;
            RawInt = 2;
            RawSag = 14;
            RawCha = 6;
            mMonsterNiveau = 1;
            AddCompetence(CompType.Detection, 14);
            AddCompetence(CompType.PerceptionAuditive, 2);

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