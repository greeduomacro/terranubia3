using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDiscret : BaseDon
    {
        public override int Icone { get { return 2249; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests de Déplacement silencieux et de Discrétion.";
            }
        }
        public DonDiscret()
            : base(DonEnum.Discret, "Discret", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
