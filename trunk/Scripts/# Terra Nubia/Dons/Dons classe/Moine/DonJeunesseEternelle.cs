using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonJeunesseEternelle : BaseDon
    {
        public DonJeunesseEternelle()
            : base(DonEnum.JeunesseEternelle, "Eternelle Jeunesse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
