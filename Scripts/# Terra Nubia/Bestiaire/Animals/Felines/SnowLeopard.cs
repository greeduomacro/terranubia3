using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Un corps de leopard des neiges" )]
	[TypeAlias( "Server.Mobiles.Snowleopard" )]
	public class SnowLeopard : NubiaCreature
	{
		[Constructable]
		public SnowLeopard() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Leopard des neiges";
			Body = Utility.RandomList( 64, 65 );
			BaseSoundID = 0x73;

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
			MinTameSkill = 53.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public SnowLeopard(Serial serial) : base(serial)
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