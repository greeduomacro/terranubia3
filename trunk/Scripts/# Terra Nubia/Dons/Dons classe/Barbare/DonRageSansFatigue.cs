using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonRageSansFatigue : BaseDon
    {
        public DonRageSansFatigue()
            : base(DonEnum.RageSansFatigue, "Rage sans fatigue", false)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
