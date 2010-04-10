using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server
{
    public class ClasseMage : Classe
    {
        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.None; } }
        public override int GetDV { get { return 4; } }
        public override int PtComp { get { return 2; } }
        public ClasseMage() { }

        public override ClasseType CType { get { return ClasseType.Mage; } }

        public override CompType[] ClasseCompetences
        {
            get
            {
                /*Art de la magie (Int), Artisanat (Int), 
                 * Concentration (Con), Connaissances  (Int), 
                 * Décryptage  (Int) et Profession (Sag).*/
                return new CompType[]{
                    CompType.ArtMagie,
                    CompType.Concentration,
                    CompType.Erudition,
                    CompType.Detection,
                    CompType.Diplomatie,
                    CompType.Dressage,
                    CompType.Equitation,
                    CompType.Survie
               };
            }
        }

        public override DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][]{
                    new DonEnum[0], //0
                    new DonEnum[]{DonEnum.DonSupClasse}, // 1
                    new DonEnum[0], //2
                    new DonEnum[0], //3
                    new DonEnum[0], //4
                    new DonEnum[]{DonEnum.DonSupClasse}, //5
                    new DonEnum[0], //6
                    new DonEnum[0], //7
                    new DonEnum[0], //8
                    new DonEnum[0], //9
                    new DonEnum[]{DonEnum.DonSupClasse}, //10
                    new DonEnum[0], //11
                    new DonEnum[0], //12
                    new DonEnum[0], //13
                    new DonEnum[0], //14
                    new DonEnum[]{DonEnum.DonSupClasse}, //15
                    new DonEnum[0], //16
                    new DonEnum[0], //17
                    new DonEnum[0], //18
                    new DonEnum[0], //19
                    new DonEnum[]{DonEnum.DonSupClasse}, //20*/
                };
            }
        }

        public override DonEnum[] getCustomDon(NubiaPlayer p, int niveau)
        {
            List<DonEnum> list = new List<DonEnum>();

            if (niveau == 1)
            {
                return new DonEnum[] { DonEnum.MageIntel, DonEnum.MageSagesse, DonEnum.MageCharisme };
            }
            else
            {
                for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
                {
                    if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString()))
                    {
                        BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString()];
                        if (don.hasConditions(p) )
                            list.Add(don.DType);
                    }
                }
            }
            return list.ToArray();
        }

        #region Magie !
        public override MageType Mage { get { return MageType.Pur; } }
        public override DndStat MagieStat { get { return DndStat.Intelligence; } }

        public override int PtsApprentissage { get { return 5; } }
        public override int PtsCreation { get { return 2; } }
        public override int getLevelSort(int niveau)
        {
            int l = (int)(Math.Log(niveau,20) * 100);
            return l;
        }


        public virtual int[][] MagieAllow
        {
            get
            {
                // int[]{ 1, 2, 3 }; 1 = pts apprentissage, 2 pts creation, 3 level autorisé
                // c'est un total a chaque fois, non un cumulatif
                return new int[][]{
                    new int[]{0,0,0}, //0
                    new int[]{0,0,0}, //1
                    new int[]{0,0,0}, //2
                    new int[]{0,0,0}, //3
                    new int[]{0,0,0}, //4
                    new int[]{0,0,0}, //5
                    new int[]{0,0,0}, //6
                    new int[]{0,0,0}, //7
                    new int[]{0,0,0}, //8
                    new int[]{0,0,0}, //9
                    new int[]{0,0,0}, //10
                    new int[]{0,0,0}, //11
                    new int[]{0,0,0}, //12
                    new int[]{0,0,0}, //13
                    new int[]{0,0,0}, //14
                    new int[]{0,0,0}, //15
                    new int[]{0,0,0}, //16
                    new int[]{0,0,0}, //17
                    new int[]{0,0,0}, //18
                    new int[]{0,0,0}, //19
                    new int[]{0,0,20}, //20
                };
                /****
                 * 
                 * 
                 * **/
            }
        }
        /*
        public override int[][] MagieAllow
        {
            get
            {
                return new int[][] { 
                    new int[0], //0
                    new int[]{3,1}, //1
                    new int[]{4,2},  //2
                    new int[]{4,2,1}, //3
                    new int[]{4,3,2}, //4
                    new int[]{4,3,2,1}, //5
                    new int[]{4,3,3,2}, //6
                    new int[]{4,4,3,2,1}, //7
                    new int[]{4,4,3,3,2}, //8
                    new int[]{4,4,4,3,2,1}, //9
                    new int[]{4,4,4,3,3,2}, //10
                    new int[]{4,4,4,4,3,2,1}, //11
                    new int[]{4,4,4,4,3,3,2}, //12
                    new int[]{4,4,4,4,4,3,2,1}, //13
                    new int[]{4,4,4,4,4,3,3,2}, //14
                    new int[]{4,4,4,4,4,4,3,2,1}, //15
                    new int[]{4,4,4,4,4,4,3,3,2}, //16
                    new int[]{4,4,4,4,4,4,4,3,2,1}, //17
                    new int[]{4,4,4,4,4,4,4,3,3,2}, //18
                    new int[]{4,4,4,4,4,4,4,4,3,3}, //19
                    new int[]{4,4,4,4,4,4,4,3,4,4}, //20
                };
            }
        }*/
        #endregion

        public override int[][] BonusAttaque
        {
            get
            {
                return new int[][] 
                { 
                    new int[] { 0 }, //0
                    new int[] { 0 }, //1
                    new int[] { 1 }, //2
                    new int[] { 1 }, //3
                    new int[] { 2 }, //4
                    new int[] { 2 }, //5
                    new int[] { 3 }, //6
                    new int[] { 3 }, //7
                    new int[] { 4 }, //8
                    new int[] { 4 }, //9
                    new int[] { 5 }, //10
                    new int[] { 5 }, //11
                    new int[] { 6,1 }, //12
                    new int[] { 6,1 }, //13
                    new int[] { 7,2 }, //14
                    new int[] { 7,2 }, //15
                    new int[] { 8,3 }, //16
                    new int[] { 8,3 }, //17
                    new int[] { 9,4 }, //18
                    new int[] { 9,4 }, //19
                    new int[] { 10,5 } //20
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
                    12, //20
                };
            }
        }
    }
}