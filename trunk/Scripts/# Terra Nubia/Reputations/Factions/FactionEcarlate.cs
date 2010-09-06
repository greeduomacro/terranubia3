using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class FactionEcarlate : BaseFaction
    {
        public override FactionEnum Faction { get { return FactionEnum.MainEcarlate; } }

        public FactionEcarlate()
        {
            mName = "La main écarlate";
        }

        public override FactionEnum[] Enemies
        {
            get { return new FactionEnum[] { FactionEnum.MilleVisage }; }
        }
        public virtual FactionEnum[] Allys
        {
            get { return new FactionEnum[0]; }
        }

        public override int ComputeBonus(NubiaPlayer p)
        {
            return base.ComputeBonus(p);
        }


    }
}
