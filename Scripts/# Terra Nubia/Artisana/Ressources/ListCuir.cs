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
        public CuirClassique(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
    /*
        Ophidian,
        Demoniaque,
        Sang,
        Rageur,
        Gargoulien,
        Lupus,
        Maritime,
        Givre,
        Chair,
        Balron,
        Reptilien,
        Terathan,
        Draconique,
        Geant,
        Rautour,
        Pierre,
        Legendaire,
        Nordique,
        Volcanique,
        Hydro,*/
}