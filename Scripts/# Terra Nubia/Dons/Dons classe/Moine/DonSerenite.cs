using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSerenite : BaseDon
    {
        public DonSerenite()
            : base(DonEnum.Serenite, "Sérénité", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
