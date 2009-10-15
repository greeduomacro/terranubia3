using System;
using System.Collections.Generic;
using System.Text;
using Server.Engines;

namespace Server.Items
{
    public enum ArmeCategorie
    {
        Courante,
        Guerre,
        Exotique
    }
    public enum ArmeTemplate{
        Baton = 0,
        Masse,
        Epee,
        Hache,
        Lance,
        Hast,
        Dague,
        Arc,
        Arbalete,
        Jet,
        Poing,

        Maximum
    }
    public enum ArmeType
    {
        Contendant,
        Tranchant,
        Perforant
    }
    public class Armes
    {
        public static void configureTemplate(NubiaWeapon weapon)
        {

        }
    }
}
