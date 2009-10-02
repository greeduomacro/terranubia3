using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server.Commands
{
    public class CommandesCombat
    {
        public static void Initialize()
        {
            CommandSystem.Register("defensetotale", AccessLevel.Player,
                new CommandEventHandler(defensetotale_OnCommand));
            CommandSystem.Register("defense", AccessLevel.Player,
                new CommandEventHandler(defense_OnCommand));
            CommandSystem.Register("roule", AccessLevel.Player,
                new CommandEventHandler(roule_OnCommand));
        }

        public static void defense_OnCommand(CommandEventArgs e)
        {
            NubiaMobile p = e.Mobile as NubiaMobile;
            p.NewActionCombat(ActionCombat.Defense);
        }

        public static void defensetotale_OnCommand(CommandEventArgs e)
        {
            NubiaMobile p = e.Mobile as NubiaMobile;
            p.NewActionCombat(ActionCombat.DefenseTotale);
        }
        public static void roule_OnCommand(CommandEventArgs e)
        {
            NubiaMobile p = e.Mobile as NubiaMobile;
            if (p.Competences[CompType.Acrobaties].getMaitrise() < 1)
            {
                p.SendMessage("Vous devez avoir au moin 1 en acrobatie");
            }
            else
            {
                if (p.Combatant == null)
                {
                    p.SendMessage("vous n'avez pas de combatant");
                }
                else
                {
                    p.Emote("*roulé boulé*");
                    p.SetLocation(NubiaHelper.getRandomPointAround(p.Combatant.Location, p.Map), true );
                }
            }
        }
    }
}