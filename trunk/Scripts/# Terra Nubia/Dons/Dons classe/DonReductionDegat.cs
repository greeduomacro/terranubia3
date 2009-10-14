using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonReductionDegat : BaseDon
    {
        public DonReductionDegat()
            : base(DonEnum.ReductionDegat, "Réduction des dégats", false)
        {
            mAchatMax = 5;
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
