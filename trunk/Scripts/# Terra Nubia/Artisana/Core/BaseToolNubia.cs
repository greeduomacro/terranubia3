using System;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using Server.Engines;
using Server.Gumps;

namespace Server.Items
{
    //[FlipableAttribute( 0x1EBA, 0x1EBB )]
    public abstract class BaseToolNubia : Item
    {
        //public override int LabelNumber{ get{ return 1041279; } } // a taxidermy kit
        private BaseMetal mMetal = null; //new MetalFer();
        private BaseBois mBois = null; // BoisErable();
        private BaseCuir mCuir = null; // CuirClassique();
        private BaseOs mOs = null; // CuirClassique();

        public BaseMetal Metal { get { return mMetal; } set { mMetal = value; } }
        public BaseBois Bois { get { return mBois; } set { mBois = value; } }
        public BaseCuir Cuir { get { return mCuir; } set { mCuir = value; } }
        public BaseOs Os { get { return mOs; } set { mOs = value; } }

        public abstract CraftSystemNubia System { get;}

        //public virtualType System{get{return typeof( ForgeArmeSystem );}}
        //[Constructable]
        public BaseToolNubia(int itemid)
            : base(itemid)
        {
        }

        public BaseToolNubia(Serial serial)
            : base(serial)
        {
        }
        public void GetNewMetal(NubiaPlayer mob)
        {
            mob.Target = new InternalTarget(mob, this, typeof(BaseMetal));
        }
        public void GetNewBois(NubiaPlayer mob)
        {
            mob.Target = new InternalTarget(mob, this, typeof(BaseBois));
        }
        public void GetNewOs(NubiaPlayer mob)
        {
            mob.Target = new InternalTarget(mob, this, typeof(BaseOs));
        }
        public void GetNewCuir(NubiaPlayer mob)
        {
            mob.Target = new InternalTarget(mob, this, typeof(BaseCuir));
        }

        private class InternalTarget : Target
        {
            private NubiaMobile mCrafter;
            private BaseToolNubia mTool;
            private Type mType;

            public InternalTarget(NubiaMobile crafter, BaseToolNubia t, Type _type)
                : base(2, false, TargetFlags.None)
            {
                mTool = t;
                mType = _type;
                mCrafter = crafter;
                mCrafter.SendMessage("Selectionnez le nouveau matériaux");
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is BaseMetal && mType == typeof(BaseMetal))
                {
                    mTool.Metal = o as BaseMetal;
                }
                else if (o is BaseBois && mType == typeof(BaseBois))
                {
                    mTool.Bois = o as BaseBois;
                }
                else if (o is BaseOs && mType == typeof(BaseOs))
                {
                    mTool.Os = o as BaseOs;
                }
                else if (o is BaseCuir && mType == typeof(BaseCuir))
                {
                    mTool.Cuir = o as BaseCuir;
                }
                else
                    mCrafter.SendMessage("Cible non valide");
                mTool.OnDoubleClick(mCrafter);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            NubiaPlayer player = from as NubiaPlayer;
            CraftSystemNubia sys = null;
 

            if (System.GetType() == typeof(CraftForgeSystem))
            {
                bool anvil, forge;
                CheckAnvilAndForge(from, 2, out anvil, out forge);
                if (!(anvil) || !(forge))
                {
                    from.SendMessage("Vous devez être proche d'une forge et d'une enclume.");
                    return;
                }
            }

            from.CloseGump(typeof(GumpArtisan));

            if (!IsChildOf(from.Backpack) && !IsChildOf(from) )
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else if (System != null)
                from.SendGump(new GumpArtisan(this, System, from as NubiaPlayer) );
            else
                from.SendMessage("[BUG] Impossible de construire le CraftSystemNubia. BaseToolNubia.cs");

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


        public static void CheckAnvilAndForge(Mobile from, int range, out bool anvil, out bool forge)
        {
            anvil = false;
            forge = false;

            Map map = from.Map;

            if (map == null)
                return;

            IPooledEnumerable eable = map.GetItemsInRange(from.Location, range);

            foreach (Item item in eable)
            {
                Type type = item.GetType();

                bool isAnvil = (item.ItemID == 4015 || item.ItemID == 4016 || item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6);
                bool isForge = (item.ItemID == 4017 || (item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8);

                if (isAnvil || isForge)
                {
                    if ((from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS(item))
                        continue;

                    anvil = anvil || isAnvil;
                    forge = forge || isForge;

                    if (anvil && forge)
                        break;
                }
            }

            eable.Free();

            for (int x = -range; (!anvil || !forge) && x <= range; ++x)
            {
                for (int y = -range; (!anvil || !forge) && y <= range; ++y)
                {
                    Tile[] tiles = map.Tiles.GetStaticTiles(from.X + x, from.Y + y, true);

                    for (int i = 0; (!anvil || !forge) && i < tiles.Length; ++i)
                    {
                        int id = tiles[i].ID & 0x3FFF;

                        bool isAnvil = (id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6);
                        bool isForge = (id == 4017 || (id >= 6522 && id <= 6569) || id == 0x2DD8);

                        if (isAnvil || isForge)
                        {
                            if ((from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z || !from.InLOS(new Point3D(from.X + x, from.Y + y, tiles[i].Z + (tiles[i].Height / 2) + 1)))
                                continue;

                            anvil = anvil || isAnvil;
                            forge = forge || isForge;
                        }
                    }
                }
            }
        }
    }

}
