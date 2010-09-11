using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonDurACuir : BaseDon
    {
        public override int Icone { get { return 2246; } }
        public override string Description
        {
            get
            {
                return "Condition. Endurance.<br>"+
"Avantage. Lorsque le total de points de vie du personnage est compris entre –1 et –9, il se stabilise automatiquement. Le joueur n’a pas à lancer 1d100 chaque round pour savoir si son personnage perd 1 point de vie.<br>"+
"Lorsque le total de points de vie du personnage est négatif, il peut choisir de se considérer comme hors de combat plutôt que mourant. Le joueur doit prendre cette décision dès que son personnage atteint un total de points de vie négatif (même si cela arrive en dehors de son tour de jeu). Si le personnage ne choisit pas cette option, il tombe aussitôt inconscient.<br>"+
"Lorsqu’il utilise ce don, le personnage peut effectuer soit un déplacement simple, soit une action simple lors de son tour de jeu (mais pas les deux). Il est incapable d’accomplir une action complexe. Effectuer une action de mouvement n’aggrave pas ses blessures, mais s’il entreprend une action simple (ou toute autre action fatigante, y compris certaines actions libres comme lancer un sort à incantation rapide), le personnage subit 1 point de dégâts aussitôt après avoir accompli son action. Le personnage meurt immédiatement si son total de points de vie atteint –10.<br>" +
"Normal. Un personnage ne possédant pas ce don suit les règles habituelles et devient mourant et inconscient lorsque son total de points de vie est compris entre –1 et –9.";
            }
        }
        //Reduction des chances de recevoir une blessure & maladie
        public DonDurACuir()
            : base(DonEnum.DurACuire, "Dure à cuir", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.Endurance);
        }
    }

}
