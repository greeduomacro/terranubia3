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
    public class RaceDrowHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Elfique", new int[]{ 1344,1343,1342,1109,1108,1107,1106 }),
        };
        public RaceDrowHue()
            : base(hues, false, "Peau d'elfe")
        {
        }
    }
    public class RaceDrow : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return false; } }

        public override CustomHuePicker HuePicker { get { return new RaceDrowHue(); } }
        public override string Name { get { return "Elfe noir"; } }
        public override string NameF { get { return "Elfe noire"; } }

        public override Apparence ApparenceMini { get { return Apparence.Elegant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Eblouissant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceDrow()
        {
        }
    }
}