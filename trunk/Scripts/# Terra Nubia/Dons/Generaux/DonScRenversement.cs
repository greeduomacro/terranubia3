using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScRenversement : BaseDon
    {
        public override int Icone { get { return 20997; } }
        public override string Description
        {
            get
            {
                return "Conditions. For 13, Attaque en puissance.<br>"+
"Avantage. Lorsque le personnage tente un renversement, sa cible ne peut choisir de l’éviter. Le personnage bénéficie de plus d’un bonus de +4 sur le test de Force opposé effectué pour envoyer sa cible à terre.<br>"+
"Normal. Sans ce don, la cible d’un renversement peut choisir d’éviter ou de bloquer son agresseur.<br>" +
"Spécial. Un guerrier peut choisir Science du renversement en tant que don supplémentaire.";
            }
        }
        public DonScRenversement()
            : base(DonEnum.ScienceDuRenversement, "Science du renversement", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawStr >= 13 && mob.hasDon(DonEnum.AttaqueEnPuissance);
        }
    }

}
