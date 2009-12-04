using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirMonte : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonTirMonte()
            : base(DonEnum.TirMonte, "Tir monté", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Competences[CompType.Equitation].getPureMaitrise() >= 1 && mob.hasDon(DonEnum.CombatMonte));
        }

    }

}
