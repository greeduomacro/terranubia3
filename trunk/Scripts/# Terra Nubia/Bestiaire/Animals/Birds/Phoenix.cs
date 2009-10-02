using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a phoenix corpse" )]
	public class Phoenix : NubiaCreature
	{
		[Constructable]
		public Phoenix() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a phoenix";
			Body = 5;
			Hue = 0x674;
			BaseSoundID = 0x8F;


            this.VirtualArmor = 6;

            this.ConfigureCreature(8, ClasseType.Barbare);
            CreatureType = MobileType.Animal;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
		}

		public override int Meat{ get{ return 1; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 36; } }

		public Phoenix( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}