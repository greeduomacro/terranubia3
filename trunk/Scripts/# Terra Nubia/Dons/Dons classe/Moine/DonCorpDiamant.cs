using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCorpDiamant : BaseDon
    {
        public DonCorpDiamant()
            : base(DonEnum.CorpDiamant, "Corp de diamant", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
