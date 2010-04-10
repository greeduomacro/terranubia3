using System;
using Server;
using Server.Spells;
using Server.Mobiles;


namespace Server.Mobiles
{
    public enum MobileType
    {
        None = -1,
        //Base de D&D3
        Aberration = 0,
        Animal,
        CreatureArtificielle,
        CreatureMagique,
        Dragon,
        Elementaire,
        Exterieur,
        Fee,
        Geant,
        Humanoide,
        HumanoideMonstrueux,
        MortVivant,
        Plante,
        Vase,
        Vermine,

        //Maximum
        Maximum
    }
    public enum MobileSousType
    {
        Air,
        Altere,
        Ange,
        Aquatique,
        Archon,
        Bien,
        Chaos,
        Extraplanaire,
        Eau,
        Feu,
        Froid,
        Gobelinoide,
        Intangible,
        Loi,
        Mal,
        Métamorphe,
        Natif,
        Nuée,
        Reptilien,
        Terre
    }
    public enum MobileForce
    {
        TresFaible = -2,
        Faible = -1,
        Normal = 0,
        Force = 1,
        TresFort = 2,
        Ancestral = 3
    }
}