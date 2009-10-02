using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Items
{
    public class LivreChirurgie : LivreSavoir
    {
        [Constructable]
        public LivreChirurgie()
        {
            Competence = CompType.Chirurgie;
        }
        [Constructable]
        public LivreChirurgie(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreUtilisationObjetMagique : LivreSavoir
    {
        [Constructable]
        public LivreUtilisationObjetMagique()
        {
            Competence = CompType.UtilisationObjetsMagiques;
        }
        [Constructable]
        public LivreUtilisationObjetMagique(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreEscamotage : LivreSavoir
    {
        [Constructable]
        public LivreEscamotage()
        {
            Competence = CompType.Escamotage;
        }
        [Constructable]
        public LivreEscamotage(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreDressage : LivreSavoir
    {
        [Constructable]
        public LivreDressage()
        {
            Competence = CompType.Dressage;
        }
        [Constructable]
        public LivreDressage(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreDesamorcage : LivreSavoir
    {
        [Constructable]
        public LivreDesamorcage()
        {
            Competence = CompType.Desamorçage;
        }
        [Constructable]
        public LivreDesamorcage(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
   /* public class LivreDecryptage : LivreSavoir
    {
        [Constructable]
        public LivreDecryptage()
        {
            Competence = CompType.Decryptage;
        }
        [Constructable]
        public LivreDecryptage(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }*/
    public class LivreCrochetage : LivreSavoir
    {
        [Constructable]
        public LivreCrochetage()
        {
            Competence = CompType.Crochetage;
        }
        [Constructable]
        public LivreCrochetage(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreArtMagie : LivreSavoir
    {
        [Constructable]
        public LivreArtMagie()
        {
            Competence = CompType.ArtMagie;
        }
        [Constructable]
        public LivreArtMagie(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public class LivreAcrobaties : LivreSavoir
    {
        [Constructable]
        public LivreAcrobaties()
        {
            Competence = CompType.Acrobaties;
        }
        [Constructable]
        public LivreAcrobaties(Serial s)
            : base(s)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
    public abstract class LivreSavoir : Item
    {
        private CompType mCompetence = CompType.Acrobaties;

        [CommandProperty(AccessLevel.GameMaster)]
        public CompType Competence
        {
            get { return mCompetence; }
            set { mCompetence = value; }
        }
        public LivreSavoir()
            : base(4029)
        {
            Name = "Livre du savoir";
        }
        public LivreSavoir(Serial s)
            : base(s)
        {
        }
        public override void OnDoubleClick(Mobile f)
        {
            base.OnDoubleClick(f);
            NubiaMobile from = f as NubiaMobile;
            from.Competences.LearnCompetence(mCompetence);
            Delete();
        }
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add("Compétence: " + mCompetence.ToString());
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
            writer.Write((int)mCompetence);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mCompetence = (CompType)reader.ReadInt();
        }
    }
}
