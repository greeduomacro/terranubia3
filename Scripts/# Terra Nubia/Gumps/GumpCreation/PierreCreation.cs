using System;
using System.Collections.Generic;
using Server.Gumps;
using System.Text;
using Server.Mobiles;

namespace Server.Items
{
    public class PierreCreation : Item
    {
        [Constructable]
        public PierreCreation()
            : base(10972)
        {
            Movable = false;
        }
        [Constructable]
        public PierreCreation(Serial s) : base(s) { }


        public override void OnDoubleClick(Mobile from)
        {
            from.CloseGump(typeof(GumpMenuCreation));
            from.CloseGump(typeof(GumpChoixBarbe));
            from.CloseGump(typeof(GumpChoixCheveux));
            from.CloseGump(typeof(GumpChoixClasse));
            from.CloseGump(typeof(GumpChoixRace));
            from.CloseGump(typeof(GumpCouleurCheveux));
            from.CloseGump(typeof(GumpBeaute));
            from.SendGump(new GumpMenuCreation(from as NubiaPlayer));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
