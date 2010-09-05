using System;
using Server;
using Server.Nubia;
using Server.Mobiles;

namespace Server.Items
{
    public class ReposItem : Item
    {

        private int mRange = 10;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Range
        {
            get { return mRange; }
            set { mRange = value; }
        }

        [Constructable]
        public ReposItem()
            : base(4010)
        {
            Weight = 255.0;
            Movable = false;
            Visible = false;
            new InternalTimer(this).Start();
        }

        public ReposItem(Serial serial)
            : base(serial)
        {
            new InternalTimer(this).Start();
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

        private class InternalTimer : Timer
        {
            private ReposItem item = null;
            public InternalTimer(ReposItem i)
                : base(TimeSpan.FromSeconds(30))
            {
                item = i;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if (item != null)
                {
                    IPooledEnumerable eable = item.GetMobilesInRange(item.Range);
                    foreach (Mobile m in eable)
                    {
                        if (m != null && m is NubiaPlayer)
                        {
                            if (m.Alive && m.Hits < m.HitsMax)
                            {
                                m.Hits += 5;
                            }
                        }
                    }
                    eable.Free();
                    new InternalTimer(item).Start();
                }
            }
        }

    }
}
