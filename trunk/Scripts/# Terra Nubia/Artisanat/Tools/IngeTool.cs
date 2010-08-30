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
    public class IngeTool : BaseToolNubia
    {
        public override CraftSystemNubia System { get { return CraftIngenSystem.Singleton; } }
        [Constructable]
        public IngeTool() : base(7864) {
            Name = "Outils d'ingénieur";

        }
        public IngeTool(Serial s) : base(s) { }

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