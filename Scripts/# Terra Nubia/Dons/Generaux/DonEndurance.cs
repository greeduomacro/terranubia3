using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEndurance : BaseDon
    {
        public override int Icone { get { return 2240; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage bénéficie d’un bonus de +4 sur chacun des tests et jets de sauvegarde suivants : les test de Natation joués pour résister à des dégâts temporaires, les tests de Constitution joués pour continuer à courir, les tests de Constitution joués pour éviter les dégâts non-létaux infligés par une marche forcée, les tests de Constitution joués pour retenir sa respiration, les tests de Constitution joués pour éviter les dégâts non-létaux infligés par la famine ou la soif, les jets de Vigueur joués pour éviter les dégâts non-létaux infligés par les climats chauds ou froids, ainsi que les jets de Vigueur joués pour résister aux dégâts infligés par l’asphyxie. De plus, le personnage peut dormir en armure légère ou intermédiaire sans se réveiller fatigué le lendemain.<br>"+
"Normal. Un personnage ne possédant pas ce don qui dort en armure intermédiaire ou lourde est automatiquement fatigué le lendemain.<br>"+
"Spécial. Un rôdeur reçoit automatiquement ce don au niveau 3 en tant que don supplémentaire. Il n’a pas à le choisir.";
            }
        }
        public DonEndurance()
            : base(DonEnum.Endurance, "Endurance", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            if (mob.hasClasse(ClasseType.Rodeur))
                return false;
            return true;
        }
    }
}