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
        private MagieEcole[] mEcoles = new MagieEcole[0];

        public int Value { get { return mValue; } }
        public SauvegardeEnum Sauvegarde { get { return mSave; } }
        public MagieEcole[] Ecoles { get { return mEcoles; } }

        public SauvegardeMod(int value, SauvegardeEnum save):
            this(value,save, new MagieEcole[0])
        {
        }
        public SauvegardeMod(int value, SauvegardeEnum save, MagieEcole[] ecoles)
        {
            mValue = value;
            mSave = save;
            mEcoles = ecoles;
        }

    }
}
