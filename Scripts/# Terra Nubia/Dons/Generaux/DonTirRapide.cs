using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirRapide : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonTirRapide()
            : base(DonEnum.TirRapide, "Tir rapide", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.hasDon(DonEnum.TirABoutPortant));
        }

    }

}
