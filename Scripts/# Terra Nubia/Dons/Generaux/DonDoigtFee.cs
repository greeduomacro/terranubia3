using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDoigtFee : BaseDon
    {
        public override int Icone { get { return 2249; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests d’Escamotage et de crochetage.";
            }
        }
        public DonDoigtFee()
            : base(DonEnum.DoigtsDeFee, "Doigt de fée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
