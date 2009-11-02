using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueEnRotation : BaseDon
    {
       // public override bool WarriorDon { get { return true; } }
        public DonAttaqueEnRotation()
            : base(DonEnum.AttaqueEnRotation, "Attaque en rotation", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawInt >= 13 && mob.RawDex >= 13 
                && mob.hasDon(DonEnum.AttaqueEclair) 
                && mob.hasDon(DonEnum.Esquive)
             //   && mob.hasDon(DonEnum.ExpertiseDuCombat)
                && mob.hasDon(DonEnum.SouplesseDuSerpent)
                && mob.BonusAttaque[0] >= 4 );
        }
        public override void OnUse(NubiaPlayer p)
        {
            if( !(p.Weapon is BaseRanged) )
                p.NewActionCombat(ActionCombat.AttaqueEnRotation);
        }
    }
}