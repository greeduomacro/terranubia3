using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonPlenitudePhysique : BaseDon
    {
        /** REGEN RATE AUGMENTE **/
        public DonPlenitudePhysique()
            : base(DonEnum.PlenitudePhysique, "Plénitude physique", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
