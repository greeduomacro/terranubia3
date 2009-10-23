using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSautAmeliore : BaseDon
    {
        public DonSautAmeliore()
            : base(DonEnum.SautAmeliore, "Saut amélioré", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }


    }

}
