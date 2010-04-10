using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonVolonteIndomptable : BaseDon
    {
        public DonVolonteIndomptable()
            : base(DonEnum.VolonteIndomptable, "Volonté Indomptable", false)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
