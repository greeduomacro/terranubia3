using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "un corps de chouette" )]
    public class Chouette : NubiaCreature
	{
		[Constructable]
		public Chouette() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
            Name = "Chouette";
            Body = 5;
            BaseSoundID = 0x2EE;
			Hue = Utility.RandomAnimalHue();

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 0;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 5 };
            mMonsterCA = 14;
            mMonsterHits = DndHelper.rollDe(De.huit, 1);
            mMonsterReflexe = 5;
            mMonsterVigueur = 2;
            mMonsterVolonte = 2;
            RawStr = 4;
            RawDex = 17;
            RawCons = 10;
            RawInt = 2;
            RawSag = 14;
            RawCha = 4;
            mMonsterNiveau = 2;
            AddCompetence(CompType.DeplacementSilencieux, 17);
            AddCompetence(CompType.Detection, 6);
            AddCompetence(CompType.PerceptionAuditive, 14);
          //  AddCompetence(CompType.Survie, 1);
			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

        public Chouette(Serial serial)
            : base(serial)
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