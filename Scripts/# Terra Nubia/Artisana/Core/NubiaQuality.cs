using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public enum NubiaQualityEnum
    {
        Mauvaise = -1,
        Normale = 0,
        Bonne = 1,
        Excellente = 2,
        Maitre = 3
    }
    public class NubiaQuality
    {
        public static string getQualityName(NubiaQualityEnum q)
        {
            switch (q)
            {
                case NubiaQualityEnum.Mauvaise: return "Mauvaise facture";
                case NubiaQualityEnum.Normale: return string.Empty;
                case NubiaQualityEnum.Bonne: return "Bonne facture";
                case NubiaQualityEnum.Excellente: return "Excellente facture";
                case NubiaQualityEnum.Maitre: return "Facture de maitre";
            }
            return string.Empty;
        }
    }
}
