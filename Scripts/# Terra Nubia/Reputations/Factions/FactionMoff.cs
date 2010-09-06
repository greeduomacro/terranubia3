using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class FactionMoff : BaseFaction
    {
        public override FactionEnum Faction { get { return FactionEnum.EdgarMoff; } }

        public FactionMoff()
        {
            mName = "Les partisans d'Edgar Moff";
        }

        public override FactionEnum[] Enemies
        {
            get { return new FactionEnum[] { FactionEnum.Auzac }; }
        }
        public virtual FactionEnum[] Allys
        {
            get { return new FactionEnum[0]; }
        }


    }
}
