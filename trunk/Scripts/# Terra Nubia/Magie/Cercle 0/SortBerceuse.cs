using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortBerceuse : BaseSort
    {
        /**
         * Berceuse
         * 
                Enchantement (coercition) [mental]
                Niveau : Bard 0
                Composantes : V, G
                Temps d’incantation : 1 action simple
                Portée : moyenne (30 m + 3 m/niveau)
                Zone d’effet : créatures vivantes situées dans une étendue de 3 m de rayon
                Durée : concentration + 1 round/niveau (T)
                Jet de sauvegarde : Volonté, annule
                Résistance à la magie : oui
         * 
         * */

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Enchantement; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Malefic; } }
        public override SortTarget Target { get { return SortTarget.Zone; } }

        public SortBerceuse()
            : base("Berceuse")
        {
            mRange = 10; //FAUX
        }
        protected override bool Execute(NubiaMobile caster, object[] Args)
        {
            if (base.Execute(caster, Args))
            {
                caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is NubiaMobile)
                    {
                        NubiaMobile mob = Args[a] as NubiaMobile;
                        mob.Emote("*Dodo !*");
                    }
                }
            }
            return false;
        }

    }

}
