using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public abstract class ClasseArtisan : Classe
    {
        public override NubiaArmorType ArmorAllow { get { return NubiaArmorType.Intermediaire; } }
        public override int GetDV { get { return 4; } }
        public override int PtComp { get { return 8; } }
        public ClasseArtisan() { }

        public override ClasseType CType { get { return ClasseType.ArtisanAlchimiste; } }

       /* public override CompType[] ClasseCompetences
        {
            get
            {
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
        }*/
        public virtual CompType[] CompToLearn
        {
            get
            {
                return new CompType[0];
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
                    new int[] { 1 }, //3
                    new int[] { 2 }, //4
                    new int[] { 2 }, //5
                   
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
                    1, //2
                    1, //3
                    2, //4
                    2, //5
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
                    0, //2
                    1, //3
                    1, //4
                    1, //5
                };
            }
        }
    }
}