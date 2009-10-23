using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortSoinLeger : BaseSort
    {
        /**
         *Hébétement
         *
         Soins légers
            Invocation (guérison)
            Niveau : Bard 1, Dru 1, Guérison 1, Pal 1, Prê 1, Rôd 2
            Composantes : V, G
            Temps d’incantation : 1 action simple
            Portée : contact
            Cible : créature touchée
            Durée : instantanée
            Jet de sauvegarde : Volonté, 1/2 dégâts (inoffensif) (voir description)
            Résistance à la magie : oui (inoffensif) (voir description)
         * */

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Ivocation; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Benefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public SortSoinLeger()
            : base("Soin leger")
        {
        }
        protected override bool CheckResiste(NubiaMobile caster, NubiaMobile cible, int cercle, DndStat stat)
        {
            if (cible is NubiaPlayer)
            {
                return ((NubiaPlayer)cible).Niveau > 4;
            }
            else if (cible is NubiaCreature)
            {
                return ((NubiaCreature)cible).Niveau > 4;
            }
            return false;
        }

        protected override bool Execute(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle, object[] Args)
        {
            if (base.Execute(caster, casterNiveau, stat, cercle, Args))
            {
                //caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is NubiaMobile)
                    {
                        NubiaMobile mob = Args[a] as NubiaMobile;
                        mob.Heal(DndHelper.rollDe(De.huit) + Math.Min(casterNiveau, 5), caster, true);
                        mob.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
                        mob.PlaySound(0x1F2);
                    }
                }
            }
            return false;
        }
     


    }

}
