using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class ClasseBarbare : Classe
    {
        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.Intermediaire; } }
        public override ArmeCategorie ArmeAllow {get { return ArmeCategorie.Guerre; } }
        public override BouclierType BouclierAllow{ get { return  BouclierType.GrandEcu; } }


        public override int GetDV { get { return 12; } }
        public override int PtComp { get { return 4; } }
        public ClasseBarbare() { }

        public override ClasseType CType { get { return ClasseType.Barbare; } }


        public override DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][]{
                    new DonEnum[0], //0
                    new DonEnum[]{DonEnum.RageBerserker}, // 1
                    new DonEnum[]{DonEnum.EsquiveInstinctive}, //2
                    new DonEnum[]{DonEnum.SensPieges}, //3
                    new DonEnum[]{DonEnum.RageBerserker}, //4
                    new DonEnum[]{DonEnum.EsquiveInstinctive}, //5
                    new DonEnum[]{DonEnum.SensPieges}, //6
                    new DonEnum[]{DonEnum.ReductionDegat}, //7
                    new DonEnum[]{DonEnum.RageBerserker}, //8
                    new DonEnum[]{DonEnum.SensPieges}, //9
                    new DonEnum[]{DonEnum.ReductionDegat}, //10
                    new DonEnum[]{DonEnum.RageGrandBerserker}, //11
                    new DonEnum[]{DonEnum.RageBerserker, DonEnum.SensPieges}, //12
                    new DonEnum[]{DonEnum.ReductionDegat}, //13
                    new DonEnum[]{DonEnum.VolonteIndomptable}, //13
                    new DonEnum[]{DonEnum.SensPieges}, //15
                    new DonEnum[]{DonEnum.RageBerserker, DonEnum.ReductionDegat}, //16
                    new DonEnum[]{DonEnum.RageSansFatigue}, //17
                    new DonEnum[]{DonEnum.SensPieges}, //18
                    new DonEnum[]{DonEnum.ReductionDegat}, //19
                    new DonEnum[]{DonEnum.RageBerserker, DonEnum.RageMaitreBerserker}, //20
                };
            }
        }
         /*public override DonEnum[] getCustomDon(NubiaPlayer p, int niveau)
        {
            List<DonEnum> list = new List<DonEnum>();

            if (niveau == 1)
            {
               // Console.WriteLine("DOn niveau 1 guerrier... Scan");
                for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
                {
                    
                    if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString().ToLower() ))
                    {
                        BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString().ToLower()];
                       // Console.WriteLine("Trouvé: "+don.ToString() );
                        if (don.hasConditions(p))
                            list.Add(don.DType);
                    }
                }
            }
            else
            {
                for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
                {
                    if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString().ToLower()))
                    {
                        BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString().ToLower()];
                        if (don.hasConditions(p) && don.WarriorDon )
                            list.Add(don.DType);
                    }
                }
            }
            return list.ToArray();
        }*/

        public override CompType[] ClasseCompetences
        {
            get
            {
                /*Les compétences du barbare 
                 * (et la caractéristique dont dépend chacune) sont : 
                 * Artisanat (Int), Dressage (Cha),
                 * Équitation (Dex), Escalade (For), 
                 * Intimidation (Cha), Natation (For),
                 * Perception auditive (Sag), Saut (For)
                 * et Survie (Sag).*/
                return new CompType[]{
                    CompType.Dressage,
                    CompType.Equitation,
                    CompType.Escalade,
                    CompType.Intimidation,
                    CompType.PerceptionAuditive,
                    CompType.Saut,
                    CompType.Survie
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
                    new int[] { 1 }, //1
                    new int[] { 2 }, //2
                    new int[] { 3 }, //3
                    new int[] { 4 }, //4
                    new int[] { 5 }, //5
                    new int[] { 6,1 }, //6
                    new int[] { 7,2 }, //7
                    new int[] { 8,3 }, //8
                    new int[] { 9,4 }, //9
                    new int[] { 10,5 }, //10
                    new int[] { 11,6,1 }, //11
                    new int[] { 12,7,2 }, //12
                    new int[] { 13,8,3 }, //13
                    new int[] { 14,9,4 }, //14
                    new int[] { 15,10,5 }, //15
                    new int[] { 16,11,6,1 }, //16
                    new int[] { 17,12,7,2 }, //17
                    new int[] { 18,13,8,3 }, //18
                    new int[] { 19,14,9,4 }, //19
                    new int[] { 20,15,10,5 } //20
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
                    0, //1
                    1, //2
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
    }
}