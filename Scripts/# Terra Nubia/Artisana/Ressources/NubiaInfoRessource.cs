using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class NubiaInfoRessource
    {
        //Generalite
        protected double mDurabilite = 0.5;
        protected int mHue = 0;
        protected int mDiff = 10;
        //Armures
        protected double mResistancePhysique = 0.05;
        protected double mResistanceFeu = 0.0;
        protected double mResistanceFroid = 0.0;
        protected double mResistanceAcide = 0.0;
        protected double mResistanceEnergie = 0.0;
        //Armes
        protected double mDegatContact = 0.80;
        protected double mDegatDistance = 0.80;

        [CommandProperty(AccessLevel.Developer)]
        public double Durabilite { get { return mDurabilite; } set { mDurabilite = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int Hue { get { return mHue; } set { mHue = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public int Diff { get { return mDiff; } set { mDiff = value; } }


        [CommandProperty(AccessLevel.Developer)]
        public double ResistancePhysique { get { return mResistancePhysique; } set { mResistancePhysique = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double ResistanceFeu { get { return mResistanceFeu; } set { mResistanceFeu = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double ResistanceFroid { get { return mResistanceFroid; } set { mResistanceFroid = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double ResistanceAcide { get { return mResistanceAcide; } set { mResistanceAcide = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double ResistanceEnergie { get { return mResistanceEnergie; } set { mResistanceEnergie = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double DegatContact { get { return mDegatContact; } set { mDegatContact = value; } }

        [CommandProperty(AccessLevel.Developer)]
        public double DegatDistance { get { return mDegatDistance; } set { mDegatDistance = value; } }


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
                case NubiaRessource.Abyssium:
                    infos.Durabilite = 0.75;
                    infos.Hue = 2041;
                    infos.ResistancePhysique = 0.5;
                    infos.ResistanceFeu = 0.5;
                    infos.ResistanceFroid = 0.5;
                    infos.ResistanceAcide = 0.0;
                    infos.ResistanceEnergie = 0.0;
                    infos.DegatDistance = 0.40;
                    infos.DegatContact = 0.85;
                    infos.Diff = 18;
                    break;
            }

            return infos;
        }
    }
}