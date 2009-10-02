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
    public abstract class NubiaArmor : BaseArmor /*, INubiaCraftable*/
    {
        
        public NubiaArmor(int itemid) : base(itemid) { }
        public NubiaArmor(Serial s) : base(s) { }

        protected ArmorModelType mModelType = ArmorModelType.Matelas;
        private int mHitsMax = 50;
        private int mHits = 50;
        private Mobile mArtisan = null;

        #region Craft Variable & Functions
        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Artisan { get { return mArtisan; } set { mArtisan = value; } }

     /*   private List<NubiaRessource> mTRessourceList = new List<NubiaRessource>();
        public List<NubiaRessource> TRessourceList { get { return TRessourceList; } }

        public void AddRessource(NubiaRessource res)
        {
            if (mTRessourceList == null)
                mTRessourceList = new List<NubiaRessource>();
            mTRessourceList.Add(res);
        }
        */
        public void ComputeRessourceBonus()
        {
            double ResPhy = 0.0;
            double ResFeu = 0.0;
            double ResFroid = 0.0;
            double ResAcid = 0.0;
            double ResEnergy = 0.0;
            double durab = 0;

           /* foreach (NubiaRessource t in mTRessourceList)
            {
                NubiaInfoRessource info = NubiaInfoRessource.GetInfoRessource(t);
                ResPhy += info.ResistancePhysique;
                ResFeu += info.ResistanceFeu;
                ResFroid += info.ResistanceFroid;
                ResAcid += info.ResistanceAcide;
                ResEnergy += info.ResistanceEnergie;
                durab += info.Durabilite;
            }
            ResPhy /= mTRessourceList.Count;
            ResFeu /= mTRessourceList.Count;
            ResFroid /= mTRessourceList.Count;
            ResAcid /= mTRessourceList.Count;
            ResEnergy /= mTRessourceList.Count;
            durab /= mTRessourceList.Count;

            PhysicalBonus = (int)ResPhy;
            FireBonus = (int)ResFeu;
            ColdBonus = (int)ResFroid;
            EnergyBonus = (int)ResEnergy;
            PoisonBonus = (int)ResAcid;*/

            double hm = 100.0 * durab;
            mHitsMax = (int)hm;
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
                    case ArmorModelType.Matelas: return 10.0;
                    case ArmorModelType.CuirSimple: return 20.0;
                    case ArmorModelType.CuirCloute: return 30.0;
                    case ArmorModelType.Anneaux: return 40.0;
                    case ArmorModelType.Maille: return 60.0;
                    case ArmorModelType.Plaque: return 80.0;
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
                return GlobalCA * PercentFromLayer;
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
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            mModelType = (ArmorModelType)reader.ReadInt();
            mArtisan = reader.ReadMobile();
        }
    }
}