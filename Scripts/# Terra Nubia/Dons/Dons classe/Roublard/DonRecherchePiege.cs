using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonRecherchePiege : BaseDon
    {
        public DonRecherchePiege()
            : base(DonEnum.RecherchePiege, "Recherche de pièges", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
