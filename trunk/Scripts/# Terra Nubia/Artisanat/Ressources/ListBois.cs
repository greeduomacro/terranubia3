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
    public class BoisErable : BaseBois
    {
        [Constructable]
        public BoisErable() : base(NubiaRessource.Erable) { }
        public BoisErable(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisPommier : BaseBois
    {
        [Constructable]
        public BoisPommier() : base(NubiaRessource.Pommier) { }
        public BoisPommier(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisPecher : BaseBois
    {
        [Constructable]
        public BoisPecher() : base(NubiaRessource.Pecher) { }
        public BoisPecher(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisPoirier : BaseBois
    {
        [Constructable]
        public BoisPoirier() : base(NubiaRessource.Poirier) { }
        public BoisPoirier(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisCedre : BaseBois
    {
        [Constructable]
        public BoisCedre() : base(NubiaRessource.Cedre) { }
        public BoisCedre(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisCocotier : BaseBois
    {
        [Constructable]
        public BoisCocotier() : base(NubiaRessource.Cocotier) { }
        public BoisCocotier(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisChene : BaseBois
    {
        [Constructable]
        public BoisChene() : base(NubiaRessource.Chene) { }
        public BoisChene(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisNoyer : BaseBois
    {
        [Constructable]
        public BoisNoyer() : base(NubiaRessource.Noyer) { }
        public BoisNoyer(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisSaule : BaseBois
    {
        [Constructable]
        public BoisSaule() : base(NubiaRessource.Saule) { }
        public BoisSaule(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class BoisElendielle : BaseBois
    {
        [Constructable]
        public BoisElendielle() : base(NubiaRessource.Elendielle) { }
        public BoisElendielle(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}