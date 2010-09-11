using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{

    ///Ninjaaaaaaa !
    ///
    public class TNNinjaBrassard : BaseClothing
    {
        [Constructable]
        public TNNinjaBrassard() : this(0) { }

        [Constructable]
        public TNNinjaBrassard(int hue)
            : base(8888, Layer.Shoes, hue)
        {
            Name = "Brassards de tissu";
            Layer = Layer.Arms;
        }
        public TNNinjaBrassard(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    
    public class TNNinjaSandals2 : BaseClothing
    {
        [Constructable]
        public TNNinjaSandals2() : this(0) { }

        [Constructable]
        public TNNinjaSandals2(int hue)
            : base(8887, Layer.Shoes, hue)
        {
            Name = "Sandales de tissu";
            Layer = Layer.Shoes;
        }
        public TNNinjaSandals2(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    
    public class TNNinjaTunic : BaseClothing
    {
        [Constructable]
        public TNNinjaTunic() : this(0) { }

        [Constructable]
        public TNNinjaTunic(int hue)
            : base(8886, Layer.OuterTorso, hue)
        {
            Name = "Tunic épaisse";
            Layer = Layer.OuterTorso;
        }
        public TNNinjaTunic(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNNinjaCache : BaseClothing
    {
        [Constructable]
        public TNNinjaCache() : this(0) { }

        [Constructable]
        public TNNinjaCache(int hue)
            : base(8885, Layer.Neck, hue)
        {
            Name = "Cache visage";
            Layer = Layer.Neck;
        }
        public TNNinjaCache(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNNinjaBoots : BaseClothing
    {
        [Constructable]
        public TNNinjaBoots() : this(0) { }

        [Constructable]
        public TNNinjaBoots(int hue)
            : base(8884, Layer.Shoes, hue)
        {
            Name = "Bottes de tissus";
            Layer = Layer.Shoes;
        }
        public TNNinjaBoots(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNNinjaSandals : BaseClothing
    {
        [Constructable]
        public TNNinjaSandals() : this(0) { }

        [Constructable]
        public TNNinjaSandals(int hue)
            : base(8883, Layer.Shoes, hue)
        {
            Name = "Sandales rembourrées";
            Layer = Layer.Shoes;
        }
        public TNNinjaSandals(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNNinjaArms : BaseClothing
    {
        [Constructable]
        public TNNinjaArms() : this(0) { }

        [Constructable]
        public TNNinjaArms(int hue)
            : base(8882, Layer.Arms, hue)
        {
            Name = "Epaulettes";
            Layer = Layer.Arms;
        }
        public TNNinjaArms(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNNinjaGlove : BaseClothing
    {
        [Constructable]
        public TNNinjaGlove() : this(0) { }

        [Constructable]
        public TNNinjaGlove(int hue)
            : base(8881, Layer.Gloves, hue)
        {
            Name = "Gants";
            Layer = Layer.Gloves;
        }
        public TNNinjaGlove(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }


    /// <summary>
    /// ROBES
    /// </summary>
    /// 
    public class TNRobe10 : BaseClothing
    {
        [Constructable]
        public TNRobe10() : this(0) { }

        [Constructable]
        public TNRobe10(int hue)
            : base(9095, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe10(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNRobe9 : BaseClothing
    {
        [Constructable]
        public TNRobe9() : this(0) { }

        [Constructable]
        public TNRobe9(int hue)
            : base(9094, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe9(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNRobe8 : BaseClothing
    {
        [Constructable]
        public TNRobe8() : this(0) { }

        [Constructable]
        public TNRobe8(int hue)
            : base(9093, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe8(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe7 : BaseClothing
    {
        [Constructable]
        public TNRobe7() : this(0) { }

        [Constructable]
        public TNRobe7(int hue)
            : base(9092, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe7(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe6 : BaseClothing
    {
        [Constructable]
        public TNRobe6() : this(0) { }

        [Constructable]
        public TNRobe6(int hue)
            : base(9091, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe6(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe5 : BaseClothing
    {
        [Constructable]
        public TNRobe5() : this(0) { }

        [Constructable]
        public TNRobe5(int hue)
            : base(9090, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe5(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe4 : BaseClothing
    {
        [Constructable]
        public TNRobe4() : this(0) { }

        [Constructable]
        public TNRobe4(int hue)
            : base(9089, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe4(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe3 : BaseClothing
    {
        [Constructable]
        public TNRobe3() : this(0) { }

        [Constructable]
        public TNRobe3(int hue)
            : base(9088, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe3(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNRobe2 : BaseClothing
    {
        [Constructable]
        public TNRobe2() : this(0) { }

        [Constructable]
        public TNRobe2(int hue)
            : base(9087, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe2(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNRobe1 : BaseClothing
    {
        [Constructable]
        public TNRobe1() : this(0) { }

        [Constructable]
        public TNRobe1(int hue)
            : base(9086, Layer.OuterTorso, hue)
        {
            Name = "Robe";
        }
        public TNRobe1(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    /// <summary>
    ///  AUTRES
    /// </summary>
    public class TNCapuche : BaseClothing
    {
        [Constructable]
        public TNCapuche() : this(0) { }

        [Constructable]
        public TNCapuche(int hue)
            : base(15828, Layer.Helm, hue)
        {
            Name = "Capuche";
        }
        public TNCapuche(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNCapucheRodeur : BaseClothing
    {
        [Constructable]
        public TNCapucheRodeur() : this(0) { }

        [Constructable]
        public TNCapucheRodeur(int hue)
            : base(15827, Layer.Helm, hue)
        {
            Name = "Capuche";
        }
        public TNCapucheRodeur(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNGuenilles : BaseClothing
    {
        [Constructable]
        public TNGuenilles() : this(0) { }

        [Constructable]
        public TNGuenilles(int hue)
            : base(11405, Layer.OuterTorso, hue)
        {
            Name = "Guenilles";
        }
        public TNGuenilles(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNPelerine : BaseClothing
    {
        [Constructable]
        public TNPelerine() : this(0) { }

        [Constructable]
        public TNPelerine(int hue)
            : base(11258, Layer.OuterTorso, hue)
        {
            Name = "Pelerine";
        }
        public TNPelerine(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNVeste : BaseClothing
    {
        [Constructable]
        public TNVeste() : this(0) { }

        [Constructable]
        public TNVeste(int hue)
            : base(11257, Layer.OuterTorso, hue)
        {
            Name = "Veste";
        }
        public TNVeste(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNCeinture5 : BaseClothing
    {
        [Constructable]
        public TNCeinture5() : this(0) { }

        [Constructable]
        public TNCeinture5(int hue)
            : base(11256, Layer.Waist, hue)
        {
            Name = "Ceinturon";
        }
        public TNCeinture5(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNCeinture4 : BaseClothing
    {
        [Constructable]
        public TNCeinture4() : this(0) { }

        [Constructable]
        public TNCeinture4(int hue)
            : base(11255, Layer.Waist, hue)
        {
            Name = "Ceinturon";
        }
        public TNCeinture4(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNCeinture3 : BaseClothing
    {
        [Constructable]
        public TNCeinture3() : this(0) { }

        [Constructable]
        public TNCeinture3(int hue)
            : base(11254, Layer.Waist, hue)
        {
            Name = "Ceinturon";
        }
        public TNCeinture3(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TNCeinture2 : BaseClothing
    {
        [Constructable]
        public TNCeinture2() : this(0) { }

        [Constructable]
        public TNCeinture2(int hue)
            : base(11253, Layer.Waist, hue)
        {
            Name = "Ceinturon";
        }
        public TNCeinture2(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    public class TNCeinture1 : BaseClothing
    {
        [Constructable]
        public TNCeinture1() : this(0) { }

        [Constructable]
        public TNCeinture1(int hue)
            : base(11252, Layer.Waist, hue)
        {
            Name = "Ceinturon";
        }
        public TNCeinture1(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
