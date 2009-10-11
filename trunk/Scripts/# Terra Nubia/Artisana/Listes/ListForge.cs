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
    public class ListForge : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Tranchante", //0
					"Masse d'arme", //1
					"Perforant", //2
					"Hast", //3
					"Haches", //4
					"Lancer", //5

                    "Broigne", //6
					"Maillé", //7
					"Plaque", //8
					"Bouclier", //9
					"Casque" //10
                };
            }
        }

        public override void ConstructList()
        {
            //EUROPE
            // épée longue
            AddEntry("Epée longue", 0 /*Tranchant, voir liste dans GetCategorieList*/, typeof(Longsword),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Hache
            AddEntry("Hache", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(Axe),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseBois), 4 ),
											new RessourceNeed( typeof(BaseCuir), 2)});

            //Hache de bataille
            AddEntry("Hache de bataille", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(BattleAxe),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 5 ),
											new RessourceNeed( typeof(BaseCuir), 3)});

            //Double hache
            AddEntry("Hache double", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(DoubleAxe),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 15 ),
											new RessourceNeed( typeof(BaseBois), 5 ),
											new RessourceNeed( typeof(BaseCuir), 3)});
            //Hache d'éxecution
            AddEntry("Hache d'éxecution", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(ExecutionersAxe),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 20 ),
											new RessourceNeed( typeof(BaseBois), 7 ),
											new RessourceNeed( typeof(BaseCuir), 7)});
            //Large hache de bataille
            AddEntry("Large hache de bataille", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(LargeBattleAxe),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 13 ),
											new RessourceNeed( typeof(BaseBois), 6 ),
											new RessourceNeed( typeof(BaseCuir), 4)});

            //Pioche
            AddEntry("Pioche", 4 /*Hache ???, voir liste dans GetCategorieList*/, typeof(Pickaxe),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 5 ),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            //Hache à deux main
            AddEntry("Hache à deux main", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(TwoHandedAxe),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 25 ),
											new RessourceNeed( typeof(BaseBois), 10 ),
											new RessourceNeed( typeof(BaseCuir), 8)});

            //Hache de guerre
            AddEntry("Hache de guerre", 4 /*Hache, voir liste dans GetCategorieList*/, typeof(WarAxe),
                                            6 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 30 ),
											new RessourceNeed( typeof(BaseBois), 15 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            //Couteau de bouché
            AddEntry("Couteau de bouché", 2 /*Perforant, voir liste dans GetCategorieList*/, typeof(ButcherKnife),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            //Dague
            AddEntry("Dague", 2 /*Perforant, voir liste dans GetCategorieList*/, typeof(Dagger),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            //Couteau
            AddEntry("Couteau", 2 /*Perforant, voir liste dans GetCategorieList*/, typeof(Cleaver),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Bec de corbin
            AddEntry("Bec de corbin", 1 /*Masse d'arme, voir liste dans GetCategorieList*/, typeof(HammerPick),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 4 ),
											new RessourceNeed( typeof(BaseBois), 4 ),
											new RessourceNeed( typeof(BaseCuir), 2)});

            //Masse
            AddEntry("Masse", 1 /*Masse d'arme, voir liste dans GetCategorieList*/, typeof(Mace),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 5 ),
											new RessourceNeed( typeof(BaseBois), 3 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Maule
            AddEntry("Maule", 1 /*Masse d'arme, voir liste dans GetCategorieList*/, typeof(Maul),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseBois), 4 )});
            //Marteau de guerre
            AddEntry("Marteau de guerre", 1 /*Masse d'arme, voir liste dans GetCategorieList*/, typeof(WarHammer),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 7 ),
											new RessourceNeed( typeof(BaseCuir), 5)});

            //Masse d'arme
            AddEntry("Masse d'arme", 1 /*Masse d'arme, voir liste dans GetCategorieList*/, typeof(WarMace),
                                            3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 13 ),
											new RessourceNeed( typeof(BaseBois), 6 ),
											new RessourceNeed( typeof(BaseCuir), 2)});

            //Bardiche
             AddEntry("Bardiche", 3 /*Hast, voir liste dans GetCategorieList*/, typeof(Bardiche),
                                            6 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 15 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            //Halbarde
             AddEntry("Halbarde", 3 /*Hast, voir liste dans GetCategorieList*/, typeof(Halberd),
                                            6 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 20 ),
											new RessourceNeed( typeof(BaseBois), 25 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            //Fouche de guerre
            AddEntry("Fourche de guerre", 2 /*Perforant, voir liste dans GetCategorieList*/, typeof(WarFork),
                                            6 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 5 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            //Epée batarde
             AddEntry("Epée batarde", 0 /*tranchant, voir liste dans GetCategorieList*/, typeof(Broadsword),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 2)});
            //Epée viking
            AddEntry("Epée viking", 0 /*tranchant, voir liste dans GetCategorieList*/, typeof(VikingSword),
                                            3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 2)});
            //ARABE
            //Couteau de dépeçage
            AddEntry("Couteau de dépeçage", 2 /*perforant, voir liste dans GetCategorieList*/, typeof(SkinningKnife),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 2)});
            //Petite épée
            AddEntry("Petite épée", 0 /*perforant, voir liste dans GetCategorieList*/, typeof(Cutlass),
                                            10 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 3)});
            //Cimetère
             AddEntry("Cimetère", 0 /*perforant, voir liste dans GetCategorieList*/, typeof(Scimitar),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 3)});

            //TRIBAL
            //Hachette
            AddEntry("Hachette", 4 /*perforant, voir liste dans GetCategorieList*/, typeof(Hatchet),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Fourche
             AddEntry("Fourche", 2 /*perforant, voir liste dans GetCategorieList*/, typeof(Pitchfork),
                                            3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 5 ),
											new RessourceNeed( typeof(BaseCuir), 2)});
            //Petite lance
             AddEntry("petite lance", 2 /*perforant, voir liste dans GetCategorieList*/, typeof(ShortSpear),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 4 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Lance
            AddEntry("Lance", 2 /*perforant, voir liste dans GetCategorieList*/, typeof(Spear),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 6 ),
											new RessourceNeed( typeof(BaseCuir), 3)});
            //Kryss
            AddEntry("Kryss", 0 /*perforant, voir liste dans GetCategorieList*/, typeof(Kryss),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 1)});
            //Epée tribal
            AddEntry("Epée tribal", 0 /*perforant, voir liste dans GetCategorieList*/, typeof(ThinLongsword),
                                            7 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 4)});


            // LANCER
            AddEntry("Boomerang", 5, typeof(NubiaBoomerang),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseBois), 5 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Fronde", 5, typeof(NubiaFronde),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseBois), 1 ),
											new RessourceNeed( typeof(BaseCuir), 4)});

            AddEntry("Hache de Jet", 5, typeof(NubiaHacheJet),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 4),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Javelot", 5, typeof(NubiaJavelot),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 4),
											new RessourceNeed( typeof(BaseBois), 2 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Shuriken (ninja)", 5, typeof(NubiaShuriken),
                                            8 /*Min value pour crafter*/, 15 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 4)});

            AddEntry("Shuriken en étoile (ninja)", 5, typeof(NubiaShurikenEtoile),
                                            8 /*Min value pour crafter*/, 15 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 4)});



            // Torse en maille
           AddEntry("Torse en maille", 7, typeof(ChainChest),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 15 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // jambière de maille
           AddEntry("jambière en maille", 7, typeof(ChainLegs),
                                            3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 15 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Bascinet
           AddEntry("Bascinet", 10, typeof(Bascinet),
                                            4 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // camail
           AddEntry("camail", 10, typeof(ChainCoif),
                                            2 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 7 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Casque fermé
           AddEntry("Casque fermé", 10, typeof(CloseHelm),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Casque
           AddEntry("Casque", 10, typeof(Helmet),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Casque nasal
           AddEntry("Casque nasal", 10, typeof(NorseHelm),
                                            50 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Casque complet
           AddEntry("Casque complet", 10, typeof(PlateHelm),
                                            9 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 20 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Torse de plaque pour femme
           AddEntry("Torse de plaque pour femme", 8, typeof(FemalePlateChest),
                                            9 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 40 ),
											new RessourceNeed( typeof(BaseCuir), 20)});
            // Brassard de plaque
           AddEntry("TBrassard de plaque", 8, typeof(PlateArms),
                                            7 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 20 ),
											new RessourceNeed( typeof(BaseCuir), 10)});
            // Torse de plaque
           AddEntry("Torse de plaque", 8, typeof(PlateChest),
                                            9 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 40 ),
											new RessourceNeed( typeof(BaseCuir), 20)});
            // Gantelet de plaque
           AddEntry("Gantelet de plaque", 8, typeof(PlateGloves),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 15 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Gorgin de plaque
           AddEntry("Gorgin de plaque", 8, typeof(PlateGorget),
                                            5 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Jambière de plaque
           AddEntry("jambière de plaque", 8, typeof(PlateLegs),
                                            9 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 35 ),
											new RessourceNeed( typeof(BaseCuir), 20)});
            // Brassard de broigne
           AddEntry("Brassard de broigne", 6, typeof(RingmailArms),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 5 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Torse de broigne
           AddEntry("Torse de broigne", 6, typeof(RingmailChest),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 10)});
            // Gantelet de broigne
           AddEntry("Gantelet de broigne", 6, typeof(RingmailGloves),
                                            0 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 5 ),
											new RessourceNeed( typeof(BaseCuir), 5)});
            // Jambière de broigne
           AddEntry("Jambière de broigne", 6, typeof(RingmailLegs),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 10)});



            /// BOUCLIER (3)

           AddEntry("Petit bouclier", 9, typeof(Buckler),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Bouclier de bois", 9, typeof(WoodenKiteShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseBois), 6 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Bouclier de bois", 9, typeof(WoodenShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 6 ),
											new RessourceNeed( typeof(BaseBois), 6 ),
											new RessourceNeed( typeof(BaseCuir), 1)});


            AddEntry("Bouclier long", 9, typeof(MetalKiteShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Bouclier lourd", 9, typeof(BronzeShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 10 ),
											new RessourceNeed( typeof(BaseCuir), 1)});

            AddEntry("Bouclier de l'Ordre", 9, typeof(OrderShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 12 ),
											new RessourceNeed( typeof(BaseCuir), 2)});

            AddEntry("Bouclier du Chaos", 9, typeof(ChaosShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 12 ),
											new RessourceNeed( typeof(BaseCuir), 2)});

           AddEntry("Pavois de plate", 9, typeof(HeaterShield),
                                            1 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 12 ),
											new RessourceNeed( typeof(BaseCuir), 2)});


        }

        public ListForge(): base( typeof( CraftForgeSystem ) )
        {
        }
    }
}