using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonFrappeKi : BaseDon
    {
        public DonFrappeKi()
            : base(DonEnum.FrappeKi, "Frappe Ki", false)
        {
            mAchatMax = 3;
            mLimiteDayUse = false;
        }


    }

}
