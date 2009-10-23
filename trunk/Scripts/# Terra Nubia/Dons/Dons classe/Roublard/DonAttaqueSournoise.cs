using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueSournoise : BaseDon
    {
        public DonAttaqueSournoise()
            : base(DonEnum.AttaqueSournoise, "Attaque sournoise", false)
        {
            mAchatMax = 10;
            mLimiteDayUse = false;
        }


    }

}
