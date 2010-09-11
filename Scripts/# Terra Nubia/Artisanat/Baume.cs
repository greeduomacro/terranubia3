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
     public class BandageBaumeTimer : Timer
        {
            private BandageBaume mBandage;
            private NubiaMobile mSoigneur;
            private NubiaMobile mVictime;
            public BandageBaumeTimer(NubiaMobile soigneur, NubiaMobile victime, BandageBaume b)
                : base(WorldData.TimeTour())
            {
                mBandage = b;
                mSoigneur = soigneur;
                mVictime = victime;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if( mSoigneur == null )
                    return;
                if ( !mSoigneur.Alive )
                    return;
                if (mVictime == null)
                    return;
                if (!mVictime.Alive)
                    return;
                if( mBandage == null )
                    return;
                if (mSoigneur.Competences[CompType.PremiersSecours].roll(15))
                {
                    mSoigneur.Emote("*Soigne {0}*", mVictime.Name);
                    mVictime.Heal( 5 + mSoigneur.Competences[CompType.PremiersSecours].intRoll() );

                }
                else
                {
                    mSoigneur.Emote("*N'arrive pas à soigner*");
                   
                }
                if (mBandage != null)
                    mBandage.Consume();
            }
        }
    public class BandageBaume : Item
    {
        [Constructable]
        public BandageBaume()
            : base(3616)
        {
            Name = "Bandage au baume d'Althae";
            Hue = 1928;
        }

        [Constructable]
        public BandageBaume(Serial s) : base(s) { }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            from.Target = new InternalTarget(from as NubiaMobile, this);
        }

        private class InternalTarget : Target
        {
            private NubiaMobile mSoigneur;
            private BandageBaume mBaume;
            public InternalTarget(NubiaMobile soigneur, BandageBaume baume)
                : base(1, false, TargetFlags.Beneficial)
            {
                mSoigneur = soigneur;
                mBaume = baume;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                base.OnTarget(from, targeted);
                if (from == null)
                    return;
                if (targeted is NubiaMobile)
                {
                    from.Emote("*tente de soigner {0}*", ((NubiaMobile)targeted).Name );
                    new BandageBaumeTimer( mSoigneur, targeted as NubiaMobile, mBaume ).Start();
                }
                else
                    from.SendMessage("vous ne pouvez pas l'utiliser là dessus");
            }
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
       

    public class PotionBaume : Item
    {
        [Constructable]
        public PotionBaume(): base(3854)
        {
            Name = "Baume d'Althaea";
            Hue = 1928;
        }

        [Constructable]
        public PotionBaume(Serial s) : base(s) { }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            if (from != null && from.Backpack != null)
            {
                Bandage b = null;
                foreach (Item item in from.Backpack.Items)
                {
                    if (item is Bandage)
                    {
                        b = item as Bandage;
                        break;
                    }
                }
                if (b != null)
                {
                    from.Emote("*impregne un bandage du baume*");

                    from.Backpack.AddItem(new BandageBaume());
                    b.Consume();
                    Delete();
                }
                from.SendMessage("Vous devez avoir un bandage propre pour l'utiliser");
            }
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
}

