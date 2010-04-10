using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles.NubiaFaction
{
    public class FactionCiteVent : BaseFaction
    {
        public override FactionEnum Faction { get { return FactionEnum.CiteVent; } }

        public FactionCiteVent()
        {
            mName = "Cité des vents";
        }

        public override FactionEnum[] Enemies
        {
            get { return new FactionEnum[0]; }
        }
        public virtual FactionEnum[] Allys
        {
            get { return new FactionEnum[0]; }
        }

        public override int ComputeBonus(NubiaPlayer p)
        {
            int bonus = base.ComputeBonus(p);
            bonus += 250;
            return bonus;
        }

    }
}
