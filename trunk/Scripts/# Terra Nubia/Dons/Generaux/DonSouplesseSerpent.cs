using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSouplesseSerpent : BaseDon
    {
        public DonSouplesseSerpent()
            : base(DonEnum.SouplesseDuSerpent, "Souplesse du serpent", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawDex >= 13 && mob.hasDon(DonEnum.Esquive);
        }
    }

}
