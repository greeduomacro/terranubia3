using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
	public enum BlessureGravite
	{
		None = -1,
        Legere = 0,
		Normal,
		Grave,
		TresGrave,
		ExtremeGrave,
		DivinGrave
	}
	public enum BlessureType
	{
		Hemoragie = 0,
		Fracture,
		Entaille,
		Perforation,
		Brulure,
	}
    public enum BlessureLocalisation
    {
        Tete,
        EpauleDroite,
        EpauleGauche,
        BrasDroit,
        BrasGauche,
        Torse,
        Ventre,
        Bassin,
        JambeDroite,
        JambeGauche
    }
}
