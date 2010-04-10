using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Corps de loup des bois" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : NubiaCreature
	{
		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Loup des bois";
			Body = 23;
			BaseSoundID = 0xE5;


            CreatureType = MobileType.Animal;

            mMonsterHits = DndHelper.rollDe(De.huit, 2) + 4;
            this.VirtualArmor = 14;
            mMonsterAttaques = new int[] { 3 };
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
			MinTameSkill = 83.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
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