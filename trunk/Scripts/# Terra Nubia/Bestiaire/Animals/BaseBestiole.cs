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

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.trois;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 0;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[] { 0 };
            mMonsterCA = 6;
            mMonsterHits = DndHelper.rollDe(De.quatre, 2);
            mMonsterReflexe = 2;
            mMonsterVigueur = 0;
            mMonsterVolonte = 0;
            RawStr = 10;
            RawDex = 8;
            RawCons = 8;
            RawInt = 2;
            RawSag = 10;
            RawCha = 6;
            mMonsterNiveau = 0;
            AddCompetence(CompType.Detection, 2);
            AddCompetence(CompType.PerceptionAuditive, 2);

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
