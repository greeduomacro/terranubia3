using System;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;
using Server.Factions;
using AMA = Server.Items.ArmorMeditationAllowance;
using AMT = Server.Items.ArmorMaterialType;
using ABT = Server.Items.ArmorBodyType;

namespace Server.Items
{
    public enum NubiaArmorType
    {
        None = -1,
        Legere = 0,
        Intermediaire = 1,
        Lourde = 2
    }
    //Pour simplifier la vie. On va définir Quelques models, toutes les armures seront callé sur ces models
    public enum ArmorModelType
    {
        Matelas = 0,
        CuirSimple = 1,
        CuirCloute = 2,
        Anneaux = 3,
        Maille = 4,
        Plaque = 5
    }
    
    public abstract class NubiaArmor : BaseArmor , INubiaCraftable
    {
        
        public NubiaArmor(int itemid) : base(itemid) { }
        public NubiaArmor(Serial s) : base(s) { }

        protected ArmorModelType mModelType = ArmorModelType.Matelas;
        private int mHitsMax = 50;
        private int mHits = 50;
        private Mobile mArtisan = null;
        private NubiaQualityEnum mNubiaQuality = NubiaQualityEnum.Mauvaise;

        #region Craft Variable & Functions
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Artisan { get { return mArtisan; } set { mArtisan = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaQualityEnum NQuality { get { return mNubiaQuality; } set { AfterCraft(value); } }

        private List<NubiaRessource> mTRessourceList = new List<NubiaRessource>();
        public List<NubiaRessource> TRessourceList { get { return mTRessourceList; } }

        private int mArBoost = 0;

        public void AfterCraft(NubiaQualityEnum quality)
        {
            mNubiaQuality = quality;
            for (int i = 0; i < mTRessourceList.Count; i++)
            {
                NubiaRessource res = mTRessourceList[i];
                NubiaInfoRessource infos = 
                    NubiaInfoRessource.GetInfoRessource(res);
                mArBoost = Math.Max(mArBoost, infos.GlobalAR);
                mHitsMax = Math.Max( (int)(50.0 * infos.Durabilite), mHitsMax );
                mHits = mHitsMax;
            }
            switch (mNubiaQuality)
            {
                case NubiaQualityEnum.Mauvaise: mArBoost--; break;
                case NubiaQualityEnum.Bonne: mHitsMax += 20; break;
                case NubiaQualityEnum.Excellente: mArBoost++; mHitsMax += 40; break;
                case NubiaQualityEnum.Maitre: mArBoost++; mHitsMax += 60; break;

            }
        }

        #endregion


        #region Getter & Setter
        [CommandProperty(AccessLevel.GameMaster)]
        public ArmorModelType ModelType
        {
            get { return mModelType; }
            set { mModelType = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaArmorType TArmorType
        {
            get
            {
                switch (mModelType)
                {
                    case ArmorModelType.Matelas: return NubiaArmorType.Legere;
                    case ArmorModelType.CuirSimple: return NubiaArmorType.Legere;
                    case ArmorModelType.CuirCloute: return NubiaArmorType.Legere;
                    case ArmorModelType.Anneaux: return NubiaArmorType.Intermediaire;
                    case ArmorModelType.Maille: return NubiaArmorType.Intermediaire;
                    case ArmorModelType.Plaque: return NubiaArmorType.Lourde;
                    default: return NubiaArmorType.Legere;
                }
            }
        }


        [CommandProperty(AccessLevel.GameMaster)]
        public double GlobalCA
        {
            get
            {
                switch (mModelType)
                {
                    case ArmorModelType.Matelas: return 1.0;
                    case ArmorModelType.CuirSimple: return 2.0;
                    case ArmorModelType.CuirCloute: return 3.0;
                    case ArmorModelType.Anneaux: return 4.0;
                    case ArmorModelType.Maille: return 6.0;
                    case ArmorModelType.Plaque: return 8.0;
                    default: return 0.0;
                }
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public double PercentFromLayer
        {
            get
            {
                switch (Layer)
                {
                    case Layer.Helm: return 0.1;
                    case Layer.Neck: return 0.1;
                    case Layer.InnerTorso: return 0.4;
                    case Layer.Arms: return 0.15;
                    case Layer.Gloves: return 0.05;
                    case Layer.Pants: return 0.20;
                    default: return 0.0;
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public double CA
        {
            get
            {
                double bonus = 0;
                switch (mNubiaQuality)
                {
                    case NubiaQualityEnum.Mauvaise: bonus = -1; break;
                    case NubiaQualityEnum.Bonne: bonus = 0.5; break;
                    case NubiaQualityEnum.Excellente: bonus = 1; break;
                    case NubiaQualityEnum.Maitre: bonus = 2; break;
                        
                }
                bonus += mArBoost;
                return (GlobalCA + bonus) * PercentFromLayer;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ModDexMaximum
        {
            get
            {
                switch (mModelType)
                {
                    case ArmorModelType.Matelas: return 8;
                    case ArmorModelType.CuirSimple: return 6;
                    case ArmorModelType.CuirCloute: return 5;
                    case ArmorModelType.Anneaux: return 3;
                    case ArmorModelType.Maille: return 1;
                    case ArmorModelType.Plaque: return 0;
                    default: return 20;
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MalusArmure
        {
            get
            {
                switch (mModelType)
                {
                    case ArmorModelType.Matelas: return 0;
                    case ArmorModelType.CuirSimple: return 0;
                    case ArmorModelType.CuirCloute: return -2;
                    case ArmorModelType.Anneaux: return -8;
                    case ArmorModelType.Maille: return -12;
                    case ArmorModelType.Plaque: return -16;
                    default: return 0;
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int PercentEchecSort
        {
            get
            {
                switch (mModelType)
                {
                    case ArmorModelType.Matelas: return 5;
                    case ArmorModelType.CuirSimple: return 10;
                    case ArmorModelType.CuirCloute: return 20;
                    case ArmorModelType.Anneaux: return 40;
                    case ArmorModelType.Maille: return 60;
                    case ArmorModelType.Plaque: return 80;
                    default: return 0;
                }
            }
        }
        #endregion


        public override void OnDoubleClick(Mobile from)
        {

            Item iti = from.FindItemOnLayer(this.Layer);
            if (iti != null)
                from.Backpack.AddItem(iti);
            from.EquipItem(this);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            string infos = "";
            if (mNubiaQuality != NubiaQualityEnum.Normale)
            {
                infos += NubiaQuality.getQualityName(mNubiaQuality) + "\n";
            }
            if (mTRessourceList.Count > 0)
            {
                for (int i = 0; i < mTRessourceList.Count; i++)
                {
                    infos += NubiaInfoRessource.GetInfoRessource(mTRessourceList[i]).Name;
                    if (i < mTRessourceList.Count - 1)
                        infos += ", ";
                }
                infos += "\n";
            }
            infos += String.Format("Catégorie: {0}\nModus dex Maxi: +{1}\nMalus: {2}\nEchec aux sorts: {3}%\nDurabilitée: {4}/{5}", TArmorType,
                ModDexMaximum,
                MalusArmure,
                PercentEchecSort,
                mHits.ToString(),
                mHitsMax.ToString());
            Console.WriteLine(infos);
            list.Add(infos);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)mModelType);
            writer.Write((Mobile)mArtisan);

            writer.Write((int)mTRessourceList.Count);
            writer.Write((int)mNubiaQuality);
            for (int i = 0; i < mTRessourceList.Count; i++)
                writer.Write((int)mTRessourceList[i]);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            mModelType = (ArmorModelType)reader.ReadInt();
            mArtisan = reader.ReadMobile();

            int rescount = reader.ReadInt();
            mNubiaQuality = (NubiaQualityEnum)reader.ReadInt();
            mTRessourceList = new List<NubiaRessource>();
            for (int i = 0; i < rescount; i++)
                mTRessourceList.Add((NubiaRessource)reader.ReadInt());

        }
    }
}