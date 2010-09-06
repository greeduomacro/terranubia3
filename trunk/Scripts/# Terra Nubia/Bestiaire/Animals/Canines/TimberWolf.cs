using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Corps loup" )]
	[TypeAlias( "Server.Mobiles.Timberwolf" )]
	public class TimberWolf : NubiaCreature
	{
		[Constructable]
        public TimberWolf()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.02, 0.4)
		{
			Name = "Loup";
			Body = 225;
			BaseSoundID = 0xE5;


            CreatureType = MobileType.Animal;
            Faction = FactionEnum.Nature;
            NiveauCreature = 5;
            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
      

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 23.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public TimberWolf(Serial serial) : base(serial)
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