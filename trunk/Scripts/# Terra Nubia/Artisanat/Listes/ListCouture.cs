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
    class ListCouture : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Chandails", // 0
                    "Pantalons et jupes", // 1
                    "Chapeaux", // 2
                    "Bottes", // 3
                    "Capes", // 4
                    "Robes et toges", // 5
                    "Accessoires", // 6
                    
                    "Armures de cuir", // 7
                    "Armures de cuir clouté", // 8
                    "Armures d'os", // 9
                };
            }
        }

        public override void ConstructList()
        {
            //Armure de cuir
            AddEntry("Brassards de cuir", 7, typeof(LeatherArms), 3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseCuir), 6)});

            AddEntry("Gants de cuir", 7, typeof(LeatherGloves), 3 /*Min value pour crafter*/, 10 /*Difficulte*/,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseCuir), 4)});

            AddEntry("Gorget de cuir", 7, typeof(LeatherGorget), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseCuir), 4)});

            AddEntry("Jambières de cuir", 7, typeof(LeatherLegs), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseCuir), 10)});

            AddEntry("Torse de cuir", 7, typeof(LeatherChest), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 1),
											new RessourceNeed( typeof(BaseCuir), 15)});


            //Armure de cuir clouté
            AddEntry("Brassards de cuir clouté", 8, typeof(StuddedArms), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 3),
											new RessourceNeed( typeof(BaseCuir), 6)});

            AddEntry("Gants de cuir clouté", 8, typeof(StuddedGloves), 4, 10,
                                new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2),
											new RessourceNeed( typeof(BaseCuir), 4)});

            AddEntry("Gorget de cuir clouté", 8, typeof(StuddedGorget), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 2),
											new RessourceNeed( typeof(BaseCuir), 4)});

            AddEntry("Jambières de cuir clouté", 8, typeof(StuddedLegs), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 5),
											new RessourceNeed( typeof(BaseCuir), 10)});

            AddEntry("Torse de cuir clouté", 8, typeof(StuddedChest), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseMetal), 8),
											new RessourceNeed( typeof(BaseCuir), 15)});


            //Armure d'os
            AddEntry("Brassards d'os", 9, typeof(BoneArms), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseOs), 6),
											new RessourceNeed( typeof(BaseCuir), 3)});

            AddEntry("Gants d'os", 9, typeof(BoneGloves), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseOs), 4),
											new RessourceNeed( typeof(BaseCuir), 2)});

            AddEntry("Jambières d'os", 9, typeof(BoneLegs), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseOs), 10),
											new RessourceNeed( typeof(BaseCuir), 5)});

            AddEntry("Torse d'os", 9, typeof(BoneChest), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseOs), 15),
											new RessourceNeed( typeof(BaseCuir), 8)});


            //Chapeaux

            AddEntry("Bandeau", 2, typeof(Bandana), 0, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 1)});

            AddEntry("Bandeau de pirate", 2, typeof(SkullCap), 1, 10,
                                          new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 2)});

    /*        AddEntry("Kasa", 2, typeof(Kasa), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 4)});

            AddEntry("Bandeau de fleurs", 2, typeof(FlowerGarland), 3, 10,  
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 2)});
*/
            AddEntry("Chapeau de pêcheur", 2, typeof(FloppyHat), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 6)});
          
            AddEntry("Casquette", 2, typeof(Cap), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

            AddEntry("Chapeau de paille", 2, typeof(StrawHat), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Bonnet", 2, typeof(Bonnet), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

            AddEntry("Chapeau à large bords", 2, typeof(WideBrimHat), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Chapeau à pointe", 2, typeof(TallStrawHat), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 7)});

            AddEntry("Chapeau à plume", 2, typeof(FeatheredHat), 5, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed( typeof(Feather), 1),
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Chapeau de bouffon", 2, typeof(JesterHat), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 6)});

            AddEntry("Tricorne", 2, typeof(TricorneHat), 7, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Chapeau de magicien", 2, typeof(WizardsHat), 8, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 7)});

     /*       AddEntry("Masque de Ninja", 2, typeof(ClothNinjaHood), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});
*/
            AddEntry("Masque de sauvage", 2, typeof(SavageMask), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Masque tribal à cornes", 2, typeof(HornedTribalMask), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 5)});

            AddEntry("Masque tribal", 2, typeof(TribalMask), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

            AddEntry("Masque d'ours", 2, typeof(BearMask), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            AddEntry("Masque de chevreuil", 2, typeof(DeerMask), 7, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            AddEntry("Capuche de rodeur", 2, typeof(TNCapucheRodeur), 8, 15,
                                           new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Capuche pelerine", 2, typeof(TNCapuche), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});


       /*     AddEntry("Masque d'orc", 2, typeof(OrcishKinMask), 8, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 5)});
*/

            // Capes
            AddEntry("Cape", 4, typeof(Cloak), 2 , 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

       /*     AddEntry("Cape de fourrure", 4, typeof(FurCape), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 10)});
*/

            //Bottes
            AddEntry("Chaussures", 3, typeof(Shoes), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 3)});
            
            AddEntry("Sandales", 3, typeof(Sandals), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 2)});

            AddEntry("Bottes", 3, typeof(Boots), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 5)});

            AddEntry("Bottes longues", 3, typeof(ThighBoots), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            AddEntry("Sandales", 3, typeof(TNNinjaSandals), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            AddEntry("Sandales", 3, typeof(TNNinjaSandals2), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            AddEntry("Sandales", 3, typeof(TNNinjaBoots), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 8)});

            /*AddEntry("Bottes elfiques", 3, typeof(ElvenBoots), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 5)});*/
/*
            AddEntry("Bottes de fourrure", 3, typeof(FurBoots), 7, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseCuir), 5)});
*/

            //Pantalons et jupes
            AddEntry("Pantalons courts", 1, typeof(ShortPants), 0, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 4)});

            AddEntry("Pantalons longs", 1, typeof(LongPants), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8)});

            /*AddEntry("Pantalons elfiques", 1, typeof(ElvenPants), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8)});*/
/*
            AddEntry("Tattsuke Hakama", 1, typeof(TattsukeHakama), 8, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed( typeof(BaseCuir), 5),
											new RessourceNeed( typeof(BaseTissu), 5)});
*/
            AddEntry("Jupe", 1, typeof(Skirt), 0, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Kilt", 1, typeof(Kilt), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

       /*     AddEntry("Hakama", 1, typeof(Hakama), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8)});

*/
            //Hauts de vetements
            AddEntry("Guenilles", 5, typeof(TNGuenilles), 0, 10,
                                      new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 4)});


            AddEntry("Chemise", 0, typeof(Shirt), 1, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8)});

            AddEntry("Chemise longue", 0, typeof(FancyShirt), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8)});

            AddEntry("Costume de bouffon", 0, typeof(JesterSuit), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Pourpoint", 0, typeof(Doublet), 4, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 6)});

            AddEntry("Tunique", 0, typeof(Tunic), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Surcot", 0, typeof(Surcoat), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 12)});

    /*        AddEntry("Hakama-Shita", 0, typeof(HakamaShita), 5, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed( typeof(BaseCuir), 6),
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Jin-Baori", 0, typeof(JinBaori), 7, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed( typeof(BaseCuir), 2),
											new RessourceNeed( typeof(BaseTissu), 6)});
*/
            /*AddEntry("Chandail elfique", 0, typeof(ElvenShirt), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});*/

      /*      AddEntry("Veste de ninja", 0, typeof(ClothNinjaJacket), 8, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 12)});

            AddEntry("Veste de cérémonie", 0, typeof(FormalShirt), 8, 10,
                                            new RessourceNeed[]{
										    new RessourceNeed( typeof(BaseTissu), 15)});
*/

            // Robes et toges

            AddEntry("Toge", 5, typeof(Robe), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 15)});

            AddEntry("Robe", 5, typeof(PlainDress), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Robe de qualité", 5, typeof(FancyDress), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 12)});

            AddEntry("Veste", 5, typeof(TNVeste), 8, 15,
                                          new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Tunic épaisse", 5, typeof(TNNinjaTunic), 8, 15,
                                          new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Pelerine", 5, typeof(TNPelerine), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});


            AddEntry("Belle robe", 5, typeof(TNRobe1), 10, 15,
                                      new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe2), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe3), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe4), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe5), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe6), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});


            AddEntry("Belle robe", 5, typeof(TNRobe7), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});


            AddEntry("Belle robe", 5, typeof(TNRobe8), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe9), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});

            AddEntry("Belle robe", 5, typeof(TNRobe10), 10, 15,
                                     new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 10)});
     /*       AddEntry("Robe de soirée", 5, typeof(GildedDress), 7, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 15)});
*/
            /*AddEntry("Toge elfique pour homme", 5, typeof(MaleElvenRobe), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 15)});*/

            /*AddEntry("Toge elfique pour femme", 5, typeof(FemaleElvenRobe), 6, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 15)});*/

     /*       AddEntry("Kamishimo", 5, typeof(Kamishimo), 8, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 17)});
*/
      /*      AddEntry("Kimono pour homme", 5, typeof(MaleKimono), 9, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 20)});

            AddEntry("Kimono pour femme", 5, typeof(FemaleKimono), 9, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 18)});
            */

            //Accessoires
            AddEntry("Ceinture de corps", 6, typeof(BodySash), 0, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 2)});

            AddEntry("Tablier court", 6, typeof(HalfApron), 2, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 4)});

            AddEntry("Tablier long", 6, typeof(FullApron), 3, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 7)});


            AddEntry("Ceinturon", 6, typeof(TNCeinture1), 8, 15,
                                           new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Ceinturon", 6, typeof(TNCeinture2), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});
            AddEntry("Ceinturon", 6, typeof(TNCeinture3), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});
            AddEntry("Ceinturon", 6, typeof(TNCeinture4), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});
            AddEntry("Ceinturon", 6, typeof(TNCeinture5), 8, 15,
                                         new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 5)});

            AddEntry("Epaulettes", 6, typeof(TNNinjaArms), 8, 15,
                                        new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8),
                                        new RessourceNeed( typeof(BaseCuir), 2)});

            AddEntry("Gants", 6, typeof(TNNinjaGlove), 8, 15,
                                       new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 8),
                                        new RessourceNeed( typeof(BaseCuir), 2)});

            AddEntry("Cache visage", 6, typeof(TNNinjaCache), 8, 15,
                                        new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

            AddEntry("Brassard", 6, typeof(TNNinjaBrassard), 8, 15,
                                       new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 3)});

     /*       AddEntry("Tablier de fourrure", 6, typeof(FullApron), 5, 10,
                                            new RessourceNeed[]{
											new RessourceNeed( typeof(BaseTissu), 6)});
*/
            AddEntry("Bourse", 6, typeof(Pouch), 5, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed(typeof(BaseCuir), 2)});
            AddEntry("Sac", 6, typeof(Bag), 5, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed(typeof(BaseCuir), 3)});
            AddEntry("Sac à dos", 6, typeof(Backpack), 5, 10,
                                            new RessourceNeed[]{
                                            new RessourceNeed(typeof(BaseCuir), 5)});
        }
        public ListCouture(): base( typeof( CraftCoutureSystem ) ) //FIXME
        {
        }
    }
}
