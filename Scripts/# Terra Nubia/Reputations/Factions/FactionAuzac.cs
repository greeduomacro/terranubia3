using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class FactionAuzac : BaseFaction
    {
        public override FactionEnum Faction { get { return FactionEnum.Auzac; } }

        public FactionAuzac()
        {
            mName = "Les partisans d'Auzac";
        }

        public override FactionEnum[] Enemies
        {
            get { return new FactionEnum[]{ FactionEnum.EdgarMoff }; }
        }
        public virtual FactionEnum[] Allys
        {
            get { return new FactionEnum[0]; }
        }


    }
}
