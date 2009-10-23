using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAmeDiamant : BaseDon
    {
        public DonAmeDiamant()
            : base(DonEnum.AmeDiamant, "Âme de diamant", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
