using System;
using System.Collections.Generic;
using Server.Gumps;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    public class PierreCreation : Item
    {
        [Constructable]
        public PierreCreation()
            : base(10972)
        {
            Movable = false;
        }
        [Constructable]
        public PierreCreation(Serial s) : base(s) { }


        public override void OnDoubleClick(Mobile from)
        {
            from.SendGump(new GumpMenuCreation(from as NubiaPlayer));
        }

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
