using System;
using Server;

namespace Server.Nubia
{
	//Tout les types de plantes
	public enum EnumPlante
	{
		//bouffe de base
		Ble = 0,
		Marnok,
		Citrouille,
		//Eau de base
		Aqualide,
		Putralide,
		Coton,
		Lin
	}

	//Le dev actuel
	public enum EnumPlanteState
	{
		Recolte = -1,
		Graine = 0,
		GrainePlante,
		Naissante,
		Jeune,
		Mature,
		Pourri,
		Morte //Très important de laisser en dernier;
	}
	//Les tares
	public enum EnumPlanteTare
	{
		Aucune = 0,
		Brule, //éclair/feu
		Malade
	}
	//Les terrains
	public enum EnumPlanteTerrain
	{
		Ferme = 0,
		Marais,
		Sable,
		Cadavre
	}
}
