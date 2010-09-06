using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps de loup des bois" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : NubiaCreature
	{
		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.02, 0.4 )
		{
			Name = "Loup des bois";
			Body = 23;
			BaseSoundID = 0xE5;


            CreatureType = MobileType.Animal;
            Faction = FactionEnum.Nature;
            NiveauCreature = 5;
            
            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
        
			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 83.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override NubiaRessource HideType{ get{ return NubiaRessource.Classique; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public DireWolf(Serial serial) : base(serial)
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