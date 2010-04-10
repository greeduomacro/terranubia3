using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ClasseMoine : Classe
    {
        public static int getDamage(int moineNiveau)
        {
            if (moineNiveau <= 0)
                return DndHelper.rollDe(De.trois);
            else if (moineNiveau <= 3)
                return DndHelper.rollDe(De.six);
            else if (moineNiveau <= 7)
                return DndHelper.rollDe(De.huit);
            else if (moineNiveau <= 11)
                return DndHelper.rollDe(De.dix);
            else if (moineNiveau <= 15)
                return DndHelper.rollDe(De.six, 2);
            else if (moineNiveau <= 19)
                return DndHelper.rollDe(De.huit, 2);
            else
                return DndHelper.rollDe(De.dix, 2);
        }

        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.None; } }
        public override int GetDV { get { return 8; } }
        public override int PtComp { get { return 4; } }
        public ClasseMoine() { }


        public override DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][]{
                    new DonEnum[0], //0
                    new DonEnum[]{DonEnum.ScienceDuCombatAMainsNues, DonEnum.DelugeCoup, DonEnum.DonSupClasse}, // 1
                    new DonEnum[]{DonEnum.DonSupClasse, DonEnum.EsquiveTotale}, //2
                    new DonEnum[]{DonEnum.Serenite}, //3
                    new DonEnum[]{DonEnum.FrappeKi}, //4
                    new DonEnum[]{DonEnum.PuretePhysique}, //5
                    new DonEnum[]{DonEnum.DonSupClasse}, //6
                    new DonEnum[]{DonEnum.PlenitudePhysique}, //7
                     new DonEnum[0], //8
                    new DonEnum[]{DonEnum.EsquiveTotale}, //9
                    new DonEnum[]{DonEnum.FrappeKi}, //10
                    new DonEnum[]{DonEnum.DelugeCoup, DonEnum.CorpDiamant }, //11
                    new DonEnum[]{DonEnum.SautAmeliore}, //12
                    new DonEnum[]{DonEnum.AmeDiamant}, //13
                    new DonEnum[0], //13
                    new DonEnum[0], //15
                    new DonEnum[]{DonEnum.FrappeKi}, //16
                    new DonEnum[]{DonEnum.JeunesseEternelle}, //17
                    new DonEnum[0], //18
                    new DonEnum[0], //19
                    new DonEnum[]{DonEnum.PerfectionEtre}, //20*/
                };
            }
        }



        public override ClasseType CType { get { return ClasseType.Moine; } }
       
        public override CompType[] ClasseCompetences
        {
            get
            {
                /*Acrobaties (Dex), Artisanat (Int), 
                 * Concentration (Con), Connaissances (mystères) (Int), 
                 * Connaissances (religion) (Int), Déplacement silencieux (Dex), 
                 * Détection (Sag), Diplomatie (Cha), Discrétion (Dex),
                 * Équilibre (Dex), Escalade (For), Évasion (Dex),
                 * Natation (For), Perception auditive (Sag), 
                 * Profession (Sag), Psychologie (Sag), 
                 * Représentation (Cha) et Saut (For).*/
                return new CompType[]{
                    CompType.Acrobaties,
                    CompType.Concentration,
                    CompType.Erudition,
                    CompType.DeplacementSilencieux,
                    CompType.Detection,
                    CompType.Diplomatie,
                    CompType.Discretion,
                    CompType.Equilibre,
                    CompType.Escalade,
                    CompType.Evasion,
                    CompType.PerceptionAuditive,
                    CompType.Psychologie,
                    CompType.Representation,
                    CompType.Saut
               };
            }
        }
        public int[][] DelugeCoup
        {
            get
            {
                return new int[][] 
                { 
                    new int[] { 0 }, //0
                    new int[] { -2,-2 }, //1
                    new int[] { -1,-1 }, //2
                    new int[] { 0,0 }, //3
                    new int[] { 1,1 }, //4
                    new int[] { 2,2 }, //5
                    new int[] { 3,3 }, //6
                    new int[] { 4,4 }, //7
                    new int[] { 5,5,0 }, //8
                    new int[] { 6,6,1}, //9
                    new int[] { 7,7,2 }, //10
                    new int[] { 8,8,8,3}, //11
                    new int[] { 9,9,9,4}, //12
                    new int[] { 9,9,9,4}, //13
                    new int[] { 10,10,10,5}, //14
                    new int[] {  11,11,11,6,1}, //15
                    new int[] { 12,12,12,7,2 }, //16
                    new int[] { 12,12,12,7,2 }, //17
                    new int[] { 13,13,13,8,3 }, //18
                    new int[] { 14,14,14,9,4}, //19
                    new int[] { 15,15,15,10,5} //20
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
                    12, //20
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
                    12, //20
                };
            }
        }
    }
}