using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Corps de loup gris" )]
	[TypeAlias( "Server.Mobiles.Greywolf" )]
	public class GreyWolf : NubiaCreature
	{
		[Constructable]
		public GreyWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Loup gris";
			Body = Utility.RandomList( 25, 27 );
			BaseSoundID = 0xE5;


            CreatureType = MobileType.Animal;

            mMonsterHits = DndHelper.rollDe(De.huit, 2) + 4;
            this.VirtualArmor = 14;
            mMonsterAttaques = new int[] { 2, -2 };
            Server.Items.Fists MonsterWeapon = new Server.Items.Fists();
            MonsterWeapon.De = De.six;
            MonsterWeapon.NbrLance = 1;
            MonsterWeapon.BonusDegatStatic = 1;
            MonsterWeapon.Movable = false;
            EquipItem(MonsterWeapon);
            mMonsterCA = VirtualArmor;

            mMonsterReflexe = 5;
            mMonsterVigueur = 5;
            mMonsterVolonte = 1;
            RawStr = 13;
            RawDex = 15;
            RawCons = 15;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;

            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 1);
            mMonsterNiveau = 1;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 53.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public GreyWolf(Serial serial) : base(serial)
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