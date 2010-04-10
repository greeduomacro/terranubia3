using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public enum ArtefactQuality
    {
        None = 0,
        Normal = 1,
        Superieur = 2,
        Rare = 3,
        Epique = 4,
        Legendaire = 5,
    }
    public class ArtefactModus
    {
        private DndStat mDndStat = DndStat.Charisme;
        private int mStatValue = 0;
        private List<CompetenceMod> mCompetenceMod = new List<CompetenceMod>();
        private List<SauvegardeMod> mSaugevardMod = new List<SauvegardeMod>();

        public DndStat DndStat { get { return mDndStat; } set { mDndStat = value; } }
        public int StatValue { get { return mStatValue; } set { mStatValue = value; } }
        public CompetenceMod[] CompentenceMod { get { return mCompetenceMod.ToArray(); } }
        public SauvegardeMod[] SauvegardeMod { get { return mSaugevardMod.ToArray(); } }
     

        public static int getNiveauReq(ArtefactQuality qualite)
        {
            switch (qualite)
            {
                case ArtefactQuality.Normal : return 5;
                case ArtefactQuality.Superieur : return 10;
                case ArtefactQuality.Rare : return 15;
                case ArtefactQuality.Epique : return 20;
                case ArtefactQuality.Legendaire : return 20;
            }
            return 0;
        }

        public static ArtefactModus generate(ArtefactQuality qualite)
        {
            ArtefactModus arte = new ArtefactModus();
            while (arte.getArtefactQuality() < qualite)
            {
                int rand = Utility.Random(2);
                if (rand == 0) // STAT
                {
                    arte.mDndStat = (DndStat)Utility.Random(5);
                    arte.mStatValue++;
                }
                else if (rand == 1) //CompetenceMod
                {
                    CompType ctype = (CompType)Utility.Random((int)CompType.Maximum);
                    if (ctype != CompType.All && ctype != CompType.Maximum)
                    {
                         int value = 0;
                         if (qualite >= ArtefactQuality.Superieur)
                             value = Utility.Random(4) + 1;
                         else
                             value = Utility.Random(2) + 1;
                        bool cOk = false;
                        foreach (CompetenceMod cmod in arte.mCompetenceMod)
                        {
                            if (cmod.Comp == ctype)
                            {
                                cOk = false;
                                break;
                            }
                        }
                        if (cOk)
                            arte.mCompetenceMod.Add(new CompetenceMod(value, ctype));
                    }
                }
                else if (rand == 2) //Sauvegarde Mod)
                {
                    SauvegardeEnum save = (SauvegardeEnum)Utility.Random(3);
                    bool doEcole = true;
                    int value = Utility.Random(4) + 1;

                    if (qualite >= ArtefactQuality.Rare)
                        doEcole = Utility.RandomBool();
                    if (doEcole)
                    {
                        int nbrEcole = Utility.Random(2) + 1;
                        SortEnergie[] ecoles = new SortEnergie[nbrEcole];
                        for (int e = 0; e < (int)nbrEcole; e++)
                        {
                            SortEnergie ecole = 1 + (SortEnergie)Utility.Random((int)SortEnergie.Air);

                            ecoles[e] = ecole;
                        }
                        arte.mSaugevardMod.Add(new SauvegardeMod(value, save, ecoles));
                    }
                    else
                        arte.mSaugevardMod.Add(new SauvegardeMod(value, save));
                }
             /*   else if (rand == 3) // CA MOD
                {
                    arte.mCAMod += Utility.Random(4) + 1;
                }
                else if (rand == 4)
                {
                    arte.mDegatMod += Utility.Random(1) + 1;
                }*/
            }
            return arte;
        }

        public ArtefactQuality getArtefactQuality()
        {
            ArtefactQuality qualite = ArtefactQuality.None;

            int value = 0;
            value += mStatValue;
            foreach (CompetenceMod cmod in mCompetenceMod)
                value += cmod.Value;
            foreach (SauvegardeMod smod in mSaugevardMod)
            {
                value += smod.Value;
                if (smod.Ecoles.Length == 0)
                    value += 4;
            }
            /*value += mCAMod;
            value += mDegatMod;*/

            if (value < 4)
                qualite = ArtefactQuality.Normal;
            else if (value < 6)
                qualite = ArtefactQuality.Superieur;
            else if (value < 8)
                qualite = ArtefactQuality.Rare;
            else if (value < 10)
                qualite = ArtefactQuality.Epique;
            else
                qualite = ArtefactQuality.Legendaire;

            return qualite;
        }
    }
}
