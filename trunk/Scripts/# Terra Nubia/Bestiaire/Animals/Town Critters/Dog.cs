using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de chien")]
    public class Dog : NubiaCreature
    {
        [Constructable]
        public Dog()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Chien";
            Body = 0xD9;
            Hue = Utility.RandomAnimalHue();
            BaseSoundID = 0x85;

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 1;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 2 };
            mMonsterCA = 12;
            mMonsterHits = DndHelper.rollDe(De.huit, 1) + 2;
            mMonsterReflexe = 4;
            mMonsterVigueur = 5;
            mMonsterVolonte = 2;
            RawStr = 13;
            RawDex = 17;
            RawCons = 15;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;
            mMonsterNiveau = 2;
            AddCompetence(CompType.Detection, 5);
            AddCompetence(CompType.PerceptionAuditive, 5);
            AddCompetence(CompType.Saut, 7);
            AddCompetence(CompType.Survie, 1);
            Tamable = true;
            ControlSlots = 1;
        }

        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        public Dog(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}