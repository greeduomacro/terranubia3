using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonPerfectionEtre : BaseDon
    {
        public DonPerfectionEtre()
            : base(DonEnum.PerfectionEtre, "Perfection de l'être", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
