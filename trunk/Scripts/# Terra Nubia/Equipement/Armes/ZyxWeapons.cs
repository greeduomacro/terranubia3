using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class ZWEpeeLongue5 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        [Constructable]
        public ZWEpeeLongue5()
            : base(13906)
        {
            //Layer = Layer.TwoHanded;
            Name = "Epée longue";
        }
        public ZWEpeeLongue5(Serial serial) : base(serial) { }

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
    public class ZWEpeeLongue4 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        [Constructable]
        public ZWEpeeLongue4()
            : base(13905)
        {
            //Layer = Layer.TwoHanded;
            Name = "Epée longue";
        }
        public ZWEpeeLongue4(Serial serial) : base(serial) { }

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
    public class ZWEpeeLongue3 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash2H; } }

        [Constructable]
        public ZWEpeeLongue3()
            : base(13904)
        {
            Layer = Layer.TwoHanded;
            Name = "Epée longue";
        }
        public ZWEpeeLongue3(Serial serial) : base(serial) { }

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
    public class ZWEpeeLongue2 : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash2H; } }

        [Constructable]
        public ZWEpeeLongue2()
            : base(13903)
        {
            Layer = Layer.TwoHanded;
            Name = "Epée longue";
        }
        public ZWEpeeLongue2(Serial serial) : base(serial) { }

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
    public class ZWEpeeLongue : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        [Constructable]
        public ZWEpeeLongue()
            : base(13900)
        {
            Name = "Epée longue";
        }
        public ZWEpeeLongue(Serial serial) : base(serial) { }

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
    public class ZWScimitar : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        [Constructable]
        public ZWScimitar()
            : base(13900)
        {
            Name = "Cimeterre";
        }
        public ZWScimitar(Serial serial) : base(serial) { }

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
    public class ZWScimitar2H : BaseSword
    {
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash2H; } }

        [Constructable]
        public ZWScimitar2H() : base(13900) {
            Layer = Layer.TwoHanded;
            Name = "Cimeterre"; 
        }
        public ZWScimitar2H(Serial serial) : base(serial) { }

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
