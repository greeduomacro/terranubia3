using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Items;

namespace Server.Spells
{
    public class SortManipDistance : BaseSort
    {
        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Transmutation; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Neutral; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public SortManipDistance()
            : base("Manip. à Distance")
        {

        }
        public override int getRange(NubiaMobile caster, int casterNiveau, DndStat stat)
        {
            return 5 + (int)(1.5 * casterNiveau);
        }
        protected override bool Execute(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle, object[] Args)
        {
            if (base.Execute(caster, casterNiveau, stat, cercle, Args))
            {
                //caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is ITelekinesisable)
                    {
                        ITelekinesisable targ = Args[a] as ITelekinesisable;
                        targ.OnTelekinesis(caster);
                        caster.SendMessage("Vous manipulez l'objet");
                    }
                    else
                        caster.SendMessage("Cet objet n'est pas manipulable");
                }
            }
            return false;
        }


    }

}
