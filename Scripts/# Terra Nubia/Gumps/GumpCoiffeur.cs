using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpCoiffeur : GumpNubia
    {
        private NubiaPlayer m_owner;
        private NubiaPlayer m_client;
        public GumpCoiffeur(NubiaPlayer _owner, NubiaPlayer _client)
            : base("Choix de la coupe pour " + _client.Name, 600, 465)
        {
            m_owner = _owner;
            m_client = _client;

            int y = YBase;
            int x = XBase;
            int line = 1;
            int scale = 50;
            int decal = 5;

            int col = 0;
            int coldecal = 200;

            int limit = 8;



            if (!m_client.Female)
            {
                AddPage(1);
                AddButton(x, y, 4014, 4015, 5, GumpButtonType.Page, 2);
                AddLabel(x + 30, y, ColorTextYellow, "Voir les barbes");
            }
            AddLabel(x + 30, y, ColorTextYellow, "Voir les barbes");
            for (int i = 0; i < (int)WorldData.HairDefList.Length; i++)
            {
                if (WorldData.HairDefList[i].skillReq >= 20)                
                    AddItem(x + col * coldecal, y + line * scale, WorldData.HairDefList[i].ItemID);
                AddSimpleButton(x + 50 + col * coldecal, y + (line * scale), i + 50, WorldData.HairDefList[i].Name , ColorTextGreen);
                line++;
                if (line > limit)
                {
                    line = 0;
                    col++;
                }
            }
            if (!m_client.Female)
            {

                AddPage(2);
                AddButton(x, y, 4005, 4006, 6, GumpButtonType.Page, 1);
                AddLabel(x + 30, y, ColorTextYellow, "Voir les coiffures");
                for (int i = 0; i < (int)WorldData.FacialHairDefList.Length; i++)
                {
                    if (WorldData.FacialHairDefList[i].skillReq >= 20)
                        AddItem(x + col * coldecal, y + line * scale, WorldData.FacialHairDefList[i].ItemID);
                    AddSimpleButton(x + 50 + col * coldecal, y + (line * scale), i + 100, WorldData.FacialHairDefList[i].Name, ColorTextGreen);
                    line++;
                    if (line > limit)
                    {
                        line = 0;
                        col++;
                    }
                }
            }
        }

        private class InternalTimer : Timer
        {
            private NubiaPlayer mCoiffeur;
            private NubiaPlayer mClient;
            private int mID;
            private bool mHair;
            public InternalTimer(NubiaPlayer coiffeur, NubiaPlayer client, int id, bool hair)
                : base(WorldData.TimeTour())
            {
                mCoiffeur = coiffeur;
                mClient = client;
                mID = id;
                mHair = hair;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if (mCoiffeur == null || mClient == null)
                    return;
                else if ( !mCoiffeur.Alive || !mClient.Alive)
                    return;

                if ( !mClient.InRange(mCoiffeur.Location, 1))
                {
                    mCoiffeur.SendMessage("vous êtes trop loin");
                    return;
                }
                int itemID = 0;
                int DD = 10;

                if (mHair)
                {
                    itemID = WorldData.HairDefList[mID].ItemID;
                    DD = (int)WorldData.HairDefList[mID].skillReq;
                }
                else
                {
                    itemID = WorldData.FacialHairDefList[mID].ItemID;
                    DD = (int)WorldData.FacialHairDefList[mID].skillReq;
                }

                if (mCoiffeur.Competences[CompType.Couture].check(DD, 0))
                {
                    mCoiffeur.Emote("*Termine la coupe de {0}*", mClient.Name);
                    if (mHair)
                        mClient.HairItemID = itemID;
                    else
                        mClient.FacialHairItemID = itemID;
                }
                else
                    mCoiffeur.Emote("*N'arrive à rien*");
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
            bool hair = true;

            int id = info.ButtonID;

            hair = id < 100;


            if (!m_client.Alive || !m_owner.Alive)
                return;

            if (id > 40 && f != null && m_client != null)
            {
                if (!m_client.InRange(m_owner.Location, 1))
                {
                    m_owner.SendMessage("Vous êtes trop loin");
                    return;
                }
                m_owner.Emote("*Commence la coupe de {0}*", m_client.Name);
                int hid = id -50;
                if( !hair )
                    hid = id - 100;
                new InternalTimer(m_owner, m_client, hid, hair).Start();
            }
        }
    }
}
