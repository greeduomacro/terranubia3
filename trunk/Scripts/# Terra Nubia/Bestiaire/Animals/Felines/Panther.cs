using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Corps de panthère" )]
	public class Panther : NubiaCreature
	{
		[Constructable]
		public Panther() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Panthère";
			Body = 0xD6;
			Hue = 0x901;
			BaseSoundID = 0x462;


            NiveauCreature = 7;

            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 9);
            AddCompetence(CompType.Discretion, 3);
            AddCompetence(CompType.Equilibre, 6);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 0);
     

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 53.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Panther(Serial serial) : base(serial)
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