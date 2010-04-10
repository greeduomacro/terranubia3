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
	public abstract class BaseRace
	{
		public abstract string Name{get;}
		public abstract string NameF{get;}
       public abstract bool AllowHair { get;}
        public abstract bool AllowFacialHair { get;}
        public abstract Apparence ApparenceMini { get; }
        public abstract Apparence ApparenceMaxi { get; }

        public abstract CustomHuePicker HuePicker { get;}

        //Bonus aux stats
		public abstract int StrMod{get;}
		public abstract int DexMod{get;}
		public abstract int IntMod{get;}
        public abstract int ConsMod { get; }
        public abstract int SagMod { get; }
        public abstract int ChaMod { get; }

	}
}