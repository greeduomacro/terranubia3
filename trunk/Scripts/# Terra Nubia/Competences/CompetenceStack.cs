using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Server.Mobiles
{
    public class NullCompetence : NubiaCompetence
    {
        public override string Name { get { return "Null Competence"; } }
        public override CompType CType { get { return CompType.None; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab { get { return new CompType[]{}; } }

        public NullCompetence(NubiaMobile m)
            : base(m)
        {
        }
    }
    public class CompetenceStack
    {
        private NubiaMobile mOwner = null;
        private Dictionary<CompType, NubiaCompetence> mCompetences =
                                new Dictionary<CompType, NubiaCompetence>();
        private NullCompetence nullComp = null;


        public bool mustWait()
        {
            if (mOwner.NextSkillTime > DateTime.Now)
            {
                mOwner.SendMessage("vous devez attendre pour utiliser une compétence");
                return true;
            }
            return false;
        }

        public CompetenceStack(NubiaMobile owner)
        {
            mOwner = owner;
            nullComp = new NullCompetence(mOwner);
            initialize();
        }
        public static CompType[] DefautCompetences
        {
            get
            {
                return new CompType[] { 
                    CompType.Bluff,
                    CompType.Concentration,
                    CompType.Deguisement,
                    CompType.DeplacementSilencieux,
                    CompType.Detection,
                    CompType.Diplomatie,
                    CompType.Discretion,
                    CompType.Equilibre,
                    CompType.Equitation,
                    CompType.Escalade,
                    CompType.Estimation,
                    CompType.Evasion,
                    CompType.Fouille,
                    CompType.Intimidation,
                    CompType.PerceptionAuditive,
                    CompType.PremiersSecours,
                    CompType.Psychologie,
                    CompType.Renseignements,
                    CompType.Representation,
                    CompType.Saut,
                    CompType.Survie
                };
            }
        }
        private void initialize()
        {
            for (int i = 0; i < DefautCompetences.Length; i++)
                AddCompetence(DefautCompetences[i]);
        }
        public void LearnCompetence(CompType comp)
        {
            this.LearnCompetence(comp, true);
        }
        public void AddCompetence(CompType comp)
        {
            this.LearnCompetence(comp, false);
        }
        
        private void LearnCompetence(CompType comp, bool msgDisplay)
        {
            if (!mCompetences.ContainsKey(comp))
            {
                NubiaCompetence c = null;
                switch (comp)
                {
                    case CompType.Acrobaties: c = new CompAcrobatie(mOwner);break;
                    case CompType.ArtMagie: c = new CompArtMagie(mOwner); break;
                    case CompType.Bluff: c = new CompBluff(mOwner); break;
                 //   case CompType.Brassage: c = new compbra
                    case CompType.Chimie: c = new CompChimie(mOwner); break;
                    case CompType.Concentration: c = new CompConcentration(mOwner); break;
                    case CompType.Couture: c = new CompCouture(mOwner); break;
                    case CompType.Crochetage: c = new CompCrochetage(mOwner); break;
                    //case CompType.Cuisine: c = new compcui
                    case CompType.Deguisement: c = new CompDeguisement(mOwner); break;
                    case CompType.DeplacementSilencieux: c = new CompDeplacementSilencieux(mOwner); break;
                    case CompType.Desamorcage: c = new CompDesamorcage(mOwner); break;
                    case CompType.Detection: c = new CompDetection(mOwner); break;
                    case CompType.Diplomatie: c = new CompDiplomatie(mOwner); break;
                    case CompType.Discretion: c = new CompDiscretion(mOwner); break;
                    case CompType.Dressage: c = new CompDressage(mOwner); break;
                    case CompType.Ebenisterie: c = new CompEbenisterie(mOwner); break;
                    case CompType.Equilibre: c = new CompEquilibre(mOwner); break;
                    case CompType.Equitation: c = new CompEquitation(mOwner); break;
                    case CompType.Erudition: c = new CompErudition(mOwner); break;
                    case CompType.Escalade: c = new CompEscalade(mOwner); break;
                    case CompType.Escamotage: c = new CompEscamotage(mOwner); break;
                    case CompType.Estimation: c = new CompEstimation(mOwner); break;
                    case CompType.Evasion: c = new CompEvasion(mOwner); break;
                    case CompType.Forge: c = new CompForge(mOwner); break;
                    case CompType.Fouille: c = new CompFouille(mOwner); break;
                    case CompType.Ingenierie: c = new CompIngenieurie(mOwner); break;
                    case CompType.Intimidation: c = new CompIntimidation(mOwner); break;
                    //case CompType.Peche
                    case CompType.PerceptionAuditive: c = new CompPerceptionAuditive(mOwner); break;
                    case CompType.PremiersSecours: c = new CompPremierSecours(mOwner); break;
                    case CompType.Psychologie: c = new CompPsychologie(mOwner); break;
                    case CompType.Renseignements: c = new CompPsychologie(mOwner); break;
                    case CompType.Representation: c = new CompRepresentation(mOwner); break;
                    case CompType.Saut: c = new CompSaut(mOwner); break;
                    case CompType.Survie: c = new CompSurvie(mOwner); break;
                    case CompType.UtilisationObjetsMagiques: c = new CompUtilisationObjetMagique(mOwner); break;
                    case CompType.VoleVoile: c = new CompVolVoile(mOwner); break;
                    case CompType.Agriculture: c = new CompAgriculture(mOwner); break;
                    case CompType.Chirurgie: c = new CompChirurgie(mOwner); break;
                }
                if( c != null && !mCompetences.ContainsKey(c.CType) ){
                    if( msgDisplay )
                        mOwner.SendMessage("Vous apprennez une nouvelle compétence: " + c.Name);
                    mCompetences.Add(c.CType, c);
                }
            }
        }

        public int Lenght
        {
            get { return mCompetences.Count; }
        }


        public NubiaCompetence this[CompType comp]
        {
            get
            {
                if (mCompetences.ContainsKey(comp))
                    return mCompetences[comp];
                else
                    return nullComp;
            }
        }
    }
}
