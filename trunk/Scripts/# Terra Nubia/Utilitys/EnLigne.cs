// (c) Sébastien Santoro aka Dereckson, 2005, tous droits réservés.
// Droits d'utilisation, de compilation et de modification (mais pas de distribution, même de l'oeuvre modifiée)
// concédés à l'équipe du serveur Kocham pour une durée indéterminée révocable par l'auteur.

/*
 *  2005-09-09 16:07  Version alpha
 */

using System;
using System.Collections;
using Server.Network;
using System.Text;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Spells;
using Server.Commands;

namespace Server.Gumps
{
    public class EnLigneGump : Gump
    {

        private static string Encode(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");

            return sb.ToString();
        }

        public static void Initialize()
        {
          //  CommandSystem.Register("EnLigne", AccessLevel.Player, new CommandEventHandler(EnLigne_OnCommand));
         //   CommandSystem.Register("Whom", AccessLevel.Player, new CommandEventHandler(EnLigne_OnCommand));
        }

        [Usage("EnLigne")]
        [Aliases("Whom")]
        [Description("Lists all connected clients.")]
        private static void EnLigne_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new EnLigneGump(e.Mobile));
        }

        /// <summary>
        /// Génère le code HTML listant les joueurs
        /// </summary>
        /// <remarks>Code repris sur le WebStatus</remarks>
        /// <returns>code HTML</returns>
        private string GenerateHTMLCode(AccessLevel invokerAccessLevel)
        {
            StringWriter op = new StringWriter();

            op.WriteLine("<p>");

            string titre = null;

            foreach (NetState state in NetState.Instances)
            {

                Mobile m = state.Mobile;

                if (m != null && m.AccessLevel <= AccessLevel.Counselor)
                {
                    titre = m.Title;
                    op.WriteLine("{0} {1}<br>", Encode(m.Name), Encode(titre));
                }

            }

            op.WriteLine("</p>");

            op.Flush();
            return op.ToString();
        }

        public EnLigneGump(Mobile m)
            : base(0, 0)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = true;
            this.AddPage(0);
            this.AddBackground(8, 9, 386, 230, 9200);
            this.AddLabel(142, 15, 0, "Joueurs en ligne");
            this.AddHtml(23, 38, 360, 188, GenerateHTMLCode(m.AccessLevel), (bool)true, (bool)true);
        }

    }
}