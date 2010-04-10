using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCoupEtourdissant : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonCoupEtourdissant()
            : base(DonEnum.CoupEtourdissant, "Coup etourdissant", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = true;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.RawSag >= 13 && mob.hasDon(DonEnum.ScienceDuCombatAMainsNues) && mob.BonusAttaque[0] >= 8);
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (p.HasFreeHand())
            {
                p.NewActionCombat(ActionCombat.CoupEtourdissant);
            }
            else
                p.SendMessage("Vous devez vous battre au poing pour cela");
        }
    }
}