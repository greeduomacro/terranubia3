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
                if ((CType == CompType.Crochetage || CType == CompType.Desamorcage) && player.hasDon(DonEnum.SavoirFaireMecanique))
                    donBonus += 2;
                //Talent
                if (CType == CompType.Acrobaties && player.hasDon(DonEnum.TalentAcrobaties))
                    donBonus += 3;
                if (CType == CompType.Agriculture && player.hasDon(DonEnum.TalentAgriculture))
                    donBonus += 3;
                if (CType == CompType.ArtMagie && player.hasDon(DonEnum.TalentArtMagie))
                    donBonus += 3;
                if (CType == CompType.Bluff && player.hasDon(DonEnum.TalentBluff))
                    donBonus += 3;
                if (CType == CompType.Brassage && player.hasDon(DonEnum.TalentBrassage))
                    donBonus += 3;
                if (CType == CompType.Buchage && player.hasDon(DonEnum.TalentBuchage))
                    donBonus += 3;
                if (CType == CompType.Chimie && player.hasDon(DonEnum.TalentChimie))
                    donBonus += 3;
                if (CType == CompType.Chirurgie && player.hasDon(DonEnum.TalentChirurgie))
                    donBonus += 3;
                if (CType == CompType.Concentration && player.hasDon(DonEnum.TalentConcentration))
                    donBonus += 3;
                if (CType == CompType.Couture && player.hasDon(DonEnum.TalentCouture))
                    donBonus += 3;
                if (CType == CompType.Crochetage && player.hasDon(DonEnum.TalentCrochetage))
                    donBonus += 3;
                if (CType == CompType.Cuisine && player.hasDon(DonEnum.TalentCuisine))
                    donBonus += 3;
                if (CType == CompType.Deguisement && player.hasDon(DonEnum.TalentDeguisement))
                    donBonus += 3;
                if (CType == CompType.DeplacementSilencieux && player.hasDon(DonEnum.TalentDeplacementSilentieux))
                    donBonus += 3;
                if (CType == CompType.Desamorcage && player.hasDon(DonEnum.TalentDesamorcage))
                    donBonus += 3;
                if (CType == CompType.Detection && player.hasDon(DonEnum.TalentDetection))
                    donBonus += 3;
                if (CType == CompType.Diplomatie && player.hasDon(DonEnum.TalentDiplomatie))
                    donBonus += 3;
                if (CType == CompType.Discretion && player.hasDon(DonEnum.TalentDiscretion))
                    donBonus += 3;
                if (CType == CompType.Dressage && player.hasDon(DonEnum.TalentDressage))
                    donBonus += 3;
                if (CType == CompType.Ebenisterie && player.hasDon(DonEnum.TalentEbenisterie))
                    donBonus += 3;
                if (CType == CompType.Equilibre && player.hasDon(DonEnum.TalentEquilibre))
                    donBonus += 3;
                if (CType == CompType.Equitation && player.hasDon(DonEnum.TalentEquitation))
                    donBonus += 3;
                if (CType == CompType.Erudition && player.hasDon(DonEnum.TalentErudition))
                    donBonus += 3;
                if (CType == CompType.Escalade && player.hasDon(DonEnum.TalentEscalade))
                    donBonus += 3;
                if (CType == CompType.Escamotage && player.hasDon(DonEnum.TalentEscamotage))
                    donBonus += 3;
                if (CType == CompType.Estimation && player.hasDon(DonEnum.TalentEstimation))
                    donBonus += 3;
                if (CType == CompType.Evasion && player.hasDon(DonEnum.TalentEvasion))
                    donBonus += 3;
                if (CType == CompType.Forge && player.hasDon(DonEnum.TalentForge))
                    donBonus += 3;
                if (CType == CompType.Fouille && player.hasDon(DonEnum.TalentFouille))
                    donBonus += 3;
                if (CType == CompType.Ingenierie && player.hasDon(DonEnum.TalentIngenierie))
                    donBonus += 3;
                if (CType == CompType.Intimidation && player.hasDon(DonEnum.TalentIntimidation))
                    donBonus += 3;
                if (CType == CompType.Minage && player.hasDon(DonEnum.TalentMinage))
                    donBonus += 3;
                /*if (CType == CompType.Peche && player.hasDon(DonEnum.TalentDesamorcage))
                    donBonus += 3;*/
                if (CType == CompType.PerceptionAuditive && player.hasDon(DonEnum.TalentPerceptionAuditive))
                    donBonus += 3;
                if (CType == CompType.PremiersSecours && player.hasDon(DonEnum.TalentPremiersSecours))
                    donBonus += 3;
                if (CType == CompType.Psychologie && player.hasDon(DonEnum.TalentPsychologie))
                    donBonus += 3;
                if (CType == CompType.Renseignements && player.hasDon(DonEnum.TalentRenseignements))
                    donBonus += 3;
                if (CType == CompType.Representation && player.hasDon(DonEnum.TalentRepresentation))
                    donBonus += 3;
                if (CType == CompType.Saut && player.hasDon(DonEnum.TalentSaut))
                    donBonus += 3;
                if (CType == CompType.Survie && player.hasDon(DonEnum.TalentSurvie))
                    donBonus += 3;
                if (CType == CompType.UtilisationObjetsMagiques && player.hasDon(DonEnum.TalentUtilisationObjetsMagiques))
                    donBonus += 3;
                if (CType == CompType.VoleVoile && player.hasDon(DonEnum.TalentVoleVoile))
                    donBonus += 3;
             
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

        public bool roll(int dd){
            return roll(dd, false);
        }
        public bool roll(int DD, bool silent)
        {
          /*  Utilisation des compétences. 
           * Voici la formule pour jouer un test de compétence :
           * 1d20 
           * + modificateur de compétence 
           * (modificateur de compétence = 
           * degré de maîtrise + modificateur de caractéristique + modificateurs divers).*/

            int roll = intRoll(silent);

            return roll > DD;
        }

        public int intRoll()
        {
            return intRoll(false);
        }

        

        public int intRoll(bool silent)
        {
            if (mOwner.NextSkillTime > DateTime.Now )
            {
                if( !silent )
                     mOwner.SendMessage("vous devez attendre pour utiliser une compétence");
                return 1;
            }
            int roll = DndHelper.rollDe(De.vingt);
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
