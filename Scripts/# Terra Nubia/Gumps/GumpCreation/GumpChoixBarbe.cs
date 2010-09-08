using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpChoixBarbe : GumpNubia
    {
        private NubiaPlayer m_owner;
        private int choix = 0;
        private bool m_primary;
        private int page = 0;
        public GumpChoixBarbe(NubiaPlayer _owner, int _choix, int _page)
            : base("Choix de la barbe...", 200, 350)
        {
            m_owner = _owner;
            choix = _choix;
            //Closable = false;
            page = _page;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 30;
            int decal = 5;

            int limit = 13;

            for (int i = page * limit; i < (int)WorldData.FacialHairDefList.Length; i++)
            {
                if (WorldData.FacialHairDefList[i].skillReq > 20)
                    continue;
                AddButtonTrueFalse(x, y + (line * scale), i + 50, (choix == i), WorldData.FacialHairDefList[i].Name);
                line++;
                if (page > 0)
                    AddButtonPagePrecedante(x + 120, y, 2);
                if (line > limit)
                {
                    AddButtonPageSuivante(x + 145, y, 1);
                    break;
                }
            }

            //line++;
            if (choix > -1)
            {
                //AddLabel( _x, y, 0, "Continuer");
                AddButton(x, y + (line * scale), 0x850, 0x851, 99, GumpButtonType.Reply, 0);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
            if (info.ButtonID == 1)
                page++;
            else if (info.ButtonID == 2)
                page--;
            else if (info.ButtonID == 99)
            {
                from.SendGump(new GumpMenuCreation(from));
                return;
            }
            int newChoix = info.ButtonID - 50;

            try
            {
                HairDef def = WorldData.FacialHairDefList[newChoix];
                if (def != null)
                    from.FacialHairItemID = def.ItemID;
            }
            catch (Exception ex) { }
            //	from.CloseGump( typeof( GumpCreation ) );
            from.SendGump(new GumpChoixBarbe(m_owner, newChoix, page));
        }

    }
}
