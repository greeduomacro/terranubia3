using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonParadeProjectile : BaseDon
    {
        public override int Icone { get { return 21017; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Science du combat à mains nues.<br>"+
"Avantage. Le personnage doit avoir au moins une main libre pour faire appel à ce don. Une fois par round, lorsqu’une arme à distance devrait le toucher, il peut la dévier à l’ultime seconde et ne subir aucun dégâts. Le personnage doit être conscient de l’attaque. Il ne doit pas être pris au dépourvu. Le geste extrêmement rapide qu’il effectue ne compte pas comme une action. Il est impossible de parer les projectiles massifs, comme un rocher lancé par un géant, et les attaques à distance générées par des sorts, comme une flèche acide de Melf.<br>"+
"Spécial. Un moine peut choisir Parade de projectiles en tant que don supplémentaire au niveau 2, même s’il n’en remplit pas les conditions.<br>" +
"Un guerrier peut choisir Parade de projectiles en tant que don supplémentaire.";
            }
        }
        public DonParadeProjectile()
            : base(DonEnum.ParadeDeProjectiles, "Parade de projectile", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.Dex >= 13 && mob.hasDon(DonEnum.ScienceDuCombatAMainsNues));
        }

    }

}
