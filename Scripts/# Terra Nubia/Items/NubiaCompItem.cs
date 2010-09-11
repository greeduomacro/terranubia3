using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    public class NubiaCompItem : Item
    {
        private bool misBloquant = false;
        private bool mprovocChute = false;
        private bool misTeleport = false;
        private Point3D mteleportTarget = new Point3D();
        private int mDD = 20;
        private CompType mComp = CompType.Acrobaties;

        [CommandProperty(AccessLevel.GameMaster)]
        public CompType Comp
        {
            get { return mComp; }
            set { mComp = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DD
        {
            get { return mDD; }
            set { mDD = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool isBloquant
        {
            get { return misBloquant; }
            set { misBloquant = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool provocChute
        {
            get { return mprovocChute; }
            set { mprovocChute = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public bool isTeleport
        {
            get { return misTeleport; }
            set { misTeleport = value; }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D teleportTarget
        {
            get { return mteleportTarget; }
            set { mteleportTarget = value; }
        }

        [Constructable]
        public NubiaCompItem()
            : base(7034)
        {
            mteleportTarget = this.Location;
            mteleportTarget.Z -= 5;
            Movable = false;
            Visible = false;
        }
        [Constructable]
        public NubiaCompItem(Serial s)
            : base(s)
        {
            Movable = false;
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (!(m is NubiaMobile))
                return false;
            NubiaMobile mob = m as NubiaMobile;
            bool resultOk = mob.Competences[mComp].roll(10);
            mob.Competences.wait(1);
            if (isBloquant)
            {
                if (resultOk)
                    mob.SendMessage("Vous n'arrivez pas à passer ici ( jet de " + mComp.ToString() + " raté)");
                else
                    mob.SendMessage("En utilisant {0} vous arrivez à passer", mComp.ToString());
                return resultOk;
            }
            else if ( provocChute)
            {
                if (!resultOk)
                {
                    mob.Emote("*chute*");
                    mob.SetLocation(mteleportTarget, false);
                }
            }
            else if (misTeleport)
            {
                if (resultOk)
                {
                    mob.SetLocation(mteleportTarget, false);
                }
                else
                {
                    mob.SendMessage("Vous n'arrivez pas à passer ici ( jet de " + mComp.ToString() + " raté)");
                }
            }
            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((bool)misBloquant);
            writer.Write((bool)mprovocChute);
            writer.Write((bool)misTeleport);
            writer.Write((Point3D)mteleportTarget);
            writer.Write((int)mDD);
            writer.Write((int)mComp);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            misBloquant = reader.ReadBool();
            mprovocChute = reader.ReadBool();
            misTeleport = reader.ReadBool();
            mteleportTarget = reader.ReadPoint3D();
            mDD = reader.ReadInt();
            mComp = (CompType)reader.ReadInt();
        }
    }
}
