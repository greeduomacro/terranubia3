using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class Fists : NubiaWeapon
	{
		public static void Initialize()
		{
			Mobile.DefaultWeapon = new Fists();
		}

		public override int DefHitSound{ get{ return -1; } }
		public override int DefMissSound{ get{ return -1; } }

		public Fists() : base( 0 )
		{
			Visible = false;
			Movable = false;

            De = De.trois;
            NbrLance = 1;
            MiniForCritique = 20;
            CritiqueMulti = 2;

		}

		public Fists( Serial serial ) : base( serial )
		{
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

			Delete();
		}

		private static bool HasFreeHands( Mobile m )
		{
			Item item = m.FindItemOnLayer( Layer.OneHanded );

			if ( item != null && !(item is Spellbook) )
				return false;

			return m.FindItemOnLayer( Layer.TwoHanded ) == null;
		}
	}
}