using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class SortNubiaInvocationArme : SortNubia
	{
		public override int GetCercle()
		{
				int niveau = 10;
				//if(Owner != null)
				//	niveau = Owner.Level;
				return (int)niveau;
		}

        public override string DefaultName { get { return "Invocation d'arme"; } }
        public override SortDomaine Domaine { get { return SortDomaine.InvocationMatiere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return true;}}

		private Timer m_timer = null;
		private int m_speed = 60;
		private string m_nom = "Arme invoquée";
		private Item m_weapon = null;
		private SkillName m_skill = SkillName.Fencing;
		private int m_id = 0xDF1;
		private int m_color = 1149;

		public string nom
		{
			get
			{
				return m_nom;
			}
			set
			{
				m_nom = (string)value;
			}
		}

		public override SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[] 
				{
					SortEnergie.All
				};
			}
		}

		[Constructable]
		public SortNubiaInvocationArme() : base ("Invocation No SortNubia")
		{
			distance = 6;
			Delay = 120.0;
			TimeToCast = 6.0;
		}
		[Constructable]
		public SortNubiaInvocationArme( Serial serial ) : base (serial)
		{
		}

		public override void StartCast()
		{
			base.StartCast();
		}

		public override bool canCast(NubiaPlayer from)
		{
			return base.canCast(from);
		}
		public override void EndSortNubia()
		{

            NubiaPlayer m = Owner as NubiaPlayer;

			Effects.SendLocationEffect( new Point3D( Owner.X, Owner.Y , Owner.Z ),Owner.Map, 0x3728, 13 );

			Owner.PlaySound( 0x228 );

			if(m_weapon != null)
				m_weapon.Delete();

			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			double time = (int)(Owner.Niveau)*(Maitrise/12.0);
			time *= getRatio();

			m_weapon = new InvocWeapon(Owner, m_skill, m_speed, Owner.Niveau, m_id);
			m_weapon.Hue = m_color;
			m_weapon.Name = m_nom;
			((InvocWeapon)m_weapon).MaxDamage = (int)(((InvocWeapon)m_weapon).MaxDamage*getRatio());

			Effects.SendLocationEffect( new Point3D( Owner.X, Owner.Y , Owner.Z),Owner.Map, 0x3728, 13 );
			
			//if( !Owner.EquipItem(m_weapon) );
				m_weapon.MoveToWorld(Owner.Location, Owner.Map);
				Owner.EquipItem(m_weapon);

			Owner.PlaySound( 0x228 );

			m_timer = new InternalTimer(this, time);
			m_timer.Start();
			return true;
		}

		private class InternalTimer : Timer
		{
			private SortNubiaInvocationArme m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaInvocationArme item, double t ) : base( TimeSpan.FromSeconds( t ) )
			{
				Priority = TimerPriority.OneSecond;
				m_Item = item;
				m_t = t;
			}

			protected override void OnTick()
			{
				if(m_Item == null)
					return;
				if(m_Item.state == MagieState.WaitEnd)
					m_Item.EndSortNubia();
				Stop();
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version
			writer.Write( (int)m_speed );
			writer.Write( (string) m_nom );
			writer.Write( (Item) m_weapon);
			writer.Write( (int) m_skill);
			writer.Write( (int) m_id);
			writer.Write( (int) m_color);
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_speed = reader.ReadInt();
			m_nom = reader.ReadString();
			m_weapon = reader.ReadItem();
			m_skill = (SkillName)reader.ReadInt();
			m_id = reader.ReadInt();
			m_color = reader.ReadInt();
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public SkillName wSkill
		{
			get{ return m_skill; }
			set{m_skill= value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string wNom
		{
			get{ return m_nom; }
			set{m_nom= value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int wId
		{
			get{ return m_id; }
			set{ m_id = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int wSpeed
		{
			get{ return m_speed; }
			set{ m_speed = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int color
		{
			get{ return m_color; }
			set{ m_color = value; InvalidateProperties(); }
		}
		
	}

}