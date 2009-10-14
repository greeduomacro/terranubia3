using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonEsquiveInstinctive : BaseDon
    {
        public DonEsquiveInstinctive()
            : base(DonEnum.EsquiveInstinctive, "Esquive Instinctive", false)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
