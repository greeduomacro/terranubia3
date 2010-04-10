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
    public class RaceElfeLuneHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Pâle", new int[]{ 1873,1874,2419,2420 }),
            new CustomHueGroup("Bleu de lune", new int[]{ 1346,1337,1319 })
        };
        public RaceElfeLuneHue()
            : base(hues, false, "Peau d'elfe de la lune")
        {
        }
    }
    public class RaceElfeLune : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return false; } }

        public override CustomHuePicker HuePicker { get { return new RaceElfeLuneHue(); } }
        public override string Name { get { return "Elfe de la lune"; } }
        public override string NameF { get { return "Elfe de la lune"; } }

        public override Apparence ApparenceMini { get { return Apparence.Elegant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Eblouissant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceElfeLune()
        {
        }
    }
}