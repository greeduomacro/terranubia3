using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEsquiveTotale : BaseDon
    {
        public DonEsquiveTotale()
            : base(DonEnum.EsquiveTotale, "Esquive totale", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

       
    }

}
