using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScFeinte : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonScFeinte()
            : base(DonEnum.ScienceDeLaFeinte, "Science de la feinte", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Int >= 13 && mob.hasDon(DonEnum.PositionDefensiveAmelio));
        }
    }
}