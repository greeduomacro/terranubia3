using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class CompArtMagie : NubiaCompetence
    {
        public override string Name { get { return "Art de la magie"; } }
        public override CompType CType { get { return CompType.ArtMagie; } }
        public override DndStat SType { get { return DndStat.Intelligence; } }
        public override bool LimitedByArmor { get { return false; } }
        //public override bool MustLearn { get { return true; } }
        public override CompType[] SynergieTab
        {
            get
            {
                return new CompType[]{
            CompType.UtilisationObjetsMagiques,
            // + Connaissance (Mystère)
            /*(int)CompType.Equilibre,*/};
            }
        }

        public CompArtMagie(NubiaMobile m)
            : base(m)
        {
        }
        public override void onUse()
        {
            base.onUse();
        }
    }
}
