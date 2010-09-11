using System;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using Server.Engines;
using System.Collections;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
    public abstract class BasePlanteSauvage : Item
    {

        protected int mDD = 15;

        [CommandProperty(AccessLevel.GameMaster)]
        public int DD
        {
            get { return mDD; }
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            from.Emote("*Tente de ramasser la plante {0}*", Name);
            new InternalTimer(from as PlayerMobile, this).Start();
        }

        private class InternalTimer : Timer
        {
            private NubiaMobile mPlayer;
            private BasePlanteSauvage mPlante;
            public InternalTimer(NubiaMobile player, BasePlanteSauvage plante)
                : base(WorldData.TimeTour())
            {
               mPlayer = player;
                mPlante = plante;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if (mPlante == null || mPlayer == null)
                    return;
                if (mPlante.Parent != null)
                {
                    mPlayer.SendMessage("la plante a déjà été ramassée");
                    return;
                }

                if (mPlayer.Competences[CompType.Survie].roll(mPlante.DD))
                {
                    mPlayer.Emote("*ramasse la plante*");
                    mPlante.Movable = true;
                    if (mPlayer.Backpack != null)
                        mPlayer.Backpack.AddItem(mPlante);
                }
                else
                {
                    mPlayer.Emote("*Saccage la plante*");
                    mPlante.Delete();
                }
            }

        }

        public BasePlanteSauvage() : base(1605){
            Name = "Plante sauvage";
            Movable = false;
        }

        public override double DefaultWeight
        {
            get { return 0.2; }
        }

        public BasePlanteSauvage(Serial s) : base(s) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}

