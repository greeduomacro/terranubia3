using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Items;

namespace Server
{
    public class XPHelper
    {
        public static int getMaximumXPJour(int cote)
        {
            switch (cote)
            {
                case 0: return 25;
                case 1: return 50;
                case 2: return 100;
                case 3: return 200;
                case 4: return 400;
                case 5: return 600;
                case 6: return 800;
                case 7: return 1000;
                case 8: return 1200;
                case 9: return 1300;
               //
                case 10: return 1400;
                case 11: return 1500;
                case 12: return 1600;
                case 13: return 1800;
                case 14: return 2000;
                case 15: return 2200;
                case 16: return 2400;
                case 17: return 2600;
                case 18: return 2800;
                case 19: return 3100;
                case 20: return 3500;
                //
            }
            return 1400;
        }
        public static double getXPFactor(int cote)
        {
            switch (cote)
            {
                case 10: return 1.0;
                case 11: return 1.07;
                case 12: return 1.14;
                case 13: return 1.30;
                case 14: return 1.40;
                case 15: return 1.55;
                case 16: return 1.70;
                case 17: return 1.85;
                case 18: return 2.00;
                case 19: return 2.20;
                case 20: return 2.50;
            }
            return 1;
        }
        public static int GetClasseNiv(int LevelGlobal)
        {
            return LevelGlobal;
        }
        public static int GetXpForLevel(int Level)
        {
            double need = (double)WorldData.XpMultiplier * (Math.Pow((double)Level, 1.45));
            if (Level > 20) //Prestige
                need *= 20;
            return (int)need;
        }
        public static int GetLevelForXP(int XP)
        {
            int niveau = 0;
            int xpLevel = 0;
            while (xpLevel < XP && niveau < 20)
            {
                niveau++;
                xpLevel += GetXpForLevel(niveau);
            }
            return niveau;
        }
    }
}