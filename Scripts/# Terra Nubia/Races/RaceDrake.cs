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
    public class RaceDrakeHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Argent", new int[]{ 2065,2302,2101,2081 }),
            new CustomHueGroup("Bleuté", new int[]{ 1401,1402,1301,1302 }),
        };
        public RaceDrakeHue()
            : base(hues, false, "Peau d'elfe")
        {
        }
    }
    public class RaceDrake : BaseRace
    {
        public override bool AllowHair { get { return false; } }
        public override bool AllowFacialHair { get { return false; } }

        public override CustomHuePicker HuePicker { get { return new RaceDrakeHue(); } }
        public override string Name { get { return "Drakéïde"; } }
        public override string NameF { get { return "Drakéïde"; } }

        public override Apparence ApparenceMini { get { return Apparence.Monstrueux; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Elegant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceDrake()
        {
        }
    }
}