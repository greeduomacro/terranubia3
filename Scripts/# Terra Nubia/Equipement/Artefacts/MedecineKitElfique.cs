using System;
using System.Collections.Generic;
using Server.Targeting;
using Server.Gumps;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    [FlipableAttribute(7864, 7865)]
    public class MedecineKitElfique : Item
    {

        [Constructable]
        public MedecineKitElfique()
            : base(7864)
        {
            Hue = 2263;
            ItemID = Utility.RandomMinMax(7864, 7865);
            Name = "Trousse de medecine elfique";
        }

        public MedecineKitElfique(Serial serial)
            : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0 && Weight == 0.1)
                Weight = -1;
        }

    }
}
