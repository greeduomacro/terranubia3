using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class ZWPerfo6 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public ZWPerfo6() : base(13735) { Name = "Fleuret"; }
        public ZWPerfo6(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class ZWPerfo5 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public ZWPerfo5() : base(13734) { Name = "Rapière"; }
        public ZWPerfo5(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class ZWPerfo4 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public ZWPerfo4() : base(13733) { Name = "Rapière"; }
        public ZWPerfo4(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class ZWPerfo3 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public ZWPerfo3() : base(13732) { Name = "Fleuret"; }
        public ZWPerfo3(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class ZWPerfo2 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public ZWPerfo2() : base(13731) { Name = "Rapière"; }
        public ZWPerfo2(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class ZWPerfo1 : BaseSword
    {
        public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
        public ZWPerfo1() : base(13730) { Name = "Fleuret"; }
        public ZWPerfo1(Serial serial): base(serial){}

		public override void Serialize( GenericWriter writer ){
			base.Serialize( writer );
            writer.Write((int)0); //Version
		}
		public override void Deserialize( GenericReader reader ){
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
    }
}
