using System;
using System.Collections.Generic;
using System.Text;
using Server.Spells;

namespace Server.Mobiles
{
    public class CompetenceMod
    {
        protected int mValue;
        protected CompType mComp = CompType.Survie;

        public int Value { get { return mValue; } }
        public CompType Comp { get { return mComp; } }

        public CompetenceMod(int value, CompType comp)
        {
            mValue = value;
            mComp = comp;
        }

    }
}
