using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompConcentration : NubiaCompetence
    {
        public override string Name { get { return "Concentration"; } }
        public override CompType CType { get { return CompType.Concentration; } }
        public override DndStat SType { get { return DndStat.Constitution; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
        //    (int)CompType.UtilisationObjetsMagiques,
            // + Connaissance (Mystère)
            /*(int)CompType.Equilibre,*/};
            }
        }

        public CompConcentration(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
