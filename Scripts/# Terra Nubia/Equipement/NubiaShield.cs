using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public enum BouclierType
    {
        None = -1,
        Targe = 0, //+1CA, +8, -1, 5%
        Ecu,       //+2CA, +6, -2, 15%
        GrandEcu,  //+3CA  +4, -6, 30%
        Pavois,    //+4CA  +2, -10, 50%
        GrandPavois, //+5CA +0, -20, 75%
    }
    public class NubiaShield : NubiaArmor
    {

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
     
        private BouclierType mBType = BouclierType.Ecu;

        public BouclierType BType
        {
            get { return mBType; }
            set { mBType = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaArmorType ArmorType
        {
            get
            {
                switch (mBType)
                {
                    case BouclierType.Targe: return NubiaArmorType.Legere;
                    case BouclierType.Ecu: return NubiaArmorType.Intermediaire;
                    case BouclierType.GrandEcu: return NubiaArmorType.Intermediaire;
                    case BouclierType.Pavois: return NubiaArmorType.Lourde;
                    case BouclierType.GrandPavois: return NubiaArmorType.Lourde;
                }
                return 0.0;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public double CA
        {
            get
            {
                switch (mBType)
                {
                    case BouclierType.Targe: return 1.0;
                    case BouclierType.Ecu: return 2.0;
                    case BouclierType.GrandEcu: return 3.0;
                    case BouclierType.Pavois: return 4.0;
                    case BouclierType.GrandPavois: return 5.0;
                }
                return 0.0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ModDexMaximum
        {
            get
            {
                switch (mBType)
                {
                    case BouclierType.Targe: return 8;
                    case BouclierType.Ecu: return 6;
                    case BouclierType.GrandEcu: return 4;
                    case BouclierType.Pavois: return 2;
                    case BouclierType.GrandPavois: return 0;
                }
                return 10;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MalusArmure
        {
            get
            {
                switch (mBType)
                {
                    case BouclierType.Targe: return 5;
                    case BouclierType.Ecu: return 15;
                    case BouclierType.GrandEcu: return 30;
                    case BouclierType.Pavois: return 50;
                    case BouclierType.GrandPavois: return 75;
                }
                return 10;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PercentEchecSort
        {
            get
            {
                switch (mBType)
                {
                    case BouclierType.Targe: return -1;
                    case BouclierType.Ecu: return -2;
                    case BouclierType.GrandEcu: return -6;
                    case BouclierType.Pavois: return -10;
                    case BouclierType.GrandPavois: return -20;
                }
                return 10;
            }
        }
              
        public NubiaShield(int itemid) : base(itemid) {
            Layer = Layer.FirstValid;
        }
        public NubiaShield(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            mModelType = (ArmorModelType)reader.ReadInt();
        }
    }
}
