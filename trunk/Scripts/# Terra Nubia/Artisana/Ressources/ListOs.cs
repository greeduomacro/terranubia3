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
   /* public class OsMorcith : BaseOs
    {
        [Constructable]
        public OsMorcith() : base(NubiaRessource.Morcith) { }
        public OsMorcith(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsArdent : BaseOs
    {
        [Constructable]
        public OsArdent() : base(NubiaRessource.Ardent) { }
        public OsArdent(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsDesertique : BaseOs
    {
        [Constructable]
        public OsDesertique() : base(NubiaRessource.Desertique) { }
        public OsDesertique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsHarpie : BaseOs
    {
        [Constructable]
        public OsHarpie() : base(NubiaRessource.Harpie) { }
        public OsHarpie(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsSsins : BaseOs
    {
        [Constructable]
        public OsSsins() : base(NubiaRessource.Ssins) { }
        public OsSsins(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsTyranoeil : BaseOs
    {
        [Constructable]
        public OsTyranoeil() : base(NubiaRessource.Tyranoeil) { }
        public OsTyranoeil(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsGargouille : BaseOs
    {
        [Constructable]
        public OsGargouille() : base(NubiaRessource.Gargouille) { }
        public OsGargouille(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsBlub : BaseOs
    {
        [Constructable]
        public OsBlub() : base(NubiaRessource.Blub) { }
        public OsBlub(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsVengeur : BaseOs
    {
        [Constructable]
        public OsVengeur() : base(NubiaRessource.Vengeur) { }
        public OsVengeur(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsCentorius : BaseOs
    {
        [Constructable]
        public OsCentorius() : base(NubiaRessource.Centorius) { }
        public OsCentorius(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsDetracteur : BaseOs
    {
        [Constructable]
        public OsDetracteur() : base(NubiaRessource.Detracteur) { }
        public OsDetracteur(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsArachnique : BaseOs
    {
        [Constructable]
        public OsArachnique() : base(NubiaRessource.Arachnique) { }
        public OsArachnique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsFeerique : BaseOs
    {
        [Constructable]
        public OsFeerique() : base(NubiaRessource.Feerique) { }
        public OsFeerique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsFeu : BaseOs
    {
        [Constructable]
        public OsFeu() : base(NubiaRessource.Feu) { }
        public OsFeu(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsMorgalin : BaseOs
    {
        [Constructable]
        public OsMorgalin() : base(NubiaRessource.Morgalin) { }
        public OsMorgalin(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsCeleste : BaseOs
    {
        [Constructable]
        public OsCeleste() : base(NubiaRessource.Celeste) { }
        public OsCeleste(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsMythique : BaseOs
    {
        [Constructable]
        public OsMythique() : base(NubiaRessource.Mythique) { }
        public OsMythique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsAncien : BaseOs
    {
        [Constructable]
        public OsAncien() : base(NubiaRessource.Ancien) { }
        public OsAncien(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    public class OsRoyal : BaseOs
    {
        [Constructable]
        public OsRoyal() : base(NubiaRessource.Royal) { }
        public OsRoyal(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }*/
}