using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Corps chat d'orgon" )]
	[TypeAlias( "Server.Mobiles.Hellcat" )]
	public class HellCat : NubiaCreature
	{
		[Constructable]
		public HellCat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Chat d'orgon";
			Body = 0xC9;
			Hue = Utility.RandomList( 0x647, 0x650, 0x659, 0x662, 0x66B, 0x674);
			BaseSoundID = 0x69;


            mMonsterHits = DndHelper.rollDe(De.huit, 6) + 18;
            this.VirtualArmor = 14;
            mMonsterAttaques = new int[] { 9, 4 };
            Server.Items.Fists MonsterWeapon = new Server.Items.Fists();
            MonsterWeapon.De = De.huit;
            MonsterWeapon.NbrLance = 1;
            MonsterWeapon.BonusDegatStatic = 6;
            MonsterWeapon.Movable = false;
            EquipItem(MonsterWeapon);
            mMonsterCA = VirtualArmor;

            mMonsterReflexe = 7;
            mMonsterVigueur = 8;
            mMonsterVolonte = 3;
            RawStr = 23;
            RawDex = 15;
            RawCons = 17;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;

            AddCompetence(CompType.Detection, 3);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.DeplacementSilencieux, 9);
            AddCompetence(CompType.Discretion, 3);
            AddCompetence(CompType.Equilibre, 6);
            AddCompetence(CompType.PerceptionAuditive, 3);
            AddCompetence(CompType.Survie, 0);
            mMonsterNiveau = 4;


			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 71.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public HellCat(Serial serial) : base(serial)
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