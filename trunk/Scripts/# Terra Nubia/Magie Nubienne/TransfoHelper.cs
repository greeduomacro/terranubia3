using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;

namespace Server.Spells
{
	public static class TransfoHelper
	{
		/*public static SkillName[] getSkillBonus(EnergieType comp)
		{
			SkillName[] sktab = new SkillName[1]{SkillName.Focus};

			if(comp == EnergieType.Felin)
			{
				sktab = new SkillName[3]
				{
					SkillName.Hiding,
					SkillName.Stealth,
					SkillName.Focus
				};
			}
			if(comp == EnergieType.Canin)
			{
				sktab = new SkillName[3]
				{
					SkillName.Tactics,
					SkillName.DetectHidden,
					SkillName.Tracking
				};
			}
			if(comp == EnergieType.Os) //Chance de blessé au contact
			{
				sktab = new SkillName[1];
				sktab[0] = SkillName.Tactics;
			}
			return sktab;
		}*/
			//Transformation Helper ;)
		public static double getModusInt(SortEnergie comp)
		{
			switch(comp)
			{
				case SortEnergie.All:	   return 1.0; break;
			}
			return 1.0;
		}
		public static double getModusDex(SortEnergie comp)
		{
			switch(comp)
			{
                case SortEnergie.All: return 1.0; break;
			}
			return 1.0;
		}
		
		public static double getModusStr(SortEnergie comp)
		{
			switch(comp)
			{
                case SortEnergie.All: return 1.0; break;
			}
			return 1.0;
		}
		/*public static int getBonusStr(EnergieType comp)
		{
			switch(comp)
			{
				case EnergieType.Error:	   return 0; break;
				case EnergieType.NinSortNubia:	   return 0; break;
				case EnergieType.ManipChakra: return 0; break;
				case EnergieType.Feu:		   return 0; break;
				case EnergieType.Air:		   return 0; break;
				case EnergieType.Terre:	   return 0; break;
				case EnergieType.Eau:		   return 0; break;
				case EnergieType.Metal:	   return 0; break;
				case EnergieType.Reptile:	   return 0; break;
				case EnergieType.Felin:	   return 0; break;
				case EnergieType.Farouche:	   return 0; break;
				case EnergieType.Canin:	   return 0; break;
				case EnergieType.Vegetal:	   return 0; break;
				case EnergieType.Os:		   return 0; break;
				case EnergieType.Chair:	   return 0; break;
				case EnergieType.Kami:		   return 0; break;
				case EnergieType.Renforcement:return 0; break;
				case EnergieType.Soin:		   return 0; break;
				case EnergieType.Contact:	   return 0; break;
				case EnergieType.Distance:	   return 0; break;
				case EnergieType.Amphibien:   return 0; break;
				case EnergieType.Insecte:	   return 0; break;
				case EnergieType.Arachnide:   return 0; break;
				case EnergieType.Son:		   return 0; break;
			}
		}*/
	}
}