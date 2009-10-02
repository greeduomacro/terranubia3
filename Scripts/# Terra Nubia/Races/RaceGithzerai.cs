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
    public class RaceGithzeraiHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Jaunâtre", new int[]{ 2413,2414,2415,2416,2417 }),
            new CustomHueGroup("Cendré", new int[]{ 1882,1883,1884,1885,1886 }),
            new CustomHueGroup("Marron", new int[]{ 1028,1034,1049,1057,1878 })
        };
        public RaceGithzeraiHue()
            : base(hues, false, "Peau de Githzerai")
        {
        }
    }
    public class RaceGithzerai : BaseRace
    {
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        public override CustomHuePicker HuePicker { get { return new RaceGithzeraiHue(); } }
        public override string Name { get { return "Githzerai"; } }
        public override string NameF { get { return "Githzerai"; } }

        public override Apparence ApparenceMini { get { return Apparence.Monstrueux; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Elegant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceGithzerai()
        {
        }
    }
}