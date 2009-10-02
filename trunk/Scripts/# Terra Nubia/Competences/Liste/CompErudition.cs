using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompErudition : NubiaCompetence
    {
        public override string Name { get { return "Erudition"; } }
        public override CompType CType { get { return CompType.Erudition; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
                    //CompType.Erudition
        //    (int)CompType.UtilisationObjetsMagiques,
            // + Connaissance (Mystère)
            /*(int)CompType.Equilibre,*/};
            }
        }

        public CompErudition(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
