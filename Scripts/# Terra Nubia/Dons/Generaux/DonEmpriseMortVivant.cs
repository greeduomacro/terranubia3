using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEmpriseMortVivant : BaseDon
    {
        public DonEmpriseMortVivant()
            : base(DonEnum.EmpriseSurLesMortsVivants, "Emprise sur les Morts-Vivants", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasClasse(ClasseType.Pretre) || mob.hasClasse(ClasseType.Paladin);
        }
    }
}