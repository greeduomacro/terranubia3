using System;
using System.Collections.Generic;
using Server.Commands;
using System.Text;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
    public enum SerrureQuality
    {
        Simple = 20,
        Moyenne = 25,
        Bonne = 30,
        TresBonne = 35,
        Excellente = 40,
        Impossible = 60
    }
	public interface ILockpickable : IPoint2D
	{
        SerrureQuality Serrure { get; set; }
		bool Locked{ get; set; }
		Mobile Picker{ get; set; }
		int MiniMaitrise{ get; set; }

		void LockPick( Mobile from );
	}

    public class CrochetageOnUse
    {
        public static void Initialize()
        {
            CommandSystem.Register("crochetage", AccessLevel.Player,
              new CommandEventHandler(crochetage_OnCommand));
        }
        public static void crochetage_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            Lockpick lockpick = null;
            if( p.Backpack != null )
            {
                foreach(Item i in p.Backpack.Items )
                {
                    if( i is Lockpick ){
                        lockpick = i as Lockpick;
                        break;
                    }
                }
            }
            
			p.SendLocalizedMessage( 502068 ); // What do you want to pick?
            p.Target = new CrochetageTarget(lockpick);
        }
        public class CrochetageTarget : Target
        {
            private Lockpick m_Item;

            public CrochetageTarget(Lockpick item)
                : base(1, false, TargetFlags.None)
            {
                m_Item = item;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is ILockpickable)
                {
                    Item item = (Item)targeted;
                    from.Direction = from.GetDirectionTo(item);

                    if (((ILockpickable)targeted).Locked)
                    {
                        from.PlaySound(0x241);

                        new InternalTimer((NubiaMobile)from, (ILockpickable)targeted, m_Item).Start();
                    }
                    else
                    {
                        // The door is not locked
                        from.SendLocalizedMessage(502069); // This does not appear to be locked
                    }
                }
                else
                {
                    from.SendLocalizedMessage(501666); // You can't unlock that!
                }
            }

            private class InternalTimer : Timer
            {
                private NubiaMobile m_From;
                private ILockpickable m_Item;
                private Lockpick m_Lockpick;

                public InternalTimer(NubiaMobile from, ILockpickable item, Lockpick lockpick)
                    : base(TimeSpan.FromSeconds(3.0))
                {
                    m_From = from;
                    m_Item = item;
                    m_Lockpick = lockpick;
                    Priority = TimerPriority.TwoFiftyMS;
                }

                protected void BrokeLockPickTest()
                {
                    // When failed, a 25% chance to break the lockpick
                    if (Utility.Random(4) == 0)
                    {
                        Item item = (Item)m_Item;

                        // You broke the lockpick.
                        item.SendLocalizedMessageTo(m_From, 502074);

                        m_From.PlaySound(0x3A4);
                        m_Lockpick.Consume();
                    }
                }

                protected override void OnTick()
                {
                    Item item = (Item)m_Item;

                    if (!m_From.InRange(item.GetWorldLocation(), 1))
                        return;

                    bool canPsy = m_From.Competences[CompType.Psychologie].check(0);
                    foreach (NubiaMobile m in m_From.GetMobilesInRange(6))
                    {
                        if (m is NubiaPlayer && m != m_From)
                        {
                            if (m.Competences[CompType.PerceptionAuditive].pureRoll(0) >= m_From.Competences[CompType.Discretion].pureRoll(0))
                            {
                                if (canPsy)
                                    m_From.SendMessage("{0} semble vous avoir repérez, vous manquez de discretion !", m.Name);
                                m_From.PrivateOverheadMessage(Server.Network.MessageType.Emote, 0, false, "*crochète une serrure*", m.NetState);
                            }
                        }
                    }

                    if (m_From.Competences[CompType.Crochetage].getPureMaitrise() < m_Item.MiniMaitrise || 
                        m_From.Competences[CompType.Crochetage].getPureMaitrise() + 20 < (int)m_Item.Serrure )
                    {
                        /*
                        // Do some training to gain skills
                        m_From.CheckSkill( SkillName.Lockpicking, 0, m_Item.LockLevel );*/

                        // The LockLevel is higher thant the LockPicking of the player
                        m_From.SendMessage("Réussite impossible");
                        item.SendLocalizedMessageTo(m_From, 502072); // You don't see how that lock can be manipulated.
                        return;
                    }

                    int malus = 0;
                    if (m_Lockpick == null)
                    {

                        malus = -4;
                        m_From.SendMessage("Vous n'avez pas d'outils, malus de circonstance de " + malus.ToString());
                    }

                    if (m_From.Competences[CompType.Crochetage].check((int)m_Item.Serrure + malus))
                    {
                        // Success! Pick the lock!
                        item.SendLocalizedMessageTo(m_From, 502076); // The lock quickly yields to your skill.
                        m_From.PlaySound(0x4A);
                        m_Item.LockPick(m_From);
                    }
                    else
                    {
                        // The player failed to pick the lock						
                        item.SendLocalizedMessageTo(m_From, 502075); // You are unable to pick the lock.
                    }

                    //Consomation du lockPick
                    if (m_Lockpick != null && !m_From.Competences[CompType.Crochetage].check((int)m_Item.Serrure))
                        BrokeLockPickTest();
                }
            }
        }
    }
}
