using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirABoutPortant : BaseDon
    {
        public override int Icone { get { return 21014; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +1 aux jets d’attaque et de dégâts avec n’importe quelle arme à distance, à condition que sa cible soit distante de 9 mètres ou moins.<br>"+
"Spécial. Un guerrier peut choisir Tir à bout portant en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonTirABoutPortant()
            : base(DonEnum.TirABoutPortant, "Tir à bout portant", false)
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
