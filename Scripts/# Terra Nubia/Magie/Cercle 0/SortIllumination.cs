using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortIllumination : BaseSort
    {
        /**
         Évocation [lumière]
         * 
            Niveau : Bard 0, Dru 0, Ens/Mag 0
            Composantes : V
            Temps d’incantation : 1 action simple
            Portée : courte (7,50 m + 1,50 m/2 niveaux)
            Effet : rayonnement de lumière
            Durée : instantanée
            Jet de sauvegarde : Vigueur, annule
            Résistance à la magie : oui
         * 
         * */

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return false; } }
        public override MagieEcole Ecole { get { return MagieEcole.Evocation; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Malefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }
        public virtual SauvegardeEnum Sauvegarde { get { return SauvegardeEnum.Vigueur; } }

        public SortIllumination()
            : base("Illumination")
        {
        }
        /* public override void doVerbal(Server.Mobiles.NubiaMobile caster)
         {
             caster.Emote("*Chante*");
             caster.Say("Dormez, dormez...");
         }*/
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
                        if (CheckResiste(caster, mob, cercle, stat) || CheckRM(caster, mob, casterNiveau) )
                        {
                            mob.Emote("*Eblouï*");
                            new IlluminationDebuff(caster, mob);
                        }
                    }
                }
            }
            return false;
        }
        public class IlluminationDebuff : BaseDebuff
        {
            public IlluminationDebuff(NubiaMobile caster, NubiaMobile cible)
                : base(caster, cible, 2245, 2, "Illumination")
            {

                Sauvegardes.Add(new SauvegardeMod(-1, SauvegardeEnum.Attaque));
                cible.Freeze(TimeSpan.FromMilliseconds(500));
                m_descrip += "Vous êtes éblouï";
            }

        }


    }

}
