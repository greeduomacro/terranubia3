using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAthletisme : BaseDon
    {
        public override int Icone { get { return 2240; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests d’Escalade.";
            }
        }
        public DonAthletisme()
            : base(DonEnum.Athletisme, "Athlétisme", false)
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
