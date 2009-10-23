using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortSommeil : BaseSort
    {
        /*/
         * Sommeil
        Enchantement (coercition) [mental]
        Niveau : Bard 1, Ens/Mag 1
        Composantes : V, G, M
        Temps d’incantation : 1 round
        Portée : moyenne (30 m + 3 m/niveau)
        Zone d’effet : 1 ou plusieurs créatures vivantes dans un rayonnement de 3 m de rayon
        Durée : 1 minute/niveau
        Jet de sauvegarde : Volonté, annule
        Résistance à la magie : oui

 */

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Enchantement; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Malefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }
        public override SauvegardeEnum Sauvegarde
        {
            get
            {
                return SauvegardeEnum.Volonte;
            }
        }

        public SortSommeil()
            : base("Sommeil")
        {
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
                        if (CheckResiste(caster, mob, cercle, stat) || CheckRM(caster, mob, casterNiveau))
                        {
                            mob.Emote("*s'endort*");
                            new SommeilDebuff(caster, mob, 5 + Math.Min( casterNiveau/2, 5) );
                        }
                    }
                }
            }
            return false;
        }

        public class SommeilDebuff : BaseDebuff
        {
            public SommeilDebuff(NubiaMobile caster, NubiaMobile cible, int tours)
                : base(caster, cible, 2242, tours, "Sommeil")
            {

                Sauvegardes.Add(new SauvegardeMod(-5, SauvegardeEnum.Reflexe));
                Sauvegardes.Add(new SauvegardeMod(-5, SauvegardeEnum.Volonte));
                Competences.Add(new CompetenceMod(-5, CompType.All));
                cible.Freeze(TimeSpan.FromMilliseconds(8000));
                m_descrip += "Vous êtes endormis";
            }

            public override bool OnTurn()
            {

                if (base.OnTurn())
                {
                    string zz = "*ZzZ*";
                    if (Utility.RandomBool())
                        zz = "*zZz*";
                    Cible.Emote(zz);
                    Cible.Freeze(TimeSpan.FromMilliseconds(8000));
                    return true;
                }
                return false;
            }
            public override void End()
            {
                if( Cible != null && Cible.Alive )
                    Cible.Emote("*se réveille*");
                base.End();
            }
        }

    }

}
