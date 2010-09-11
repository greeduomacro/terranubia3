using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirMonte : BaseDon
    {
        public override int Icone { get { return 21016; } }
        public override string Description
        {
            get
            {
                return "Conditions. Degré de maîtrise de 1 en Équitation, Combat monté.<br>"+
"Avantage. Le malus subi normalement quand on utilise une arme à distance à dos de monture est divisé par deux : –2 au lieu de –4 si la monture effectue un déplacement double, et –4 au lieu de –8 si elle court.<br>" +
"Spécial. Un guerrier peut choisir Tir monté en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonTirMonte()
            : base(DonEnum.TirMonte, "Tir monté", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Competences[CompType.Equitation].getPureMaitrise() >= 1 && mob.hasDon(DonEnum.CombatMonte));
        }

    }

}
