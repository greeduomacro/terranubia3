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
            CommandSystem.Register("attaque", AccessLevel.Player,
               new CommandEventHandler(attaque_OnCommand));

            CommandSystem.Register("defensetotale", AccessLevel.Player,
                new CommandEventHandler(defensetotale_OnCommand));
            CommandSystem.Register("defense", AccessLevel.Player,
                new CommandEventHandler(defense_OnCommand));
            CommandSystem.Register("roule", AccessLevel.Player,
                new CommandEventHandler(roule_OnCommand));
        }
        public static void attaque_OnCommand(CommandEventArgs e)
        {
            NubiaMobile p = e.Mobile as NubiaMobile;
            if (e.Arguments.Length > 0)
            {
                try
                {
                    int a = Convert.ToInt32(e.Arguments[0]);
                    if (a < 1)
                        a = 1;
                    if (a > p.BonusAttaque.Length)
                    {
                        p.SendMessage("Vous ne pouvez pas attaque plus de {0} par tour", p.BonusAttaque.Length);
                        a = p.BonusAttaque.Length;
                    }
                    p.AttaqueParTour = a;
                    p.SendMessage("Vous attaquez maintenant {0} fois par tour", p.AttaqueParTour);

                }
                catch (Exception ex) {
                    p.SendMessage("Utilisation: .attaque [Nombre]");
                }
            }
            else
                p.SendMessage("Utilisation: .attaque [Nombre]");
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