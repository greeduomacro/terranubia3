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
        public override NSortTarget STarget { get { return NSortTarget.Zone; } }
        public virtual SauvegardeEnum Sauvegarde { get { return SauvegardeEnum.Volonte; } }

        public SortBerceuse()
            : base("Berceuse")
        {

        }
        public override int getRange(NubiaMobile caster, int casterNiveau, DndStat stat)
        {
            return 5 + (int)(1.5 * casterNiveau);
        }
       
        public override void doVerbal(NubiaMobile caster)
        {
            caster.Emote("*Chante*");
            caster.Say("Dormez, dormez...");
        }
        protected override bool Execute(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle, object[] Args)
        {
            if (base.Execute(caster,casterNiveau, stat, cercle, Args))
            {
                //caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is NubiaMobile)
                    {
                        NubiaMobile mob = Args[a] as NubiaMobile;
                        if (mob.CanSee(caster))
                        {
                            if ( !CheckResiste(mob, mob, cercle, stat) && !CheckRM(caster, mob, casterNiveau ) )
                            {
                                mob.Emote("*Baille*");
                                int niveau = 5;
                                if (caster is NubiaPlayer)
                                    niveau = ((NubiaPlayer)caster).Niveau;
                                new BerceuseDebuff(caster, mob, (int)caster.Competences[CompType.Concentration].getMaitrise() + niveau);
                            }
                        }
                    }
                }
            }
            return false;
        }
        public class BerceuseDebuff : BaseDebuff
        {
            public BerceuseDebuff(NubiaMobile caster, NubiaMobile cible, int roundDure)
                : base(caster, cible, 2242, roundDure, "Berceuse")
            {
                Sauvegardes.Add( new SauvegardeMod(-2, SauvegardeEnum.Volonte, new MagieEcole[]{ MagieEcole.Enchantement } ) );
                Competences.Add(new CompetenceMod(-5, CompType.Detection));
                Competences.Add(new CompetenceMod(-5, CompType.PerceptionAuditive));
                m_descrip += "Vos paupières sont lourdes. Vous êtes un peu endormi, vous baillez facilement et votre attention est réduite";
            }
           
        }
       

    }

}
