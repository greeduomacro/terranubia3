using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles.NubiaFaction
{
    public class FactionNature : BaseFaction
    {
        public override FactionEnum Faction { get { return FactionEnum.Nature; } }

        public FactionNature()
        {
            mName = "Nature & Animaux";
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
            bonus -= 100; //Naturellement agressif
            if (p.Race is RaceDemiElfe)
                bonus += 100;
            else if (p.Race is RaceElfeLune)
                bonus += 150;
            else if (p.Race is RaceDemiOrc)
                bonus -= 100;
            else if (p.Race is RaceHumain)
                bonus -= 50;

            foreach (Classe c in p.GetClasses())
            {
                if (c is ClasseDruide)
                    bonus += 150;                
                else if (c is ClasseRodeur)
                    bonus += 100;
            }

            return bonus;
        }

    }
}
