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
    public class RaceHumainHue : CustomHuePicker
    {
        public static CustomHueGroup[] hues = new CustomHueGroup[]{
            new CustomHueGroup("Rosé", new int[]{ 1023,1030,1037,1045,1052 }),
            new CustomHueGroup("Brune", new int[]{ 1025,1032,1039,1047,1054 }),
            new CustomHueGroup("Marron", new int[]{ 1028,1034,1049,1057,1878 })
        };
        public RaceHumainHue()
            : base(hues, false, "Peau d'humain")
        {
        }
    }
	public class RaceHumain : BaseRace
	{
        public override bool AllowHair { get { return true; } }
        public override bool AllowFacialHair { get { return true; } }

        public override CustomHuePicker HuePicker { get { return new RaceHumainHue(); } }
        public override string Name { get { return "Humain"; } }
        public override string NameF { get { return "Humaine"; } }
 
        public override Apparence ApparenceMini { get { return Apparence.Repoussant; } }
        public override Apparence ApparenceMaxi { get { return Apparence.Seduisant; } }

        public override int StrMod { get { return 0; } }
        public override int DexMod { get { return 0; } }
        public override int IntMod { get { return 0; } }
        public override int ConsMod { get { return 0; } }
        public override int SagMod { get { return 0; } }
        public override int ChaMod { get { return 0; } }

        public RaceHumain()
		{
		}
	}
}