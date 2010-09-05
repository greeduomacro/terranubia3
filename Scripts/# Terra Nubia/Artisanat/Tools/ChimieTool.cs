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
    public class ChimieTool : BaseToolNubia
    {
        public override CraftSystemNubia System { get { return CraftAlchimieSystem.Singleton; } }
        [Constructable]
        public ChimieTool() : base(3739) { }
        public ChimieTool(Serial s) : base(s) { }

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

