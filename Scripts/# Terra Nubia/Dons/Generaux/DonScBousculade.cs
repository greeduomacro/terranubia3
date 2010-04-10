using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScBousculade : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonScBousculade()
            : base(DonEnum.ScienceDeLaBousculade, "Science de la Bousculade", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return ( mob.Str >= 13 && mob.hasDon(DonEnum.AttaqueEnPuissance) );
        }
    }
}