using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirEnMouvement : BaseDon
    {
        public override int Icone { get { return 21016; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Esquive, Souplesse du serpent, Tir à bout portant, bonus de base à l’attaque de +4.<br>"+
"Avantage. Lorsqu’il entreprend une action d’attaque avec une arme à distance, le personnage peut se déplacer avant et après son attaque, du moment que le total de la distance parcourue durant le round ne dépasse pas sa vitesse de déplacement.<br>" +
"Spécial. Un guerrier peut choisir Tir en mouvement en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonTirEnMouvement()
            : base(DonEnum.TirEnMouvement, "Tir en mouvement", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.hasDon(DonEnum.SouplesseDuSerpent) && mob.hasDon(DonEnum.TirABoutPortant) && mob.BonusAttaque[0] >= 4);
        }

    }

}
