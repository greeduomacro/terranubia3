using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaquePuissance : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonAttaquePuissance()
            : base(DonEnum.AttaqueEnPuissance, "Attaque en puissance", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawStr >= 13);
        }
        public override void OnUse(NubiaPlayer p)
        {
            p.NewActionCombat(ActionCombat.AttaqueEnPuissance);
        }
    }
}