using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirDePrecision : BaseDon
    {
        public override int Icone { get { return 21016; } }
        public override string Description
        {
            get
            {
                return "Condition. Tir à bout portant.<br>"+
"Avantage. Si le personnage utilise une arme à projectiles, par exemple un arc, son facteur de portée augmente de 50% (multipliez-le par 1,5). S’il utilise une arme de jet, le facteur de portée est doublé.<br>" +
"Spécial. Un guerrier peut choisir Tir de loin en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonTirDePrecision()
            : base(DonEnum.TirDePrecision, "Tir de précision", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.TirABoutPortant));
        }

    }

}
