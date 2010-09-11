using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonNegociation : BaseDon
    {
        public override int Icone { get { return 20999; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests de Diplomatie et de Psychologie.";
            }
        }
        public DonNegociation()
            : base(DonEnum.Negociation, "Négociation", false)
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
