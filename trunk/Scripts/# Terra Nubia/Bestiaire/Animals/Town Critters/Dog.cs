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

            NiveauCreature = 2;
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