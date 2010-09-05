using System;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using Server.Engines;
using System.Collections;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
    public class PlanteSauvageAlthaea : BasePlanteSauvage
    {
        [Constructable]
        public PlanteSauvageAlthaea()
        {
            Name = "Althaea officinalis";
            ItemID = 1605;
            Hue = 1646;
            mDD = 15;
        }

        [Constructable]
        public PlanteSauvageAlthaea(Serial s) : base(s) { }

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

