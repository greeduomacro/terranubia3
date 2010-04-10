using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Items;
using Server.Misc;

namespace Server
{
    public enum De
    {
        trois = 3,
        quatre = 4,
        six = 6,
        huit = 8,
        dix = 10,
        douze = 12,
        vingt = 20
    }
    public  class DndHelper
    {
      /*  public static int getDonTotal(int Niveau)
        {
            return ( Niveau / 3 ) + 1;
        }*/
        public static string nomDe(De de, int nbr)
        {
            return nbr.ToString() + "d" + ((int)de).ToString();
        }
        public static int rollDe(De de)
        {
            return rollDe(de, 1);
        }
        public static int rollDe(De de, int nbr)
        {
            int roll = 0;
            for (int i = 0; i < nbr; i++)
                roll += Utility.RandomMinMax(1, (int)de);
            return roll;
        }
        public static int getMaitriseMax(int niveau)
        {
            if (niveau < 5)
                return 2;
            else if (niveau < 10)
                return 3;
            else if (niveau < 15)
                return 4;
            else
                return 5;
        }
        public static int getTotalMaitrise(int niveau)
        {
            return 3 + ( (niveau / 5)*2 );
        }

        public static int getTotalStat(int niveau)
        {
            return (10 * 6) /*Charac de départ*/ + 10 /*10 charac création*/ + (niveau / 4);
        }

        public static bool CaracModIsLimited(NubiaMobile from, DndStat stat)
        {
            return (GetCaracMod(from, stat, true) > GetCaracMod(from, stat, false));
        }
        public static double GetCaracMod(NubiaMobile from, DndStat stat)
        {
            return GetCaracMod(from, stat, false);
        }
        public static double GetCaracMod(NubiaMobile from, DndStat stat, bool bypass)
        {
            //Table des modificateur.
            //J'ai multiplier par 5 le niveau nessecaire pour obtenir le modificateur
            //Donc un 20 dnd équivaut a 100 Nubia
            //100 donnera +5.0
            double mod = 0;
            if (stat == DndStat.Dexterite)
                mod = from.Dex;
            else if (stat == DndStat.Force)
                mod = from.Str;
            else if (stat == DndStat.Intelligence)
                mod = from.Int;
            else if (stat == DndStat.Sagesse)
                mod = from.Sag;
            else if (stat == DndStat.Charisme)
                mod = from.Cha;
            else if (stat == DndStat.Constitution)
                mod = from.Cons;

            mod /= 2;
            mod -= 5;
            if (stat == DndStat.Dexterite && !bypass)
            {
                int limit = GetDexArmorLimite(from);
                if (mod > limit)
                    mod = limit;
            }
            //    Console.WriteLine("- Bonus de Carac: {0} / +{1}", c, (int)mod);
            return mod;
        }

        public static double GetArmorCA(NubiaMobile mob)
        {
            double BACA = 0;
            if (mob is BaseCreature)
            {
                BaseCreature creature = mob as BaseCreature;
                BACA = creature.VirtualArmor;
            }
            else
            {
                for (int i = 0; i < 22; i++)
                {
                    Item item = mob.FindItemOnLayer((Layer)i);
                    if (item != null)
                    {
                        if (item is NubiaArmor)
                        {
                            NubiaArmor armor = item as NubiaArmor;
                            //    Console.WriteLine("{0} donne {1}", armor, GetCAFromType(armor.MaterialType));
                            BACA += armor.CA;
                        }
                        /*if (item is NubiaShield)
                        {
                            NubiaShield bouclier = item as NubiaShield;
                            BACA += bouclier.CA;
                        }*/
                    }
                }
            }
            //   Console.WriteLine("Bonus d'armure à la CA: " + BACA);
            return BACA;
        }
        public static NubiaArmor GetBiggerArmor(NubiaMobile mob)
        {
            NubiaArmor toReturn = null;
            for (int i = 0; i < 22; i++)
            {
                Item item = mob.FindItemOnLayer((Layer)i);
                if (item != null)
                {
                    if (item is NubiaArmor)
                    {
                        NubiaArmor armor = item as NubiaArmor;
                        if (toReturn == null)
                            toReturn = armor;
                        else if (toReturn.ModelType < armor.ModelType)
                            toReturn = armor;
                    }
                }
            }
            return toReturn;
        }

        public static int GetDDArmorMalus(NubiaMobile mob)
        {
            NubiaArmor armor = GetBiggerArmor(mob);
            int malus = 0;
            if (armor != null)
                malus = armor.MalusArmure;

            Item item = mob.FindItemOnLayer(Layer.TwoHanded);
            if (item != null)
            {
                if (item is NubiaShield)
                {
                    NubiaShield bouclier = item as NubiaShield;
                    if (bouclier.MalusArmure < malus)
                        malus = bouclier.MalusArmure;
                }
            }

            return malus;
        }
        public static int GetDexArmorLimite(NubiaMobile mob)
        {
            NubiaArmor armor = GetBiggerArmor(mob);
            int limit = 50;
            if (armor != null)
                limit = armor.ModDexMaximum;

            Item item = mob.FindItemOnLayer(Layer.TwoHanded);
            if (item != null)
            {
                if (item is NubiaShield)
                {
                    NubiaShield bouclier = item as NubiaShield;
                    if (bouclier.ModDexMaximum < limit)
                        limit = bouclier.ModDexMaximum;
                }
            }

            return limit;
        }

    }
}
