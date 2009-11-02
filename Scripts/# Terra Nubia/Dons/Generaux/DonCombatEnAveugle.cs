using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCombatEnAveugle : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonCombatEnAveugle()
            : base(DonEnum.CombatEnAveugle, "Combat en aveugle", false)
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