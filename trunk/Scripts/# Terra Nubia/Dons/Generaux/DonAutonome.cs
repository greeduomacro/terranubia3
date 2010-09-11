using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAutonome : BaseDon
    {
        public override int Icone { get { return 2241; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests de Premiers secours et de Survie.";
            }
        }
        //public override bool WarriorDon { get { return true; } }
        public DonAutonome()
            : base(DonEnum.Autonome, "Autonome", false)
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