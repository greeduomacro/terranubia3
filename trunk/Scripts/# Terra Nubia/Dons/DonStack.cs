using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class DonEntry
    {
        private DonEnum mDon = DonEnum.AffiniteMagique;
        private int mValue = 0;
        private ClasseType mClasse = ClasseType.None;
        private int mGiveAtLevel = 0;
        private int mUseThisDay = 0;

        public DonEntry(DonEnum don, ClasseType classe, int giveatlevel)
        {
            
            mValue = 1;
            mDon = don;
            mClasse = classe;
            mGiveAtLevel = giveatlevel;
        }
        public DonEnum Don { get { return mDon; } }
        public int Value { get { return mValue; } set { mValue = value; } }
        public ClasseType Classe { get { return mClasse; } }
        public int GiveAtLevel { get { return mGiveAtLevel; } }
        public int UseThisDay { get { return mUseThisDay; } set { mUseThisDay = value; } }
    }
    public class DonStack
    {
        private NubiaPlayer mOwner = null;
        protected Dictionary<DonEnum, DonEntry> mDons = new Dictionary<DonEnum, DonEntry>();
        private DateTime mNextDonUse = DateTime.Now;
        private int mCountDonClasse = 0;

        public DonStack(NubiaPlayer owner)
        {
            mOwner = owner;
        }
   
        public Dictionary<DonEnum, DonEntry> DonsEntrys
        {
            get { return mDons; }
        }

        public void Reset()
        {
            mDons = new Dictionary<DonEnum, DonEntry>();
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
            }
        }

        public bool canUpClasse()
        {
            foreach (DonEntry entry in mDons.Values)
            {
                if (entry.Don == DonEnum.DonSupClasse)
                {
                    mOwner.SendMessage("Vous avez un don supplémentaire de " + Classe.GetNameClasse(entry.Classe) + " à choisir !");
                    return false;
                }
            }
            return true;
        }


       
        public void LearnDonClasse(Classe classe, int niveau)
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
        }

        public void CompileDonClasse()
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
        }

        public bool canUseDon(BaseDon don)
        {
            if (mOwner == null)
                return false;
            if (mNextDonUse > DateTime.Now)
            {
                mOwner.SendMessage("Il est encore trop tôt pour utiliser un don");
                return false;
            }
            if ( mDons.ContainsKey(don.DType) )
            {
                if (don.LimiteDayUse)
                {
                        int uses = mDons[don.DType].UseThisDay;
                        int maxUses = mDons[don.DType].Value;
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
                            mDons[don.DType].UseThisDay = uses;
                            return true;
                        }

                    
                }
                else
                    return true;
            }
            return false;
        }

        public ICollection Dons
        {
            get
            {
                return mDons.Keys;
            }
        }

        public int getDonNiveau(DonEnum don)
        {
            if (mDons.ContainsKey(don))
            {
                return mDons[don].Value;
            }
            return 0;
        }

        public bool hasDon(DonEnum don)
        {
            if (mDons.ContainsKey(don))
                return true;
            return false;
        }
    }
}
