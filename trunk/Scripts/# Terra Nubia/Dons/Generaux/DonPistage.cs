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
        public override int Icone { get { return 20999; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage peu pister des créatures (humaine ou non) sur un jet de survie<br>"+
                    "Spécial. Les rôdeurs bénéficient automatiquement de Pistage en tant que don supplémentaire. Ils n’ont pas besoin de le choisir.<br>"+
"Ce don ne permet pas de trouver ou de suivre la piste d’un individu sous l’effet du sort passage sans trace.";
            }
        }
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
