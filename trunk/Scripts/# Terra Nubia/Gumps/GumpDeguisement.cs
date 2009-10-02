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

        public GumpDeguisement(NubiaPlayer _owner)
            : base("Confection de déguisement", 495, 405)
        {
            Closable = true;
            mOwner = _owner;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 27;
            int decal = 5;

            if (mFemale != -1)
                mFemale = ( mOwner.Female ? 1 : 0 );

            if (mRace == RaceType.None)
                mRace = RaceManager.getRaceType(mOwner.Race.GetType());

            AddBackground(x, y, 160, 25, 3000);
            AddTextEntry(x + 5, y + 2, 155, 123, ColorTextGreen, 10, mOwner.Name);
            line++;

            AddButtonTrueFalse(x, y + line * scale, 20, (mOwner.Female), "Femme");
            AddButtonTrueFalse(x + 200, y + line * scale, 20, (!mOwner.Female), "Homme");
            line++;

        }
    }
}
