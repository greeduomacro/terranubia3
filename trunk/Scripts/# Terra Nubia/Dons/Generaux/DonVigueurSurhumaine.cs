using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonVigueurSurhumaine : BaseDon
    {
        public override int Icone { get { return 2246; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +2 à tous ses jets de Vigueur.";
            }
        }
        public DonVigueurSurhumaine()
            : base(DonEnum.VigueurSurhumaine, "Vigueur surhumaine", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }

    }

}
