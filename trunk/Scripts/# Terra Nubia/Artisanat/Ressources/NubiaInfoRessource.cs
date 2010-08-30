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
            if ((int)res < (int)NubiaRessourceType.Cuir)
                return NubiaRessourceType.Metal;
            else if ((int)res < (int)NubiaRessourceType.Os)
                return NubiaRessourceType.Cuir;
            else if ((int)res < (int)NubiaRessourceType.Bois)
                return NubiaRessourceType.Os;
            else
                return NubiaRessourceType.Bois;
        }

        public static NubiaInfoRessource GetInfoRessource(NubiaRessource res)
        {
            NubiaInfoRessource infos = new NubiaInfoRessource();

            switch (res)
            {
                #region metal
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
                    infos.Hue = 2263;
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
                    infos.Diff = 17;
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
                #endregion

                #region Cuir
                    //+1
                case NubiaRessource.Ophidian:
                    infos.Name = "Ophidian";
                    infos.Durabilite = 1;
                    infos.Hue = 1417;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Demoniaque:
                    infos.Name = "Démoniaque";
                    infos.Durabilite = 1;
                    infos.Hue = 1417;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Sang:
                    infos.Name = "Sang";
                    infos.Durabilite = 1;
                    infos.Hue = 2034;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Rageur:
                    infos.Name = "Rageur";
                    infos.Durabilite = 1;
                    infos.Hue = 1946;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Gargoulien:
                    infos.Name = "Gargoulien";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2263;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 1;
                    infos.Diff = 13;
                    break;
                    //+2
                case NubiaRessource.Lupus:
                    infos.Name = "Lupus";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2176;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceAcide = 2;
                    break;
                case NubiaRessource.Maritime:
                    infos.Name = "Maritime";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2172;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;
                case NubiaRessource.Givre:
                    infos.Name = "Givre";
                    infos.Durabilite = 1.5;
                    infos.Hue = 1948;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceFeu = 2;
                    break;
                    //+4
                case NubiaRessource.Chair:
                    infos.Name = "Chair";
                    infos.Durabilite = 2;
                    infos.Hue = 2033;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Balron:
                    infos.Name = "Balron";
                    infos.Durabilite = 2;
                    infos.Hue = 1942;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Reptilien:
                    infos.Name = "Reptilien";
                    infos.Durabilite = 2;
                    infos.Hue = 2051;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 3;
                    infos.Diff = 17;
                    infos.ResistanceFroid = 1;
                    break;
                case NubiaRessource.Terathan:
                    infos.Name = "Terathan";
                    infos.Durabilite = 2;
                    infos.Hue = 1945;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceFeu = 1;
                    break;
                case NubiaRessource.Draconique:
                    infos.Name = "Draconique";
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
                    //+5
                case NubiaRessource.Geant:
                    infos.Name = "Géant";
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
                case NubiaRessource.Rautour:
                    infos.Name = "Rautour";
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
                case NubiaRessource.Pierre:
                    infos.Name = "Pierre";
                    infos.Durabilite = 3;
                    infos.Hue = 1940;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 0;
                    infos.Diff = 18;
                    infos.ResistanceFroid = 3;
                    break;
                case NubiaRessource.Legendaire:
                    infos.Name = "Légendaire";
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
                case NubiaRessource.Nordique:
                    infos.Name = "Nordique";
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
                case NubiaRessource.Volcanique:
                    infos.Name = "Volcanique";
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
                case NubiaRessource.Hydro:
                    infos.Name = "Hydro";
                    infos.Durabilite = 3;
                    infos.Hue = 1944;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 4;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 2;
                    infos.ResistanceEnergie = 2;
                    infos.ResistanceAcide = 2;
                    infos.ResistanceFroid = 2;
                    break;
                #endregion

                #region Os
                case NubiaRessource.Morcith:
                    infos.Name = "Morcith";
                    infos.Durabilite = 1;
                    infos.Hue = 1417;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Ardent:
                    infos.Name = "Ardent";
                    infos.Durabilite = 1;
                    infos.Hue = 2034;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Desertique:
                    infos.Name = "Désertique";
                    infos.Durabilite = 1;
                    infos.Hue = 2188;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Harpie:
                    infos.Name = "Harpie";
                    infos.Durabilite = 1;
                    infos.Hue = 1946;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Ssins:
                    infos.Name = "Ssins";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2263;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 1;
                    infos.Diff = 13;
                    break;
                    

                    // +2
                case NubiaRessource.Tyranoeil:
                    infos.Name = "Tyranoeil";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2176;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceAcide = 2;
                    break;
                case NubiaRessource.Gargouille:
                    infos.Name = "Gargouille";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2172;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;
                case NubiaRessource.Blub:
                    infos.Name = "Blub";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2171;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;
                case NubiaRessource.Vengeur:
                    infos.Name = "Vengeur";
                    infos.Durabilite = 1.5;
                    infos.Hue = 1948;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceFeu = 2;
                    break;

                // +4
                case NubiaRessource.Centorius:
                    infos.Name = "Centorius";
                    infos.Durabilite = 2;
                    infos.Hue = 2033;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Detracteur:
                    infos.Name = "Détracteur";
                    infos.Durabilite = 2;
                    infos.Hue = 1942;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Arachnique:
                    infos.Name = "Arachnique";
                    infos.Durabilite = 2;
                    infos.Hue = 2051;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 3;
                    infos.Diff = 17;
                    infos.ResistanceFroid = 1;
                    break;
                case NubiaRessource.Feerique:
                    infos.Name = "Féerique";
                    infos.Durabilite = 2;
                    infos.Hue = 1945;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceFeu = 1;
                    break;
                case NubiaRessource.Feu:
                    infos.Name = "Feu";
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

                // +5
                case NubiaRessource.Morgalin:
                    infos.Name = "Morgalin";
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
                case NubiaRessource.Celeste:
                    infos.Name = "Céleste";
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
                case NubiaRessource.Mythique:
                    infos.Name = "Mythique";
                    infos.Durabilite = 3;
                    infos.Hue = 1940;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 0;
                    infos.Diff = 18;
                    infos.ResistanceFroid = 3;
                    break;
                case NubiaRessource.Ancien:
                    infos.Name = "Ancien";
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
                case NubiaRessource.Royal:
                    infos.Name = "Royal";
                    infos.Durabilite = 3;
                    infos.Hue = 1944;
                    infos.GlobalAR = 5;
                    infos.BonusAttaque = 4;
                    infos.BonusDegat = 0;
                    infos.Diff = 18;
                    infos.ResistanceFeu = 2;
                    infos.ResistanceEnergie = 2;
                    infos.ResistanceAcide = 2;
                    infos.ResistanceFroid = 2;
                    break;
                #endregion

                #region Bois
                    //+1
                case NubiaRessource.Pommier:
                    infos.Name = "Pommier";
                    infos.Durabilite = 1;
                    infos.Hue = 1417;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 0;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Pecher:
                    infos.Name = "Pêcher";
                    infos.Durabilite = 1;
                    infos.Hue = 2034;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 0;
                    infos.BonusDegat = 1;
                    infos.Diff = 12;
                    break;
                case NubiaRessource.Poirier:
                    infos.Name = "Poirier";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2263;
                    infos.GlobalAR = 1;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 1;
                    infos.Diff = 13;
                    break;

                    //+2
                case NubiaRessource.Cedre:
                    infos.Name = "Cèdre";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2176;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 1;
                    infos.Diff = 15;
                    infos.ResistanceAcide = 2;
                    break;
                case NubiaRessource.Cocotier:
                    infos.Name = "Cocotier";
                    infos.Durabilite = 1.5;
                    infos.Hue = 2172;
                    infos.GlobalAR = 2;
                    infos.BonusAttaque = 1;
                    infos.BonusDegat = 2;
                    infos.Diff = 15;
                    infos.ResistanceEnergie = 2;
                    break;

                    //+4
                case NubiaRessource.Chene:
                    infos.Name = "Chêne";
                    infos.Durabilite = 2;
                    infos.Hue = 2033;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 3;
                    infos.BonusDegat = 2;
                    infos.Diff = 17;
                    infos.ResistanceEnergie = 1;
                    break;
                case NubiaRessource.Noyer:
                    infos.Name = "Noyer";
                    infos.Durabilite = 2;
                    infos.Hue = 2051;
                    infos.GlobalAR = 4;
                    infos.BonusAttaque = 2;
                    infos.BonusDegat = 3;
                    infos.Diff = 17;
                    infos.ResistanceFroid = 1;
                    break;

                    //+5
                case NubiaRessource.Saule:
                    infos.Name = "Saule";
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
                case NubiaRessource.Elendielle:
                    infos.Name = "Elendielle";
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
                #endregion
            }

            return infos;
        }
    }
}