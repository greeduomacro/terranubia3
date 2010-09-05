using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class CeintureForce : BodySash
    {
        public CeintureForce(Serial s)
            : base(s)
        {
            Hue = 2118;
            Name = "Ceinture de l'ours";
            ArtefactModus modus = new ArtefactModus();
            modus.DndStat = Server.Mobiles.DndStat.Force;
            modus.StatValue = 2;
            this.ArtefactModus = modus;
        }
        [Constructable]
        public CeintureForce()
        {
            Hue = 2118;
            Name = "Ceinture de l'ours";
            ArtefactModus modus = new ArtefactModus();
            modus.DndStat = Server.Mobiles.DndStat.Force;
            modus.StatValue = 2;
            this.ArtefactModus = modus;
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
