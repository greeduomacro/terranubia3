using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAffiniteMagique : BaseDon
    {
        public override string Description { get { return "Avantage. Le personnage obtient un bonus de +2 sur tous ses tests d’Art de la magie et d’Utilisation des objets magiques."; } }
        public override int Icone { get { return 2270; } }

        public DonAffiniteMagique()
            : base(DonEnum.AffiniteMagique, "Affinité Magique", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
    }

}
