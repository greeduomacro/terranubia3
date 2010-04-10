using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDoigtFee : BaseDon
    {
        public DonDoigtFee()
            : base(DonEnum.DoigtsDeFee, "Doigt de fée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
