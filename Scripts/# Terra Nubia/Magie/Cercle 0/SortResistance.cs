using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Items;

namespace Server.Spells
{
    public class SortResistance : BaseSort
    {
        public override bool ComposanteVerbal { get { return false; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Abjuration; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Benefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public SortResistance()
            : base("Resistance")
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
                    NubiaMobile mob = Args[a] as NubiaMobile;
                    new ResistanceBuff(caster, mob);
                }
            }
            return false;
        }


    }
    public class ResistanceBuff : BaseBuff
    {
        public ResistanceBuff(NubiaMobile caster, NubiaMobile cible)
            : base(caster, cible, 2246, 8, "Resistance")
        {

            Sauvegardes.Add(new SauvegardeMod(1, SauvegardeEnum.Reflexe));
            Sauvegardes.Add(new SauvegardeMod(1, SauvegardeEnum.Vigueur));
            Sauvegardes.Add(new SauvegardeMod(1, SauvegardeEnum.Volonte));
            m_descrip += "Vous vous sentez plus resistant aux menaces extérieurs";
        }

    }

}
