using System;
using Server.Items;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server.Engines.Craft;

namespace Server.Items
{
    public interface INubiaCraftable
    {
        Mobile Artisan { get;set;}

        List<NubiaRessource> TRessourceList { get;}

        void AfterCraft(NubiaQualityEnum quality);
    }
}