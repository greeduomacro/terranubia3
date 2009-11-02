using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAmelioCreatureConvoc : BaseDon
    {
        public DonAmelioCreatureConvoc()
            : base(DonEnum.AmeliorationDesCreaturesConvoquees, "Amélioration des Créatures convoquées", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceInvocation);
        }
    }

}
