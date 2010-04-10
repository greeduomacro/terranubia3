using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public class InvocWeapon : BaseMeleeWeapon
	{
		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Slashing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		private NubiaPlayer m_owner;

		[Constructable]
        public InvocWeapon(NubiaPlayer owner, SkillName skill, int speed, int Niveau, int itemID)
            : base(itemID)
		{
			//66 pour 10 degat
			double ratio = speed/5.0;
			MaxDamage =	(int)(100/ratio+(Niveau/2));
			MinDamage =	(int)(90/ratio+(Niveau/3));
			Skill = skill;
			m_owner = owner;
			Speed = speed;
		}

		[Constructable]
		public InvocWeapon( Serial serial ) : base( serial )
		{
		}

		public override bool OnEquip(Mobile from)
		{
			if(from != m_owner)
			{
				from.Emote("*l'arme tombe en poussière à votre contact*");
				return false;
				Delete();
			}
			//else
			//	Movable = false;
			return true;
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

		public override void OnDoubleClick( Mobile from )
		{
			from.SendLocalizedMessage( 1010018 ); // What do you want to use this item on?

			from.Target = new BladedItemTarget( this );
		}

        public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
		{
			base.OnHit( attacker, defender, damageBonus );

			if ( !Core.AOS && Poison != null && PoisonCharges > 0 )
			{
				--PoisonCharges;

				if ( Utility.RandomDouble() >= 0.5 ) // 50% chance to poison
					defender.ApplyPoison( attacker, Poison );
			}
		}
	}
}