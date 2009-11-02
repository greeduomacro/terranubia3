using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public abstract class NubiaCompetence
    {
        public abstract string Name { get; }
        public abstract CompType CType { get; }
        public abstract DndStat SType { get; }
        public abstract bool LimitedByArmor { get; }
       // public abstract bool MustLearn { get; }
        private int mAchat = 0;
        private NubiaMobile mOwner = null;

        public int Achat
        {
            get { return mAchat; }
            set { mAchat = value; }
        }

        public NubiaCompetence(NubiaMobile owner)
        {
            mOwner = owner;
        }

        public bool isCompetenceClasse
        {
            get
            {
                if (mOwner is NubiaPlayer)
                {
                    foreach (Classe cl in ((NubiaPlayer)mOwner).GetClasses())
                        if (cl.isComptenceClasse(CType))
                            return true;
                    return false;
                }
                else
                    return true;
            }
        }
        public double getCap()
        {
            double max = 0.0;
            if (mOwner is NubiaPlayer)
            {
                foreach (Classe c in ((NubiaPlayer)mOwner).GetClasses())
                {
                    if (c is ClasseArtisan)
                    {
                        ClasseArtisan ca = c as ClasseArtisan;
                        for (int i = 0; i < ca.ClasseCompetences.Length; i++)
                        {
                            if (ca.ClasseCompetences[i] == CType)
                                return getArtisanCap(ca);
                        }
                        for (int s = 0; s < ca.CompToLearn.Length; s++)
                        {
                            if (ca.CompToLearn[s] == CType)
                                return getArtisanCap(ca);
                        }
                        break;
                    }
                }

                if (isCompetenceClasse)
                    max = ((NubiaPlayer)mOwner).Niveau + 3;
                else
                    max = (((NubiaPlayer)mOwner).Niveau + 3) / 2;
                return Math.Round(max, 2);
            }
            else
                return 100;
        }
        public int getArtisanCap( ClasseArtisan c )
        {
            if (isCompetenceClasse)
                return (c.Niveau * 4) + 3;
            else
                return ((c.Niveau * 4) + 3) / 2;
        }
        public bool canRaise()
        {

            if (getPureMaitrise() + (isCompetenceClasse ? 1 : 0.5) >= getCap() + 0.4)
                return false;
            return true;
        }

        public double getPureMaitrise()
        {
            double maitrise = (isCompetenceClasse ? mAchat : ((double)mAchat / 2.0)) + DndHelper.GetCaracMod(mOwner, SType, !LimitedByArmor);
            maitrise = Math.Round(maitrise, 2);
            
            return maitrise;
        }

        public double getMaitrise()
        {
            int donBonus = 0;
            if (mOwner is NubiaPlayer)
            {
                NubiaPlayer player = mOwner as NubiaPlayer;
                if (CType == CompType.Saut && player.hasDon(DonEnum.SautAmeliore))
                    donBonus += 5;
                if ((CType == CompType.ArtMagie || CType == CompType.UtilisationObjetsMagiques) && player.hasDon(DonEnum.AffiniteMagique))
                    donBonus += 2;
                if(CType == CompType.Saut && player.hasDon(DonEnum.Athletisme)  )
                    donBonus += 2;
                if ((CType == CompType.Survie || CType == CompType.PremiersSecours) && player.hasDon(DonEnum.Autonome))
                    donBonus += 2;
                if ((CType == CompType.DeplacementSilencieux || CType == CompType.Discretion) && player.hasDon(DonEnum.Discret))
                    donBonus += 2;
                if ((CType == CompType.Escamotage || CType == CompType.Crochetage) && player.hasDon(DonEnum.DoigtsDeFee))
                    donBonus += 2;
                if ((CType == CompType.Renseignements || CType == CompType.Fouille) && player.hasDon(DonEnum.FinLimier))
                    donBonus += 2;
                if ((CType == CompType.Deguisement) && player.hasDon(DonEnum.Fourberie))
                    donBonus += 2;
                if ((CType == CompType.Dressage || CType == CompType.Equitation) && player.hasDon(DonEnum.FraterniteAnimale))
                    donBonus += 2;
                if ((CType == CompType.Equilibre || CType == CompType.Evasion) && player.hasDon(DonEnum.Funambule))
                    donBonus += 2;
                if ((CType == CompType.Erudition || CType == CompType.Estimation) && player.hasDon(DonEnum.Meticuleux))
                    donBonus += 2;
                if ((CType == CompType.Diplomatie || CType == CompType.Psychologie) && player.hasDon(DonEnum.Negociation))
                    donBonus += 2;
                if ((CType == CompType.Bluff || CType == CompType.Intimidation) && player.hasDon(DonEnum.Persuasion))
                    donBonus += 2;
                if ((CType == CompType.Crochetage || CType == CompType.Desamorçage) && player.hasDon(DonEnum.SavoirFaireMecanique))
                    donBonus += 2;
            }
            return getPureMaitrise() + getSynergie() + donBonus;
        }

        public int getSynergie()
        {
           // DateTime deb = DateTime.Now;
            int syn = 0;

           // Console.WriteLine("Competence = " + Name);
           
            for (int i = 0; i < (int)CompType.Maximum; i++)
            {
                NubiaCompetence c = mOwner.Competences[(CompType)i];
                if (c is NullCompetence)
                    continue;

                if (c == null)
                    continue;
                else if (c.SynergieTab == null)
                    continue;
                else if (c.SynergieTab.Length == 0)
                    continue;
                for (int s = 0; s < c.SynergieTab.Length; s++)
                {
                   if (c.SynergieTab[s] == CType && c.getPureMaitrise() >= 5)
                      syn += 2;
               }
            }
           // Console.WriteLine("Calcul synergie de {0} en {1}ms", Name, (DateTime.Now - deb).TotalMilliseconds);
            return syn;
        }

        public abstract CompType[] SynergieTab { get; } // [i]=CompType [i+1]=Value

        public bool check(int tourActions){
            return check(10, tourActions);
        }
        public bool check(int DD, int tourActions)
        {
          /*  Utilisation des compétences. 
           * Voici la formule pour jouer un test de compétence :
           * 1d20 
           * + modificateur de compétence 
           * (modificateur de compétence = 
           * degré de maîtrise + modificateur de caractéristique + modificateurs divers).*/

            int roll = pureRoll(tourActions);

            return roll > DD;
        }
       
        public int pureRoll( int tourActions)
        {
            if (mOwner.NextSkillTime > DateTime.Now && tourActions > 0)
            {
                mOwner.SendMessage("vous devez attendre pour utiliser une compétence");
                return 1;
            }
            int roll = Utility.RandomMinMax(1, 20);
            roll += (int)getMaitrise();
            double msst = WorldData.TimeTour().TotalMilliseconds;
            msst *= tourActions;
            msst -= 500;
            
            mOwner.NextSkillTime = DateTime.Now + TimeSpan.FromMilliseconds(msst);
            //Bonus Malus
            roll += mOwner.getBonusRoll();

            if( mOwner is NubiaPlayer )
                ((NubiaPlayer)mOwner).GiveXP(roll);

            return roll;
        }
        public virtual void onUse()
        {
        }
    }
}
