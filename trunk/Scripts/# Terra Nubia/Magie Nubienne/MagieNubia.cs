using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using System.Collections;

namespace Server.Spells
{
    public class MagieNubia
    {
        private NubiaPlayer mOwner = null;
        private ArrayList m_sorts = new ArrayList();
        private Dictionary<SortDomaine, int> m_domaines = new Dictionary<SortDomaine, int>();
        private Dictionary<SortEnergie, int> m_energies = new Dictionary<SortEnergie, int>();

        
        public MagieNubia(NubiaPlayer m)
        {
            mOwner = m;
        }

        public int GetPuissance()
        {
            if (mOwner == null)
                return 0;
            else
            {
                int niv = 0;
                if (mOwner.hasClasse(ClasseType.Mage))
                    niv = mOwner.getNiveauClasse(ClasseType.Mage);
                if (mOwner.hasClasse(ClasseType.Barde))
                    niv += mOwner.getNiveauClasse(ClasseType.Barde) / 2;
                return niv;
            }
        }
     
        public ArrayList Sorts { get { return m_sorts; } }

        public void ResetSorts()
        {
            foreach (SortNubia j in m_sorts)
                j.Delete();
            m_sorts = new ArrayList();
        }

        public SortNubia[] sortList
        {
            get
            {
                int count = m_sorts.Count;
                SortNubia[] ret = new SortNubia[count];
                for (int i = 0; i < count; i++)
                {
                    ret[i] = m_sorts[i] as SortNubia;
                }
                return ret;
            }
        }

        public void addSort(SortNubia sort)
        {
            /*foreach(Jutsu jut in m_jutsuList)
            {
                if(jut.Nom == jutsu.Nom)
                    return;
            }*/
            int count = m_sorts.Count;
            bool exist = false;
            for (int i = 0; i < count; i++)
            {
                SortNubia juti = m_sorts[i] as SortNubia;
                if (juti.Nom == sort.Nom)
                    exist = true;
            }
            if (exist)
            {
                return;
            }
            else
            {
                sort.Owner = this.mOwner;
                m_sorts.Add(sort);
            }
        }

        public void executeSort(int index)
        {
            try
            {
                SortNubia sort = m_sorts[index] as SortNubia;
                sort.StartCast();
            }
            catch { }//	SendMessage("Le jutsu que vous voulez executez n'existe pas");	}
        }
        public SortNubia getSort(int index)
        {
            try { return ((SortNubia)m_sorts[index]); }
            catch { return null; }//	SendMessage("Le jutsu que vous voulez executez n'existe pas");	}
        }
    }
}
