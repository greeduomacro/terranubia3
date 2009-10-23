using System;
using System.Collections.Generic;

using System.Text;

namespace Server.Items
{
    public class MagieBook : Item
    {
        private ClasseType mClasse = ClasseType.Druide;

        [CommandProperty(AccessLevel.GameMaster)]
        public ClasseType NClasse
        {
            get { return mClasse; }
            set { mClasse = value; }
        }

        [Constructable]
        public MagieBook()
            : base(8793)
        {
            Name = "Grimoire";

        }
        public override void GetProperties(ObjectPropertyList list)
        {
            string infos = "Magie de "+Classe.GetNameClasse(mClasse);
            list.Add(infos);
        }
        public MagieBook(Serial s)
            : base(s)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);//version
            writer.Write((int)mClasse);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mClasse = (ClasseType)reader.ReadInt();
        }
    }
}
