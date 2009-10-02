using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a crane corpse" )]
	public class Crane : BaseBestiole
	{
		[Constructable]
		public Crane() 
		{
			Name = "Oiseaux";
			Body = 254;
			BaseSoundID = 0x4D7;

		}

		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }


		public override int GetAngerSound()
		{
			return 0x4D9;
		}

		public override int GetIdleSound()
		{
			return 0x4D8;
		}

		public override int GetAttackSound()
		{
			return 0x4D7;
		}

		public override int GetHurtSound()
		{
			return 0x4DA;
		}

		public override int GetDeathSound()
		{
			return 0x4D6;
		}

		public Crane(Serial serial) : base(serial)
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