using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonFraterniteAnimale : BaseDon
    {
        public override int Icone { get { return 20491; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests de Dressage et d’Équitation.";
            }
        }
        public DonFraterniteAnimale()
            : base(DonEnum.FraterniteAnimale, "Fraternité animale", false)
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
