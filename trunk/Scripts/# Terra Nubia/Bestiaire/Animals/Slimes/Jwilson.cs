using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a jwilson corpse" )]
    public class Jwilson : BaseBestiole
	{
		[Constructable]
		public Jwilson() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Hue = Utility.RandomList(0x89C,0x8A2,0x8A8,0x8AE);
			this.Body = 0x33;
			this.Name = ("a jwilson");
			this.VirtualArmor = 8;
            NiveauCreature = 4;
		}

		public Jwilson(Serial serial) : base(serial)
		{
		}

		public override int GetAngerSound() 
		{ 
			return 0x1C8; 
		} 

		public override int GetIdleSound() 
		{ 
			return 0x1C9; 
		} 

		public override int GetAttackSound() 
		{ 
			return 0x1CA; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x1CB; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x1CC; 
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
