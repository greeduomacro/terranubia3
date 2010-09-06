using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public abstract class BaseFaction
    {

        

        public abstract FactionEnum Faction { get; }
        protected string mName = "base faction";

        public string Name
        {
            get { return mName; }
        }

        public virtual int ComputeBonus(NubiaPlayer p)
        {
            return 0;
        }
        public virtual FactionEnum[] Enemies
        {
            get { return new FactionEnum[0]; }
        }
        public virtual FactionEnum[] Allys
        {
            get { return new FactionEnum[0]; }
        }

    }
}
