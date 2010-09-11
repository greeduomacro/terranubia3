using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScBousculade : BaseDon
    {
        public override int Icone { get { return 20485; } }
        public override string Description
        {
            get
            {
                return "Conditions. For 13, Attaque en puissance.<br>"+
"Avantage. Le personnage peut tenter une bousculade sans provoquer d’attaque d’opportunité de la part de la cible. Le personnage bénéficie de plus d’un bonus de +4 sur le test de Force opposé effectué pour repousser sa cible.<br>" +
"Spécial. Un guerrier peut choisir Science de la bousculade en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonScBousculade()
            : base(DonEnum.ScienceDeLaBousculade, "Science de la Bousculade", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return ( mob.Str >= 13 && mob.hasDon(DonEnum.AttaqueEnPuissance) );
        }
    }
}