using System;
using Server;
using Server.Nubia;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
    public class PackMonture : Item
    {

        private class InternalTarget : Target
        {
            private PackMonture mPack = null;
            public InternalTarget(PackMonture pack)
                : base(1, false, TargetFlags.None)
            {
                mPack = pack;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                base.OnTarget(from, targeted);
                if (from == null)
                    return;
                if (!from.Alive)
                    return;

                if (targeted is NubiaCreature)
                {
                    NubiaCreature mount = targeted as NubiaCreature;

                    if (mount.IsFriend(from) || mount.ControlMaster == from)
                    {
                        int body = mount.BodyValue;
                        if (body == 0xC8 ||
                             body == 0x3E9F ||
                              body == 0xE2 ||
                             body == 0x3EA0 ||
                             body == 0xE4 ||
                             body == 0x3EA1 ||
                             body == 0xCC ||
                             body == 0x3EA2) //HORSE
                        {
                            from.Emote("*Scelle les sacs sur le cheval*");
                            Point3D p = mount.Location;
                            Map m = mount.Map;
                            Mobile master = mount.ControlMaster;
                            bool tamed = mount.Controlled;
                            mount.Delete();
                            PackHorse horse = new PackHorse();
                            horse.MoveToWorld(p, m);
                            horse.ControlMaster = master;
                            horse.Controlled = tamed;
                            horse.ControlOrder = OrderType.Stay;
                            if (mPack != null)
                                mPack.Delete();
                        }
                        else if (mount is Llama || mount is RidableLlama)
                        {
                            from.Emote("*Scelle les sacs sur le Lama*");
                            Point3D p = mount.Location;
                            Map m = mount.Map;
                            Mobile master = mount.ControlMaster;
                            bool tamed = mount.Controlled;
                            mount.Delete();
                            PackLlama lama = new PackLlama();
                            lama.MoveToWorld(p, m);
                            lama.ControlMaster = master;
                            lama.Controlled = tamed;
                            lama.ControlOrder = OrderType.Stay;
                            if (mPack != null)
                                mPack.Delete();
                        }
                        else
                            from.SendMessage("Utilisez cela sur un cheval ou un lama");
                    }
                    else
                    {
                        from.SendMessage("La monture ne se laisse pas approcher");
                        mount.Emote("*s'agite nerveusement*");
                    }
                }
                else
                    from.SendMessage("Vous devez visez une monture vous appartenant");
            }
        }

        [Constructable]
        public PackMonture()
            : base(8790)
        {
            Name = "Sacs pour monture";
            Weight = 10.0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            from.SendMessage("Quelle monture voulez vous équipez de ces sacs ?");
            from.Target = new InternalTarget(this);
        }
        [Constructable]
        public PackMonture(Serial serial)
            : base(serial)
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