using System;
using Server;
using Server.Nubia;
using Server.Mobiles;

namespace Server.Items
{
	public class BloodNubia : Item
	{
		[Constructable]
		public BloodNubia() : this( Utility.RandomMinMax(4650,4654) )
		{
			Movable = false;
		}

		[Constructable]
		public BloodNubia( NubiaMobile mob ) : base( Utility.RandomMinMax(4650,4654) )
		{
			Movable = false;

			new InternalTimer( this ).Start();
		}


		public BloodNubia( Serial serial ) : base( serial )
		{
			new InternalTimer( this ).Start();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private Item m_Blood;

			public InternalTimer( Item blood ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				Priority = TimerPriority.OneSecond;

				m_Blood = blood;
			}

			protected override void OnTick()
			{
				if(m_Blood != null)
					m_Blood.Delete();
			}
		}
	}
}
