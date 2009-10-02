using System;
using Server.Items;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
    public interface INubiaCraftable
    {
        Mobile Artisan { get;set;}

        List<NubiaRessource> TRessourceList { get;}

        void AddRessource(NubiaRessource res);

        void ComputeRessourceBonus();
    }
}