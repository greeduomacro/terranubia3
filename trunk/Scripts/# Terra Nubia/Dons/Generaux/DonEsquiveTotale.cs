using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEsquiveTotale : BaseDon
    {
        public override int Icone { get { return 2261; } }
        public override string Description
        {
            get
            {
                return "Esquive totale (Ext). L’agilité presque surhumaine d’un moine de niveau 2 lui permet d’éviter les attaques magiques ou inhabituelles. S’il réussit son jet de Réflexes contre une attaque dont les dégâts sont normalement réduits de moitié en cas de jet de Réflexes réussi (comme c’est le cas pour une boule de feu ou le souffle enflammé d’un dragon rouge), il l’évite totalement et ne subit pas le moindre dégât. Un moine portant une armure intermédiaire ou lourde, ou qui se trouve sans défense (parce qu’il est inconscient ou paralysé, par exemple) perd les avantages de d’esquive totale.";
            }
        }
        public DonEsquiveTotale()
            : base(DonEnum.EsquiveTotale, "Esquive totale", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.hasDon(DonEnum.Esquive) && mob.Dex >= 15;
        }
       
    }

}
