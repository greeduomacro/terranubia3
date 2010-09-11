using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueFinesse : BaseDon
    {
        public override int Icone { get { return 21015; } }
        public override string Description
        {
            get
            {
                return "Condition. Bonus de base à l’attaque de +1.<br>"+
"Avantage. Lorsqu’il utilise une arme légère, une rapière, un fouet ou une chaîne cloutée (et que cette arme est destinée à une créature de sa catégorie de taille), le personnage peut choisir d’appliquer son bonus de Dextérité à ses jets d’attaque plutôt que celui de Force. Si le personnage utilise un bouclier, le malus d’armure aux tests imposé par ce dernier s’applique aux jets d’attaque.<br>"+
"Spécial. Un guerrier peut choisir Attaque en finesse en tant que don supplémentaire.<br>" +
"Les armes naturelles sont toujours considérées comme étant des armes légères.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonAttaqueFinesse()
            : base(DonEnum.AttaqueEnFinesse, "Attaque en finesse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return ( mob.BonusAttaque[0] >= 1 );
        }
    }
}