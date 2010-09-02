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
    public class RaceHautElfeHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Elfique", new int[]{ 1873,1874,2419,2420 }),
        };
        public RaceHautElfeHue()
            : base(hues, false, "Peau d'elfe")
        {
        }
    }
    public class RaceHautElf : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return false; } }

        public override CustomHuePicker HuePicker { get { return new RaceHautElfeHue(); } }
        public override string Name { get { return "Haut elfe"; } }
        public override string NameF { get { return "Haute elfe"; } }

        public override Apparence ApparenceMini { get { return Apparence.Elegant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Eblouissant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceHautElf()
        {
        }
    }
}