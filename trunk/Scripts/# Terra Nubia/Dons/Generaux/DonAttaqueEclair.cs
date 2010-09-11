using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueEclair : BaseDon
    {
        public override int Icone { get { return 21542; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Esquive, Souplesse du serpent, bonus de base à l’attaque de +4.<br>"+
"Avantage. Lorsque le personnage entreprend une action d’attaque à l’aide d’une arme de corps à corps, il peut se déplacer avant et après avoir frappé, à condition que son mouvement total reste dans les limites de sa vitesse de déplacement. L’ensemble de ce déplacement ne provoque pas d’attaque d’opportunité de la part de la cible de son attaque, mais d’autres créatures peuvent éventuellement porter des attaques d’opportunité selon les cas. Il est impossible d’utiliser ce don en armure lourde.<br>"+
"Pour bénéficier des avantages d’une attaque éclair, le personnage doit se déplacer d’au moins 1,50 mètre à la fois avant et après avoir porté son attaque.<br>"+
"Spécial. Un guerrier peut choisir Attaque éclair en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonAttaqueEclair()
            : base(DonEnum.AttaqueEclair, "Attaque Eclair", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.hasDon(DonEnum.Esquive) && mob.hasDon(DonEnum.SouplesseDuSerpent) && mob.BonusAttaque[0] >= 4);
        }
    }
}