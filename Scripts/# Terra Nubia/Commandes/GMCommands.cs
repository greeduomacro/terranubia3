using System;
using System.Collections.Generic;
using System.Text;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Commands
{
    public class GMCommands
    {
        public static void Initialize()
        {

            CommandSystem.Register("healgm", AccessLevel.GameMaster, new CommandEventHandler(healgm_OnCommand));
            CommandSystem.Register("ga", AccessLevel.GameMaster, new CommandEventHandler(ga_OnCommand));

            CommandSystem.Register("cotation", AccessLevel.Seer, new CommandEventHandler(gestion_OnCommand));
            CommandSystem.Register("levelup", AccessLevel.GameMaster, new CommandEventHandler(levelup_OnCommand));
            CommandSystem.Register("moraltest", AccessLevel.GameMaster, new CommandEventHandler(moraltest_OnCommand));

            CommandSystem.Register("gm", AccessLevel.Player, new CommandEventHandler(gm_OnCommand));
               }

        public static void ga_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is NubiaPlayer)
            {
                NubiaPlayer player = e.Mobile as NubiaPlayer;
                player.MoveToWorld(new Point3D(1362, 1073, 0), Map.Ilshenar);
            }
        }

        public static void healgm_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is NubiaPlayer)
            {
                NubiaPlayer player = e.Mobile as NubiaPlayer;
                player.Target = new InternalHealTarget(player);
            }
        }
        private class InternalHealTarget : Target
        {
            private NubiaPlayer m_owner;
            private NubiaMobile m_cible;

            public InternalHealTarget(NubiaPlayer owner)
                : base(20, false, TargetFlags.None)
            {
                m_owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is NubiaMobile)
                {
                    m_cible = o as NubiaMobile;
                    m_cible.SendMessage("Une force occulte vous envahi");
                    //m_cible.ResetBlessure();
                    m_cible.Hits += 10000;
                    m_cible.Mana += 10000;
                    m_cible.Stam += 10000;
                }
            }
        }

        public static void moraltest_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            p.changeMoral(-20);
        }
        public static void gm_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            if (p.Account.AccessLevel >= AccessLevel.GameMaster)
            {
                if (p.AccessLevel == AccessLevel.Player)
                {
                    p.AccessLevel = p.Account.AccessLevel;
                }
                else
                    p.AccessLevel = AccessLevel.Player;
                p.SendMessage("AccessLevel: " + p.AccessLevel.ToString());
            }
        }
        public static void levelup_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            int xp = XPHelper.GetXpForLevel(p.Niveau);
            p.GiveXP(xp+1);
            /*   p.CloseGump(typeof(GumpFichePerso));
               p.SendGump(new GumpFichePerso(p, p));*/
        }
        public static void gestion_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            
            p.CloseGump(typeof(GumpCotation));
            p.SendGump(new GumpCotation(p));
        }
    }
}
