using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortHebetement : BaseSort
    {
        /**
         *Hébétement
         *
            Enchantement (coercition) [mental]
            Niveau : Bard 0, Ens/Mag 0
            Composantes : V, G, M
            Temps d’incantation : 1 action simple
            Portée : courte (7,50 m + 1,50 m/2 niveaux)
            Cible : 1 humanoïde de 4 DV ou moins
            Durée : 1 round
            Jet de sauvegarde : Volonté, annule
            Résistance à la magie : oui

            Cet enchantement brouille les idées d’un humanoïde de 4 dés de vie ou moins, ce qui l’empêche d’entreprendre la moindre action. Les humanoïdes ayant au moins 5 DV sont immunisés contre l’hébétement. La victime n’est pas étourdie. Ses adversaires ne bénéficient donc d’aucun avantage.
            Composante matérielle : un peu de laine ou matière similaire.
         * 
         * */

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Enchantement; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Malefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public SortHebetement()
            : base("Hébêtement")
        {
        }
       /* public override void doVerbal(Server.Mobiles.NubiaMobile caster)
        {
            caster.Emote("*Chante*");
            caster.Say("Dormez, dormez...");
        }*/
        public override bool CheckResiste(NubiaMobile cible, ClasseType classe, int cercle)
        {
           return cible.HitsMax <= (4 * cible.Niveau);
        }
        protected override bool Execute(NubiaMobile caster, ClasseType classe, int cercle, Object[] Args)
        {
            if (base.Execute(caster, classe, cercle, Args))
            {
                //caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is NubiaMobile)
                    {
                        NubiaMobile mob = Args[a] as NubiaMobile;
                        if (CheckResiste(mob, classe, cercle))
                        {
                            mob.Emote("*Hébêté*");
                            new HebetementDebuff(caster, mob);
                        }
                    }
                }
            }
            return false;
        }
        public class HebetementDebuff : BaseDebuff
        {
            public HebetementDebuff(NubiaMobile caster, NubiaMobile cible)
                : base(caster, cible, 2242, 2, "Hébêtement")
            {
                
                Sauvegardes.Add(new SauvegardeMod(-5, SauvegardeEnum.Reflexe));
                Competences.Add(new CompetenceMod(-5, CompType.All));
                cible.Freeze(TimeSpan.FromMilliseconds(500));
                m_descrip += "Vos idées sont brouillées";
            }

        }


    }

}
