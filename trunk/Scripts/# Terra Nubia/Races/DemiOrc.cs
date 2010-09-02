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
    public class RaceDemiOrcHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Racine Orc", new int[]{ 1450,1451,1452,2420,1441,1442,1443,1444 }),
            new CustomHueGroup("Racine Humaine", new int[]{ 1025,1032,1049,1057,1878 }),
        };
        public RaceDemiOrcHue()
            : base(hues, false, "Peau de demi-orque")
        {
        }
    }
    public class RaceDemiOrc : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }
        
        public override CustomHuePicker HuePicker { get { return new RaceDemiOrcHue(); } }
        public override string Name { get { return "Demi-orque"; } }
        public override string NameF { get { return "Demi-orque"; } }

        public override Apparence ApparenceMini { get { return Apparence.Monstrueux; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Banal; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceDemiOrc()
        {
        }
    }
}