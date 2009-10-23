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
                case 0: return 250;
                case 1: return 500;
                case 2: return 1000;
                case 3: return 2000;
                case 4: return 4000;
                case 5: return 6000;
                case 6: return 8000;
                case 7: return 10000;
                case 8: return 12000;
                case 9: return 13000;
               //
                case 10: return 14000;
                case 11: return 15000;
                case 12: return 16000;
                case 13: return 18000;
                case 14: return 20000;
                case 15: return 22000;
                case 16: return 24000;
                case 17: return 26000;
                case 18: return 28000;
                case 19: return 31000;
                case 20: return 35000;
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
            return ((double)cote / 10 );
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