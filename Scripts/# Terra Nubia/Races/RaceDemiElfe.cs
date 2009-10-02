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
    public class RaceDemiElfeHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Racine Elfique", new int[]{ 1873,1874,2419,2420 }),
            new CustomHueGroup("Racine Humaine", new int[]{ 1023,1030,1037,1054,1047 }),
        };
        public RaceDemiElfeHue()
            : base(hues, false, "Peau de demi-elfe")
        {
        }
    }
    public class RaceDemiElfe : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        public override CustomHuePicker HuePicker { get { return new RaceDemiElfeHue(); } }
        public override string Name { get { return "Demi-elfe"; } }
        public override string NameF { get { return "Demi-elfe"; } }
 
        public override Apparence ApparenceMini { get { return Apparence.Banal; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Envoutant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceDemiElfe()
        {
        }
    }
}