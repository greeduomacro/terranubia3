using System;
using System.Collections.Generic;
using System.Text;
using Server.Spells;

namespace Server.Mobiles
{
    public enum SauvegardeEnum
    {
        Attaque = 1,
        Vigueur,
        Volonte,
        Reflexe
    }
    public class SauvegardeMod
    {
        protected int mValue;
        protected SauvegardeEnum mSave = SauvegardeEnum.Attaque;
        private SortEnergie[] mEcoles = new SortEnergie[0];

        public int Value { get { return mValue; } }
        public SauvegardeEnum Sauvegarde { get { return mSave; } }
        public SortEnergie[] Ecoles { get { return mEcoles; } }

        public SauvegardeMod(int value, SauvegardeEnum save):
            this(value, save, new SortEnergie[0])
        {
        }
        public SauvegardeMod(int value, SauvegardeEnum save, SortEnergie[] ecoles)
        {
            mValue = value;
            mSave = save;
            mEcoles = ecoles;
        }

    }
}
