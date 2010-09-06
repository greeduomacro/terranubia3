using System;
using System.Collections.Generic;
using System.Text;
using Server.Targeting;
using Server.Network;
using Server.Spells;
using Server.Commands;

namespace Server.Mobiles
{
    class SautOnUse
    {
        public static void Initialize()
        {
            CommandSystem.Register("saut", AccessLevel.Player,
              new CommandEventHandler(saut_OnCommand));
        }
        public static void saut_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            if (p.Competences.mustWait())
            {
                p.SendMessage("Où sauter ?");
                p.Target = new InternalSautTarget(p);
            }
            p.SendMessage("Vous devez attendre pour utiliser une compétence");
        }

        public class InternalSautTarget : Target
        {
            private NubiaPlayer m_Owner;

            public InternalSautTarget(NubiaPlayer owner)
                : base(8, true, TargetFlags.None)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile f, object o)
            {
                if (o is Item)
                {
                    m_Owner.SendMessage("Visez le sol");
                    return;
                }
                if (!(o is IPoint3D))
                    return;

                IPoint3D p = o as IPoint3D;



                if (p != null)
                {

                    SpellHelper.GetSurfaceTop(ref p);


                    if (!m_Owner.CanSee(p))
                    {
                        m_Owner.SendMessage("Vous ne voyez pas votre point de chute");
                        return;
                    }
                    if (Factions.Sigil.ExistsOn(m_Owner))
                    {
                        m_Owner.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
                    }
                    else if (Server.Misc.WeightOverloading.IsOverloaded(m_Owner))
                    {
                        m_Owner.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
                    }
                    else if (!SpellHelper.CheckTravel(m_Owner, TravelCheckType.TeleportFrom))
                    {
                    }
                    else if (!SpellHelper.CheckTravel(m_Owner, m_Owner.Map, new Point3D(p), TravelCheckType.TeleportTo))
                    {
                    }
                    else if (m_Owner.Map == null || !m_Owner.Map.CanSpawnMobile(p.X, p.Y, p.Z))
                    {
                        m_Owner.SendLocalizedMessage(501942); // That location is blocked.
                    }
                    else if (SpellHelper.CheckMulti(new Point3D(p), m_Owner.Map))
                    {
                        m_Owner.SendLocalizedMessage(501942); // That location is blocked.
                    }

                    int hauteur = p.Z - m_Owner.Z;
                    if (hauteur < 0)
                        hauteur = 0;
                    hauteur /= 5;
                    int distance = (int)m_Owner.GetDistanceToSqrt(p);
                    int diff = (10 + distance) + (hauteur);
                    if (m_Owner.Stam < diff)
                    {
                        m_Owner.SendMessage("Trop loin, trop dur");
                        return;
                    }

                    Point3D from = m_Owner.Location;
                    Point3D to = new Point3D(p);
                    m_Owner.Stam -= diff;

                    if ( m_Owner.Competences[CompType.Saut].check(diff) )
                    {
                        m_Owner.Emote("*Saute*");

                        m_Owner.Stam += diff / 2;
                        m_Owner.Location = to;
                        //m_Owner.ProcessDelta();
                    }
                    else
                    {
                        m_Owner.Emote("*Essaie de sauter*");
                        m_Owner.Damage(6, null);
                        m_Owner.SendMessage("Vous n'y arrivez pas");
                    }

                   /* if (m_Owner.Player && m_Owner.Hidden == false)
                    {
                        Effects.SendLocationParticles(EffectItem.Create(from, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
                        Effects.SendLocationParticles(EffectItem.Create(to, m_Owner.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);
                    }
                    else
                    {
                        m_Owner.FixedParticles( 0x376A, 9, 32, 0x13AF, EffectLayer.Waist );
                    }*/
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
            }
        }
    }
}
