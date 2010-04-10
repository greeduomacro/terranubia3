using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class BottleWater : BeverageBottle
    {
        [Constructable]
        public BottleWater()
            : base(BeverageType.Water)
        {
        }
        public BottleWater(Serial s)
            : base(s)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
