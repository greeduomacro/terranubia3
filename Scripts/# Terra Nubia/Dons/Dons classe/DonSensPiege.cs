using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonSensPieges : BaseDon
    {
        public DonSensPieges()
            : base(DonEnum.SensPieges, "Sens des pièges", false)
        {
            mAchatMax = 12;
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
