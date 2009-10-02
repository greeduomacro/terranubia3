using System;
using System.Collections.Generic;
using System.Text;
using Server.Commands;
using Server.Targeting;
using Server.Network;

namespace Server.Mobiles
{
    public class DressageOnUse
    {
        public static void Initialize()
        {
            CommandSystem.Register("dressage", AccessLevel.Player,
              new CommandEventHandler(dressage_OnCommand));
        }
        public static void dressage_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            p.Target = new DressageTarget();

        }
        public static bool MustBeSubdued( BaseCreature bc )
		{
			return bc.SubdueBeforeTame && (bc.Hits > (bc.HitsMax / 10));
		}
        public class DressageTarget : Target
        {
            public DressageTarget()
                : base(8, false, TargetFlags.None)
            {
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                NubiaPlayer player = from as NubiaPlayer;
                if (targeted is NubiaCreature)
                {
                    NubiaCreature creature = targeted as NubiaCreature;
                        if ( !creature.Tamable )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1049655, from.NetState ); // That creature cannot be tamed.
						}
						else if ( creature.Controlled )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 502804, from.NetState ); // That animal looks tame already.
						}
						else if ( from.Female && !creature.AllowFemaleTamer )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1049653, from.NetState ); // That creature can only be tamed by males.
						}
						else if ( !from.Female && !creature.AllowMaleTamer )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1049652, from.NetState ); // That creature can only be tamed by females.
						}
						else if ( from.Followers + creature.ControlSlots > from.FollowersMax )
						{
							from.SendLocalizedMessage( 1049611 ); // You have too many followers to tame that creature.
						}
						else if ( creature.Owners.Count >= BaseCreature.MaxOwners && !creature.Owners.Contains( from ) )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1005615, from.NetState ); // This animal has had too many owners and is too upset for you to tame.
						}
						else if ( MustBeSubdued( creature ) )
						{
							creature.PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1054025, from.NetState ); // You must subdue this creature before you can tame it!
						}			
					    else
					    {
                            if (creature.DressageDD - 10 > player.Competences[CompType.Dressage].getPureMaitrise() || player.Competences[CompType.Dressage].getPureMaitrise() < 2)
                            {
                                creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502806, from.NetState); // You have no chance of taming this creature.
                            }
                            else
                            {
                                player.Emote("*essaie de dresser {0}*", creature.Name);
                                new InternalTimer(player, creature, Utility.RandomMinMax(3, 7)).Start();
                            }
					    }
                }
                else
                    player.SendMessage("Vous ne pouvez pas dresser cela");
            }
        }
        private class InternalTimer : Timer
        {
            private NubiaMobile m_Tamer;
            private NubiaCreature m_Creature;
            private int m_MaxCount;
            private int m_Count;
            private bool m_Paralyzed;
            private DateTime m_StartTime;

            public InternalTimer(NubiaMobile tamer, NubiaCreature creature, int count)
                : base(TimeSpan.FromSeconds(3.0), TimeSpan.FromSeconds(3.0), count)
            {
                m_Tamer = tamer;
                m_Creature = creature;
                m_MaxCount = count;
                m_Paralyzed = creature.Paralyzed;
                m_StartTime = DateTime.Now;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                m_Count++;

                DamageEntry de = m_Creature.FindMostRecentDamageEntry(false);
                bool alreadyOwned = m_Creature.Owners.Contains(m_Tamer);

                if (!m_Tamer.InRange(m_Creature, 6))
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502795, m_Tamer.NetState); // You are too far away to continue taming.
                    Stop();
                }
                else if (!m_Tamer.CheckAlive())
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502796, m_Tamer.NetState); // You are dead, and cannot continue taming.
                    Stop();
                }
                else if (!m_Tamer.CanSee(m_Creature) || !m_Tamer.InLOS(m_Creature))
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1049654, m_Tamer.NetState); // You do not have a clear path to the animal you are taming, and must cease your attempt.
                    Stop();
                }
                else if (!m_Creature.Tamable)
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1049655, m_Tamer.NetState); // That creature cannot be tamed.
                    Stop();
                }
                else if (m_Creature.Controlled)
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502804, m_Tamer.NetState); // That animal looks tame already.
                    Stop();
                }
                else if (m_Creature.Owners.Count >= BaseCreature.MaxOwners && !m_Creature.Owners.Contains(m_Tamer))
                {
                    ;
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1005615, m_Tamer.NetState); // This animal has had too many owners and is too upset for you to tame.
                    Stop();
                }
                else if (MustBeSubdued(m_Creature))
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 1054025, m_Tamer.NetState); // You must subdue this creature before you can tame it!
                    Stop();
                }
                else if (de != null && de.LastDamage > m_StartTime)
                {
                    m_Tamer.NextSkillTime = DateTime.Now;
                    m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502794, m_Tamer.NetState); // The animal is too angry to continue taming.
                    Stop();
                }
                else if (m_Count < m_MaxCount)
                {
                    m_Tamer.RevealingAction();

                    switch (Utility.Random(3))
                    {
                        case 0: m_Tamer.PublicOverheadMessage(MessageType.Regular, 0x3B2, Utility.Random(502790, 4)); break;
                        case 1: m_Tamer.PublicOverheadMessage(MessageType.Regular, 0x3B2, Utility.Random(1005608, 6)); break;
                        case 2: m_Tamer.PublicOverheadMessage(MessageType.Regular, 0x3B2, Utility.Random(1010593, 4)); break;
                    }


                    //XP Gain
                    m_Tamer.GiveXP(5);

                    if (m_Creature.Paralyzed)
                        m_Paralyzed = true;
                }
                else
                {
                    m_Tamer.RevealingAction();
                    m_Tamer.NextSkillTime = DateTime.Now;

                    if (m_Creature.Paralyzed)
                        m_Paralyzed = true;


                    if (alreadyOwned || m_Tamer.Competences[CompType.Dressage].check(m_Creature.DressageDD))
                    {

                        if (alreadyOwned)
                        {
                            m_Tamer.SendLocalizedMessage(502797); // That wasn't even challenging.
                        }
                        else
                        {
                            m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502799, m_Tamer.NetState); // It seems to accept you as master.
                            m_Creature.Owners.Add(m_Tamer);
                        }

                        m_Creature.SetControlMaster(m_Tamer);
                        m_Creature.IsBonded = false;
                    }
                    else
                    {
                        m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502798, m_Tamer.NetState); // You fail to tame the creature.
                    }
                }
            }
        }
    }
}
