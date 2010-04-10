using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de Corbeau")]
    public class Corbeau : NubiaCreature
    {
        [Constructable]
        public Corbeau()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Corbeau";
            Body = 5;
            BaseSoundID = 0x2EE;
            Hue = 1109;

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.trois;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 4;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 4 };
            mMonsterCA = 14;
            mMonsterHits = DndHelper.rollDe(De.trois, 1);
            mMonsterReflexe = 5;
            mMonsterVigueur = 2;
            mMonsterVolonte = 2;
            RawStr = 1;
            RawDex = 15;
            RawCons = 10;
            RawInt = 2;
            RawSag = 14;
            RawCha = 6;
            mMonsterNiveau = 1;
            AddCompetence(CompType.Detection, 5);
            AddCompetence(CompType.PerceptionAuditive, 3);
            //  AddCompetence(CompType.Survie, 1);
            Tamable = false;
            ControlSlots = 1;
        }

        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        public Corbeau(Serial serial)
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