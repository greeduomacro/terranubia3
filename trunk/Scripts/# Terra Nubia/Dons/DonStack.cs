using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class DonEntry
    {
        private DonEnum mDon = DonEnum.AffiniteMagique;
        //private int mValue = 0;
        private ClasseType mClasse = ClasseType.None;
        private int mGiveAtLevel = 0;
        //private int mUseThisDay = 0;
        private bool mChoosen = false;
        public DonEntry(DonEnum don, ClasseType classe, int giveatlevel, bool choosen)
        {
            
          //  mValue = 1;
            mChoosen = choosen;
            mDon = don;
            mClasse = classe;
            mGiveAtLevel = giveatlevel;
        }
        public bool Choosen { get { return mChoosen; } set { mChoosen = value; } }
        public DonEnum Don { get { return mDon; } }
        //public int Value { get { return mValue; } set { mValue = value; } }
        public ClasseType Classe { get { return mClasse; } }
        public int GiveAtLevel { get { return mGiveAtLevel; } }
        //public int UseThisDay { get { return mUseThisDay; } set { mUseThisDay = value; } }
    }
    public class DonStack
    {
        private NubiaPlayer mOwner = null;
        //protected Dictionary<DonEnum, DonEntry> mDons = new Dictionary<DonEnum, DonEntry>();
        private List<DonEntry> mDons = new List<DonEntry>();
        private Dictionary<DonEnum, int> mDonUsed = new Dictionary<DonEnum, int>();
        private DateTime mNextDonUse = DateTime.Now;
        private int mCountDonClasse = 0;

        public DonStack(NubiaPlayer owner)
        {
            mOwner = owner;
        }

        public List<DonEntry> DonsEntrys
        {
            get { return mDons; }
        }

        public void Reset()
        {
            if (mOwner == null)
                return;
            mDons = new List<DonEntry>();
            
            ComputeDons();
           /* mDons = new Dictionary<DonEnum, DonEntry>();
            mNextDonUse = DateTime.Now;
            if (mOwner != null)
            {
                foreach (Classe c in mOwner.GetClasses())
                {
                    for (int n = 0; n < c.Niveau; n++)
                    {
                        LearnDonClasse(c, n);
                    }
                }
            }*/
            Console.WriteLine("Reset des dons de " + mOwner.Name);
            mOwner.SendMessage("Reset des dons effectuée");
        }

        public bool canUpClasse()
        {
          /*  foreach (DonEntry entry in mDons)
            {
                if (entry.Don == DonEnum.DonSupClasse)
                {
                    mOwner.SendMessage("Vous avez un don supplémentaire de " + Classe.GetNameClasse(entry.Classe) + " à choisir !");
                    return false;
                }
            }*/
            return true;
        }

        public void ComputeDons()
        {
            if (mOwner == null)
                return;

           // Console.WriteLine("COMPUTE DON DE " + mOwner.Name);
            List<DonEntry> toAdd = new List<DonEntry>();
            //DOns Hors classes
            for (int n = 0; n <= mOwner.Niveau; n += 3)
            {
                bool has = false;
                foreach (DonEntry entry in mDons)
                {
                    if (entry.Classe == ClasseType.None && entry.GiveAtLevel == n)
                        has = true;
                }
                if (!has)
                    toAdd.Add( new DonEntry(DonEnum.DonSupClasse, ClasseType.None, n, false) );
            }

            foreach (Classe c in mOwner.GetClasses())
            {
                for (int n = 1; n <= c.Niveau; n++)
                {
                    for (int d = 0; d < c.DonClasse[n].Length; d++)
                    {
                       // Console.WriteLine("Classe {0} niveau {1} don {2} ", c, n, d);
                        if (c.DonClasse[n][d] == null)
                            continue;
                        
                        DonEnum don = c.DonClasse[n][d];
                      //  Console.WriteLine("Don = " + don.ToString());
                        if (don == DonEnum.DonSupClasse)
                        {
                            bool has = false;
                            foreach (DonEntry entry in mDons)
                            {
                                if (entry.Classe == c.CType && entry.GiveAtLevel == n )
                                    has = true;
                            }
                            if (!has)
                                toAdd.Add(new DonEntry(DonEnum.DonSupClasse, c.CType, n, false));
                        }
                        else
                        {
                            bool has = false;
                            foreach (DonEntry entry in mDons)
                            {
                                if (entry.Classe == c.CType && entry.GiveAtLevel == n  && entry.Don == don)
                                    has = true;
                            }
                            if (!has)
                                toAdd.Add(new DonEntry(don, c.CType, n, false));
                        }
                    }
                }

                foreach (DonEntry entry in toAdd)
                    mDons.Add(entry);
                toAdd.Clear();
            }
        }
       
     /*   public void LearnDonClasse(Classe classe, int niveau)
        {
            if (classe.DonClasse.Length <= niveau )
            {
                Console.WriteLine("Aucun don pour la classe " + classe.ToString() + " a partir du niveau " + niveau);
                return;
            }

            for (int d = 0; d < classe.DonClasse[niveau].Length; d++)
            {
                DonEnum don = classe.DonClasse[niveau][d];
                
                DonEntry entry = new DonEntry(don, classe.CType, niveau);
                if( mDons.ContainsKey(don) )
                    mDons[don].Value++;
                else
                    mDons.Add(don, entry);

                ///TODOOOOOOOOOOOOO !!!
                if (don == DonEnum.DonSupClasse)
                {
                    if (mOwner.DonCredits.ContainsKey(classe.CType))
                        mOwner.DonCredits[classe.CType]++;
                    else
                        mOwner.DonCredits.Add(classe.CType, 1);
                    canUpClasse();
                }
                else
                    mOwner.SendMessage("Vous gagnez le don {0} {1}", BaseDon.getDonName(don), (entry.Value > 1 ? "( Rang " + entry.Value.ToString() + " )" : ""));
                
            }
        }*/

    /*    public void CompileDonClasse()
        {
            if (mOwner == null)
                return;
            //Vérification des dons
            
            //On vire, par sécurité, tout les dons de classe
            List<DonEnum> toRemove = new List<DonEnum>();

                
                foreach (DonEntry d in mDons.Values)
                {
                    if ( d.Classe != ClasseType.None ) //Don de classe
                        toRemove.Add(d.Don);
                }
                foreach (DonEnum r in toRemove)
                {
                    if (mDons.ContainsKey(r))
                    {
                       // SendMessage("Vous perdez le don: ", r.ToString());
                        mDons.Remove(r);
                    }
                }
            

            foreach ( Classe c in mOwner.GetClasses() )
            {
                for (int i = 0; i < c.DonClasse.Length && i <= c.Niveau; i++)
                {
                    for (int d = 0; d < c.DonClasse[i].Length; d++)
                    {
                        DonEnum don = c.DonClasse[i][d];
                        if (don == DonEnum.DonSupClasse)
                        {
                            //mDonClasseToChoose.Add(new DonEntry(DonEnum.DonSupClasse, c.CType, i));
                            mOwner.SendMessage(2049, "Vous gagnez un don supplémentaire ("+Classe.GetNameClasse(c.CType)+")");
                        }
                        else
                        {
                            if (mDons.ContainsKey(don))
                                mDons[don].Value++;
                            else
                                mDons.Add(don, new DonEntry(don, c.CType, i));

                            if (don == DonEnum.PerfectionEtre)
                                mOwner.CreatureType = MobileType.Exterieur;

                            if (!toRemove.Contains(don))
                            {
                                string dname = "";
                                if (BaseDon.DonBank.ContainsKey(don.ToString().ToLower()))
                                    dname = BaseDon.DonBank[don.ToString().ToLower()].Name;
                                else
                                    dname = don.ToString();
                                mOwner.SendMessage(2049, "Vous gagnez le don: " + dname + " ( rang " + mDons[don].Value + " )");
                            }

                            mCountDonClasse++;
                        }
                    }
                }
            }
        }*/

        public bool canUseDon(BaseDon don)
        {
            if (mOwner == null)
                return false;
            if (mNextDonUse > DateTime.Now)
            {
                mOwner.SendMessage("Il est encore trop tôt pour utiliser un don");
                return false;
            }
            if ( hasDon(don.DType) )
            {
                if (don.LimiteDayUse)
                {
                    int uses = mDonUsed[don.DType];
                    int maxUses = getDonNiveau(don.DType);
                        if (don.DType == DonEnum.CoupEtourdissant)
                        {
                            maxUses = mOwner.Niveau / 4;
                            if (mOwner.hasClasse(ClasseType.Moine))
                            {
                                maxUses += mOwner.getNiveauClasse(ClasseType.Moine) / 4;
                            }
                        }
                        if (uses >= maxUses )
                        {
                            mOwner.SendMessage("Vous ne pouvez plus utiliser ce don (Utilisé déjà {0} fois ce jour)", uses);
                            return false;
                        }
                        else
                        {
                            uses++;
                            mDonUsed[don.DType] = uses;
                            return true;
                        }

                    
                }
                else
                    return true;
            }
            return false;
        }

     /*   public ICollection Dons
        {
            get
            {
                return mDons.Keys;
            }
        }*/

        public int getDonNiveau(DonEnum don)
        {
            int count = 0;
            lock(mDons)
            {
                foreach (DonEntry entry in mDons)
                {
                    if (entry.Don == don)
                        count++;
                }
            }
            return count;
        }

        public bool hasDon(DonEnum don)
        {
            lock (mDons)
            {
                foreach (DonEntry entry in mDons)
                {
                    if (entry.Don == don)
                        return true;
                }
            }
            return false;
        }
    }
}
