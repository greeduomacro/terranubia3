using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonScCombatMainNue : BaseDon
    {
        public override int Icone { get { return 2255; } }
        public override string Description
        {
            get
            {
                return "Avantage. Le personnage est considéré comme armé même quand il n’a pas d’arme. Cela signifie que le fait d’attaquer à mains nues un adversaire armé ne provoque pas d’attaque d’opportunité. De plus, le personnage a droit à une attaque d’opportunité chaque fois qu’on l’attaque à mains nues.<br>"+
"Enfin, les attaques à mains nues du personnage peuvent infliger des dégâts létaux ou non-létaux, à sa discrétion.<br>"+
"Normal. Sans ce don, un personnage se battant à mains nues est considéré comme étant désarmé et ne peut infliger que des dégâts non- létaux avec ce type d’attaque.<br>"+
"Spécial. Les moines obtiennent automatiquement Science du combat à mains nues en tant que don supplémentaire au niveau 1. Ils n’ont pas besoin de le choisir.<br>"+
"Un guerrier peut choisir Science du combat à mains nues en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon{get{return true;}}
        public DonScCombatMainNue()
            : base(DonEnum.ScienceDuCombatAMainsNues, "Science du combat à main nue", false)
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
