using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class GumpCotation : GumpNubia
    {
        private NubiaPlayer mOwner = null;
        private List<NubiaPlayer> mPlayers = new List<NubiaPlayer>();

        private void constructList()
        {
            mPlayers = new List<NubiaPlayer>();
            if( mOwner == null )
                return;

            List<Mobile> worldMobiles = new List<Mobile>(World.Mobiles.Values);

            for (int i = 0; i < worldMobiles.Count; i++)
            {
                if (!(worldMobiles[i] is NubiaPlayer))
                    continue;
                NubiaPlayer player = worldMobiles[i] as NubiaPlayer;
                if (player.isCotable(mOwner.Account.Username) && player.AccessLevel == AccessLevel.Player)
                {
                    mPlayers.Add(player);
                }
                else
                    continue;
            }
        }

        public GumpCotation(NubiaPlayer _owner)
            : base("GM Cotations: Soyez objectif !", 495, 405)
        {
            Closable = true;
            mOwner = _owner;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 27;
            int decal = 5;

            constructList();

            if (mPlayers.Count == 0)
                AddLabel(x, y, ColorTextRed, "Aucun joueur à coter");
            else
            {

                AddBackground(x, y + line * scale, 80, 25, 3000);
                AddLabel(x + 5, y + line * scale, ColorTextYellow, "Account");

                AddBackground(x + 80, y + line * scale, 170, 25, 3000);
                AddLabel(x + 85, y + line * scale, ColorTextYellow, "Nom du personnage");

                AddBackground(x + 165 + 85, y + line * scale, 70, 25, 3000);
                AddLabel(x + 170 + 90, y + line * scale, ColorTextYellow, "Cote");

                AddBackground(x + 320, y + line * scale, 160, 25, 3000);
                AddLabel(x + 335, y + line * scale + 1, ColorTextYellow, "Options");
                line++;

                for (int i = 0; i < mPlayers.Count; i++)
                {
                    NubiaPlayer player = mPlayers[i];
                    AddBackground(x, y + line * scale, 80, 25, 3000);
                    AddLabel(x + 5, y + line * scale, ColorText, player.Account.Username);

                    AddBackground(x + 80, y + line * scale, 170, 25, 3000);
                    AddLabel(x + 85, y + line * scale, ColorTextLight, player.Name);

                    AddBackground(x + 165 + 85, y + line * scale, 70, 25, 3000);
                    AddLabel(x + 185 + 90, y + line * scale, ( player.Cote >= 10 ? ColorTextGreen : ColorTextRed), ((int)player.Cote).ToString() );
              //      AddLabel(x + 185 + 90, y + line * scale, ColorTextGray, "("+player.Cote.ToString()+")" ); 

             //       AddBackground(x + 320, y + line * scale, 160, 25, 3000);
                    /* Negatif*/ 
                    AddButton(x + 335, y + line * scale +1, 252, 253, 500 + i, GumpButtonType.Reply, 0);
                    /* Neutre */
                    AddButton(x + 355, y + line * scale +1, 2141, 2142, 1000 + i, GumpButtonType.Reply, 0);
                    /* Positif */
                    AddButton(x + 410, y + line * scale + 1, 250, 251, 1500 + i, GumpButtonType.Reply, 0);



                    if (NetState.Instances.Contains(player.NetState)) // ON LINE !
                        AddButton(x + 435, y + line * scale +1, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);

                    line++;
                }
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int id = info.ButtonID;
            if (id >= 100 && id < 500) //View
            {
                NubiaPlayer player = mPlayers[id - 100];
                mOwner.Hidden = true;
                mOwner.MoveToWorld(player.Location, player.Map);
            }
            else if (id >= 500 && id < 1000) //Negative cote
            {
                NubiaPlayer player = mPlayers[id - 500];
                player.doCotation(mOwner.Account.Username, - 1);
            }
            else if (id >= 1000 && id < 1500) //neutre cote
            {
                NubiaPlayer player = mPlayers[id - 1000];
                player.doCotation(mOwner.Account.Username, 0);
            }
            else if (id >= 1500 && id < 2000) //positiv cote
            {
                NubiaPlayer player = mPlayers[id - 1500];
                player.doCotation(mOwner.Account.Username,  1);
            }


            if( id != 0 )
                mOwner.SendGump(new GumpCotation(mOwner));
        }
    }
}
