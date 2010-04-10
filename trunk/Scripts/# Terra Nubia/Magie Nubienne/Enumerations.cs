using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Spells
{
    public enum MageSpe
    {
        Generaliste = 1,
        Normal,
        Specialiste
    }
    public enum SortEnergie
    {
        Piege,
        All,
        Mental, //Default
        Air ,
        Vie,
        Eau ,
        Matiere ,
        Terre ,

        Mort,
        
        Feu,
        Maximum
    }
    public enum SortDomaine
    {
        All,
        Evocation,
        Poison,
        Chimere,
        Entrave,
        Soin,
        Abjuration,
        InvocationVie,
        InvocationMatiere,
        Maximum
    }
    public enum MagieCondition
    {
        None = 0,
        MainNue = 1,
        ObjetEquiper = 2,
        ObjetAlentour = 3,
        MobileAlentour = 4,
        SortNubia = 5
    }
    public enum MagieColor
    {
        Aucune = 0,
        Chakra = 1,
        Connaissance = 2
    }

    public enum MagieState
    {
        None = 0,
        InCast = 1,
        WaitEnd = 2
    }

    public enum MagieDisturb
    {
        None = 0,
        SortNubia = 1,
        Mort = 2,
        Mouvement = 3,
        Mana = 4
    }
    public enum MagieRender
    {
        Normal = 0,
        Assombri = 1,
        Eclairci = 2,
        TransparencePartiele = 3,
        Translucide = 4,
        TranslicidePrimaire = 5,
        Negatif = 6
    }

    /*	1 It becomes dark
        2 It becomes bright
        3 Bright color is emphasized and dark color is converted transparently
        4 The translucency (transparency is high)
        5 The translucency (it is close to primary color)
        6 Negative positive reversal
        7 The background which is transparent negative positive reversal*/
    /*  MessageType (Enum)
        Regular = 0,
        System = 1,
        Emote = 2,
        Label = 6,
        Focus = 7,
        Whisper = 8,
        Yell = 9,
        Spell = 10,
        Encoded = 192*/
}
