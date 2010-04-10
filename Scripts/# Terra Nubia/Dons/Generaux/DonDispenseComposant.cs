using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDispenseComposant : BaseDon
    {
        public DonDispenseComposant()
            : base(DonEnum.DispenseDeComposantsMateriels, "Dispense de Composant (Magie)", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
