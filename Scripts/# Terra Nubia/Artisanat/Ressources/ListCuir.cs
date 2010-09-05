using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Misc;

namespace Server.Engines
{
    //Toutes les infos sur les métaux sont dans NubiaInfoRessource.cs (en bas)
    public class CuirClassique : BaseCuir
    {
        [Constructable]
        public CuirClassique() : base(NubiaRessource.Classique) { }
        public CuirClassique(int amount) : base(NubiaRessource.Classique, amount) { }
        public CuirClassique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirOphidian : BaseCuir
    {
        [Constructable]
        public CuirOphidian() : base(NubiaRessource.Ophidian) { }
        public CuirOphidian(int amount) : base(NubiaRessource.Ophidian, amount) { }
        public CuirOphidian(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirDemoniaque : BaseCuir
    {
        [Constructable]
        public CuirDemoniaque() : base(NubiaRessource.Demoniaque) { }
        public CuirDemoniaque(int amount) : base(NubiaRessource.Demoniaque, amount) { }
        public CuirDemoniaque(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirSang : BaseCuir
    {
        [Constructable]
        public CuirSang() : base(NubiaRessource.Sang) { }
        public CuirSang(int amount) : base(NubiaRessource.Sang, amount) { }
        public CuirSang(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirRageur : BaseCuir
    {
        [Constructable]
        public CuirRageur() : base(NubiaRessource.Rageur) { }
        public CuirRageur(int amount) : base(NubiaRessource.Rageur, amount) { }
        public CuirRageur(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirGargoulien : BaseCuir
    {
        [Constructable]
        public CuirGargoulien() : base(NubiaRessource.Gargoulien) { }
        public CuirGargoulien(int amount) : base(NubiaRessource.Gargoulien, amount) { }
        public CuirGargoulien(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirLupus : BaseCuir
    {
        [Constructable]
        public CuirLupus() : base(NubiaRessource.Lupus) { }
        public CuirLupus(int amount) : base(NubiaRessource.Lupus, amount) { }
        public CuirLupus(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirMaritime : BaseCuir
    {
        [Constructable]
        public CuirMaritime() : base(NubiaRessource.Maritime) { }
        public CuirMaritime(int amount) : base(NubiaRessource.Maritime, amount) { }
        public CuirMaritime(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirGivre : BaseCuir
    {
        [Constructable]
        public CuirGivre() : base(NubiaRessource.Givre) { }
        public CuirGivre(int amount) : base(NubiaRessource.Givre, amount) { }
        public CuirGivre(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirChair : BaseCuir
    {
        [Constructable]
        public CuirChair() : base(NubiaRessource.Chair) { }
        public CuirChair(int amount) : base(NubiaRessource.Chair, amount) { }
        public CuirChair(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirBalron : BaseCuir
    {
        [Constructable]
        public CuirBalron() : base(NubiaRessource.Balron) { }
        public CuirBalron(int amount) : base(NubiaRessource.Balron, amount) { }
        public CuirBalron(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirReptilien : BaseCuir
    {
        [Constructable]
        public CuirReptilien() : base(NubiaRessource.Reptilien) { }
        public CuirReptilien(int amount) : base(NubiaRessource.Reptilien, amount) { }
        public CuirReptilien(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirTerathan : BaseCuir
    {
        [Constructable]
        public CuirTerathan() : base(NubiaRessource.Terathan) { }
        public CuirTerathan(int amount) : base(NubiaRessource.Terathan, amount) { }
        public CuirTerathan(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirDraconique : BaseCuir
    {
        [Constructable]
        public CuirDraconique() : base(NubiaRessource.Draconique) { }
        public CuirDraconique(int amount) : base(NubiaRessource.Draconique, amount) { }
        public CuirDraconique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirGeant : BaseCuir
    {
        [Constructable]
        public CuirGeant() : base(NubiaRessource.Geant) { }
        public CuirGeant(int amount) : base(NubiaRessource.Geant, amount) { }
        public CuirGeant(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirRautour : BaseCuir
    {
        [Constructable]
        public CuirRautour() : base(NubiaRessource.Rautour) { }
        public CuirRautour(int amount) : base(NubiaRessource.Rautour, amount) { }
        public CuirRautour(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirPierre : BaseCuir
    {
        [Constructable]
        public CuirPierre() : base(NubiaRessource.Pierre) { }
        public CuirPierre(int amount) : base(NubiaRessource.Pierre, amount) { }
        public CuirPierre(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirLegendaire : BaseCuir
    {
        [Constructable]
        public CuirLegendaire() : base(NubiaRessource.Legendaire) { }
        public CuirLegendaire(int amount) : base(NubiaRessource.Legendaire, amount) { }
        public CuirLegendaire(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirNordique : BaseCuir
    {
        [Constructable]
        public CuirNordique() : base(NubiaRessource.Nordique) { }
        public CuirNordique(int amount) : base(NubiaRessource.Nordique, amount) { }
        public CuirNordique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirVolcanique : BaseCuir
    {
        [Constructable]
        public CuirVolcanique() : base(NubiaRessource.Volcanique) { }
        public CuirVolcanique(int amount) : base(NubiaRessource.Volcanique, amount) { }
        public CuirVolcanique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class CuirHydro : BaseCuir
    {
        [Constructable]
        public CuirHydro() : base(NubiaRessource.Hydro) { }
        public CuirHydro(int amount) : base(NubiaRessource.Hydro, amount) { }
        public CuirHydro(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
 
}