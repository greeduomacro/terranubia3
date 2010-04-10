using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonFeuNourri : BaseDon
    {
         public override bool WarriorDon { get { return true; } }
         public DonFeuNourri()
            : base(DonEnum.FeuNourri, "Feu nourri", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return ( mob.RawDex >= 17
                && mob.hasDon(DonEnum.TirABoutPortant)
                && mob.hasDon(DonEnum.TirRapide)
                //   && mob.hasDon(DonEnum.ExpertiseDuCombat)
              //  && mob.hasDon(DonEnum.SouplesseDuSerpent)
                && mob.BonusAttaque[0] >= 6);
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (p.Stam >= 10)
            {
                if (p.Weapon is BaseRanged)
                    p.NewActionCombat(ActionCombat.FeuNourri);
                else
                    p.SendMessage("Utilisable seulement avec Arc ou Arbalètes");
            }
            else
                p.SendMessage("Vous n'avez pas assez de souffle pour cela");
        }
    }
}