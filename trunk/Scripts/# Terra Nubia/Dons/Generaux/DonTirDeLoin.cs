using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirDeLoin : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonTirDeLoin()
            : base(DonEnum.TirDeLoin, "Tir de loin", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.TirABoutPortant));
        }

    }

}
