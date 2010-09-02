using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;


namespace Server.Mobiles
{
    public class RaceAasimar : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        public override CustomHuePicker HuePicker { get { return new RaceHumainHue(); } }
        public override string Name { get { return "Aasimar"; } }
        public override string NameF { get { return "Aasimar"; } }

        public override Apparence ApparenceMini { get { return Apparence.Elegant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Eblouissant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceAasimar()
        {
        }
    }
}