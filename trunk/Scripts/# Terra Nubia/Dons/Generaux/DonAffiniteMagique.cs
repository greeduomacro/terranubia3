using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAffiniteMagique : BaseDon
    {
        public DonAffiniteMagique()
            : base(DonEnum.AffiniteMagique, "Affinité Magique", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
