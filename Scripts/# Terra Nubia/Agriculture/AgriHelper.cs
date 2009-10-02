using System;
using Server;
using Server.Nubia;
using Server.Engines;

namespace Server.Items
{
	public class AgriHelper
	{
		public static int GetPlanteID( EnumPlante type, EnumPlanteState state )
		{
			if( type == EnumPlante.Ble )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 4108;
					case EnumPlanteState.Graine: return 0xF27;
					case EnumPlanteState.GrainePlante: return Utility.RandomList( 7871, 7870 );
					case EnumPlanteState.Naissante: return 3502;
					case EnumPlanteState.Jeune: return 3161;
					case EnumPlanteState.Mature: return Utility.RandomList( 3163, 3162 );
					case EnumPlanteState.Pourri: return 3160;
				
				}
			}

			if( type == EnumPlante.Marnok )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 3200;
					case EnumPlanteState.Graine: return 0xF27;
					case EnumPlanteState.GrainePlante: return 0xF27;
					case EnumPlanteState.Naissante: return 15639;
					case EnumPlanteState.Jeune: return 15640;
					case EnumPlanteState.Mature: return 3197;
					case EnumPlanteState.Pourri: return 3197;
				
				}
			}

			if( type == EnumPlante.Citrouille )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 3178;
					case EnumPlanteState.Graine: return 3884;
					case EnumPlanteState.GrainePlante: return 3148;
					case EnumPlanteState.Naissante: return Utility.RandomList( 3188, 3189 );
					case EnumPlanteState.Jeune: return 3180;
					case EnumPlanteState.Mature: return Utility.RandomList( 3178, 3179 );
					case EnumPlanteState.Pourri: return Utility.RandomList( 3178, 3179 );
				
				}
			}


			if( type == EnumPlante.Aqualide )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 15425;
					case EnumPlanteState.Graine: return 3884;
					case EnumPlanteState.GrainePlante: return 3148;
					case EnumPlanteState.Naissante: return Utility.RandomList( 15371, 15372 );
					case EnumPlanteState.Jeune: return Utility.RandomList( 15406, 15407 );
					case EnumPlanteState.Mature: return Utility.RandomList( 15433, 15434 );
					case EnumPlanteState.Pourri: return Utility.RandomList( 15433, 15434 );
				
				}
			}

			if( type == EnumPlante.Putralide )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 15481;
					case EnumPlanteState.Graine: return 3884;
					case EnumPlanteState.GrainePlante: return 3148;
					case EnumPlanteState.Naissante: return Utility.RandomList( 15426, 15427 );
					case EnumPlanteState.Jeune: return Utility.RandomList( 15361, 15362 );
					case EnumPlanteState.Mature: return Utility.RandomList( 15363, 15364 );
					case EnumPlanteState.Pourri: return Utility.RandomList( 15363, 15364 );
				
				}
			}
			
			if( type == EnumPlante.Coton )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 15481;
					case EnumPlanteState.Graine: return 3884;
					case EnumPlanteState.GrainePlante: return 3148;
					case EnumPlanteState.Naissante: return Utility.RandomList( 3155, 3156 );
					case EnumPlanteState.Jeune: return Utility.RandomList( 3155, 3156 );
					case EnumPlanteState.Mature: return Utility.RandomList( 3151, 3152 );
					case EnumPlanteState.Pourri: return Utility.RandomList( 3151, 3152 );
				
				}
			}

			if( type == EnumPlante.Lin )
			{
				switch (state)
				{
					case EnumPlanteState.Recolte: return 15481;
					case EnumPlanteState.Graine: return 3884;
					case EnumPlanteState.GrainePlante: return 3148;
					case EnumPlanteState.Naissante: return Utility.RandomList( 15446, 15447 );
					case EnumPlanteState.Jeune: return Utility.RandomList( 15446, 15447 );
					case EnumPlanteState.Mature: return Utility.RandomList( 15448, 15449 );
					case EnumPlanteState.Pourri: return Utility.RandomList( 15448, 15449 );
				
				}
			}


			return 0x28DD;
		}
		public static Item GetRecolteItem(EnumPlante type )
		{
			switch (type)
			{
				case EnumPlante.Aqualide: return new PlanteRecolteAqualide();
				case EnumPlante.Coton: return new TissuCoton();
				case EnumPlante.Lin: return new TissuLin();
				
			}
			return null;
		}
		public static string GetStateString(EnumPlanteState state )
		{
			switch (state)
			{
				case EnumPlanteState.Graine: return "Graine";
				case EnumPlanteState.GrainePlante: return "Graine plantée";
				case EnumPlanteState.Naissante: return "Naissante";
				case EnumPlanteState.Jeune: return "Jeune";
				case EnumPlanteState.Mature: return "Mature";
				case EnumPlanteState.Pourri: return "Pourrie";
				
			}
			return "inconue";
		}
		public static string GetPlanteString(EnumPlante type )
		{
			switch (type)
			{
				case EnumPlante.Ble: return "Blé";
				case EnumPlante.Marnok: return "Marnok";	
				case EnumPlante.Citrouille: return "Citrouille";
				case EnumPlante.Aqualide: return "Aqualide";
			}
			return "inconue";
		}
	}
}
