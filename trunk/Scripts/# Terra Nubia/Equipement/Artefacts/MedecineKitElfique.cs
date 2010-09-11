using System;
using System.Collections.Generic;
using Server.Targeting;
using Server.Gumps;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    public class MedecineKitElfique : MedecineKit
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
        }

    }
}
