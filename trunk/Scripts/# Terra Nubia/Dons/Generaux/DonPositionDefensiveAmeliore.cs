using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonPositionDefensiveAmeliore : BaseDon
    {
        public override int Icone { get { return 20741; } }
        public override string Description
        {
            get
            {
                return "Avantage. A venir...";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonPositionDefensiveAmeliore()
            : base(DonEnum.PositionDefensiveAmelio, "Position défensive améliorée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawInt >= 13;
        }
    }
}