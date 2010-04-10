using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Engines.Harvest;

namespace Server.Engines
{
    public class ListIngen : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Outils", //0
                    "Lumières", //1
                };
            }
        }

        public override void ConstructList()
        {
            // O U T I L S
            AddEntry("Nessecaire d'écriture", 0, typeof(EruditionTool), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(Feather), 2),
                    new RessourceNeed(typeof(BaseMetal), 1) });

            AddEntry("Marteau de forgeron", 0, typeof(ForgeronTool), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 1),
                    new RessourceNeed(typeof(BaseMetal), 1) });

            AddEntry("Sciseaux", 0, typeof(Scissors), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 2) });

            AddEntry("Mortier & Pilon", 0, typeof(MortarPestle), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 3) });

            AddEntry("Hachette", 0, typeof(Hatchet), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 4) ,
                    new RessourceNeed (typeof(BaseBois), 1) });

            AddEntry("Pioche", 0, typeof(Pickaxe), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 4) ,
                    new RessourceNeed (typeof(BaseBois), 1) });

            AddEntry("Crochet à serrure", 0, typeof(Lockpick), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 1)});

            // L U M I E R E S
            AddEntry("Lanterne", 0, typeof(Lantern), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 3)});

        }

        public ListIngen()
            : base(typeof(CraftIngenSystem))
        {
        }
    }
}