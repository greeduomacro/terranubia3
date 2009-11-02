using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonParadeProjectile : BaseDon
    {
        public DonParadeProjectile()
            : base(DonEnum.ParadeDeProjectiles, "Parade de projectile", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Dex >= 13 && mob.hasDon(DonEnum.ScienceDuCombatAMainsNues));
        }

    }

}
