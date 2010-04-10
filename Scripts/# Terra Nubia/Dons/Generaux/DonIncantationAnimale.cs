using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonIncantationAnimale : BaseDon
    {
        public DonIncantationAnimale()
            : base(DonEnum.IncantationAnimale, "Incantation animale", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.Sag >= 13;
        }

    }

}
