using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public enum NubiaRessourceType
    {
        Metal = 0,
        Cuir = 500,
        Os = 1000,
        Bois = 1500,
        Tissu = 2000
    }
    public enum NubiaRessource
    {
        //Metaux
        Fer = 0, 
        Verdan,
        Carriate,
        Remiar,
        Orafir,
        Mythril,
        Nafarite,
        Revarium,
        Trechar,
        Floreas,
        Oragite,
        Lonaris,
        Celiar,
        Firatas,
        Verate,
        Drachior,
        Glarias,
        Nethar,
        Divarium,
        Palerias,
        Nirior,


        //Cuir
        Classique = 500,
        Ophidian,
        Demoniaque,
        Sang,
        Rageur,
        Gargoulien,
        Lupus,
        Maritime,
        Givre,
        Chair,
        Balron,
        Reptilien,
        Terathan,
        Draconique,
        Geant,
        Rautour,
        Pierre,
        Legendaire,
        Nordique,
        Volcanique,
        Hydro,


        //Os
        Animaux = 1000,
        Morcith,
        Ardent,
        Desertique,
        Harpie,
        Ssins,
        Tyranoeil,
        Gargouille,
        Blub,
        Vengeur,
        Centorius,
        Detracteur,
        Arachnique,
        Feerique,
        Feu,
        Morgalin,
        Celeste,
        Mythique,
        Ancien,
        Royal,


        //Bois
        Erable = 1500,
		Pommier,
		Pecher,
		Poirier,
		Cedre,
		Cocotier,
		Chene,
		Noyer,
		Saule,
        Elendielle,


        // Tissu
        Lin = 2000,
		Coton,
		Soie,
		Laine
    }
}