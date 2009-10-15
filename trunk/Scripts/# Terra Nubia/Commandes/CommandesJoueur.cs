using System;
using System.Collections.Generic;
using System.Text;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;

namespace Server.Commands
{
    public class CommandesJoueur
    {
        public static void Initialize()
        {
            CommandSystem.Register("magie", AccessLevel.Player,
              new CommandEventHandler(magie_OnCommand));

            CommandSystem.Register("deguisement", AccessLevel.Player,
              new CommandEventHandler(deguisement_OnCommand));
            CommandSystem.Register("cache", AccessLevel.Player,
              new CommandEventHandler(cache_OnCommand));
            CommandSystem.Register("acrobatie", AccessLevel.Player,
               new CommandEventHandler(acrobatie_OnCommand));
            CommandSystem.Register("fiche", AccessLevel.Player, 
                new CommandEventHandler(fiche_OnCommand));
            CommandSystem.Register("comp", AccessLevel.Player,
               new CommandEventHandler(comp_OnCommand));
            CommandSystem.Register("anim", AccessLevel.Player,
                new CommandEventHandler(anim_OnCommand));
            CommandSystem.Register("blessure", AccessLevel.Player,
               new CommandEventHandler(blessure_OnCommand));
        }
        public static void magie_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            p.SendGump(new GumpLivreMagie(p, ClasseType.Barde));
        }
        public static void deguisement_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            if (p.Competences[CompType.Deguisement].getPureMaitrise() >= 2)
            {
                p.RemoveDeguisement();
                p.CloseGump(typeof(GumpDeguisement) );
                p.SendGump(new GumpDeguisement(p));
            }
            else
                p.SendMessage("Vous devez avoir au moin 2 en déguisement");
        }
        public static void blessure_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;

            p.Target = new MedecineTarget(p);
        }
        public static void cache_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            bool canHide = false;
            int DD = 0;
            int NuitModus = 0;
            if (p.Competences.mustWait())
                return;
            if (LightCycle.ComputeLevelFor(p) > p.LightLevel)
            {
                if (LightCycle.ComputeLevelFor(p) > 15)
                    NuitModus += 5;
                else if (LightCycle.ComputeLevelFor(p) < 15)
                    NuitModus -= 5;

                p.SendMessage("Bonus de nuit: " + NuitModus);
            }
            else
            {
                if (p.LightLevel > 15)
                    NuitModus += 5;
                else if (p.LightLevel < 15)
                    NuitModus -= 5;
                p.SendMessage("Bonus de nuit: " + NuitModus);
            }
            DD += NuitModus;
            DD += (int)p.Taille * 2;
            bool mustBluff = false;
            foreach (NubiaMobile mob in p.GetMobilesInRange(8))
            {
                if (mob == p)
                    continue;
                if (mob.CanSee(p))
                {
                    int mobPsy = mob.Competences[CompType.Psychologie].pureRoll() - NuitModus;
                    int bluff = mob.Competences[CompType.Bluff].pureRoll() + NuitModus;
                    if (mobPsy < bluff)
                    {
                        mob.SendMessage("Quelques choses vous attire l'oeil plus loin");
                    }
                    DD += mobPsy - bluff;
                    mustBluff = true;
                }
            }

            if (mustBluff)
            {
                if (p.Competences[CompType.Bluff].check(DD))
                {
                    p.SendMessage("Vous réussissez à distraitre les observateurs pour vous cacher");
                }
                else
                {
                    p.SendMessage("Trop de monde vous observer, impossible de vous cacher");
                    return;
                }
            }
            if (p.Competences[CompType.Discretion].check(DD))
            {
                p.SendMessage("Vous vous dissimulez avec discretion");
                p.Hidden = true;
            }
            else
            {
                p.SendMessage("Vous n'arrivez pas a vous dissimuler");
            }
        }
        public static void acrobatie_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            if (p.Competences.mustWait())
                return;

            if (p.InCombat)
            {
                p.SendMessage("Vous ne pouvez pas faire d'acrobatie pour l'instant");
                return;
            }

            bool can = p.Competences[CompType.Acrobaties].check();
            if (can)
            {
                p.Emote("*execute une acrobatie*");
                foreach (NubiaPlayer player in p.GetMobilesInRange(8))
                {
                    if (player.CanSee(p))
                    {
                        player.changeMoral(Utility.Random(1, 8));
                    }
                }
            }
            else
            {
                p.Emote("*rate son acrobatie*");
                p.Damage(Utility.Random(1, 4));
            }
        }

        public static void anim_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            if (e.Arguments.Length > 0)
            {
                try
                {
                    int a = Convert.ToInt32( e.Arguments[0] );
                    
                    p.Animate(a, 7, 1, true, false, 0 );
                }
                catch (Exception ex) { }
            }
        }

        public static void comp_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            p.CloseGump(typeof(GumpCompetences));
            p.SendGump(new GumpCompetences(p, p));
        }

        public static void fiche_OnCommand(CommandEventArgs e)
        {
            NubiaPlayer p = e.Mobile as NubiaPlayer;
            p.CloseGump(typeof(GumpFichePerso));
            p.SendGump(new GumpFichePerso(p, p));
        }
    }
}
