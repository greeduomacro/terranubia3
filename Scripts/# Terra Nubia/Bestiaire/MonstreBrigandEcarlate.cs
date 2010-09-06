using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    public class MonstreBrigandEcarlate : NubiaCreature
    {
        public override bool ClickTitle { get { return false; } }

        [Constructable]
        public MonstreBrigandEcarlate()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.4)
        {
            SpeechHue = Utility.RandomDyedHue();
            Title = " de la main écarlate";
            Hue = Utility.RandomList(new int[] { 1025, 1032, 1049, 1057, 1878 });

            if (this.Female = Utility.RandomBool())
            {
                Body = 401;
                Name = NameList.RandomName("female");
                AddItem(new Skirt(Utility.RandomNeutralHue()));
            }
            else
            {
                Body = 400;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }

            if (Utility.RandomDouble() > .8)
            {
                int hueOrc = Utility.RandomList(new int[] { 1450, 1451, 1452, 2420, 1441, 1442, 1443, 1444, 1025, 1032, 1049, 1057, 1878 });
                TNRaceSkinHalforc skin = new TNRaceSkinHalforc(hueOrc);
                this.Hue = hueOrc;
                skin.Movable = false;
                AddItem(skin);
            }

            AddItem(new Boots(Utility.RandomNeutralHue()));
            if (Utility.RandomBool())
                AddItem(new StuddedChest());
            else
                AddItem(new RingmailChest());

            AddItem(new RingmailLegs());
            AddItem(new RingmailArms());
            AddItem(new RingmailGloves());
            AddItem(new PlateGorget());

            if (Utility.RandomBool())
                AddItem(new SkullCap(2118));
            else
                AddItem(new Bandana(2118));

            AddItem(new BodySash(2118));

            switch (Utility.Random(7))
            {
                case 0: AddItem(new Longsword()); break;
                case 1: AddItem(new Cutlass()); break;
                case 2: AddItem(new Broadsword()); break;
                case 3: AddItem(new Axe()); break;
                case 4: AddItem(new Club()); break;
                case 5: AddItem(new Dagger()); break;
                case 6: AddItem(new Spear()); break;
            }

            if (FindItemOnLayer(Layer.OneHanded) != null)
            {
                if (FindItemOnLayer(Layer.OneHanded) is BaseSword && Utility.RandomBool())
                    AddItem(new WoodenShield());
            }

            NiveauCreature = Utility.RandomMinMax(6,8);
            Faction = FactionEnum.MainEcarlate;

            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
            //Utility.AssignRandomHair( this );
            NubiaHelper.RandomHair(this);

            VirtualArmor = 3;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }

        public override bool AlwaysMurderer { get { return true; } }

        public MonstreBrigandEcarlate(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}