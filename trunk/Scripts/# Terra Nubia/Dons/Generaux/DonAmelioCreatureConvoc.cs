using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAmelioCreatureConvoc : BaseDon
    {
        public override int Icone { get { return 2279; } }
        public override string Description
        {
            get
            {
                return "Condition. École renforcée (invocation). <br>"+
            "Avantage. Toutes les créatures que le personnage convoque grâce à un sort de convocation quelconque obtiennent un bonus d’altération de +4 en Force et en Constitution pendant la durée du sort qui les a convoquées.";
            }
        }
        public DonAmelioCreatureConvoc()
            : base(DonEnum.AmeliorationDesCreaturesConvoquees, "Amélioration des Créatures convoquées", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceInvocation);
        }
    }

}
