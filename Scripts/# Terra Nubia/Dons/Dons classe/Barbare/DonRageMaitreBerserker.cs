using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonRageMaitreBerserker : BaseDon
    {
        public DonRageMaitreBerserker()
            : base(DonEnum.RageMaitreBerserker, "Rage de Maitre Berserker", false)
        {
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }

}
