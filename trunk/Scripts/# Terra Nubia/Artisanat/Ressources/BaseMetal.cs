using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Misc;

namespace Server.Engines
{
    public abstract class BaseMetal : BaseRessource
    {      
        [CommandProperty(AccessLevel.GameMaster)]
        public override bool isRaffine
        {
            get
            {
                return m_isRaffine;
            }
            set
            {
                m_isRaffine = value;
                if (m_isRaffine)
                {
                    ItemID = 7157;
                }
                else
                    ItemID = 0x19B9;
            }
        }

        public BaseMetal(NubiaRessource _metal)
            : base(0x19B9)
        {
            mRessource = _metal;
            Hue = Infos.Hue;
            Name = "Metal";
        }

        public BaseMetal(Serial s)
            : base(s)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (isRaffine)
                return;
            if (from.NextSkillTime > DateTime.Now)
                return;
            else
                from.Target = new InternalFonteTarget(from as NubiaPlayer, this);
        }
        private class InternalFonteTarget : Target
        {
            private NubiaPlayer m_owner;
            private BaseMetal m_metal;

            public InternalFonteTarget(NubiaPlayer owner, BaseMetal met)
                : base(1, true, TargetFlags.None)
            {
                m_owner = owner;
                m_metal = met;
                m_owner.SendMessage("Où fondre le minerai ?");
            }

            protected override void OnTarget(Mobile from, object obj)
            {
                int itemID = 0;

                if (obj is Item)
                    itemID = ((Item)obj).ItemID;
                else if (obj is StaticTarget)
                    itemID = ((StaticTarget)obj).ItemID & 0x3FFF;

                bool canFonte = (itemID == 4017 || (itemID >= 6522 && itemID <= 6569));


                if (canFonte)
                {
                    from.NextSkillTime = DateTime.Now + TimeSpan.FromSeconds(8.0);
                    from.Emote("*Fond du minerai*");
                    from.SendMessage("Vous commencez à fondre le métal");
                    new DelayFonte(m_owner, m_metal).Start();
                }
                else
                    from.SendMessage("Ceci n'est pas adapté");

            }
        }
        private class DelayFonte : Timer
        {
            private NubiaPlayer m_owner;
            private BaseMetal m_metal;

            public DelayFonte(NubiaPlayer _owner, BaseMetal _metal)
                : base(TimeSpan.FromSeconds(6.0))
            {
                Priority = TimerPriority.OneSecond;
                m_owner = _owner;
                m_owner.Animate(16, 30, 1, true, false, 0);
                //m_mineur.PlaySound( 0x51D );
                m_metal = _metal;
                m_owner.Freeze(TimeSpan.FromSeconds(6.0));
            }

            protected override void OnTick()
            {
                if ( true )//SkillCheck.CheckSkill(m_owner, m_owner.Skills[SkillName.Mining], m_metal.Infos.Diff ))
                {
                    m_owner.SendMessage("Vous fondez le metal avec succès");
                    m_metal.isRaffine = true;
                }
                else
                {
                    m_owner.SendMessage("Vous n'arrivez pas a fondre le métal. Votre tentative rend le minerai inexploitable");
                    if (m_metal.Amount > 2)
                        m_metal.Amount /= 2;
                    else
                        m_metal.Delete();
                }
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

        }
    }
}
