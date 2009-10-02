using System;
using System.Collections;
using System.Reflection;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server
{
    public enum ClasseType
    {
        Barbare,
        Barde,
        Druide,
        Ensorceleur,
        Guerrier,
        Magicien,
        Moine,
        Paladin,
        Pretre,
        Rodeur,
        Roublard,
        Artisan,

        Maximum //pour comptage
    }
    public abstract class Classe
    {
        public virtual int GetDV { get { return 4; } }
        public virtual int PtComp { get { return 2; } } //x pts par niveau (d'achat)
        public virtual NubiaArmorType ArmorAllow { get { return NubiaArmorType.None; } }
        public static Type GetClasse(ClasseType ct)
        {
            //Console.WriteLine("GetClasse dans Classe: "+ct);
            Type type = typeof(ClasseGuerrier);
            switch (ct)
            {
                case ClasseType.Barbare: type = typeof(ClasseBarbare); break;
                case ClasseType.Barde: type = typeof(ClasseBarde); break;
                case ClasseType.Druide: type = typeof(ClasseDruide); break;
                case ClasseType.Ensorceleur: type = typeof(ClasseEnsorceleur); break;
                case ClasseType.Guerrier: type = typeof(ClasseGuerrier); break;
                case ClasseType.Magicien: type = typeof(ClasseMagicien); break;
                case ClasseType.Moine: type = typeof(ClasseMoine); break;
                case ClasseType.Paladin: type = typeof(ClassePaladin); break;
                case ClasseType.Pretre: type = typeof(ClassePretre); break;
                case ClasseType.Rodeur: type = typeof(ClasseRodeur); break;
                case ClasseType.Roublard: type = typeof(ClasseRoublard); break;
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