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
    public abstract class BaseBois : BaseRessource
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
                    ItemID = 0x1BDA;
                }
                else
                    ItemID = 0x1BDD;
            }
        }

        public BaseBois(NubiaRessource _bois)
            : base(0x1BDD)
        {
            mRessource = _bois;
            Hue = Infos.Hue;
            Name = "Bois";
        }



        public BaseBois(Serial s)
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
                from.Target = new InternalPlancheTarget(from as NubiaPlayer, this);
        }
        private class InternalPlancheTarget : Target
        {
            private NubiaPlayer m_owner;
            private BaseBois m_metal;

            public InternalPlancheTarget(NubiaPlayer owner, BaseBois met)
                : base(1, true, TargetFlags.None)
            {
                m_owner = owner;
                m_metal = met;
                m_owner.SendMessage("Où voulez vous travailler les buches ?");
            }

            protected override void OnTarget(Mobile from, object obj)
            {
                int itemID = 0;

                if (obj is Item)
                    itemID = ((Item)obj).ItemID;
                else if (obj is StaticTarget)
                    itemID = ((StaticTarget)obj).ItemID & 0x3FFF;

                bool canPlanche = (itemID >= 6641 && itemID <= 6648);


                if (canPlanche)
                {
                    from.NextSkillTime = DateTime.Now + TimeSpan.FromSeconds(8.0);
                    from.Emote("*Travail du bois*");
                    from.SendMessage("Vous commencez à travailler le bois");
                    new DelayPlanche(m_owner, m_metal).Start();
                }
                else
                    from.SendMessage("Ceci n'est pas adapté");

            }
        }
        private class DelayPlanche : Timer
        {
            private NubiaPlayer m_owner;
            private BaseBois m_metal;

            public DelayPlanche(NubiaPlayer _owner, BaseBois _metal)
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
                if ( true ) //SkillCheck.CheckSkill(m_owner, m_owner.Skills[SkillName.Lumberjacking], m_metal.Infos.Diff))
                {
                    m_owner.SendMessage("Vous travaillez le bois avec succès");
                    m_metal.isRaffine = true;
                }
                else
                {
                    m_owner.SendMessage("Vous n'arrivez pas à travailler le bois. Votre tentative rend les buches inexploitables");
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
