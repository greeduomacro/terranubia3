using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de blaireau")]
    public class Blaireau : NubiaCreature
    {
        [Constructable]
        public Blaireau()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Blaireau";
            Body = 278;
            BaseSoundID = 0xCC;
            Hue = Utility.RandomAnimalHue();

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;


            mMonsterHits = DndHelper.rollDe(De.huit, 1) + 2;
            mMonsterCA = 12;
            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 0;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 4 };
           
            mMonsterReflexe = 5;
            mMonsterVigueur = 4;
            mMonsterVolonte = 1;
            RawStr = 8;
            RawDex = 17;
            RawCons = 15;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;
            mMonsterNiveau = 2;
            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Evasion, 7);
            Tamable = true;
            ControlSlots = 1;
        }

        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        public Blaireau(Serial serial)
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