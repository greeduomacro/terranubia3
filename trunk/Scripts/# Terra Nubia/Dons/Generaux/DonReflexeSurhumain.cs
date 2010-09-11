using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonReflexeSurhumain : BaseDon
    {
        public override int Icone { get { return 21283; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +2 aux jets de Réflexes.";
            }
        }
        public DonReflexeSurhumain()
            : base(DonEnum.ReflexesSurhumains, "Reflexes surhumains", false)
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
