using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSouplesseSerpent : BaseDon
    {
        public override int Icone { get { return 20494; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Esquive.<br>"+
"Avantage. Le personnage bénéficie d’un bonus d’esquive de +4 à la CA contre les attaques d’opportunité provoquées lorsqu’il se déplace dans un espace contrôlé (ou lorsqu’il en sort). Il perd automatiquement ce bonus s’il se trouve dans une situation lui faisant perdre son bonus de Dextérité à la CA. Contrairement à la plupart des types de bonus, le bonus d’esquive est cumulatif (il peut par exemple s’ajouter à celui dont les nains bénéficient naturellement contre les géants).<br>"+
"Spécial. Un guerrier peut choisir Souplesse du serpent en tant que don supplémentaire.";
            }
        }
        public DonSouplesseSerpent()
            : base(DonEnum.SouplesseDuSerpent, "Souplesse du serpent", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawDex >= 13 && mob.hasDon(DonEnum.Esquive);
        }
    }

}
