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
	public class SortNubiaClone : SortNubia
	{
		public override int GetCercle()
		{
				int niveau = 4; //Moyenne de degat
				
				return (int)niveau;
		}

        public override SortDomaine Domaine { get { return SortDomaine.Chimere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return false;}}

		public override bool isGestuel{ get{return false;}}
		public override bool mustCrier{ get{return false;}}
		public override bool isUnique{ get{return true;}}

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

		
		private ArrayList m_saveItems = new ArrayList();
		private ArrayList m_copyItems = new ArrayList();
		private int m_hair = 0;
		private int m_beard = 0;
		private int m_hue = 0;
		private int m_hairHue = 0;
		private int m_body = 0;
		private string m_name = "no";
		private Timer m_timer = null;
	
		[Constructable]
		public SortNubiaClone() : base ("Illusion d'apparence")
		{
			distance = 25;
			Delay = 30.0;
			TimeToCast = 4.0;
		}
		[Constructable]
		public SortNubiaClone( Serial serial ) : base (serial)
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
			
			//Clone
			for( int i = 0; i < m_copyItems.Count; i++ )
			{
				Item it = m_copyItems[i] as Item;
				it.Delete();
			}
			for( int c = 0; c < m_saveItems.Count; c++ )
			{
				Item it = m_saveItems[c] as Item;
				Owner.EquipItem(it);
			}
			Owner.BodyValue = m_body;
			Owner.HueMod = -1;
			Owner.HairItemID = m_hair;
			Owner.HairHue = m_hairHue;
			Owner.FacialHairItemID = m_beard;
			Owner.FacialHairHue = m_hairHue;
			Owner.Name = m_name;
			
			SortNubiaHelper.makeBigSmoke(Owner.Location, Owner.Map);
			Owner.SendMessage("Fin de l'effet de '{0}'", Nom );
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;
			
			//if(m_canCible)
				Owner.Target = new InternalTarget( this );
			//else
			//	FinishSequence(Owner);
			return true;
		}
		public void FinishSequence(Mobile cible)
		{
			Owner.Animate( 17, 7, 1, true, false, 0 );
			double time = (int)(Owner.Niveau/3)*(Maitrise/5.0);
			time *= getRatio();

			SortNubiaHelper.makeBigSmoke(Owner.Location, Owner.Map);

			//SAVES
			m_saveItems = new ArrayList();
			m_copyItems = new ArrayList();
			/*private int m_hair = 0;
			private int m_beard = 0;*/
			m_hair = Owner.HairItemID;
			m_beard = Owner.FacialHairItemID;
			m_hue = Owner.Hue;
			m_hairHue = Owner.HairHue;
			m_body = Owner.BodyValue;
			m_name = Owner.Name;

			for( int i = 0; i < 24; i++ )
			{
				Item it = Owner.FindItemOnLayer((Layer)i) as Item;
				if( it != null && !(it is Backpack))
				{
					m_saveItems.Add( it );
					try{Owner.Backpack.AddItem(it);}
					catch{}
				}
			}


			//Clone
			for( int c = 0; c < 24; c++ )
			{
				Item it = NubiaHelper.CopyItem(cible.FindItemOnLayer((Layer)c) as Item);
				if( it != null && !(it is Backpack))
				{
					m_copyItems.Add( it );
					Owner.EquipItem(it);
					it.Movable = false;
				}
			}
			Owner.Name = cible.Name;
			Owner.BodyValue = cible.BodyValue;
			Owner.HueMod = cible.Hue;
			Owner.HairItemID = cible.HairItemID;
			Owner.HairHue = cible.HairHue;
			Owner.FacialHairItemID = cible.FacialHairItemID;
			Owner.FacialHairHue = cible.FacialHairHue;

			m_timer = new InternalTimer(this, time);
			Owner.SendMessage("Vous garderez cette apparence pour {0} secondes", ((int)time).ToString() );
			m_timer.Start();
			return;
		}

		private class InternalTimer : Timer
		{
			private SortNubiaClone m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaClone item, double t ) : base( TimeSpan.FromSeconds( t ) )
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

		private class InternalTarget : Target
		{
			private SortNubiaClone m_Owner;

			public InternalTarget( SortNubiaClone owner ) : base( owner.distance, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.FinishSequence( (Mobile)o );
			}
		}

		/*m_saveItems = new ArrayList();
			m_copyItems = new ArrayList();
			/*private int m_hair = 0;
			private int m_beard = 0;
			m_hair = Owner.HairItemID;
			m_beard = Owner.FacialHairItemID;
			m_hue = Owner.Hue;
			m_hairHue = Owner.HairHue;
			m_body = Owner.BodyValue;*/

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version

			writer.Write( (int)m_saveItems.Count);
			for (int i = 0; i < m_saveItems.Count ; i++ )
			{
				writer.Write( (Item)m_saveItems[i] as Item ) ;
			}

			writer.Write( (int)m_copyItems.Count);
			for (int c = 0; c < m_copyItems.Count ; c++ )
			{
				writer.Write( (Item)m_copyItems[c] as Item ) ;
			}

			writer.Write( (int)m_hair );
			writer.Write( (int)m_beard );
			writer.Write( (int)m_hue );
			writer.Write( (int)m_hairHue );
			writer.Write( (int)m_body );
			writer.Write( (string)m_name );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();	

			int countS = reader.ReadInt();
			m_saveItems = new ArrayList();
			for(int i = 0; i < countS; i++)
			{
				m_saveItems.Add(reader.ReadItem() );
			}
			int countC = reader.ReadInt();
			m_copyItems = new ArrayList();
			for(int i = 0; i < countC; i++)
			{
				m_copyItems.Add(reader.ReadItem() );
			}
			m_hair = reader.ReadInt();
			m_beard = reader.ReadInt();
			m_hue = reader.ReadInt();
			m_hairHue = reader.ReadInt();
			m_body = reader.ReadInt();
			m_name = reader.ReadString();
		}
		
	}

}