using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using System.Reflection;
using System.Collections;

namespace Server.Spells
{
    public class SortEntry
    {
        private BaseSort mSort = null;
        private DateTime mLastCast = DateTime.Now;
        private ClasseType mClasse = ClasseType.Barde;
        private int mCercle = 0;
        public SortEntry(BaseSort sort, ClasseType classe, int cercle)
        {
            mSort = sort;
            mClasse = classe;
            mLastCast = DateTime.Now;
            mCercle = cercle;
        }
        public DateTime LastCast
        {
            get { return mLastCast; }
            set { mLastCast = value; }
        }
        public BaseSort Sort
        {
            get { return mSort; }
        }
        public ClasseType Classe
        {
            get { return mClasse; }
        }
        public int Cercle
        {
            get { return mCercle; }
        }
    }
    public class MagieList
    {
        private NubiaPlayer mOwner = null;
        private ClasseType mClasse = ClasseType.Barde;
        private DndStat mMagicStat = DndStat.Charisme;
        private bool mInstinctMagic = true;

        private List<SortEntry> mSorts = new List<SortEntry>();
        private Dictionary<int, int> mCastNumber = new Dictionary<int, int>(); //sort déjà utilisé par cercle
        private int[] mSortAllow = new int[0];

        public bool Cast(Type sortType)
        {
            return false;
        }

        public bool canCast(Type sortType)
        {
            if (mInstinctMagic)
            {
                SortEntry sort = null;
                foreach( SortEntry s in mSorts )
                {
                    if( s.GetType().Equals(sortType) )
                        sort = s;
                }
                if( sort == null )
                    return false;
                if (mCastNumber.ContainsKey(sort.Cercle) && mSortAllow.Length > sort.Cercle)
                {
                    if (mCastNumber[sort.Cercle] > mSortAllow[sort.Cercle - 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void MakeInstinctList()
        {
            mCastNumber = new Dictionary<int, int>();
            for (int i = 0; i <= 9; i++)
                mCastNumber.Add(i, 0);
            foreach (Classe cl in mOwner.GetClasses())
            {
                if (cl == null)
                    continue;

                if (cl.MagieAllow.Length > cl.Niveau)
                {
                    mSortAllow = cl.MagieAllow[cl.Niveau];
                }
                /*
                 * Sorts d'instinct
                 * */
                if (cl.CType == mClasse)
                {
                    mMagicStat = cl.MagieStat;
                    mInstinctMagic = cl.InstinctiveMagie;

                    mSorts = new List<SortEntry>();
                    for (int c = 0; c < cl.SortAllow.Length; c++)
                    {
                        for (int s = 0; s < cl.SortAllow[c].Length; s++)
                        {
                            BaseSort sort = null;
                            Type stype = cl.SortAllow[c][s];
                            ConstructorInfo ctor = stype.GetConstructor(Type.EmptyTypes);
                            if (ctor != null)
                            {
                                sort = ctor.Invoke(new object[] { null }) as BaseSort;
                                SortEntry entry = new SortEntry(sort, cl.CType, c);
                                mSorts.Add(entry);
                            }
                        }
                    }
                }
            }
        }
    }
}
