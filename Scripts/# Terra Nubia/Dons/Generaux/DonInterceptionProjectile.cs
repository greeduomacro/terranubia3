using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonInterceptionProjectile : BaseDon
    {
        public override int Icone { get { return 21017; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 15, Parade de projectile, Science du combat à mains nues.<br>"+
"Avantage. Lorsqu’il utilise le don Parade de projectiles, le personnage peut intercepter l’arme au lieu de simplement le dévier. Les armes de jet, comme les lances ou les haches de lancer, peuvent être relancées immédiatement (même si ce n’est pas le tour de jeu du personnage), ou conservées pour un usage ultérieur.<br>"+
"Il faut au moins une main libre pour utiliser ce don.<br>" +
"Spécial. Un guerrier peut choisir Interception de projectiles en tant que don supplémentaire.";
            }
        }
        public DonInterceptionProjectile()
            : base(DonEnum.InterceptionDeProjectile, "Interception de projectile", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Sag >= 15 && mob.hasDon(DonEnum.ParadeDeProjectiles) && mob.hasDon(DonEnum.ScienceDuCombatAMainsNues) );
        }

    }

}
