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

    public class MetalAbyssium : BaseMetal
    {
        [Constructable]
        public MetalAbyssium() : base(NubiaRessource.Abyssium) { }
        public MetalAbyssium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalLithiar : BaseMetal
    {
        [Constructable]
        public MetalLithiar() : base(NubiaRessource.Lithiar) { }
        public MetalLithiar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalKhandarium : BaseMetal
    {
        [Constructable]
        public MetalKhandarium() : base(NubiaRessource.Khandarium) { }
        public MetalKhandarium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalLuminar : BaseMetal
    {
        [Constructable]
        public MetalLuminar() : base(NubiaRessource.Luminar) { }
        public MetalLuminar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalArgent : BaseMetal
    {
        [Constructable]
        public MetalArgent() : base(NubiaRessource.Argent) { }
        public MetalArgent(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalAcier : BaseMetal
    {
        [Constructable]
        public MetalAcier() : base(NubiaRessource.Acier) { }
        public MetalAcier(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalMaritium : BaseMetal
    {
        [Constructable]
        public MetalMaritium() : base(NubiaRessource.Maritium) { }
        public MetalMaritium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalDraconyr : BaseMetal
    {
        [Constructable]
        public MetalDraconyr() : base(NubiaRessource.Draconyr) { }
        public MetalDraconyr(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalDelirium : BaseMetal
    {
        [Constructable]
        public MetalDelirium() : base(NubiaRessource.Delirium) { }
        public MetalDelirium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalMagentis : BaseMetal
    {
        [Constructable]
        public MetalMagentis() : base(NubiaRessource.Magentis) { }
        public MetalMagentis(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBersekium : BaseMetal
    {
        [Constructable]
        public MetalBersekium() : base(NubiaRessource.Bersekium) { }
        public MetalBersekium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalRoseal : BaseMetal
    {
        [Constructable]
        public MetalRoseal() : base(NubiaRessource.Roseal) { }
        public MetalRoseal(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBrumire : BaseMetal
    {
        [Constructable]
        public MetalBrumire() : base(NubiaRessource.Brumire) { }
        public MetalBrumire(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalSombraril : BaseMetal
    {
        [Constructable]
        public MetalSombraril() : base(NubiaRessource.Sombraril) { }
        public MetalSombraril(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalOmbrium : BaseMetal
    {
        [Constructable]
        public MetalOmbrium() : base(NubiaRessource.Ombrium) { }
        public MetalOmbrium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalVolcanium : BaseMetal
    {
        [Constructable]
        public MetalVolcanium() : base(NubiaRessource.Volcanium) { }
        public MetalVolcanium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalOrilium : BaseMetal
    {
        [Constructable]
        public MetalOrilium() : base(NubiaRessource.Orilium) { }
        public MetalOrilium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalSolinar : BaseMetal
    {
        [Constructable]
        public MetalSolinar() : base(NubiaRessource.Solinar) { }
        public MetalSolinar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBrazium : BaseMetal
    {
        [Constructable]
        public MetalBrazium() : base(NubiaRessource.Brazium) { }
        public MetalBrazium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalTeilium : BaseMetal
    {
        [Constructable]
        public MetalTeilium() : base(NubiaRessource.Teilium) { }
        public MetalTeilium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalHeliotrope : BaseMetal
    {
        [Constructable]
        public MetalHeliotrope() : base(NubiaRessource.Heliotrope) { }
        public MetalHeliotrope(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalCuivre : BaseMetal
    {
        [Constructable]
        public MetalCuivre() : base(NubiaRessource.Cuivre) { }
        public MetalCuivre(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBronze : BaseMetal
    {
        [Constructable]
        public MetalBronze() : base(NubiaRessource.Bronze) { }
        public MetalBronze(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalHeptazion : BaseMetal
    {
        [Constructable]
        public MetalHeptazion() : base(NubiaRessource.Heptazion) { }
        public MetalHeptazion(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalEtheril : BaseMetal
    {
        [Constructable]
        public MetalEtheril() : base(NubiaRessource.Etheril) { }
        public MetalEtheril(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalSanguinar : BaseMetal
    {
        [Constructable]
        public MetalSanguinar() : base(NubiaRessource.Sanguinar) { }
        public MetalSanguinar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBiotite : BaseMetal
    {
        [Constructable]
        public MetalBiotite() : base(NubiaRessource.Biotite) { }
        public MetalBiotite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalAgapite : BaseMetal
    {
        [Constructable]
        public MetalAgapite() : base(NubiaRessource.Agapite) { }
        public MetalAgapite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalCitrius : BaseMetal
    {
        [Constructable]
        public MetalCitrius() : base(NubiaRessource.Citrius) { }
        public MetalCitrius(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalChrysoberil : BaseMetal
    {
        [Constructable]
        public MetalChrysoberil() : base(NubiaRessource.Chrysoberil) { }
        public MetalChrysoberil(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalEquilibrium : BaseMetal
    {
        [Constructable]
        public MetalEquilibrium() : base(NubiaRessource.Equilibrium) { }
        public MetalEquilibrium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalHerbrosite : BaseMetal
    {
        [Constructable]
        public MetalHerbrosite() : base(NubiaRessource.Herbrosite) { }
        public MetalHerbrosite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalMytheril : BaseMetal
    {
        [Constructable]
        public MetalMytheril() : base(NubiaRessource.Mytheril) { }
        public MetalMytheril(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalJusticium : BaseMetal
    {
        [Constructable]
        public MetalJusticium() : base(NubiaRessource.Justicium) { }
        public MetalJusticium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalOdium : BaseMetal
    {
        [Constructable]
        public MetalOdium() : base(NubiaRessource.Odium) { }
        public MetalOdium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalMuscovite : BaseMetal
    {
        [Constructable]
        public MetalMuscovite() : base(NubiaRessource.Muscovite) { }
        public MetalMuscovite(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalTchszarium : BaseMetal
    {
        [Constructable]
        public MetalTchszarium() : base(NubiaRessource.Tchszarium) { }
        public MetalTchszarium(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalPyroxene : BaseMetal
    {
        [Constructable]
        public MetalPyroxene() : base(NubiaRessource.Pyroxene) { }
        public MetalPyroxene(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalJolinar : BaseMetal
    {
        [Constructable]
        public MetalJolinar() : base(NubiaRessource.Jolinar) { }
        public MetalJolinar(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }

    public class MetalBoreal : BaseMetal
    {
        [Constructable]
        public MetalBoreal() : base(NubiaRessource.Boreal) { }
        public MetalBoreal(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}