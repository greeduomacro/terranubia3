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