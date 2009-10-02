using System;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using Server.Engines;
using System.Collections;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
    //[FlipableAttribute( 0x1EBA, 0x1EBB )]
    public class ForgeronTool : BaseToolNubia, INubiaCraftable
    {
        public Mobile Artisan { get { return null; } set { return; } }

        public List<NubiaRessource> TRessourceList { get { return null; } }

        public void AddRessource(NubiaRessource res) { }

        public void ComputeRessourceBonus() { }

        public override CraftSystemNubia System { get { return CraftForgeSystem.Singleton; } }
        [Constructable]
        public ForgeronTool(): base(0x13E4){}
        public ForgeronTool(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    
}