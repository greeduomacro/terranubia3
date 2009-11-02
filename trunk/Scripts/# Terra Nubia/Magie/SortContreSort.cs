using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Spells
{
    public class SortContreSort : BaseSort
    {

        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Abjuration; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Malefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }
        public override TimeSpan Delay { get { return TimeSpan.FromSeconds(5); } }

        public SortContreSort()
            : base("Contre-Sort")
        {
        }
        public override void doVerbal(NubiaMobile caster)
        {
            caster.Emote("*Contre-incante*");
        }
        protected override bool CheckResiste(NubiaMobile caster, NubiaMobile cible, int cercle, DndStat stat)
        {
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
                       
                    }
                }
            }
            return false;
        }


    }

}
