using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.Harvest;
using Server.ContextMenus;

namespace Server.Items
{
	public abstract class BasePoleArm : NubiaWeapon
	{
		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash2H; } }

	

		public BasePoleArm( int itemID ) : base( ArmeTemplate.Hast, itemID )
		{
		}

		public BasePoleArm( Serial serial ) : base( serial )
		{
		}

	
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

		}
	}
}