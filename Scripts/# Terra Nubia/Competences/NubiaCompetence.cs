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
                foreach (Classe cl in mOwner.GetClasses())
                    if (cl.isComptenceClasse(CType))
                        return true;
                return false;
            }
        }
        public double getCap()
        {
            double max = 0.0;
            if (isCompetenceClasse)
                max = mOwner.Niveau + 3;
            else
                max = (mOwner.Niveau + 3);
            return Math.Round(max, 2);
        }
        public bool canRaise()
        {
            if (getMaitrise() + (isCompetenceClasse ? 1 : 0.5) >= getCap()+ 0.4 )
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
            return getPureMaitrise() + getSynergie();
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

        public bool check(){
            return check(10);
        }
        public bool check(int DD)
        {
          /*  Utilisation des compétences. 
           * Voici la formule pour jouer un test de compétence :
           * 1d20 
           * + modificateur de compétence 
           * (modificateur de compétence = 
           * degré de maîtrise + modificateur de caractéristique + modificateurs divers).*/

            int roll = pureRoll();

            return roll > DD;
        }
       
        public int pureRoll()
        {
            if (mOwner.NextSkillTime > DateTime.Now)
            {
                //mOwner.SendMessage("vous devez attendre pour utiliser une compétence");
                return -1;
            }
            int roll = Utility.RandomMinMax(1, 20);
            roll += (int)getMaitrise();
            mOwner.NextSkillTime = DateTime.Now + WorldData.TimeTour();
            //Bonus Malus
            roll += mOwner.getBonusRoll();
            return roll;
        }
        public virtual void onUse()
        {
        }
    }
}
