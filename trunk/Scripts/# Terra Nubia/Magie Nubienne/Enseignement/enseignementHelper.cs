using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Spells
{
	public static class enseignementHelper
	{
		public static SortEnergie[] getAdaptedComp(SortNubia originale, NubiaPlayer eleve)
		{
			//SortNubia newSortNubia = (SortNubia)KonohaHelper.CopyItem(originale);
			ArrayList compPoss = new ArrayList();
			for(int i = 0; i < originale.allowCompetence.Length ; i++)
			{
				CompType comp = (CompType)originale.allowCompetence[i];
				Console.WriteLine("Competence autorisé pour le SortNubia: "+comp.ToString() );
				//if(eleve.getValueFor(comp) > 0.0)
				//{
				//	Console.WriteLine("-- Competence Ok pour l'élève: "+comp.ToString() );
					//TODO
                compPoss.Add(comp);
				//}
			}
			if(compPoss.Count == 0)
				return null;
            SortEnergie[] cp = new SortEnergie[compPoss.Count];

			for(int f = 0; f < cp.Length; f++)
                cp[f] = (SortEnergie)compPoss[f];
			return cp;
		}
	}
}