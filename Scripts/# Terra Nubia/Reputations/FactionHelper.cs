using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public class FactionHelper
    {
        public static BaseFaction getFaction(FactionEnum fac)
        {

            if (ReputationStack.FactionsBank.ContainsKey(fac))
            {
                return ReputationStack.FactionsBank[fac];
            }
            else
              return null;
        }

        public static bool friendOf(FactionEnum fac1, FactionEnum fac2)
        {
            BaseFaction factionA = getFaction(fac1);
            if (factionA != null)
            {
                for (int i = 0; i < factionA.Allys.Length; i++)
                {
                    if (factionA.Allys[i] == fac2)
                        return true;
                }
            }
            return false;
        }

        public static double getValAI(ReputationEnum rep)
        {
            switch (rep)
            {
                case ReputationEnum.EnemiAncestral: return 130;
                case ReputationEnum.HaineArdente: return 120;
                case ReputationEnum.HaineProfonde: return 110;
                case ReputationEnum.Haine: return 100;
                case ReputationEnum.Deteste: return 80;
                case ReputationEnum.Deprecie: return 60;
                case ReputationEnum.Inamical: return 40;
                case ReputationEnum.Neutre: return 10;
                case ReputationEnum.Indulgence: return 5;
                case ReputationEnum.Tolere: return 4;
                case ReputationEnum.Amical: return 1;
                case ReputationEnum.Adore: return 0;
                case ReputationEnum.Revere: return -5;
                case ReputationEnum.Exalte: return -10;
                case ReputationEnum.AllieAncestral: return -20;
            }
            return 0;
        }

        public static int getHueForReput( ReputationEnum rep){
            switch(rep){
                case ReputationEnum.EnemiAncestral: return 38;
                case ReputationEnum.HaineArdente: return 39;
                case ReputationEnum.HaineProfonde: return 43;
                case ReputationEnum.Haine: return 44;
                case ReputationEnum.Deteste: return 48;
                case ReputationEnum.Deprecie: return 49;
                case ReputationEnum.Inamical: return 50;
                case ReputationEnum.Neutre: return 51;
                case ReputationEnum.Indulgence: return 56;
                case ReputationEnum.Tolere: return 61;
                case ReputationEnum.Amical: return 65;
                case ReputationEnum.Adore: return 59;
                case ReputationEnum.Revere: return 58;
                case ReputationEnum.Exalte: return 95;
                case ReputationEnum.AllieAncestral: return 94;
            }
            return 0;
        }

        public static string getNameForReput(ReputationEnum rep)
        {
            switch (rep)
            {
                case ReputationEnum.EnemiAncestral: return "Enemi Ancestral";
                case ReputationEnum.HaineArdente: return "Ardement haï";
                case ReputationEnum.HaineProfonde: return "Profondément haï";
                case ReputationEnum.Haine: return "Haï";
                case ReputationEnum.Deteste: return "Déstesté";
                case ReputationEnum.Deprecie: return "Déprécié";
                case ReputationEnum.Inamical: return "Peu apprécié";
                case ReputationEnum.Neutre: return "Neutre";
                case ReputationEnum.Indulgence: return "Indulgence";
                case ReputationEnum.Tolere: return "Toléré";
                case ReputationEnum.Amical: return "Amitié";
                case ReputationEnum.Adore: return "Adoré";
                case ReputationEnum.Revere: return "Rêvéré";
                case ReputationEnum.Exalte: return "Exalté";
                case ReputationEnum.AllieAncestral: return "Allié Ancestral";
            }
            return "Haie?Neutre?ami?";
        }

        public static ReputationEnum getReputForVal(int rep)
        {
           /*EnemiAncestral = -7,
        HaineArdente = -6,
        HaineProfonde = -5,
        Haine = -4,
        Deteste = -3,
        Deprecie = -2,
        Inamical = -1,
        Neutre = 0,
        Indulgence = 1,
        Tolere = 2,
        Amical = 3,
        Adore = 4,
        Revere = 5,
        Exalte = 6,
        AllieAncestral = 7,*/
            if (rep <= -700)
                return ReputationEnum.EnemiAncestral;
            else if (rep <= -600)
                return ReputationEnum.HaineArdente;
            else if (rep <= -500)
                return ReputationEnum.HaineProfonde;
            else if (rep <= -400)
                return ReputationEnum.Haine;
            else if (rep <= -300)
                return ReputationEnum.Deteste;
            else if (rep <= -200)
                return ReputationEnum.Deprecie;
            else if (rep <= -100)
                return ReputationEnum.Inamical;
            else if (rep <= 0)
                return ReputationEnum.Neutre;
            else if (rep <= 100)
                return ReputationEnum.Indulgence;
            else if (rep <= 200)
                return ReputationEnum.Tolere;
            else if (rep <= 300)
                return ReputationEnum.Amical;
            else if (rep <= 400)
                return ReputationEnum.Adore;
            else if (rep <= 500)
                return ReputationEnum.Revere;
            else if (rep <= 600)
                return ReputationEnum.Exalte;
            else if (rep > 600)
                return ReputationEnum.AllieAncestral;

            return ReputationEnum.EnemiAncestral;
        }
    }
}