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
                    "Jeux", // 2
                    "Sacs", // 3
                };
            }
        }

        public override void ConstructList()
        {
            // O U T I L S
            AddEntry("Parchemin d'ecriture", 0, typeof(NubiaParchemin), 5, 15,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 1) });
            AddEntry("Nécessaire d'écriture", 0, typeof(EruditionTool), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(Feather), 2),
                    new RessourceNeed(typeof(BaseMetal), 1) });

            AddEntry("Marteau de forgeron", 0, typeof(ForgeronTool), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 1),
                    new RessourceNeed(typeof(BaseMetal), 1) });

            AddEntry("Nécessaire de couture", 0, typeof(CoutureTool), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2),
                    new RessourceNeed(typeof(BaseMetal), 1) });

            AddEntry("Ciseaux", 0, typeof(Scissors), 5, 10,
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
            AddEntry("Lanterne", 1, typeof(Lantern), 5, 10,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 3)});
            
            AddEntry("Chandelle", 1, typeof(Candle), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseMetal), 2)});

            // J E U X
            AddEntry("Jeu de backgammon", 2, typeof(Backgammon), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Jeu d'échec", 2, typeof(Chessboard), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Jeu de dames", 2, typeof(CheckerBoard), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Dés", 2, typeof(Dices), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 1)});

            // S A C S
            AddEntry("Bourse", 3, typeof(Pouch), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseCuir), 2)});
            AddEntry("Sac", 3, typeof(Bag), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseCuir), 3)});
            AddEntry("Sac à dos", 3, typeof(Backpack), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseCuir), 5)});

        }

        public ListIngen()
            : base(typeof(CraftIngenSystem))
        {
        }
    }
}