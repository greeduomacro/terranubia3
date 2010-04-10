using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonSpeMageIntel : BaseDon
    {
        public DonSpeMageIntel()
            : base(DonEnum.MageIntel, "Mage d'étude (Intelligence)", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
        }
        
        public override bool hasConditions(NubiaPlayer mob)
        {
            return false;
        }
    }

    public class DonSpeMageSagesse : BaseDon
    {
        public DonSpeMageSagesse()
            : base(DonEnum.MageSagesse, "Mage spirituel (Sagesse)", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return false;
        }
    }

    public class DonSpeMageCharisme : BaseDon
    {
        public DonSpeMageCharisme()
            : base(DonEnum.MageCharisme, "Mage inné (Charisme)", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return false;
        }
    }
}
