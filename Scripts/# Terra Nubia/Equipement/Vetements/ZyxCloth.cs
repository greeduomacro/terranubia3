using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class MCVeste : BaseClothing
    {
        [Constructable]
        public MCVeste() : this(0) { }

        [Constructable]
        public MCVeste(int hue)
            : base(13999, Layer.OuterTorso, hue)
        {
            Name = "Veste";
        }
        public MCVeste(Serial serial) : base(serial) { }

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
    public class MCTuniqueMao : BaseClothing
    {
        [Constructable]
        public MCTuniqueMao() : this(0) { }

        [Constructable]
        public MCTuniqueMao(int hue)
            : base(13998, Layer.OuterTorso, hue)
        {
            Name = "Tunique Mao";
        }
        public MCTuniqueMao(Serial serial) : base(serial) { }

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
    public class MCKimonoSimple : BaseClothing
    {
        [Constructable]
        public MCKimonoSimple() : this(0) { }

        [Constructable]
        public MCKimonoSimple(int hue)
            : base(13996, Layer.OuterTorso, hue)
        {
            Name = "Kimono simple";
        }
        public MCKimonoSimple(Serial serial) : base(serial) { }

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
    public class MCKimonoCombat : BaseClothing
    {
        [Constructable]
        public MCKimonoCombat() : this(0) { }

        [Constructable]
        public MCKimonoCombat(int hue)
            : base(13995, Layer.OuterTorso, hue)
        {
            Name = "Kimono de combat";
        }
        public MCKimonoCombat(Serial serial) : base(serial) { }

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
    public class MCPantalonAmple : BaseClothing
    {
        [Constructable]
        public MCPantalonAmple() : this(0) { }

        [Constructable]
        public MCPantalonAmple(int hue)
            : base(13994, Layer.Pants, hue)
        {
            Name = "Pantalons amples";
        }
        public MCPantalonAmple(Serial serial) : base(serial) { }

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
    public class MCHakama : BaseClothing
    {
        [Constructable]
        public MCHakama() : this(0) { }

        [Constructable]
        public MCHakama(int hue)
            : base(13993, Layer.OuterLegs, hue)
        {
            Name = "Hakama";
        }
        public MCHakama(Serial serial) : base(serial) { }

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
    public class MCCapeStrict : BaseClothing
    {
        [Constructable]
        public MCCapeStrict() : this(0) { }

        [Constructable]
        public MCCapeStrict(int hue)
            : base(13992, Layer.Cloak, hue)
        {
            Name = "Cape Strict";
        }
        public MCCapeStrict(Serial serial) : base(serial) { }

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
    public class MCBotteMouke : BaseClothing
    {
        [Constructable]
        public MCBotteMouke() : this(0) { }

        [Constructable]
        public MCBotteMouke(int hue)
            : base(13991, Layer.Shoes, hue)
        {
            Name = "Botte 'Mouke'";
        }
        public MCBotteMouke(Serial serial) : base(serial) { }

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
    public class MCToqueCuisine : BaseClothing
    {
        [Constructable]
        public MCToqueCuisine() : this(0) { }

        [Constructable]
        public MCToqueCuisine(int hue)
            : base(13990, Layer.Helm, hue)
        {
            Name = "Toque";
        }
        public MCToqueCuisine(Serial serial) : base(serial) { }

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

    public class MCRobeDivine : BaseClothing
    {
        [Constructable]
        public MCRobeDivine() : this(0) { }

        [Constructable]
        public MCRobeDivine(int hue)
            : base(13989, Layer.OuterTorso, hue)
        {
            Name = "Robe 'divine'";
        }
        public MCRobeDivine(Serial serial) : base(serial) { }

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
    public class MCCapeFourre : BaseClothing
    {
        [Constructable]
        public MCCapeFourre() : this(0) { }

        [Constructable]
        public MCCapeFourre(int hue)
            : base(13988, Layer.Cloak, hue)
        {
            Name = "Cape fourrée";
        }
        public MCCapeFourre(Serial serial) : base(serial) { }

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

    public class MCCapeCol : BaseClothing
    {
        [Constructable]
        public MCCapeCol() : this(0) { }

        [Constructable]
        public MCCapeCol(int hue)
            : base(13987, Layer.Cloak, hue)
        {
            Name = "Cape à col";
        }
        public MCCapeCol(Serial serial) : base(serial) { }

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
    public class MCBottesFourre : BaseClothing
    {
        [Constructable]
        public MCBottesFourre() : this(0) { }

        [Constructable]
        public MCBottesFourre(int hue)
            : base(13986, Layer.Shoes, hue)
        {
            Name = "Bottes fourrée";
        }
        public MCBottesFourre(Serial serial) : base(serial) { }

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
    public class MCRobeMort : BaseClothing
    {
        [Constructable]
        public MCRobeMort() : this(0) { }

        [Constructable]
        public MCRobeMort(int hue)
            : base(13979, Layer.OuterTorso, hue)
        {
            Name = "Robe des morts";
        }
        public MCRobeMort(Serial serial) : base(serial) { }

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
    public class MCManteau : BaseClothing
    {
        [Constructable]
        public MCManteau() : this(0) { }

        [Constructable]
        public MCManteau(int hue)
            : base(13978, Layer.OuterTorso, hue)
        {
            Name = "Manteau";
        }
        public MCManteau(Serial serial) : base(serial) { }

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
    public class MCPardessusLong : BaseClothing
    {
        [Constructable]
        public MCPardessusLong() : this(0) { }

        [Constructable]
        public MCPardessusLong(int hue)
            : base(13823, Layer.OuterTorso, hue)
        {
            Name = "Long pardessus";
        }
        public MCPardessusLong(Serial serial) : base(serial) { }

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
    public class MCTogeRaffine : BaseClothing
    {
        [Constructable]
        public MCTogeRaffine() : this(0) { }

        [Constructable]
        public MCTogeRaffine(int hue)
            : base(13822, Layer.OuterTorso, hue)
        {
            Name = "Toge raffinée";
        }
        public MCTogeRaffine(Serial serial) : base(serial) { }

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
    public class MCRobeGitane : BaseClothing
    {
        [Constructable]
        public MCRobeGitane() : this(0) { }

        [Constructable]
        public MCRobeGitane(int hue)
            : base(13821, Layer.MiddleTorso, hue)
        {
            Name = "Robe gitane";
        }
        public MCRobeGitane(Serial serial) : base(serial) { }

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
    public class MCJupette : BaseClothing
    {
        [Constructable]
        public MCJupette() : this(0) { }

        [Constructable]
        public MCJupette(int hue)
            : base(13813, Layer.OuterLegs, hue)
        {
            Name = "Jupette";
        }
        public MCJupette(Serial serial) : base(serial) { }

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
    public class MCTuniqueRembourre : BaseClothing
    {
        [Constructable]
        public MCTuniqueRembourre() : this(0) { }

        [Constructable]
        public MCTuniqueRembourre(int hue)
            : base(13812, Layer.OuterTorso, hue)
        {
            Name = "Tunique rembourrée";
        }
        public MCTuniqueRembourre(Serial serial) : base(serial) { }

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

    public class MCMasqueFin : BaseClothing
    {
        [Constructable]
        public MCMasqueFin() : this(0) { }

        [Constructable]
        public MCMasqueFin(int hue)
            : base(13811, Layer.Helm, hue)
        {
            Name = "Masque fin";
        }
        public MCMasqueFin(Serial serial) : base(serial) { }

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

    public class NCChemiseRaffine : BaseClothing
    {
        [Constructable]
        public NCChemiseRaffine() : this(0) { }

        [Constructable]
        public NCChemiseRaffine(int hue)
            : base(13810, Layer.MiddleTorso, hue)
        {
            Name = "Chemise Raffinée";
        }
        public NCChemiseRaffine(Serial serial) : base(serial) { }

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
    public class NCHautMoulant : BaseClothing
    {
        [Constructable]
        public NCHautMoulant() : this(0) { }

        [Constructable]
        public NCHautMoulant(int hue)
            : base(13769, Layer.MiddleTorso, hue)
        {
            Name = "Haut moulant";
        }
        public NCHautMoulant(Serial serial) : base(serial) { }

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
    public class NCDoubletUneManche : BaseClothing
    {
        [Constructable]
        public NCDoubletUneManche() : this(0) { }

        [Constructable]
        public NCDoubletUneManche(int hue)
            : base(13768, Layer.InnerTorso, hue)
        {
            Name = "Doublet une manche";
        }
        public NCDoubletUneManche(Serial serial) : base(serial) { }

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
    public class NCChemiseTombante : BaseClothing
    {
        [Constructable]
        public NCChemiseTombante() : this(0) { }

        [Constructable]
        public NCChemiseTombante(int hue)
            : base(13767, Layer.MiddleTorso, hue)
        {
            Name = "Chemise tombante";
        }
        public NCChemiseTombante(Serial serial) : base(serial) { }

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
    public class NCDoubletRaffine : BaseClothing
    {
        [Constructable]
        public NCDoubletRaffine() : this(0) { }

        [Constructable]
        public NCDoubletRaffine(int hue)
            : base(13766, Layer.InnerTorso, hue)
        {
            Name = "Doublet raffiné";
        }
        public NCDoubletRaffine(Serial serial) : base(serial) { }

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
    public class NCPantalonMoulant : BaseClothing
    {
        [Constructable]
        public NCPantalonMoulant() : this(0) { }

        [Constructable]
        public NCPantalonMoulant(int hue)
            : base(13765, Layer.Pants, hue)
        {
            Name = "Pantalon moulant";
        }
        public NCPantalonMoulant(Serial serial) : base(serial) { }

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
    public class NCRobeCompose : BaseClothing
    {
        [Constructable]
        public NCRobeCompose() : this(0) { }

        [Constructable]
        public NCRobeCompose(int hue)
            : base(13763, Layer.InnerTorso, hue)
        {
            Name = "Robe Composée";
        }
        public NCRobeCompose(Serial serial) : base(serial) { }

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
    public class NCRobeAraigne : BaseClothing
    {
        [Constructable]
        public NCRobeAraigne() : this(0) { }

        [Constructable]
        public NCRobeAraigne(int hue)
            : base(13762, Layer.InnerTorso, hue)
        {
            Name = "Robe Araignée";
        }
        public NCRobeAraigne(Serial serial) : base(serial) { }

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
    public class NCRobeElegante : BaseClothing
    {
        [Constructable]
        public NCRobeElegante() : this(0) { }

        [Constructable]
        public NCRobeElegante(int hue)
            : base(13761, Layer.InnerTorso, hue)
        {
            Name = "Robe Elegante";
        }
        public NCRobeElegante(Serial serial) : base(serial) { }

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
    public class NCRobeFantaisie : BaseClothing
    {
        [Constructable]
        public NCRobeFantaisie() : this(0) { }

        [Constructable]
        public NCRobeFantaisie(int hue)
            : base(13760, Layer.InnerTorso, hue)
        {
            Name = "Robe Fantaisie";
        }
        public NCRobeFantaisie(Serial serial) : base(serial) { }

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
    public class NCTricornePirate : BaseClothing
    {
        [Constructable]
        public NCTricornePirate() : this(0) { }

        [Constructable]
        public NCTricornePirate(int hue)
            : base(13737, Layer.Helm, hue)
        {
            Name = "Tricorne Pirate";
        }
        public NCTricornePirate(Serial serial) : base(serial) { }

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
    public class NCTricorneTDM : BaseClothing
    {
        [Constructable]
        public NCTricorneTDM() : this(0) { }

        [Constructable]
        public NCTricorneTDM(int hue)
            : base(13736, Layer.Helm, hue)
        {
            Name = "Tricorne Tete de mort";
        }
        public NCTricorneTDM(Serial serial) : base(serial) { }

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
    public class NCChapeauMelon : BaseClothing
    {
        [Constructable]
        public NCChapeauMelon() : this(0) { }

        [Constructable]
        public NCChapeauMelon(int hue)
            : base(13741, Layer.Helm, hue)
        {
            Name = "Chapeau Melon";
        }
        public NCChapeauMelon(Serial serial) : base(serial) { }

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
    public class NCRobeFeuille : BaseClothing
    {
        [Constructable]
        public NCRobeFeuille() : this(0) { }

        [Constructable]
        public NCRobeFeuille(int hue)
            : base(13740, Layer.InnerTorso, hue)
        {
            Name = "Robe feuille";
        }
        public NCRobeFeuille(Serial serial) : base(serial) { }

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
    public class NCRobeFendue : BaseClothing
    {
        [Constructable]
        public NCRobeFendue() : this(0) { }

        [Constructable]
        public NCRobeFendue(int hue)
            : base(13739, Layer.MiddleTorso, hue)
        {
            Name = "Robe fendue";
        }
        public NCRobeFendue(Serial serial) : base(serial) { }

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
    public class NCKimono : BaseClothing
    {
        [Constructable]
        public NCKimono() : this(0) { }

        [Constructable]
        public NCKimono(int hue)
            : base(13738, Layer.OuterTorso, hue)
        {
            Name = "Kimono";
        }
        public NCKimono(Serial serial) : base(serial) { }

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
    public class NCBandageTorse : BaseClothing
    {
        [Constructable]
        public NCBandageTorse() : this(0) { }

        [Constructable]
        public NCBandageTorse(int hue)
            : base(12553, Layer.MiddleTorso, hue)
        {
            Name = "Bandages";
        }
        public NCBandageTorse(Serial serial) : base(serial) { }

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
    public class NCBandageJambes : BaseClothing
    {
        [Constructable]
        public NCBandageJambes() : this(0) { }

        [Constructable]
        public NCBandageJambes(int hue)
            : base(12551, Layer.Arms, hue)
        {
            Name = "Bandages";
        }
        public NCBandageJambes(Serial serial) : base(serial) { }

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
    public class NCBandageBras : BaseClothing
    {
        [Constructable]
        public NCBandageBras() : this(0) { }

        [Constructable]
        public NCBandageBras(int hue)
            : base(12551, Layer.Arms, hue)
        {
            Name = "Bandages";
        }
        public NCBandageBras(Serial serial) : base(serial) { }

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
    public class NCPlumes : BaseClothing
    {
        [Constructable]
        public NCPlumes() : this(0) { }

        [Constructable]
        public NCPlumes(int hue)
            : base(12550, Layer.Helm, hue)
        {
            Name = "Plumes";
        }
        public NCPlumes(Serial serial) : base(serial) { }

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
    public class NCPetiteBourse : BaseClothing
    {
        [Constructable]
        public NCPetiteBourse() : this(0) { }

        [Constructable]
        public NCPetiteBourse(int hue)
            : base(12549, Layer.Waist, hue)
        {
            Name = "Petite bourse";
        }
        public NCPetiteBourse(Serial serial) : base(serial) { }

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
    public class NCColierOs : BaseClothing
    {
        [Constructable]
        public NCColierOs() : this(0) { }

        [Constructable]
        public NCColierOs(int hue)
            : base(12548, Layer.Neck, hue)
        {
            Name = "Collier d'os";
        }
        public NCColierOs(Serial serial) : base(serial) { }

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
    
    public class NCBourses : BaseClothing
    {
        [Constructable]
        public NCBourses() : this(0) { }

        [Constructable]
        public NCBourses(int hue)
            : base(12547, Layer.Waist, hue)
        {
            Name = "Bourses";
        }
        public NCBourses(Serial serial) : base(serial) { }

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
    public class NCCeinture : BaseClothing
    {
        [Constructable]
        public NCCeinture() : this(0) { }

        [Constructable]
        public NCCeinture(int hue)
            : base(12546, Layer.Waist, hue)
        {
            Name = "Ceinture";
        }
        public NCCeinture(Serial serial) : base(serial) { }

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



    /**
     * LOT 1 
     */ 
    public class NCMasque : BaseClothing
    {
        [Constructable]
        public NCMasque() : this(0) { }

        [Constructable]
        public NCMasque(int hue)
            : base(12535, Layer.Helm, hue)
        {
            Name = "Masque";
        }
        public NCMasque(Serial serial) : base(serial) { }

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

    public class NCFoulardNoble : BaseClothing
    {
        [Constructable]
        public NCFoulardNoble() : this(0) { }

        [Constructable]
        public NCFoulardNoble(int hue)
            : base(12533, Layer.Helm, hue)
        {
            Name = "Foulard raffiné";
        }
        public NCFoulardNoble(Serial serial) : base(serial) { }

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
    public class NCBrassardResille : BaseClothing
    {
        [Constructable]
        public NCBrassardResille() : this(0) { }

        [Constructable]
        public NCBrassardResille(int hue)
            : base(12532, Layer.Arms, hue)
        {
            Name = "Brassard résille";
        }
        public NCBrassardResille(Serial serial) : base(serial) { }

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

    public class NCFoulard : BaseClothing
    {
        [Constructable]
        public NCFoulard() : this(0) { }

        [Constructable]
        public NCFoulard(int hue)
            : base(12531, Layer.Helm, hue)
        {
            Name = "Foulard";
        }
        public NCFoulard(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            if (ItemID == 12531)
                ItemID = 12534;
            else
                ItemID = 12531;
        }

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

    public class NCGeta : BaseClothing
    {
        [Constructable]
        public NCGeta() : this(0) { }

        [Constructable]
        public NCGeta(int hue)
            : base(12530, Layer.Shoes, hue)
        {
            Name = "Getas";
        }
        public NCGeta(Serial serial) : base(serial) { }

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
    public class NCBracer : BaseClothing
    {
        [Constructable]
        public NCBracer(): this(0){}

        [Constructable]
        public NCBracer(int hue)
            : base(12529, Layer.Gloves, hue)
        {
            Name = "Bracelets";
        }
        public NCBracer(Serial serial): base(serial){}

        public override void Serialize(GenericWriter writer){
            base.Serialize(writer); writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader){
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
