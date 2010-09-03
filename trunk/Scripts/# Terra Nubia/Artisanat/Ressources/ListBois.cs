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
    public class BoisNormal : BaseBois
    {
        [Constructable]
        public BoisNormal() : base(NubiaRessource.Bois) { }
        public BoisNormal(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisVela : BaseBois
    {
        [Constructable]
        public BoisVela() : base(NubiaRessource.Vela) { }
        public BoisVela(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisVespre : BaseBois
    {
        [Constructable]
        public BoisVespre() : base(NubiaRessource.Vespre) { }
        public BoisVespre(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisMalatia : BaseBois
    {
        [Constructable]
        public BoisMalatia() : base(NubiaRessource.Malatia) { }
        public BoisMalatia(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisEstiu : BaseBois
    {
        [Constructable]
        public BoisEstiu() : base(NubiaRessource.Estiu) { }
        public BoisEstiu(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisFosc : BaseBois
    {
        [Constructable]
        public BoisFosc() : base(NubiaRessource.Fosc) { }
        public BoisFosc(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisAmanida : BaseBois
    {
        [Constructable]
        public BoisAmanida() : base(NubiaRessource.Amanida) { }
        public BoisAmanida(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisGlacera : BaseBois
    {
        [Constructable]
        public BoisGlacera() : base(NubiaRessource.Glacera) { }
        public BoisGlacera(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisNoctar : BaseBois
    {
        [Constructable]
        public BoisNoctar() : base(NubiaRessource.Noctar) { }
        public BoisNoctar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisRiquesa : BaseBois
    {
        [Constructable]
        public BoisRiquesa() : base(NubiaRessource.Riquesa) { }
        public BoisRiquesa(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisCaoba : BaseBois
    {
        [Constructable]
        public BoisCaoba() : base(NubiaRessource.Caoba) { }
        public BoisCaoba(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}