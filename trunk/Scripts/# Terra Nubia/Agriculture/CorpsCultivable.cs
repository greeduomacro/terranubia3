using System;
using Server;
using Server.Nubia;

namespace Server.Items
{
	public class CorpsCultivable : Item
	{
		[Constructable]
		public CorpsCultivable() : this( 155 )
		{
		}
		[Constructable]
		public CorpsCultivable(int body) : base( 0x2006 )
		{
			Amount = body; // protocol defines that for itemid 0x2006, amount=body
			Movable = false;
			Hue = 2070;
			Name = "Cadavre Ecorché";
			new InternalTimer( this ).Start();
		}

		public CorpsCultivable( Serial serial ) : base( serial )
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

			public InternalTimer( Item blood ) : base( TimeSpan.FromDays( 2.0 ) )
			{
				Priority = TimerPriority.OneMinute;

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
