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
    public class MetalFer : BaseMetal
    {
        [Constructable]
        public MetalFer(): base(NubiaRessource.Fer){}
        public MetalFer(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer){base.Serialize(writer);}
        public override void Deserialize(GenericReader reader){base.Deserialize(reader);}
    }
    public class MetalCarriate : BaseMetal
    {
        [Constructable]
        public MetalCarriate() : base(NubiaRessource.Carriate) { }
        public MetalCarriate(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalRemiar : BaseMetal
    {
        [Constructable]
        public MetalRemiar() : base(NubiaRessource.Remiar) { }
        public MetalRemiar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalOrafir : BaseMetal
    {
        [Constructable]
        public MetalOrafir() : base(NubiaRessource.Orafir) { }
        public MetalOrafir(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalMythril : BaseMetal
    {
        [Constructable]
        public MetalMythril() : base(NubiaRessource.Mythril) { }
        public MetalMythril(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalNafarite : BaseMetal
    {
        [Constructable]
        public MetalNafarite() : base(NubiaRessource.Nafarite) { }
        public MetalNafarite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalRevarium : BaseMetal
    {
        [Constructable]
        public MetalRevarium() : base(NubiaRessource.Revarium) { }
        public MetalRevarium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalTrechar : BaseMetal
    {
        [Constructable]
        public MetalTrechar() : base(NubiaRessource.Trechar) { }
        public MetalTrechar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalFloreas : BaseMetal
    {
        [Constructable]
        public MetalFloreas() : base(NubiaRessource.Floreas) { }
        public MetalFloreas(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalOragite : BaseMetal
    {
        [Constructable]
        public MetalOragite() : base(NubiaRessource.Oragite) { }
        public MetalOragite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalLonaris : BaseMetal
    {
        [Constructable]
        public MetalLonaris() : base(NubiaRessource.Lonaris) { }
        public MetalLonaris(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalCeliar : BaseMetal
    {
        [Constructable]
        public MetalCeliar() : base(NubiaRessource.Celiar) { }
        public MetalCeliar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalFiratas : BaseMetal
    {
        [Constructable]
        public MetalFiratas() : base(NubiaRessource.Firatas) { }
        public MetalFiratas(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalVerate : BaseMetal
    {
        [Constructable]
        public MetalVerate() : base(NubiaRessource.Verate) { }
        public MetalVerate(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalDrachior : BaseMetal
    {
        [Constructable]
        public MetalDrachior() : base(NubiaRessource.Drachior) { }
        public MetalDrachior(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalGlarias : BaseMetal
    {
        [Constructable]
        public MetalGlarias() : base(NubiaRessource.Glarias) { }
        public MetalGlarias(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalNethar : BaseMetal
    {
        [Constructable]
        public MetalNethar() : base(NubiaRessource.Nethar) { }
        public MetalNethar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalDivarium : BaseMetal
    {
        [Constructable]
        public MetalDivarium() : base(NubiaRessource.Divarium) { }
        public MetalDivarium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalPalerias : BaseMetal
    {
        [Constructable]
        public MetalPalerias() : base(NubiaRessource.Palerias) { }
        public MetalPalerias(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class MetalNirior : BaseMetal
    {
        [Constructable]
        public MetalNirior() : base(NubiaRessource.Nirior) { }
        public MetalNirior(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}