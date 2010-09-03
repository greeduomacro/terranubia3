using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;

namespace Server.Engines
{
    public abstract class BaseRessource : Item
    {

        public static BaseRessource getRessource(NubiaRessource res)
        {
            switch (res)
            {
                case NubiaRessource.Amanida: return new BoisAmanida();
                case NubiaRessource.Ancien: return new OsAncien();
                case NubiaRessource.Animaux: return new OsAnimaux();
                case NubiaRessource.Arachnique: return new OsArachnique();
                case NubiaRessource.Ardent: return new OsArdent();
                case NubiaRessource.Balron: return new CuirBalron();
                case NubiaRessource.Blub: return new OsBlub();
                case NubiaRessource.Bois: return new BoisNormal();
                case NubiaRessource.Caoba: return new BoisCaoba();
                case NubiaRessource.Carriate: return new MetalCarriate();
                case NubiaRessource.Celeste: return new OsCeleste();
                case NubiaRessource.Celiar: return new MetalCeliar();
                case NubiaRessource.Centorius: return new OsCentorius();
                case NubiaRessource.Chair: return new CuirChair();
                case NubiaRessource.Classique: return new CuirClassique();
                case NubiaRessource.Coton: return new TissuCoton();
                case NubiaRessource.Demoniaque: return new CuirDemoniaque();
                case NubiaRessource.Desertique: return new OsDesertique();
                case NubiaRessource.Detracteur: return new OsDetracteur();
                case NubiaRessource.Divarium: return new MetalDivarium();
                case NubiaRessource.Drachior: return new MetalDrachior();
                case NubiaRessource.Draconique: return new CuirDraconique();
                case NubiaRessource.Estiu: return new BoisEstiu();
                case NubiaRessource.Feerique: return new OsFeerique();
                case NubiaRessource.Fer: return new MetalFer();
                case NubiaRessource.Feu: return new OsFeu();
                case NubiaRessource.Firatas: return new MetalFiratas();
                case NubiaRessource.Floreas: return new MetalFloreas();
                case NubiaRessource.Fosc: return new BoisFosc();
                case NubiaRessource.Gargouille: return new OsGargouille();
                case NubiaRessource.Gargoulien: return new CuirGargoulien();
                case NubiaRessource.Geant: return new CuirGeant();
                case NubiaRessource.Givre: return new CuirGivre();
                case NubiaRessource.Glacera: return new BoisGlacera();
                case NubiaRessource.Glarias: return new MetalGlarias();
                case NubiaRessource.Harpie: return new OsHarpie();
                case NubiaRessource.Hydro: return new CuirHydro();
                case NubiaRessource.Laine: return new TissuLaine();
                case NubiaRessource.Legendaire: return new CuirLegendaire();
                case NubiaRessource.Lin: return new TissuLin();
                case NubiaRessource.Lonaris: return new MetalLonaris();
                case NubiaRessource.Lupus: return new CuirLupus();
                case NubiaRessource.Malatia: return new BoisMalatia();
                case NubiaRessource.Maritime: return new CuirMaritime();
                case NubiaRessource.Morcith: return new OsMorcith();
                case NubiaRessource.Morgalin: return new OsMorgalin();
                case NubiaRessource.Mythique: return new OsMythique();
                case NubiaRessource.Mythril: return new MetalMythril();
                case NubiaRessource.Nafarite: return new MetalNafarite();
                case NubiaRessource.Nethar: return new MetalNethar();
                case NubiaRessource.Nirior: return new MetalNirior();
                case NubiaRessource.Noctar: return new BoisNoctar();
                case NubiaRessource.Nordique: return new CuirNordique();
                case NubiaRessource.Ophidian: return new CuirOphidian();
                case NubiaRessource.Orafir: return new MetalOrafir();
                case NubiaRessource.Oragite: return new MetalOragite();
                case NubiaRessource.Palerias: return new MetalPalerias();
                case NubiaRessource.Pierre: return new CuirPierre();
                case NubiaRessource.Rageur: return new CuirRageur();
                case NubiaRessource.Rautour: return new CuirRautour();
                case NubiaRessource.Remiar: return new MetalRemiar();
                case NubiaRessource.Reptilien: return new CuirReptilien();
                case NubiaRessource.Revarium: return new MetalRevarium();
                case NubiaRessource.Riquesa: return new BoisRiquesa();
                case NubiaRessource.Royal: return new OsRoyal();
                case NubiaRessource.Sang: return new CuirSang();
                case NubiaRessource.Soie: return new TissuSoie();
                case NubiaRessource.Ssins: return new OsSsins();
                case NubiaRessource.Terathan: return new CuirTerathan();
                case NubiaRessource.Trechar: return new MetalTrechar();
                case NubiaRessource.Tyranoeil: return new OsTyranoeil();
                case NubiaRessource.Vela: return new BoisVela();
                case NubiaRessource.Vengeur: return new OsVengeur();
                case NubiaRessource.Verate: return new MetalVerate();
                case NubiaRessource.Verdan: return new MetalVerdan();
                case NubiaRessource.Vespre: return new BoisVespre();
                case NubiaRessource.Volcanique: return new CuirVolcanique();
            }
            return null;
        }


        protected bool m_isRaffine = false;
        protected NubiaRessource mRessource = NubiaRessource.Fer;


        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaRessource Ressource
        {
            get
            {
                return mRessource;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaInfoRessource Infos
        {
            get
            {
                return NubiaInfoRessource.GetInfoRessource(mRessource);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual bool isRaffine
        {
            get
            {
                return m_isRaffine;
            }
            set
            {
                m_isRaffine = value;
            }
        }

        public BaseRessource(int itemid)
            : this(itemid, 1)
        {

        }
        public BaseRessource(int itemid, int amount)
            : base(itemid)
        {
            Name = "Ressource";
            Stackable = true;
            Amount = amount;
        }
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add("["+mRessource.ToString()+"]");
        }

        public BaseRessource(Serial s)
            : base(s)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_isRaffine = reader.ReadBool();
            mRessource = (NubiaRessource)reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((bool)m_isRaffine);
            writer.Write((int)mRessource);

        }
    }
}
