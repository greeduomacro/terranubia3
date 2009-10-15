using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Spells;
using System.Text;

namespace Server.Gumps
{
    public class GumpLivreMagie : Gump
    {
        public GumpLivreMagie(NubiaPlayer owner, ClasseType classe)
            : base(100, 100)
        {
            AddImage(0, 0, 2220);

            int x = 60;
            int y = 30;
            int line = 0;
            int scale = 22;


            for (int page = 1; page <= 10; page++)
            {
                int prevPage = page - 1;
                if (prevPage < 1)
                    prevPage = 1;
                int nextPage = page + 1;
                if (nextPage > 10)
                    nextPage = 10;

                int cercle = page - 1;

                AddPage(page);
                AddButton(50, 8, 2205, 2205, 1, GumpButtonType.Page, prevPage);
                AddButton(321, 8, 2206, 2206, 2, GumpButtonType.Page, nextPage);
                AddLabel(95, 10, GumpNubia.ColorTextLight, "Cercle " + cercle);



                Classe cl = null;
                foreach (Classe c in owner.GetClasses())
                    if (c.CType == classe)
                        cl = c;
                if (cl != null)
                {
                    for (int i = 0; i < cl.SortAllow.Length; i++)
                    {
                        AddLabel(x, y + line * scale, GumpNubia.ColorText, cl.SortAllow[i][0].ToString());
                    }
                }
            }
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            base.OnResponse(sender, info);
        }
    }
}
