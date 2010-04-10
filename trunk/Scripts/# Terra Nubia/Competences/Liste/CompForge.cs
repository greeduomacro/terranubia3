using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompForge : NubiaCompetence
    {
        public override string Name { get { return "Forge & Ferronerie"; } }
        public override CompType CType { get { return CompType.Forge; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return false; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
        /*    (int)CompType.UtilisationObjetsMagiques,*/
            // + Connaissance (Mystère)
            /*(int)CompType.Equilibre,*/};
            }
        }

        public CompForge(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
