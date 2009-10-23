using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
namespace Server
{
    public class ClasseBarde : Classe
    {
        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.Legere; } }
        public override ArmeCategorie ArmeAllow { get { return ArmeCategorie.Courante; } }
        public override BouclierType BouclierAllow { get { return BouclierType.GrandEcu; } }

        public override int GetDV { get { return 6; } }
        public override int PtComp { get { return 6; } }
        public ClasseBarde() { }

        public override ClasseType CType { get { return ClasseType.Barde; } }

        public override DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][]{
                    new DonEnum[0], //0
                    new DonEnum[]{DonEnum.ContreChant, DonEnum.InspirationVaillante}, // 1
                    new DonEnum[0], //2
                    new DonEnum[]{DonEnum.InspirationTalent}, //3
                    new DonEnum[0], //4
                    new DonEnum[0], //5
                    new DonEnum[0], //6
                    new DonEnum[0], //7
                    new DonEnum[]{DonEnum.InspirationVaillante}, //8
                    new DonEnum[]{DonEnum.InspirationHero}, //9
                    new DonEnum[0], //10
                    new DonEnum[0], //11
                    new DonEnum[]{DonEnum.ChantLiberte}, //12
                    new DonEnum[0], //13
                    new DonEnum[]{DonEnum.InspirationVaillante}, //14
                    new DonEnum[]{DonEnum.InspirationIntrepide}, //15
                    new DonEnum[0], //16
                    new DonEnum[0], //17
                    new DonEnum[0], //18
                    new DonEnum[0], //19
                    new DonEnum[]{DonEnum.InspirationVaillante}, //20*/
                };
            }
        }

        #region Magie !
        public override bool InstinctiveMagie { get { return true; } }
        public override MageType Mage { get { return MageType.Hybrid; } }
        public virtual DndStat MagieStat { get { return DndStat.Charisme; } }
        public override Type[][] SortAllow
        {
            get
            {
                return new Type[][]{
                    /* Cercle 0 */ 
                    new Type[]{ typeof(SortBerceuse), typeof(SortHebetement) , 
                        typeof(SortLumiere), typeof(SortManipDistance), typeof(SortResistance) },
                        /* Cercle 1 */
                        new Type[]{ typeof(SortSoinLeger), typeof(SortSommeil) }
                };
            }
        }
        public override int[][] MagieAllow
        {
            get
            {
                return new int[][] { 
                    new int[0], //0
                    new int[]{2}, //1
                    new int[]{3,0},  //2
                    new int[]{3,1}, //3
                    new int[]{3,2,0}, //4
                    new int[]{3,3,1}, //5
                    new int[]{3,3,2}, //6
                    new int[]{3,3,2,0}, //7
                    new int[]{3,3,3,1}, //8
                    new int[]{3,3,3,2}, //9
                    new int[]{3,3,3,2,0}, //10
                    new int[]{3,3,3,2,1}, //11
                    new int[]{3,3,3,3,2}, //12
                    new int[]{3,3,3,3,2,0}, //13
                    new int[]{4,3,3,3,3,1}, //14
                    new int[]{4,4,4,3,3,2}, //15
                    new int[]{4,4,4,3,3,2,0}, //16
                    new int[]{4,4,4,4,3,3,1}, //17
                    new int[]{4,4,4,4,4,3,2}, //18
                    new int[]{4,4,4,4,4,4,3}, //19
                    new int[]{4,4,4,4,4,4,4}, //20
                };
            }
        }
        #endregion

        public override CompType[] ClasseCompetences
        {
            get
            {
                /*Acrobaties (Dex), Art de la magie (Int),
                 * Artisanat (Int), Bluff (Cha), 
                 * Concentration (Con), Erudition (Int), 
                 * Décryptage (Int), Déguisement (Cha), 
                 * Déplacement silencieux (Dex), 
                 * Diplomatie (Cha), Discrétion (Dex), 
                 * Équilibre (Dex), Escalade (For), 
                 * Escamotage (Dex), Estimation (Int), 
                 * Évasion (Dex), Langue (aucune), 
                 * Perception auditive (Sag), Profession (Sag), 
                 * Psychologie (Sag), Renseignements (Cha), 
                 * Représentation (Cha), Saut (For) 
                 * et Utilisation d’objets magiques (Cha).*/
                return new CompType[]{
                    CompType.Acrobaties,
                    CompType.ArtMagie,
                    CompType.Bluff,
                    CompType.Concentration,
                    CompType.Erudition,
                    //CompType.Decryptage,
                    CompType.Deguisement,
                    CompType.DeplacementSilencieux,
                    CompType.Diplomatie,
                    CompType.Discretion,
                    CompType.Equilibre,
                    CompType.Escalade,
                    CompType.Escamotage,
                    CompType.Estimation,
                    CompType.Evasion,
                    CompType.PerceptionAuditive,
                    CompType.Psychologie,
                    CompType.Renseignements,
                    CompType.Representation,
                    CompType.Saut,
                    CompType.UtilisationObjetsMagiques
               };
            }
        }

        public override int[][] BonusAttaque
        {
            get
            {
                return new int[][] 
                { 
                    new int[] { 0 }, //0
                    new int[] { 0 }, //1
                    new int[] { 1 }, //2
                    new int[] { 2 }, //3
                    new int[] { 3 }, //4
                    new int[] { 3 }, //5
                    new int[] { 4 }, //6
                    new int[] { 5 }, //7
                    new int[] { 6,1 }, //8
                    new int[] { 6,1 }, //9
                    new int[] { 7,2 }, //10
                    new int[] { 8,3 }, //11
                    new int[] { 9,4 }, //12
                    new int[] { 9,4 }, //13
                    new int[] { 10,5 }, //14
                    new int[] { 11,6,1 }, //15
                    new int[] { 12,7,2 }, //16
                    new int[] { 12,7,2 }, //17
                    new int[] { 13,8,3 }, //18
                    new int[] { 14,9,4 }, //19
                    new int[] { 15,10,5 } //20
                };
            }
        }

        public override int[] BonusReflexe
        {
            get
            {
                return new int[]
                {
                    0, //0
                    2, //1
                    3, //2
                    3, //3
                    4, //4
                    4, //5
                    5, //6
                    5, //7
                    6, //8
                    6, //9
                    7, //10
                    7, //11
                    8, //12
                    8, //13
                    9, //14
                    9, //15
                    10, //16
                    10, //17
                    11, //18
                    11, //19
                    12 //20
                };
            }
        }

        public override int[] BonusVigueur
        {
            get
            {
                return new int[]
                {
                    0, //0
                    0, //1
                    0, //2
                    1, //3
                    1, //4
                    1, //5
                    2, //6
                    2, //7
                    2, //8
                    3, //9
                    3, //10
                    3, //11
                    4, //12
                    4, //13
                    4, //14
                    5, //15
                    5, //16
                    5, //17
                    6, //18
                    6, //19
                    6 //20
                };
            }
        }

        public override int[] BonusVolonte
        {
            get
            {
                return new int[]
                {
                    0, //0
                    2, //1
                    3, //2
                    3, //3
                    4, //4
                    4, //5
                    5, //6
                    5, //7
                    6, //8
                    6, //9
                    7, //10
                    7, //11
                    8, //12
                    8, //13
                    9, //14
                    9, //15
                    10, //16
                    10, //17
                    11, //18
                    11, //19
                    12 //20
                };
            }
        }
    }
}