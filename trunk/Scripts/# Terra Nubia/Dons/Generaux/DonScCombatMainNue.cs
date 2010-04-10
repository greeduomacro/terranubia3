using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonScCombatMainNue : BaseDon
    {
        public override bool WarriorDon{get{return true;}}
        public DonScCombatMainNue()
            : base(DonEnum.ScienceDuCombatAMainsNues, "Science du combat à main nue", false)
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
