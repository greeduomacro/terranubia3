using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirDePrecision : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonTirDePrecision()
            : base(DonEnum.TirDePrecision, "Tir de précision", false)
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
