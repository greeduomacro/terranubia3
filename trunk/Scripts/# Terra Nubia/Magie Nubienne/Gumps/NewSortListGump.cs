using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Spells;
using Server.Network;

namespace Server.Gumps
{
    public class NewSortListGump : GumpNubia
    {
        private NubiaPlayer mOwner = null;
        public NewSortListGump(NubiaPlayer _owner)
            : base("Fiche de personnage", 520, 400, 250)
        {
            Closable = true;
            mOwner = _owner;
            bool Gm = false; // mOwner.AccessLevel >= AccessLevel.GameMaster;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 22;
            int decal = 5;
            int col1 = x;
            AddLabel(x, y + line * scale, ColorText, "Niveau de sort maxi: " + mOwner.getLevelMagie());
            line++;
            AddLabel(x, y + line * scale, ColorText, "Points d'apprentissage: " + mOwner.getTotalPtsApprentissage());
            line++;
            AddLabel(x, y + line * scale, ColorText, "Points de creation: " + mOwner.getTotalPtsCreation());
            line++;

            //18lignes max ;)
            for (int i = 0; i < mOwner.Magie.sortList.Length; i++)
            {
                if (!Gm)
                    AddButton(col1,y+ (line * scale), 0xFA5, 0xFA7, 100 + i, GumpButtonType.Reply, 0); //Lancer
                else
                {
                    AddButton(col1, y+(line * scale), 0xFA8, 0xFA9, 300 + i, GumpButtonType.Reply, 0); //Propriété
                    AddButton(col1 - 80,y+ (line * scale), 0xFA8, 0xFA9, 500 + i, GumpButtonType.Reply, 0); //Extraction
                }
                AddButton(col1 - 40, y+(line * scale), 0xFAB, 0xFAC, 200 + i, GumpButtonType.Reply, 0); //Voir

                int color = 2122;
                if (!mOwner.Magie.sortList[i].timeStateOk())
                    color = 2117;

                AddLabel(col1 + 45, y+(line * scale), color, "[" + i + "] " + mOwner.Magie.sortList[i].Nom);
                line++;
                if (line > 14)
                {
                    line = 3;
                    col1 += 280;
                }
            }

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            if (info.ButtonID >= 100 && info.ButtonID < 200) //Jutsu Cast
            {
                from.Magie.executeSort(info.ButtonID - 100);
            }
            if (info.ButtonID >= 200 && info.ButtonID < 300)
            {
                from.CloseGump(typeof(SortInfoGump));
                from.SendGump(new SortInfoGump(mOwner.Magie.getSort(info.ButtonID - 200)));
            }
            if (info.ButtonID >= 300 && info.ButtonID < 500)
            {
                from.CloseGump(typeof(SortInfoGump));
                from.SendGump(new PropertiesGump(from, mOwner.Magie.getSort(info.ButtonID - 300)));
            }
            if (info.ButtonID >= 500) //Extraire un parchemin
            {
                from.CloseGump(typeof(SortInfoGump));
                try
                {
                    SortNubia jutsu = (SortNubia)NubiaHelper.CopyItem(mOwner.Magie.getSort(info.ButtonID - 500));
                    jutsu.MoveToWorld(from.Location, from.Map);
                    from.SendMessage("Copy faite");
                }
                catch { from.SendMessage("Copy impossible!"); }
                //from.SendGump(  new PropertiesGump( from, from.getJutsu(info.ButtonID-300) ) );
            }
        }

    }
}
