using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompAcrobatie : NubiaCompetence
    {
        public override string Name { get { return "Acrobaties"; } }
        public override CompType CType { get { return CompType.Acrobaties; } }
        public override DndStat SType { get { return DndStat.Dexterite; } }
        public override bool LimitedByArmor { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            CompType.Saut, 
            CompType.Equilibre,};
        } }

        public CompAcrobatie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
