using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCombatMonte : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonCombatMonte()
            : base(DonEnum.CombatMonte, "Combat monté", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.Competences[CompType.Equitation].getPureMaitrise() >= 1;
        }
    }
}