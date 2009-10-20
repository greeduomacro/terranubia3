using System;
using System.Collections.Generic;
using Server.Items;
using System.Text;
using Server.Network;
using Server.Commands;
using Server.Targeting;
using Server.SkillHandlers;

namespace Server.Mobiles
{
    public class Escamotage
    {
        /**
         * 
         * E S C A M O T A G E 
         * ( V O L )
         * 
         */

        public static void Initialize()
        {
            CommandSystem.Register("vol", AccessLevel.Player,
              new CommandEventHandler(vol_OnCommand));
        }
        public static void vol_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer player = e.Mobile as NubiaPlayer;

            if ( !IsEmptyHanded( player ) )
			{
				player.SendLocalizedMessage( 1005584 ); // Both hands must be free to steal.
			}
			else if( !player.Competences.mustWait() )
			{
				player.Target = new NubiaStealingTarget( player );

				player.SendLocalizedMessage( 502698 ); // Which item do you want to steal?
			}

        }

        private class NubiaStealingTarget : Target
		{
			private NubiaMobile m_Thief;

			public NubiaStealingTarget( NubiaMobile thief ) : base ( 1, false, TargetFlags.None )
			{
				m_Thief = thief;

				AllowNonlocal = true;
			}

			private Item TryStealItem( Item toSteal, ref bool caught )
			{
				Item stolen = null;

				object root = toSteal.RootParent;

				if ( !IsEmptyHanded( m_Thief ) )
				{
					m_Thief.SendLocalizedMessage( 1005584 ); // Both hands must be free to steal.
				}
				else if ( root is PlayerVendor )
				{
					m_Thief.SendLocalizedMessage( 502709 ); // You can't steal from vendors.
				}
				else if ( !m_Thief.CanSee( toSteal ) )
				{
					m_Thief.SendLocalizedMessage( 500237 ); // Target can not be seen.
				}
				else if ( m_Thief.Backpack == null || !m_Thief.Backpack.CheckHold( m_Thief, toSteal, false, true ) )
				{
					m_Thief.SendLocalizedMessage( 1048147 ); // Your backpack can't hold anything else.
				}
				else if ( toSteal.LootType == LootType.Newbied || toSteal.CheckBlessed( root ) )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( !m_Thief.InRange( toSteal.GetWorldLocation(), 1 ) )
				{
					m_Thief.SendLocalizedMessage( 502703 ); // You must be standing next to an item to steal it.
				}
				else if ( toSteal.Parent is Mobile )
				{
					m_Thief.SendLocalizedMessage( 1005585 ); // You cannot steal items which are equiped.
				}
				else if ( root == m_Thief )
				{
					m_Thief.SendLocalizedMessage( 502704 ); // You catch yourself red-handed.
				}
				else if ( root is Mobile && ((Mobile)root).AccessLevel > AccessLevel.Player )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( root is Corpse )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else
				{
					double w = toSteal.Weight + toSteal.TotalWeight;

					if ( w > 10 )
					{
						m_Thief.SendMessage( "That is too heavy to steal." );
					}
					else
					{
						if ( toSteal.Stackable && toSteal.Amount > 1 )
						{
							int maxAmount = (int)((m_Thief.Skills[SkillName.Stealing].Value / 10.0) / toSteal.Weight);

							if ( maxAmount < 1 )
								maxAmount = 1;
							else if ( maxAmount > toSteal.Amount )
								maxAmount = toSteal.Amount;

							int amount = Utility.RandomMinMax( 1, maxAmount );

							if ( amount >= toSteal.Amount )
							{
								int pileWeight = (int)Math.Ceiling( toSteal.Weight * toSteal.Amount );
								pileWeight *= 10;

								if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, pileWeight - 22.5, pileWeight + 27.5 ) )
									stolen = toSteal;
							}
							else
							{
								int pileWeight = (int)Math.Ceiling( toSteal.Weight * amount );
								pileWeight *= 10;

								if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, pileWeight - 22.5, pileWeight + 27.5 ) )
								{
									stolen = Mobile.LiftItemDupe( toSteal, toSteal.Amount - amount );

									if ( stolen == null )
										stolen = toSteal;
								}
							}
						}
						else
						{
							int iw = (int)Math.Ceiling( w );
							iw *= 10;

							if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, iw - 22.5, iw + 27.5 ) )
								stolen = toSteal;
						}

						if ( stolen != null )
						{
							m_Thief.SendLocalizedMessage( 502724 ); // You succesfully steal the item.
						}
						else
						{
							m_Thief.SendLocalizedMessage( 502723 ); // You fail to steal the item.
						}

						caught = m_Thief.Competences[CompType.Escamotage].check(1);
					}
				}

				return stolen;
			}

			protected override void OnTarget( Mobile from, object target )
			{
				Item stolen = null;
				object root = null;
				bool caught = false;

				if ( target is Item )
				{
					root = ((Item)target).RootParent;
					stolen = TryStealItem( (Item)target, ref caught );
				} 
                else 
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}

				if ( stolen != null )
				{
					from.AddToBackpack( stolen );

					StolenItem.Add( stolen, m_Thief, root as Mobile );
				}

				if ( caught )
				{
					if ( root is Mobile )
					{
						Mobile mobRoot = (Mobile)root;

						string message = String.Format( "Vous remarquer {0} voler un objet de {1}.", m_Thief.Name, mobRoot.Name );

						foreach ( NetState ns in m_Thief.GetClientsInRange( 8 ) )
						{
							if ( ns.Mobile != m_Thief )
                            {
                                NubiaPlayer obs = ns.Mobile as NubiaPlayer;
                                if( obs.Competences[CompType.Detection].check(10 + (int)obs.GetDistanceToSqrt(m_Thief) ) )
								    ns.Mobile.SendMessage( message );
                            }
						}
					}
				}
			}
		}

		public static bool IsEmptyHanded( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.OneHanded ) != null )
				return false;

			if ( from.FindItemOnLayer( Layer.TwoHanded ) != null )
				return false;

			return true;
		}

	


        /***
         * 
         *  S N O O P I N G
         * 
         * */
        public static void Configure()
        {
            Container.SnoopHandler = new ContainerSnoopHandler( NubiaContainer_Snoop );
        }
        public static bool NubiaCheckSnoopAllowed(Mobile from, Mobile to)
        {
            Map map = from.Map;

            if (to.Player)
                return from.CanBeHarmful(to, false, true); // normal restrictions

            BaseCreature cret = to as BaseCreature;

            if (to.Body.IsHuman && (cret == null || (!cret.AlwaysAttackable && !cret.AlwaysMurderer)))
                return false; // in town we cannot snoop blue human npcs

            return true;
        }

        public static void NubiaContainer_Snoop(Container cont, Mobile f)
        {
            NubiaMobile from = f as NubiaMobile;
            if (from.AccessLevel > AccessLevel.Player || from.InRange(cont.GetWorldLocation(), 1))
            {
                NubiaMobile root = cont.RootParent as NubiaMobile;

                if (root != null && !root.Alive)
                    return;

                if (root != null && root.AccessLevel > AccessLevel.Player && from.AccessLevel == AccessLevel.Player)
                {
                    from.SendLocalizedMessage(500209); // You can not peek into the container.
                    return;
                }

                if (root != null && from.AccessLevel == AccessLevel.Player && !NubiaCheckSnoopAllowed(from, root))
                {
                    from.SendLocalizedMessage(1001018); // You cannot perform negative acts on your target.
                    return;
                }

                bool canSnoop = false;

                
                Map map = from.Map;
                IPooledEnumerable eable =  null;
                if( map != null )
                    eable = map.GetClientsInRange(from.Location, 8);

                if (root != null && from.AccessLevel == AccessLevel.Player)
                {

                    if (eable != null)
                    {
                        string message = String.Format("Vous remarquez {0} fouiller dans le sac de {1}.", from.Name, root.Name);

                        foreach (NetState ns in eable)
                        {
                            if (ns.Mobile != from)
                            {
                                //Detection
                                NubiaPlayer obs = ns.Mobile as NubiaPlayer;
                                if (obs.Competences[CompType.Detection].pureRoll(0)
                                    >
                                    from.Competences[CompType.Discretion].pureRoll(0) + from.GetDistanceToSqrt(obs))
                                {
                                    obs.SendMessage(message);
                                    from.PrivateOverheadMessage(MessageType.Emote, 0, false, "*fouille dans le sac de " + root.Name + "*", ns);
                                }
                            }
                        }

                        if (from.Competences[CompType.Escamotage].check(10 + root.getBonusReflexe()))
                            canSnoop = true;
                      
                    }
                }
                if( eable != null )
                    eable.Free();

                if (from.AccessLevel > AccessLevel.Player || canSnoop)
                {
                   /* if (cont is TrapableContainer && ((TrapableContainer)cont).ExecuteTrap(from) )
                        return;*/

                    cont.DisplayTo(from);
                }
                else
                {
                    from.SendLocalizedMessage(500210); // You failed to peek into the container.
                }
            }
            else
            {
                from.SendLocalizedMessage(500446); // That is too far away.
            }
        }
    }
}
