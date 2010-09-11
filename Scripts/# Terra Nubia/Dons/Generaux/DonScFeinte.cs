using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonScFeinte : BaseDon
    {
        public override int Icone { get { return 21004; } }
        public override string Description
        {
            get
            {
                return "Conditions. Int 13, Expertise du combat.<br>"+
"Avantage. Le personnage peut effectuer un test de Bluff pour tenter une feinte par une action de mouvement.<br>"+
"Normal. Une feinte de combat est habituellement une action simple.<br>" +
"Spécial. Un guerrier peut choisir Science de la feinte en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonScFeinte()
            : base(DonEnum.ScienceDeLaFeinte, "Science de la feinte", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Int >= 13 && mob.hasDon(DonEnum.PositionDefensiveAmelio));
        }
    }
}