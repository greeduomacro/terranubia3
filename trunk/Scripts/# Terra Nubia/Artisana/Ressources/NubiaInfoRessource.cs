using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class NubiaInfoRessource
    {
        //Generalite
        protected string mName = "";
        protected double mDurabilite = 0.5;
        protected int mHue = 0;
        protected int mDiff = 10;
        //Armures
        protected int mGlobalAR = 0;
        protected int mResistanceFeu = 0;
        protected int mResistanceFroid = 0;
        protected int mResistanceAcide = 0;
        protected int mResistanceEnergie = 0;
        //Armes
        protected int mBonusAttaque = 0;
        protected int mBonusDegat = 0;

        [CommandProperty(AccessLevel.Developer)]
        public string Name { get { return mName; } set { mName = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double Durabilite { get { return mDurabilite; } set { mDurabilite = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int Hue { get { return mHue; } set { mHue = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int Diff { get { return mDiff; } set { mDiff = value; } }


        [CommandProperty(AccessLevel.Developer)]
        public int GlobalAR { get { return mGlobalAR; } set { mGlobalAR = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int ResistanceFeu { get { return mResistanceFeu; } set { mResistanceFeu = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int ResistanceFroid { get { return mResistanceFroid; } set { mResistanceFroid = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int ResistanceAcide { get { return mResistanceAcide; } set { mResistanceAcide = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int ResistanceEnergie { get { return mResistanceEnergie; } set { mResistanceEnergie = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int BonusAttaque { get { return mBonusAttaque; } set { mBonusAttaque = value; } }
        
        [CommandProperty(AccessLevel.Developer)]
        public int BonusDegat { get { return mBonusDegat; } set { mBonusDegat = value; } }


        public NubiaInfoRessource()
        {
        }

        public static NubiaRessourceType GetRessourceType(NubiaRessource res)
        {
            if ((int)res < (int)NubiaRessourceType.Metal)
                return NubiaRessourceType.Metal;
            else if ((int)res < (int)NubiaRessourceType.Cuir)
                return NubiaRessourceType.Cuir;
            else if ((int)res < (int)NubiaRessourceType.Os)
                return NubiaRessourceType.Os;
            else
                return NubiaRessourceType.Bois;
        }

        public static NubiaInfoRessource GetInfoRessource(NubiaRessource res)
        {
            NubiaInfoRessource infos = new NubiaInfoRessource();

            switch (res)
            {
                    ///// +1
                case NubiaRessource.Verdan:
                    infos.Name = "Verdan";
                    infos.Durabilite = 1;
                    infos.Hue = 1417;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Carriate:
                    infos.Name = "Carriate";
                    infos.Durabilite = 1;
                    infos.Hue = 2034;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Remiar:
                    infos.Name = "Remiar";
                    infos.Durabilite = 1;
                    infos.Hue = 2188;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Orafir:
                    infos.Name = "Orafir";
                    infos.Durabilite = 1;
                    infos.Hue = 1946;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Mythril:
                    infos.Name = "Mythril";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2049;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 1;
                    infos.Diff = 13;
                    break;

                    //// +2
                case NubiaRessource.Nafarite:
                    infos.Name = "Nafarite";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2176;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceAcide = 2;
                    break;
                case NubiaRessource.Revarium:
                    infos.Name = "Rêvarium";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2172;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;
                case NubiaRessource.Trechar:
                    infos.Name = "Trechar";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2171;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;
                case NubiaRessource.Floreas:
                    infos.Name = "Floreas";
                    infos.Durabilite = 1.5;
                    infos.Hue = 1948;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceFeu = 2;
                    break;

                    /// +4
                case NubiaRessource.Oragite:
                    infos.Name = "Oragite";
                    infos.Durabilite = 2;
                    infos.Hue = 2033;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Lonaris:
                    infos.Name = "Lonaris";
                    infos.Durabilite = 2;
                    infos.Hue = 1942;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Celiar:
                    infos.Name = "Celiar";
                    infos.Durabilite = 2;
                    infos.Hue = 2051;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 3;
                    infos.Diff = 17;
                    infos.ResistanceFroid = 1;
                    break;
                case NubiaRessource.Firatas:
                    infos.Name = "Firatas";
                    infos.Durabilite = 2;
                    infos.Hue = 1945;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceFeu = 1;
                    break;
                case NubiaRessource.Verate:
                    infos.Name = "Vérate";
                    infos.Durabilite = 2;
                    infos.Hue = 2173;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceFeu = 1;
                    infos.ResistanceEnergie = 1;
                    infos.ResistanceAcide = 1;
                    infos.ResistanceFroid = 1;
                    break;

                    ////+5
                case NubiaRessource.Drachior:
                    infos.Name = "Drachior";
                    infos.Durabilite = 3;
                    infos.Hue = 2158;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 3;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 2;
                    infos.ResistanceEnergie = 2;
                    infos.ResistanceAcide = 2;
                    infos.ResistanceFroid = 2;
                    break;
                case NubiaRessource.Glarias:
                    infos.Name = "Glarias";
                    infos.Durabilite = 3;
                    infos.Hue = 2158;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 2;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 3;
                    infos.ResistanceEnergie = 3;
                    infos.ResistanceAcide = 3;
                    infos.ResistanceFroid = 3;
                    break;
                case NubiaRessource.Nethar:
                    infos.Name = "Nethar";
                    infos.Durabilite = 3;
                    infos.Hue = 1940;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 0;
                    infos.Diff = 18;
                    infos.ResistanceFroid = 3;
                    break;
                case NubiaRessource.Divarium:
                    infos.Name = "Divarium";
                    infos.Durabilite = 3;
                    infos.Hue = 1953;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 3;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 1;
                    infos.ResistanceEnergie = 1;
                    infos.ResistanceAcide = 1;
                    infos.ResistanceFroid = 1;
                    break;
                case NubiaRessource.Palerias:
                    infos.Name = "Palerias";
                    infos.Durabilite = 3;
                    infos.Hue = 1944;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 4;
                    infos.BonusDegat = 0;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 1;
                    infos.ResistanceEnergie = 1;
                    infos.ResistanceAcide = 1;
                    infos.ResistanceFroid = 1;
                    break;
                case NubiaRessource.Nirior:
                    infos.Name = "Nirior";
                    infos.Durabilite = 3;
                    infos.Hue = 1944;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 4;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 2;
                    infos.ResistanceEnergie = 2;
                    infos.ResistanceAcide = 2;
                    infos.ResistanceFroid = 2;
                    break;

            }

            return infos;
        }
    }
}