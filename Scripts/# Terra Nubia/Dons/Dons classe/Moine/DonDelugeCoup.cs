using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDelugeCoup : BaseDon
    {
        public DonDelugeCoup()
            : base(DonEnum.DelugeCoup, "Déluge de coup", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
            if (p.Stam > 5)
            {
                p.DelugeDeCoup = true;
                p.Emote("*Déluge de coup*");
                p.AttaqueParTour = p.BonusAttaque.Length;
            }
            else
                p.SendMessage("Vous êtes trop fatigué pour cela");
        }
    }

}
