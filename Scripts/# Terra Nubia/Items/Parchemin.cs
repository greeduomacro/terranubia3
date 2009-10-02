using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class NubiaParchemin : Item
    {
        [Constructable]
        public NubiaParchemin(): base(5357)
        {
        }
        [Constructable]
        public NubiaParchemin(Serial s)
            : base(s)
        {
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
