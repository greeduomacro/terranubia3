using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonRobustesse : BaseDon
    {
        public DonRobustesse()
            : base(DonEnum.Robustesse, "Robustesse", false)
        {
            mAchatMax = 10;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }

    }

}
