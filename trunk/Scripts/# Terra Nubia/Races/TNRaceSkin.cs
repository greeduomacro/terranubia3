using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;

namespace Server.Mobiles
{
    class TNRaceSkinTiefelin : TNRaceSkin
    {
        private static int itemID = 0x2298;

        [Constructable]
        public TNRaceSkinTiefelin() : this(0) { }
        [Constructable]
        public TNRaceSkinTiefelin(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinTiefelin(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinHalforc : TNRaceSkin
    {
        private static int itemID = 0x2297;

        [Constructable]
        public TNRaceSkinHalforc() : this(0) { }
        [Constructable]
        public TNRaceSkinHalforc(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinHalforc(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinHalfelin : TNRaceSkin
    {
        private static int itemID = 0x2296;

        [Constructable]
        public TNRaceSkinHalfelin() : this(0) { }
        [Constructable]
        public TNRaceSkinHalfelin(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinHalfelin(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinHalfElf : TNRaceSkin
    {
        private static int itemID = 0x2295;

        [Constructable]
        public TNRaceSkinHalfElf() : this(0) { }
        [Constructable]
        public TNRaceSkinHalfElf(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinHalfElf(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinGith : TNRaceSkin
    {
        private static int itemID = 0x2294;

        [Constructable]
        public TNRaceSkinGith() : this(0) { }
        [Constructable]
        public TNRaceSkinGith(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinGith(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinElf : TNRaceSkin
    {
        private static int itemID = 0x2293;

        [Constructable]
        public TNRaceSkinElf() : this(0) { }
        [Constructable]
        public TNRaceSkinElf(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinElf(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinDrake : TNRaceSkin
    {
        private static int itemID = 0x2292;

        [Constructable]
        public TNRaceSkinDrake() : this(0) { }
        [Constructable]
        public TNRaceSkinDrake(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinDrake(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinChangelin : TNRaceSkin
    {
        private static int itemID = 0x2291;

        [Constructable]
        public TNRaceSkinChangelin() : this(0) { }
        [Constructable]
        public TNRaceSkinChangelin(int hue) : base(itemID, hue) { }
        [Constructable]
        public TNRaceSkinChangelin(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer) { }
        public override void Deserialize(GenericReader reader) { }
    }

    class TNRaceSkinAasimar : TNRaceSkin
    {
        private static int itemID = 0x2290;

        [Constructable]
        public TNRaceSkinAasimar() : this(0) { }
        [Constructable]
		public TNRaceSkinAasimar( int hue ) : base( itemID, hue ){}
        [Constructable]
        public TNRaceSkinAasimar(Serial serial): base(serial){}

		public override void Serialize( GenericWriter writer ){}
		public override void Deserialize( GenericReader reader ){}
    }
    
    class TNRaceSkin : BaseShirt
    {
        private void config()
        {
            Layer = Layer.Shirt;
            Movable = false;
            Name = "Peau";
        }
        public TNRaceSkin( int itemID ) : this( itemID, 0 )
		{
            config();
		}

		public TNRaceSkin( int itemID, int hue ) : base( itemID,hue )
		{
            config();
		}

        public TNRaceSkin(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
    }
}
