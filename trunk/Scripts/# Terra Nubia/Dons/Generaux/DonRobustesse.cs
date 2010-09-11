using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonRobustesse : BaseDon
    {
        public override int Icone { get { return 21020; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage gagne 3 points de vie supplémentaires.<br>"+
"Spécial. Ce don peut être pris plusieurs fois. Ses effets sont cumulatifs.";
            }
        }
        public DonRobustesse()
            : base(DonEnum.Robustesse, "Robustesse", false)
        {
            mAchatMax = 10;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }

    }

}
