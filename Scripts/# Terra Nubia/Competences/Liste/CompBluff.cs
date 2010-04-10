using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompBluff : NubiaCompetence
    {
        public override string Name { get { return "Bluff"; } }
        public override CompType CType { get { return CompType.Bluff; } }
        public override DndStat SType { get { return DndStat.Charisme; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    CompType.Diplomatie,
                    CompType.Escamotage,
                    CompType.Intimidation
        //    (int)CompType.UtilisationObjetsMagiques,
            // + Connaissance (Mystère)
            /*(int)CompType.Equilibre,*/};
            }
        }

        public CompBluff(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
