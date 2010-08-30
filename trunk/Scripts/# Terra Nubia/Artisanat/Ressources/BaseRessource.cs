using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;

namespace Server.Engines
{
    public abstract class BaseRessource : Item
    {
        protected bool m_isRaffine = false;
        protected NubiaRessource mRessource = NubiaRessource.Fer;


        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaRessource Ressource
        {
            get
            {
                return mRessource;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaInfoRessource Infos
        {
            get
            {
                return NubiaInfoRessource.GetInfoRessource(mRessource);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual bool isRaffine
        {
            get
            {
                return m_isRaffine;
            }
            set
            {
                m_isRaffine = value;
            }
        }

        public BaseRessource(int itemid)
            : this(itemid, 1)
        {

        }
        public BaseRessource(int itemid, int amount)
            : base(itemid)
        {
            Name = "Ressource";
            Stackable = true;
            Amount = amount;
        }
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add("["+mRessource.ToString()+"]");
        }

        public BaseRessource(Serial s)
            : base(s)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_isRaffine = reader.ReadBool();
            mRessource = (NubiaRessource)reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((bool)m_isRaffine);
            writer.Write((int)mRessource);

        }
    }
}
