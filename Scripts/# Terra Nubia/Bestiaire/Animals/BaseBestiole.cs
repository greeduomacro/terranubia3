using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mobiles
{
    public abstract class BaseBestiole : NubiaCreature
    {
        public BaseBestiole()
            : this(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.5)
        {
        }
        public BaseBestiole(AIType aitype, FightMode aggr, int un, int deux, double dun, double ddeux) : base( aitype, aggr, un, deux, dun, ddeux )
		{
			Body = 0xD0;
			BaseSoundID = 0x6E;

			
            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;


            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;

		}


		public BaseBestiole(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
    
    }
}
