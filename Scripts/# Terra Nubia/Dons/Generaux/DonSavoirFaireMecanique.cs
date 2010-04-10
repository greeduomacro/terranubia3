using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSavoirFaireMecanique : BaseDon
    {
        public DonSavoirFaireMecanique()
            : base(DonEnum.SavoirFaireMecanique, "Savoir faire mécanique", false)
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
