using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonVigilance : BaseDon
    {
        public override int Icone { get { return 2249; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +2 sur tous ses tests de Détection et de Perception auditive.<br>"+
"Spécial. Le maître d’un familier bénéficie automatiquement des effets de ce don tant que son familier se trouve assez près de lui pour qu’il puisse le toucher en tendant le bras.";
            }
        }
        public DonVigilance()
            : base(DonEnum.Vigilance, "Vigilance", false)
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
