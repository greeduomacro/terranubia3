using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompMinage : NubiaCompetence
    {
        public override string Name { get { return "Minage"; } }
        public override CompType CType { get { return CompType.Minage; } }
        public override DndStat SType { get { return DndStat.Force; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompMinage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompBuchage : NubiaCompetence
    {
        public override string Name { get { return "Buchage"; } }
        public override CompType CType { get { return CompType.Buchage; } }
        public override DndStat SType { get { return DndStat.Force; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompBuchage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }

    public class CompChirurgie : NubiaCompetence
    {
        public override string Name { get { return "Chirurgie"; } }
        public override CompType CType { get { return CompType.Chirurgie; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    CompType.PremiersSecours
            };
            }
        }

        public CompChirurgie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }

    public class CompAgriculture : NubiaCompetence
    {
        public override string Name { get { return "Agriculture"; } }
        public override CompType CType { get { return CompType.Agriculture; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompAgriculture(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
   public class CompUtilisationObjetMagique : NubiaCompetence
    {
        public override string Name { get { return "Utilisation d'objet magique"; } }
        public override CompType CType { get { return CompType.UtilisationObjetsMagiques; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompUtilisationObjetMagique(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompSurvie : NubiaCompetence
    {
        public override string Name { get { return "Survie"; } }
        public override CompType CType { get { return CompType.Survie; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompSurvie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompSaut : NubiaCompetence
    {
        public override string Name { get { return "Saut"; } }
        public override CompType CType { get { return CompType.Saut; } }
        public override DndStat SType { get { return DndStat.Force; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompSaut(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompRepresentation : NubiaCompetence
    {
        public override string Name { get { return "Représentation"; } }
        public override CompType CType { get { return CompType.Representation; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompRepresentation(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompRenseignement : NubiaCompetence
    {
        public override string Name { get { return "Renseignement"; } }
        public override CompType CType { get { return CompType.Renseignements; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompRenseignement(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompPsychologie : NubiaCompetence
    {
        public override string Name { get { return "Psychologie"; } }
        public override CompType CType { get { return CompType.Psychologie; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompPsychologie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompPremierSecours : NubiaCompetence
    {
        public override string Name { get { return "Premiers secours"; } }
        public override CompType CType { get { return CompType.PremiersSecours; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompPremierSecours(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompPerceptionAuditive : NubiaCompetence
    {
        public override string Name { get { return "Perception auditive"; } }
        public override CompType CType { get { return CompType.PerceptionAuditive; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompPerceptionAuditive(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompVolVoile : NubiaCompetence
    {
        public override string Name { get { return "Vole à voiles"; } }
        public override CompType CType { get { return CompType.VoleVoile; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompVolVoile(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
  /*  public class CompMaitriseCorde : NubiaCompetence
    {
        public override string Name { get { return "Maitrise des cordes"; } }
        public override CompType CType { get { return CompType.MaitriseCordes; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    CompType.Evasion
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompMaitriseCorde(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }*/
    public class CompIntimidation : NubiaCompetence
    {
        public override string Name { get { return "Intimidation"; } }
        public override CompType CType { get { return CompType.Intimidation; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //(int)CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompIntimidation(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompFouille : NubiaCompetence
    {
        public override string Name { get { return "Fouille"; } }
        public override CompType CType { get { return CompType.Fouille; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    CompType.Survie
                   // (int)CompType.Equitation
            };
            }
        }

        public CompFouille(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEvasion : NubiaCompetence
    {
        public override string Name { get { return "Evasion"; } }
        public override CompType CType { get { return CompType.Evasion; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // CompType.MaitriseCordes,
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEvasion(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEstimation : NubiaCompetence
    {
        public override string Name { get { return "Estimation"; } }
        public override CompType CType { get { return CompType.Estimation; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEstimation(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEscamotage : NubiaCompetence
    {
        public override string Name { get { return "Escamotage"; } }
        public override CompType CType { get { return CompType.Escamotage; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEscamotage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEscalade : NubiaCompetence
    {
        public override string Name { get { return "Escalade"; } }
        public override CompType CType { get { return CompType.Escalade; } }
        public override DndStat SType { get { return DndStat.Force; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEscalade(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEquitation : NubiaCompetence
    {
        public override string Name { get { return "Equitation"; } }
        public override CompType CType { get { return CompType.Equitation; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEquitation(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompEquilibre : NubiaCompetence
    {
        public override string Name { get { return "Equilibre"; } }
        public override CompType CType { get { return CompType.Equilibre; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                   // (int)CompType.Equitation
            };
            }
        }

        public CompEquilibre(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompDressage : NubiaCompetence
    {
        public override string Name { get { return "Dressage"; } }
        public override CompType CType { get { return CompType.Dressage; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    CompType.Equitation
            };
            }
        }

        public CompDressage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompDiscretion : NubiaCompetence
    {
        public override string Name { get { return "Discrétion"; } }
        public override CompType CType { get { return CompType.Discretion; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDiscretion(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompDiplomatie : NubiaCompetence
    {
        public override string Name { get { return "Diplomatie"; } }
        public override CompType CType { get { return CompType.Diplomatie; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDiplomatie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
    public class CompDetection : NubiaCompetence
    {
        public override string Name { get { return "Détection"; } }
        public override CompType CType { get { return CompType.Detection; } }
        public override DndStat SType { get { return DndStat.Sagesse; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDetection(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }

    public class CompDesamorcage : NubiaCompetence
    {
        public override string Name { get { return "Désamorçage"; } }
        public override CompType CType { get { return CompType.Desamorcage; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDesamorcage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }

    public class CompDeplacementSilencieux : NubiaCompetence
    {
        public override string Name { get { return "Déplacement silencieux"; } }
        public override CompType CType { get { return CompType.DeplacementSilencieux; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDeplacementSilencieux(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }

    public class CompDeguisement : NubiaCompetence
    {
        public override string Name { get { return "Deguisement"; } }
        public override CompType CType { get { return CompType.Deguisement; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDeguisement(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
   /* public class CompDecryptage : NubiaCompetence
    {
        public override string Name { get { return "Decryptage"; } }
        public override CompType CType { get { return CompType.Decryptage; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompDecryptage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }*/
    public class CompCrochetage : NubiaCompetence
    {
        public override string Name { get { return "Crochetage"; } }
        public override CompType CType { get { return CompType.Crochetage; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompCrochetage(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
   /* public class CompContrefacon : NubiaCompetence
    {
        public override string Name { get { return "Contrefaçon"; } }
        public override CompType CType { get { return CompType.Contrefacon; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            };
            }
        }

        public CompContrefacon(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }*/
}
