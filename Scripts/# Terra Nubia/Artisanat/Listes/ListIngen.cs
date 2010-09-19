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
                    "Contenants", // 3
                    "Batons", //4
                    "Arcs & Arbalètes", //5 
                    "Munitions", //6
                    "Livres" //7
                };
            }
        }

        public override void ConstructList()
        {
            //Munitions
            AddEntry("10 Flèches", 5, typeof(Arrow10), 2, 10,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 5),
             new RessourceNeed(typeof(Feather), 10) });

            AddEntry("10 Carreaux", 6, typeof(Bolt), 2, 10,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 5),
             new RessourceNeed(typeof(Feather), 10) });

            //Arcs & Arbalètes
            AddEntry("Arc", 5, typeof(Bow), 5, 12,
              new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 5),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc Composite", 5, typeof(CompositeBow), 8, 18,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 6),
               new RessourceNeed(typeof(BaseCuir), 2)});

            AddEntry("Arbalète", 5, typeof(Crossbow), 8, 18,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 6),
               new RessourceNeed(typeof(BaseMetal), 2)});
            AddEntry("Arbalète lourde", 5, typeof(HeavyCrossbow), 8, 20,
        new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 6),
               new RessourceNeed(typeof(BaseMetal), 2)});

            AddEntry("Arc", 5, typeof(Arc1), 8, 20,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc2), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc3), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc4), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc5), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc6), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc7), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc8), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc9), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc10), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc11), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc12), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc13), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc14), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            AddEntry("Arc", 5, typeof(Arc15), 8, 20,
           new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 7),
               new RessourceNeed(typeof(BaseCuir), 1)});

            //Batons
            AddEntry("Baton metalique", 4, typeof(BlackStaff), 5, 15,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 5) });

            AddEntry("Baton de bois", 4, typeof(QuarterStaff), 5, 15,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2) });

            AddEntry("Baton noueux", 4, typeof(GnarledStaff), 5, 15,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2) });

            AddEntry("Baton", 4, typeof(Baton1), 8, 20,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 2) });
            AddEntry("Baton", 4, typeof(Baton2), 8, 20,
            new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2) });
            AddEntry("Baton", 4, typeof(Baton3), 8, 20,
          new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2) });
            AddEntry("Baton", 4, typeof(Baton4), 8, 20,
            new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseBois), 2) });

            // O U T I L S
            AddEntry("Paire de ciseaux", 0, typeof(Scissors), 5, 15,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 1) });
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

           AddEntry("Torche", 1, typeof(Torch), 6, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});

            // J E U X
            AddEntry("Jeu de backgammon", 2, typeof(Backgammon), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Jeu d'échec", 2, typeof(Chessboard), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Jeu de dames", 2, typeof(CheckerBoard), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});
            AddEntry("Dés", 2, typeof(Dices), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 1)});

            // Contenants
            AddEntry("Petite caisse", 3, typeof(SmallCrate), 2, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 3)});

            AddEntry("Caisse", 3, typeof(MediumCrate), 2, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)});

            AddEntry("Grosse caisse", 3, typeof(LargeCrate), 2, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 8)});

            AddEntry("Boîte de bois", 3, typeof(WoodenBox), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseMetal), 1),
                    new RessourceNeed(typeof(BaseBois), 5)});

            AddEntry("Boîte de métal", 3, typeof(MetalBox), 3, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseMetal), 6)});

            AddEntry("Coffre de bois", 3, typeof(WoodenChest), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseMetal), 2),
                    new RessourceNeed(typeof(BaseBois), 8)});

            AddEntry("Coffre de métal", 3, typeof(MetalChest), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseMetal), 10)});

            AddEntry("Sacs pour monture", 3, typeof(PackMonture), 5, 20,
             new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseCuir), 20),
                    new RessourceNeed(typeof(BaseMetal), 4)
             });

            AddEntry("Livre (20 pages)", 7, typeof(BlueBook20), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 3)
                });

            AddEntry("Livre (20 pages)", 7, typeof(BrownBook20), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 3)
                });

            AddEntry("Livre (20 pages)", 7, typeof(RedBook20), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 3)
                });

            AddEntry("Livre (20 pages)", 7, typeof(TanBook20), 5, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 3)
                });

            AddEntry("Livre (50 pages)", 7, typeof(BlueBook50), 7, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)
                });

            AddEntry("Livre (50 pages)", 7, typeof(BrownBook50), 7, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)
                });

            AddEntry("Livre (50 pages)", 7, typeof(RedBook50), 7, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)
                });

            AddEntry("Livre (50 pages)", 7, typeof(TanBook50), 7, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 5)
                });

            AddEntry("Livre (100 pages)", 7, typeof(BlueBook100), 9, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 8)
                });

            AddEntry("Livre (100 pages)", 7, typeof(BrownBook100), 9, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 8)
                });

            AddEntry("Livre (100 pages)", 7, typeof(RedBook100), 9, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 8)
                });

            AddEntry("Livre (100 pages)", 7, typeof(TanBook100), 9, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 8)
                });

            AddEntry("Livre (200 pages)", 7, typeof(BlueBook200), 11, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 14)
                });

            AddEntry("Livre (200 pages)", 7, typeof(BrownBook200), 11, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 14)
                });

            AddEntry("Livre (200 pages)", 7, typeof(RedBook200), 11, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 14)
                });

            AddEntry("Livre (200 pages)", 7, typeof(TanBook200), 11, 10,
                new RessourceNeed[]{
                    new RessourceNeed(typeof(BaseBois), 14)
                });
           

        }

        public ListIngen()
            : base(typeof(CraftIngenSystem))
        {
        }
    }
}