using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCourse : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonCourse()
            : base(DonEnum.Course, "Course", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (DndHelper.GetBiggerArmor(p) == null || DndHelper.GetBiggerArmor(p).ModelType < ArmorModelType.Maille)
            {
                new SpeedContext(p, SpeedContext.SpeedState.Fast, "Course");
                new InternalTimer(p).Start();
            }
            else
                p.SendMessage("Votre armure est trop encombrante pour courir");
        }
        private class InternalTimer : Timer
        {
            NubiaPlayer owner = null;
            public InternalTimer(NubiaPlayer o): base(WorldData.TimeTour() )
            {
                owner = o;
            }
            protected override void  OnTick()
            {
                if (owner != null)
                    SpeedContext.RemoveContext(owner, "Course");
 	             base.OnTick();
            }
        }
    }
}