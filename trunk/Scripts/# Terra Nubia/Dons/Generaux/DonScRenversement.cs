using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScRenversement : BaseDon
    {
        public DonScRenversement()
            : base(DonEnum.ScienceDuRenversement, "Science du renversement", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawStr >= 13 && mob.hasDon(DonEnum.AttaqueEnPuissance);
        }
    }

}
