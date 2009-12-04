using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirABoutPortant : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonTirABoutPortant()
            : base(DonEnum.TirABoutPortant, "Tir à bout portant", false)
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
