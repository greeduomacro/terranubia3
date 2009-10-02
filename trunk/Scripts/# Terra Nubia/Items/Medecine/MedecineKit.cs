using System;
using System.Collections.Generic;
using Server.Targeting;
using Server.Gumps;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    [FlipableAttribute(7864, 7865)]
    public class MedecineKit : Item
    {

        [Constructable]
        public MedecineKit()
            : base(7864)
        {
            ItemID = Utility.RandomMinMax(7864, 7865);
            Name = "Tousse de medecine";
        }

        public MedecineKit(Serial serial)
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

        public override void OnDoubleClick(Mobile from)
        {
            if (this.Parent == from.Backpack)
                from.Target = new MedecineTarget(from);
            else
                from.SendMessage("L'outil doit être dans votre sac");
        }
       
    }
    public class MedecineTarget : Target
    {
        public MedecineTarget(Mobile from)
            : base(1, false, TargetFlags.None)
        {
            from.SendMessage("Qui voulez vous examiner ?");
        }
        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is NubiaMobile)
            {
                if (((NubiaMobile)targeted).BlessureList.Count > 1)
                    from.SendGump(new GumpBlessure((NubiaPlayer)targeted, (NubiaPlayer)from));
                else
                    from.SendMessage("{0} n'est pas blessé", ((NubiaMobile)targeted).Name);
            }
            else
                from.SendMessage("Ceci ne peu pas être soigné");
        }
    }
}
