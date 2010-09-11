using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTalentAcrobaties : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>"+
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentAcrobaties()
            : base(DonEnum.TalentAcrobaties, "Talent: Acrobaties", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentArtMagie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentArtMagie()
            : base(DonEnum.TalentArtMagie, "Talent: Art de la magie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentCouture : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentCouture()
            : base(DonEnum.TalentCouture, "Talent: Couture", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentForge : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentForge()
            : base(DonEnum.TalentForge, "Talent: Forge", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentIngenierie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentIngenierie()
            : base(DonEnum.TalentIngenierie, "Talent: Ingénierie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEbenisterie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEbenisterie()
            : base(DonEnum.TalentEbenisterie, "Talent: Ébénisterie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentChimie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentChimie()
            : base(DonEnum.TalentChimie, "Talent: Chimie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentAgriculture : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentAgriculture()
            : base(DonEnum.TalentAgriculture, "Talent: Agriculture", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentMinage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentMinage()
            : base(DonEnum.TalentMinage, "Talent: Minage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentBuchage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentBuchage()
            : base(DonEnum.TalentBuchage, "Talent: Buchage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentBluff : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentBluff()
            : base(DonEnum.TalentBluff, "Talent: Bluff", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentConcentration : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentConcentration()
            : base(DonEnum.TalentConcentration, "Talent: Concentration", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentErudition : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentErudition()
            : base(DonEnum.TalentErudition, "Talent: Érudition", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentCrochetage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentCrochetage()
            : base(DonEnum.TalentCrochetage, "Talent: Crochetage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDeguisement : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDeguisement()
            : base(DonEnum.TalentDeguisement, "Talent: Déguisement", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDeplacementSilentieux : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDeplacementSilentieux()
            : base(DonEnum.TalentDeplacementSilentieux, "Talent: Déplacement silentieux", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDesamorcage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDesamorcage()
            : base(DonEnum.TalentDesamorcage, "Talent: Désamorçage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDetection : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDetection()
            : base(DonEnum.TalentDetection, "Talent: Détection", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDiplomatie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDiplomatie()
            : base(DonEnum.TalentDiplomatie, "Talent: Diplomatie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDiscretion : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDiscretion()
            : base(DonEnum.TalentDiscretion, "Talent: Discrétion", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentDressage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentDressage()
            : base(DonEnum.TalentDressage, "Talent: Dressage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEquilibre : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEquilibre()
            : base(DonEnum.TalentEquilibre, "Talent: Équilibre", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEquitation : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEquitation()
            : base(DonEnum.TalentEquitation, "Talent: Équitation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEscalade : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEscalade()
            : base(DonEnum.TalentEscalade, "Talent: Escalade", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEscamotage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEscamotage()
            : base(DonEnum.TalentEscamotage, "Talent: Escamotage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEstimation : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEstimation()
            : base(DonEnum.TalentEstimation, "Talent: Estimation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentEvasion : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentEvasion()
            : base(DonEnum.TalentEvasion, "Talent: Évasion", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentFouille : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentFouille()
            : base(DonEnum.TalentFouille, "Talent: Fouille", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentIntimidation : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentIntimidation()
            : base(DonEnum.TalentIntimidation, "Talent: Intimidation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentVoleVoile : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentVoleVoile()
            : base(DonEnum.TalentVoleVoile, "Talent: VoleVoile", false) //<---- WTF !?
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentPerceptionAuditive : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentPerceptionAuditive()
            : base(DonEnum.TalentPerceptionAuditive, "Talent: Perception auditive", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentPremiersSecours : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentPremiersSecours()
            : base(DonEnum.TalentPremiersSecours, "Talent: Premiers secours", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentPsychologie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentPsychologie()
            : base(DonEnum.TalentPsychologie, "Talent: Psychologie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentRenseignements : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentRenseignements()
            : base(DonEnum.TalentRenseignements, "Talent: Renseignements", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentRepresentation : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentRepresentation()
            : base(DonEnum.TalentRepresentation, "Talent: Représentation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentSaut : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentSaut()
            : base(DonEnum.TalentSaut, "Talent: Saut", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentSurvie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentSurvie()
            : base(DonEnum.TalentSurvie, "Talent: Survie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentUtilisationObjetsMagiques : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentUtilisationObjetsMagiques()
            : base(DonEnum.TalentUtilisationObjetsMagiques, "Talent: Utilisation d'objets magiques", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentCuisine : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentCuisine()
            : base(DonEnum.TalentCuisine, "Talent: Cuisine", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    /*public class DonTalentPeche : BaseDon
    {
        public DonTalentPeche()
            : base(DonEnum.TalentPeche, "Talent: Pêche", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }*/

    public class DonTalentBrassage : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentBrassage()
            : base(DonEnum.TalentBrassage, "Talent: Brassage", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

    public class DonTalentChirurgie : BaseDon
    {
        public override int Icone { get { return 20484; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +3 à tous les tests concernant la compétence choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle compétence.";
            }
        }
        public DonTalentChirurgie()
            : base(DonEnum.TalentChirurgie, "Talent: Chirurgie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
}