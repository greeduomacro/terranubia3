using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	[TypeAlias( "Server.Mobiles.Bear" )]
	public class BlackBear : NubiaCreature
	{
		[Constructable]
		public BlackBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Ours noir";
			Body = 211;
            BaseSoundID = 0xA3;

            this.VirtualArmor = 1;

            CreatureType = MobileType.Animal;

            Server.Items.Fists griffes = new Server.Items.Fists();
            griffes.De = De.quatre;
            griffes.NbrLance = 1;
            griffes.BonusDegatStatic = 4;
            griffes.Movable = false;
            EquipItem(griffes);
            mMonsterAttaques = new int[]{2,6};
            mMonsterCA = 13;
            mMonsterHits = DndHelper.rollDe(De.huit, 3) + 6;
            mMonsterReflexe = 4;
            mMonsterVigueur = 5;
            mMonsterVolonte = 2;
            RawStr = 19;
            RawDex = 13;
            RawCons = 15;
            RawInt = 2;
            RawSag = 12;
            RawCha = 6;
            mMonsterNiveau = 2;
            AddCompetence(CompType.Detection, 4);
            AddCompetence(CompType.PerceptionAuditive, 4);
            AddCompetence(CompType.Escalade, 4);

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public BlackBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}