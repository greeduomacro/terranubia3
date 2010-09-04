using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEmpathieSauvage : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEmpathieSauvage()
            : base(DonEnum.EmpathieSauvage, "EmpathieSauvage", false)
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