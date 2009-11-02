using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;
using Server.SkillHandlers;

namespace Server.Mobiles.Dons
{
    public class DonPistage : BaseDon
    {
        public DonPistage()
            : base(DonEnum.Pistage, "Pistage", true)
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
            p.SendLocalizedMessage(1011350); // What do you wish to track?

            p.CloseGump(typeof(TrackWhatGump));
            p.CloseGump(typeof(TrackWhoGump));
            p.SendGump(new TrackWhatGump(p));

        }

    }

}
