using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueEclair : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonAttaqueEclair()
            : base(DonEnum.AttaqueEclair, "Attaque Eclair", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.hasDon(DonEnum.Esquive) && mob.hasDon(DonEnum.SouplesseDuSerpent) && mob.BonusAttaque[0] >= 4);
        }
    }
}