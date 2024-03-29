﻿using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    public class GardeAuzac : NubiaCreature
    {
        public override bool ClickTitle { get { return false; } }

        [Constructable]
        public GardeAuzac()
            : base(AIType.AI_Melee, FightMode.Closest, 15, 2, 0.1, 0.2)
        {
            SpeechHue = Utility.RandomDyedHue();
            Title = "(Garde d'Auzac)";
            Hue = Utility.RandomList(new int[] { 1025, 1032, 1049, 1057, 1878 });

            if (this.Female = Utility.RandomBool())
            {
                Body = 401;
                Name = NameList.RandomName("female");
            }
            else
            {
                Body = 400;
                Name = NameList.RandomName("male");
            }


            AddItem(new Boots(Utility.RandomNeutralHue()));
            
            AddItem(new PlateLegs());
            AddItem(new ChainChest());
            AddItem(new StuddedArms());
            AddItem(new StuddedGloves());
            AddItem(new PlateGorget());
            AddItem(new Helmet() );


            AddItem(new Cloak(2241) );
            AddItem(new Surcoat(2241) );

            switch (Utility.Random(4))
            {
                case 0: AddItem(new Spear()); break;
                case 1: AddItem(new Halberd()); break;
                case 2: AddItem(new DoubleBladedStaff()); break;
                case 3: AddItem(new Bardiche()); break;
            }

            mMonsterHits = Utility.RandomMinMax(150, 200);

            NiveauCreature = 8;
            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
     

            //Utility.AssignRandomHair( this );
            NubiaHelper.RandomHair(this);


        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
        }


        public GardeAuzac(Serial serial)
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