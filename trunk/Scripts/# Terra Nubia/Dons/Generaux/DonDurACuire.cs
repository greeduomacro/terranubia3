using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDurACuir : BaseDon
    {
        //Reduction des chances de recevoir une blessure & maladie
        public DonDurACuir()
            : base(DonEnum.DurACuire, "Dure à cuir", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.Endurance);
        }
    }

}
