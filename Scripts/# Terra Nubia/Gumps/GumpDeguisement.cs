using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpDeguisement : GumpNubia
    {
        private NubiaPlayer mOwner = null;
        private int mFemale = -1;
        private RaceType mRace = RaceType.None;
        private string mName = string.Empty;

        public GumpDeguisement(NubiaPlayer _owner)
            : this(_owner, -1, RaceType.None, string.Empty)
        {
        }
        private GumpDeguisement(NubiaPlayer _owner, int female, RaceType race, string name)
            : base("Confection de déguisement", 495, 405)
        {
            Closable = true;
            mOwner = _owner;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 27;
            int decal = 5;

            mFemale = female;
            mRace = race;
            mName = name;

            if (mFemale != -1)
                mFemale = ( mOwner.Female ? 1 : 0 );

            if (mName == string.Empty)
                mName = mOwner.Name;

            if (mRace == RaceType.None)
                mRace = RaceManager.getRaceType(mOwner.Race.GetType());

            AddBackground(x, y, 160, 25, 3000);
            AddTextEntry(x + 5, y + 2, 155, 123, ColorTextGreen, 10, mName);
            line++;

            AddButtonTrueFalse(x, y + line * scale, 20, (mFemale == 1), "Femme");
            AddButtonTrueFalse(x + 200, y + line * scale, 21, (mFemale == 0), "Homme");
            line++;

            AddButtonTrueFalse(x, y + line * scale, 50, (mRace == RaceType.Humain), "Humain");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 51, (mRace == RaceType.DemiElf), "Demi-Elfe");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 52, (mRace == RaceType.DemiOrc), "Demi-Orc");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 53, (mRace == RaceType.ElfLune), "Elfe de la lune");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 54, (mRace == RaceType.Githzerai), "Githzerai");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 55, (mRace == RaceType.Halfelin), "Halfelin");
            line++;
            line++;

            AddSimpleButton(x, y + line * scale, 99, "Se déguiser");
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int id = info.ButtonID;

            mName = info.GetTextEntry(10).Text;

            if (id == 20)
                mFemale = 0;
            else if (id == 21)
                mFemale = 1;
            else if (id == 50)
                mRace = RaceType.Humain;
            else if (id == 51)
                mRace = RaceType.DemiElf;
            else if (id == 52)
                mRace = RaceType.DemiOrc;
            else if (id == 53)
                mRace = RaceType.ElfLune;
            else if (id == 54)
                mRace = RaceType.Githzerai;
            else if (id == 55)
                mRace = RaceType.Halfelin;
            else if (id == 99)
            {
                if (mName != mOwner.Name)
                {
                    int DD = 15;
                    if( mFemale == 0 && mOwner.Female || mFemale == 1 && !mOwner.Female )
                        DD += 5;
                    if( mRace != RaceManager.getRaceType( mOwner.Race.GetType() ) )
                        DD += 5;
                    int result = mOwner.Competences[CompType.Deguisement].pureRoll();
                    if (result >= DD)
                    {
                        mOwner.SendMessage("Vous réussissez à vous déguiser");
                        mOwner.Emote("*se déguise*");
                        DeguisementMod deg = new DeguisementMod();
                        deg.Female = (mFemale == 1 ? true : false);
                        deg.Name = mName;
                        deg.Race = mRace;
                        deg.Reussite = (result - DD) + 10;
                        mOwner.ApplyDeguisement(deg);
                    }
                    else
                        mOwner.SendMessage("Vous n'arrivez pas a vous déguiser");
                }
                else
                {
                    mOwner.SendMessage("Vous devez changer de nom");
                }
            }

            if (id != 0)
                mOwner.SendGump(new GumpDeguisement(mOwner, mFemale, mRace, mName));
        }
    }
}
