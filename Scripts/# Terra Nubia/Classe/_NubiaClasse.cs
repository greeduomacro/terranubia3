using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server
{
    public enum ClasseType
    {
        None = -1,
        Barbare = 0,
        Barde,
        Guerrier,
        Mage,
        Moine,
        Rodeur,
        Roublard,
        //Artisana
        ArtisanSoigneur,
        ArtisanCouturier,
        ArtisanForgeron,
        ArtisanIngenieur,
        ArtisanEbeniste,
        ArtisanAlchimiste,
        ArtisanPaysan,

        Maximum //pour comptage
    }
    public enum MageType
    {
        None,
        Pur,
        Hybrid
    }
    public abstract class Classe
    {
        public virtual int GetDV { get { return 4; } }
        public virtual int PtComp { get { return 2; } } //x pts par niveau (d'achat)
        public virtual NubiaArmorType ArmorAllow { get { return NubiaArmorType.None; } }
        public virtual BouclierType BouclierAllow { get { return BouclierType.None; } }
        public virtual ArmeCategorie ArmeAllow { get { return ArmeCategorie.Courante; } }

        #region Magie !
        public virtual MageType Mage { get { return MageType.None; } }
        public virtual DndStat MagieStat { get { return DndStat.Intelligence; } }

        public virtual int PtsApprentissage { get { return 0; } }
        public virtual int PtsCreation { get { return 0; } }
        public virtual int getLevelSort(int niveau)
        {
            return 0;
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
                    new int[]{0,0,0}, //20
                };
            }
        }

        #endregion

        public virtual DonEnum[][] DonClasse
        {
            get
            {
                return new DonEnum[][] { new DonEnum[0] };
            }
        }
        public virtual DonEnum[] getCustomDon(NubiaPlayer p, int niveau)
        {
            List<DonEnum> list = new List<DonEnum>();
            for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
            {
                //     Console.WriteLine("Don de custom: " + (DonEnum)d);
                if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString().ToLower()))
                {
                    BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString().ToLower()];
                    //     Console.WriteLine("Don de la bank: " + don.ToString());
                    if (don.hasConditions(p))
                        list.Add(don.DType);
                }
            }
            return list.ToArray();
        }

        public static string GetNameClasse(ClasseType ct)
        {
            switch (ct)
            {
                case ClasseType.Barbare: return "Barbare";
                case ClasseType.Barde: return "Barde";
                case ClasseType.Guerrier: return "Guerrier";
                case ClasseType.Mage: return "Mage";
                case ClasseType.Moine: return "Moine";
                case ClasseType.ArtisanSoigneur: return "Artisan: Soigneur";
                case ClasseType.Rodeur: return "Rôdeur";
                case ClasseType.Roublard: return "Roublard";
                case ClasseType.ArtisanAlchimiste: return "Artisan: Alchimiste";
                case ClasseType.ArtisanCouturier: return "Artisan: Couturier";
                case ClasseType.ArtisanEbeniste: return "Artisan: Ebeniste";
                case ClasseType.ArtisanForgeron: return "Artisan: Forgeron";
                case ClasseType.ArtisanIngenieur: return "Artisan: Ingenieur";
                case ClasseType.ArtisanPaysan: return "Artisan: Paysan";
            }
            return "Classe: Inconnu";
        }

        public static Type GetClasse(ClasseType ct)
        {
            //Console.WriteLine("GetClasse dans Classe: "+ct);
            Type type = typeof(ClasseGuerrier);
            switch (ct)
            {
                case ClasseType.Barbare: type = typeof(ClasseBarbare); break;
                case ClasseType.Barde: type = typeof(ClasseBarde); break;
                case ClasseType.Guerrier: type = typeof(ClasseGuerrier); break;
                case ClasseType.Mage: type = typeof(ClasseMage); break;
                case ClasseType.Moine: type = typeof(ClasseMoine); break;
                case ClasseType.ArtisanSoigneur: type = typeof(ArtisanSoigneur); break;
                case ClasseType.Rodeur: type = typeof(ClasseRodeur); break;
                case ClasseType.Roublard: type = typeof(ClasseRoublard); break;
                case ClasseType.ArtisanAlchimiste: type = typeof(ArtisanAlchimiste); break;
                case ClasseType.ArtisanCouturier: type = typeof(ArtisanCouturier); break;
                case ClasseType.ArtisanEbeniste: type = typeof(ArtisanEbeniste); break;
                case ClasseType.ArtisanForgeron: type = typeof(ArtisanForgeron); break;
                case ClasseType.ArtisanIngenieur: type = typeof(ArtisanIngenieur); break;
                case ClasseType.ArtisanPaysan: type = typeof(ArtisanPaysan); break;
            }
            return type;
        }
        public virtual ClasseType CType { get { return ClasseType.Guerrier; } }

        private int m_niveau = 0;
        public int Niveau { get { return m_niveau; } set { m_niveau = value; } }

        public virtual CompType[] ClasseCompetences
        {
            get
            {
                return new CompType[] { CompType.Acrobaties };
            }
        }

        public bool isComptenceClasse(CompType c)
        {
            bool isit = false;
            for (int i = 0; i < ClasseCompetences.Length; i++)
            {
                if (c == ClasseCompetences[i])
                {
                    isit = true;
                    break;
                }
            }
            return isit;
        }

        public virtual int[][] BonusAttaque
        {
            get
            {
                return new int[][] { new int[] { 0 } };
            }
        }

        public virtual int[] BonusReflexe
        {
            get
            {
                return new int[] { 0 };
            }
        }

        public virtual int[] BonusVigueur
        {
            get
            {
                return new int[] { 0 };
            }
        }

        public virtual int[] BonusVolonte
        {
            get
            {
                return new int[] { 0 };
            }
        }

        public Classe()
        {
        }
    }
}