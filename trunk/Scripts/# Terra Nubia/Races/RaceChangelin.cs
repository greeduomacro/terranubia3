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
    public class RaceChangelinHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Elfique", new int[]{ 1344,1343,1342,1109,1108,1107,1106 }),
             new CustomHueGroup("Elfique", new int[]{ 1344,1343,1342,1109,1108,1107,1106 }),
             new CustomHueGroup("Argent", new int[]{ 2065,2302,2101,2081 }),
            new CustomHueGroup("Bleuté", new int[]{ 1401,1402,1301,1302 }),
             new CustomHueGroup("Rosé", new int[]{ 1023,1030,1037,1045,1052 }),
            new CustomHueGroup("Brune", new int[]{ 1025,1032,1039,1047,1054 }),
            new CustomHueGroup("Marron", new int[]{ 1028,1034,1049,1057,1878 }),
             new CustomHueGroup("Racine Orc", new int[]{ 1450,1451,1452,2420,1441,1442,1443,1444 }),
        };
        public RaceChangelinHue()
            : base(hues, false, "Peau de Changelin")
        {
        }
    }
    public class RaceChangelin : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return false; } }

        public override CustomHuePicker HuePicker { get { return new RaceChangelinHue(); } }
        public override string Name { get { return "Changelin"; } }
        public override string NameF { get { return "Changelin"; } }

        public override Apparence ApparenceMini { get { return Apparence.Elegant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Eblouissant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceChangelin()
        {
        }
    }
}