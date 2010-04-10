using System;
using Server;

namespace Server.Items
{
	public class TerreRetourne : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}


		[Constructable]
		public TerreRetourne() : base( 0x31F4 )
		{
			Stackable = false;
			Name="Terre Retourné";
			Movable=false;
			new DelayEfface( this ).Start();
		}

		public TerreRetourne( Serial serial ) : base( serial )
		{
		}

		private class DelayEfface : Timer
		{
			private Item m_terre;

			public DelayEfface( Item _terre ) : base( TimeSpan.FromHours( 12.0 ) )
			{
				Priority = TimerPriority.OneSecond;
				m_terre=_terre;
			}

			protected override void OnTick()
			{
				m_terre.Delete();
			}
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
	}
}