using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonGrandBerserker : BaseDon
    {
        public DonGrandBerserker()
            : base(DonEnum.RageGrandBerserker, "Rage de Grand Berserker", false)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
