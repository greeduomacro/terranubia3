using System;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Nubia;

namespace Server.Items
{
	public abstract class BaseLancer : NubiaWeapon
	{
		//public abstract int EffectID{ get; }
		//public abstract Type AmmoType{ get; }
		//public abstract Item Ammo{ get; }

		private int m_charges = 50;

		private int m_projectilID = 3906;

		public virtual bool IsNinjaReserved{get{return false;}}

		[CommandProperty( AccessLevel.GameMaster )]	
		public int ProjectilID 
		{
			get
			{
				return m_projectilID;
			}
			set
			{
				m_projectilID = value;
			}
		}
		[CommandProperty( AccessLevel.GameMaster )]	
		public int charges 
		{
			get
			{
				return m_charges;
			}
			set
			{
				m_charges = value;
			}
		}
		public override int DefHitSound{ get{ return 0x234; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Wrestle; } }


		public BaseLancer( int itemID ) : base(ArmeTemplate.Jet,  itemID )
		{
            
		}

		public BaseLancer( Serial serial ) : base( serial )
		{
			
		}

		public override bool OnEquip( Mobile f )
		{
			/*if( IsNinjaReserved )
			{
				NubiaMobile from = f as NubiaMobile;
				if( from.GetDisciplineValue( typeof(DisciplineNinSortNubia) ) < 1 ){
					from.SendMessage("Vous devez avoir le rang 1 de la discipline ninSortNubia pour manier cette arme");
					return false;
				}
				else
					return true;
			}*/
			return true;
		}

		public override TimeSpan OnSwing( Mobile attacker, Mobile defender )
		{
			OnFired(attacker, defender);
			return base.OnSwing(attacker, defender);
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damage )
		{
			//if ( attacker.Player && !defender.Player && (defender.Body.IsAnimal || defender.Body.IsMonster) && 0.4 >= Utility.RandomDouble() )
			//	defender.AddToBackpack( Ammo );

            base.OnHit(attacker, defender, damage);
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			Item ammo = new Item();
			ammo.Hue = Hue;
			ammo.ItemID = ItemID;
			ammo.Name = Name+" brisé";
			if ( attacker.Player && 0.4 >= Utility.RandomDouble()  )
				ammo.MoveToWorld( new Point3D( defender.X + Utility.RandomMinMax( -1, 1 ), defender.Y + Utility.RandomMinMax( -1, 1 ), defender.Z ), defender.Map );

			base.OnMiss( attacker, defender );
		}

		public virtual bool OnFired( Mobile attacker, Mobile defender )
		{
			Container pack = attacker.Backpack;

			attacker.MovingEffect( defender, m_projectilID, 18, 1, false, false,this.Hue, 0 );
			m_charges--;

			if ( m_charges < 1 )
			{
				Delete();
				return false;
			}
			//attacker.MovingEffect( defender, EffectID, 18, 1, false, false );
			
			string nam = Name;
			Name = nam;
			return true;
		}

		/*public override void GetProperties( ObjectPropertyList list )
		{
			list.Add(Name);
			list.Add("Restant: "+m_charges);
		}*/

		public override void OnSingleClick( Mobile from )
		{
			int number = 0;
			if ( Name == null )
			{
				number = LabelNumber;
				LabelTo( from, number );
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			/*if( Artisan != null )
				LabelTo(from, "Artisan: "+Artisan.Name);*/
			//LabelTo(from, "~Qualité "+Qualite.ToString()+"~");
			LabelTo( from, "Restant: "+m_charges );
			return;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_charges );
			writer.Write( (int) m_projectilID );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_charges = reader.ReadInt();
			m_projectilID = reader.ReadInt();
		}
	}
}