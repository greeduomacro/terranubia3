using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCoupEtourdissant : BaseDon
    {
        public override int Icone { get { return 21541; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Sag 13, Science du combat à mains nues, bonus de base à l’attaque de +8.<br>"+
"Avantage. Le joueur doit annoncer que son personnage donne un coup étourdissant avant d’effectuer son jet d’attaque (en cas d’échec, l’utilisation du don est donc perdue). Si son attaque à mains nues porte, son adversaire subit les dégâts normaux et doit réussir un jet de Vigueur (DD 10 + modificateur de Sagesse du personnage + 1/2 niveau du personnage) pour éviter d’être étourdi pendant 1 round (soit jusqu’au début du prochain tour de jeu du personnage). Un individu étourdi est incapable d’agir, perd son bonus de Dextérité à la CA et subit un malus de –2 à la classe d’armure. Chaque jour, le personnage peut tenter un nombre de coups étourdissants égal à un quart de son niveau global, dans la limite d’un par round. Les créatures artificielles, les morts- vivants, les plantes et les vases, ainsi que les créatures intangibles et les créatures immunisées contre les coups critiques ne peuvent être étourdies.<br>"+
"Spécial. Un moine peut choisir Coup étourdissant en tant que don supplémentaire au niveau 1, même s’il n’en remplit pas les conditions. Un moine qui possède ce don peut tenter un coup étourdissant un nombre de fois par jour égal à son niveau de moine, plus un quart des niveaux qu’il possède dans d’autres classes que moine.<br>" +
"Un guerrier peut choisir Coup étourdissant en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonCoupEtourdissant()
            : base(DonEnum.CoupEtourdissant, "Coup etourdissant", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = true;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.RawSag >= 13 && mob.hasDon(DonEnum.ScienceDuCombatAMainsNues) && mob.BonusAttaque[0] >= 8);
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (p.HasFreeHand())
            {
                p.NewActionCombat(ActionCombat.CoupEtourdissant);
            }
            else
                p.SendMessage("Vous devez vous battre au poing pour cela");
        }
    }
}