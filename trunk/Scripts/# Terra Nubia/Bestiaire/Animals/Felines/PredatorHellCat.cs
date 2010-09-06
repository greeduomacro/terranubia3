using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "un corps de chat des ombres" )]
	[TypeAlias( "Server.Mobiles.Preditorhellcat" )]
	public class PredatorHellCat : NubiaCreature
	{
		[Constructable]
		public PredatorHellCat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Chat des ombres";
			Body = 127;
			BaseSoundID = 0xBA;

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
			MinTameSkill = 89.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Hides{ get{ return 10; } }
		public override NubiaRessource HideType{ get{ return NubiaRessource.Demoniaque; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public PredatorHellCat(Serial serial) : base(serial)
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