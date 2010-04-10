using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("un corps de Corbeau")]
    public class Faucon : NubiaCreature
    {
        [Constructable]
        public Faucon()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Faucon";
            Body = 5;
            BaseSoundID = 0x2EE;

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 0;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 5 };
            mMonsterCA = 17;
            mMonsterHits = DndHelper.rollDe(De.huit, 1);
            mMonsterReflexe = 5;
            mMonsterVigueur = 2;
            mMonsterVolonte = 2;
            RawStr = 6;
            RawDex = 17;
            RawCons = 10;
            RawInt = 2;
            RawSag = 14;
            RawCha = 6;
            mMonsterNiveau = 1;
            AddCompetence(CompType.Detection, 14);
            AddCompetence(CompType.PerceptionAuditive, 2);
            //  AddCompetence(CompType.Survie, 1);
            Tamable = false;
            ControlSlots = 1;
        }

        public override int Meat { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.Meat; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

        public Faucon(Serial serial)
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