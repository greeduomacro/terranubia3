using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDiscret : BaseDon
    {
        public DonDiscret()
            : base(DonEnum.Discret, "Discret", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
