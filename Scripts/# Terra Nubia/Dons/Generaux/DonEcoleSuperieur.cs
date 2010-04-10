using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEcoleSuperieurAbjuration : BaseDon
    {
        public DonEcoleSuperieurAbjuration()
            : base(DonEnum.EcoleSuperieureAbjuration, "Ecole supérieure: Abjuration", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceAbjuration);
        }
    }

    public class DonEcoleSuperieurDivination : BaseDon
    {
        public DonEcoleSuperieurDivination()
            : base(DonEnum.EcoleSuperieureDivination, "Ecole supérieure: Divination", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceDivination);
        }
    }
    public class DonEcoleSuperieurEnchantement : BaseDon
    {
        public DonEcoleSuperieurEnchantement()
            : base(DonEnum.EcoleSuperieureEnchantement, "Ecole supérieure: Enchantement", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceEnchantement);
        }
    }
    public class DonEcoleSuperieurEvocation : BaseDon
    {
        public DonEcoleSuperieurEvocation()
            : base(DonEnum.EcoleSuperieureEvocation, "Ecole supérieure: Evocation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceEvocation);
        }
    }
    public class DonEcoleSuperieurIllusion : BaseDon
    {
        public DonEcoleSuperieurIllusion()
            : base(DonEnum.EcoleSuperieureIllusion, "Ecole supérieure: Illusion", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceIllusion);
        }
    }
    public class DonEcoleSuperieurInvocation : BaseDon
    {
        public DonEcoleSuperieurInvocation()
            : base(DonEnum.EcoleSuperieureInvocation, "Ecole supérieure: Invocation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceInvocation);
        }
    }
    public class DonEcoleSuperieurNecromancie : BaseDon
    {
        public DonEcoleSuperieurNecromancie()
            : base(DonEnum.EcoleSuperieureNecromancie, "Ecole supérieure: Nécromancie", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceNecromancie);
        }
    }
    public class DonEcoleSuperieurTransmutation : BaseDon
    {
        public DonEcoleSuperieurTransmutation()
            : base(DonEnum.EcoleSuperieureTransmutation, "Ecole supérieure: Transmutation", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.EcoleRenforceTransmutation);
        }
    }
}
