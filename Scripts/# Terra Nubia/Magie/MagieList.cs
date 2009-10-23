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
        private bool mInstinctMagic = false;

        private List<SortEntry> mSorts = new List<SortEntry>();
        private Dictionary<int, int> mCastNumber = new Dictionary<int, int>(); //sort déjà utilisé par cercle
        private int[] mSortAllow = new int[0];

        public SortEntry[] Sorts
        {
            get
            {
                return mSorts.ToArray();
            }
        }
        public bool InstinctMagie
        {
            get { return mInstinctMagic; }
        }
        public void Restart()
        {
            mCastNumber = new Dictionary<int, int>();
        }
        public int getSortDispo(int cercle)
        {
            int utilise = 0;
            if (mCastNumber.ContainsKey(cercle))
                utilise = mCastNumber[cercle];
            int total = 0;
            if (mSortAllow.Length > cercle)
            {
                total = mSortAllow[cercle];
            }
            return total - utilise;
        }
        public MagieList(NubiaPlayer owner, ClasseType type)
        {
            mOwner = owner;
            mClasse = type;
            if (mOwner.hasClasse(type))
            {
                Classe cl = mOwner.getClasse(type);
                mMagicStat = cl.MagieStat;
                mInstinctMagic = cl.InstinctiveMagie;
            }
            if (mInstinctMagic)
                MakeInstinctList();
        }

        public bool Cast(Type sortType)
        {
            if (mOwner.NextSortCast > DateTime.Now)
            {
                mOwner.SendMessage("Vous êtres déjà en train d'incanter");
                return false;
            }
            foreach (SortEntry entry in mSorts)
            {
                if (entry.Sort == null)
                    continue;
                if( entry.Sort.GetType().Equals(sortType)){

                    entry.Sort.Cast(mOwner, mOwner.getNiveauClasse(mClasse), mOwner.getClasse(mClasse).MagieStat, entry.Cercle);
                    if (mCastNumber.ContainsKey(entry.Cercle))
                        mCastNumber[entry.Cercle] += 1;
                    mOwner.NextSortCast = DateTime.Now + entry.Sort.Delay;
                }
            }
            return false;
        }

        public bool canCast(Type sortType)
        {
           
            if (mInstinctMagic)
            {
                SortEntry sort = null;
                foreach( SortEntry s in mSorts )
                {
                    if (s.Sort == null)
                        continue;
                    if( s.Sort.GetType().Equals( sortType ) )
                        sort = s;
                }
              //  Console.WriteLine("Sort = " + sort);
                if( sort == null )
                    return false;
                if (mCastNumber.ContainsKey(sort.Cercle) && mSortAllow.Length > sort.Cercle)
                {
                //  Console.WriteLine("Cercle = " + sort.Cercle);
               //   Console.WriteLine("Allow = "+ mSortAllow[sort.Cercle]);
                    if (mCastNumber[sort.Cercle] < mSortAllow[sort.Cercle])
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
                                sort = ctor.Invoke(new object[0]) as BaseSort;
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
