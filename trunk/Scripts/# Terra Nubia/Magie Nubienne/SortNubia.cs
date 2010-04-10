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
	public abstract class SortNubia : Item
	{
		private class InternalTimer : Timer
		{
			private SortNubia m_Item;
			private bool m_first = true;
			private double m_t = 0.0;

			public InternalTimer( bool first, SortNubia item, double t ) : base( TimeSpan.FromSeconds( t ) )
			{
				Priority = TimerPriority.OneSecond;
				m_Item = item;
				m_first = first;
				m_t = t;
			}

			protected override void OnTick()
			{
				if(m_Item == null)
					return;

				//Console.WriteLine("Tick de SortNubia: "+m_Item.Nom);
				
				if( m_Item.isDisturb() )
					return;

				if(!m_first)
					m_Item.Cast();
				else
				{
					m_first = false;
					if(m_Item.isGestuel && m_Item.Emote != "")	
						m_Item.Owner.Emote("*"+m_Item.Emote+"*");
					//if(m_Item.SortNubiaType != SortNubiaType.silencieuse && m_Item.Owner != null )
					if(m_Item.mustCrier)
						m_Item.Owner.FixedParticles( 0x376A, 1, (int)m_t*20, 0x251D, m_Item.Owner.ChakraColor, 0, EffectLayer.Waist );
					new InternalTimer(m_first, m_Item, m_t).Start();
					//Stop();
				}
				Stop();
			}
		}

		private NubiaPlayer m_owner;
		private string m_createur = "";

		private string m_name = "Sortilège";
		private double m_time = 100.0; //Temps entre utilisation en secondes
		private double m_timeToCast = 5.0;

		private double m_maitrise = 0.0;
		private int m_distance  = 1;

		private SortEnergie m_energie = SortEnergie.Air;

        public virtual int GetCercle() {return 1;}

		public double miniCategorie{get{return GetCercle()*3.3;}}
		public double miniCompetence{get{return ((GetCercle()*3.3)-(GetCercle()/2));}}
		public double miniSkill{get{return ( 7.0+(double)(GetCercle()*3) ) ;}}
		public int chakra{get{return GetCercle()*7;}}

		protected string m_emote = "Se concentre";
		//protected bool m_finished = true; //en cas de crash pour mettre fin au SortNubia... genre la transfo ou abréger le sort avant

		//TYPE
		public virtual bool playEffect{ get	{	return true;	}}
        public virtual SortDomaine Domaine { get { return SortDomaine.Evocation; } }
        public virtual string DefaultName { get { return "Sort nubien"; } }
        private MagieColor m_couleur = MagieColor.Aucune;
        private MagieState m_state = MagieState.None;
        private MagieDisturb m_disturb = MagieDisturb.None;
        private SortNubiaEffect m_effect = SortNubiaEffect.FireBall;

		//CONDITION
        private MagieCondition m_condition = MagieCondition.None;
		private Item m_Object = null;
		private Mobile m_Mobile = null;
		private SortNubia m_SortNubia = null;
        private MagieRender m_render = MagieRender.Normal;
		private bool m_achat = true; //on paye en doublecliquant pour apprendre ?


		//APPRENTISSAGE

		public virtual bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public virtual bool canBePere{ get{return false;}}
		public virtual bool isGestuel{ get{return true;}}
		public virtual bool mustCrier{ get{return true;}}
		public virtual bool isUnique{ get{return false;}}

		public DateTime LastUse = DateTime.Now - TimeSpan.FromSeconds(160.0);

		public void doMoveDisturb() { m_disturb = MagieDisturb.Mouvement; }		
		public void forceCondition(MagieCondition con){ m_condition = con; }

		public bool canCraft(NubiaPlayer from)
		{
			if(from == null)
			{
				Console.WriteLine("From null dans canCraft magie");
				return false;
			}
		

            if (SortNubiaHelper.calculMaitriseEnergie(this.energie, from.Energie) > 0 &&
                SortNubiaHelper.calculMaitriseDomaine(this.Domaine, from.Domaine) > 0)
                return true;


			return false;
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public virtual SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[2] 
				{
					SortEnergie.Air,
					SortEnergie.Mental
				};
			}
		}
		[CommandProperty( AccessLevel.GameMaster )]	
		public SortNubia SortNubiaPere 
		{
			get
			{
				return m_SortNubia;
			}
			set
			{
				m_Object = null;
				m_condition = MagieCondition.SortNubia;
				m_Mobile = null;
				m_SortNubia = value;
			}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public Item ObjectToEquip 
		{
			get
			{
				return m_Object;
			}
			set
			{
				m_Object = value;
				m_condition = MagieCondition.ObjetEquiper;
				m_Mobile = null;
				m_SortNubia = null;
			}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public MagieRender render
		{
			get	{return m_render;}
			set	{m_render = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public SortNubiaEffect effect
		{
			get	{return m_effect;}
			set	{m_effect = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public MagieColor couleur
		{
			get	{return m_couleur;}
			set	{m_couleur = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public MagieCondition condition
		{
			get	{return m_condition;}
			set	{m_condition = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public MagieDisturb disturb
		{
			get{ return m_disturb; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public MagieState state
		{
			get{ return m_state; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Createur
		{
			get{ return m_createur; }
			set{ m_createur = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Emote
		{
			get{ return m_emote; }
			set{ m_emote = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public int distance
		{
			get{ return m_distance; }
			set{ m_distance = value;  }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public SortEnergie energie
		{
			get{ return m_energie; }
            set { m_energie = value; }
		}
	
		[CommandProperty( AccessLevel.GameMaster )]
		public double Delay
		{
			get{ return m_time; }
			set{ m_time = value; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public double TimeToCast
		{
			get{ return m_timeToCast; }
			set{ m_timeToCast = value; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public string Nom
		{
			get{ return m_name; }
			set{ m_name = value; Name = value;}
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public NubiaPlayer Owner
		{
			get{ return m_owner; }
			set{ m_owner = value; }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public double Maitrise
		{
			get{ return m_maitrise; }
			set{ m_maitrise = value;  }
		}
		//[Constructable]
		public SortNubia(string _name) : base ( 0x14F0 )
		{
			Nom = _name;
			m_state = MagieState.None;
			Hue = 2117;
			energie = allowCompetence[0];
		}
		//[Constructable]
		public SortNubia( Serial serial ) : base (serial)
		{
			
		}

		public bool isDisturb()
		{
			if(disturb != MagieDisturb.None)
			{
				Owner.PrivateOverheadMessage(MessageType.System, 1645,true, SortNubiaHelper.GetDisturbMessage(disturb), Owner.NetState);
				m_state = MagieState.None;
				m_disturb = MagieDisturb.None;
				return true;
			}
			return false;
		}

		public bool timeStateOk()
		{
			if( DateTime.Now < (LastUse) + TimeSpan.FromSeconds( m_time ) || m_state != MagieState.None)
			{
				return false;
			}
			
			return true;
		}
		public bool InCast()
		{
			//Console.WriteLine("State avant InCast: "+state);
            bool ok = (state == MagieState.InCast);
			//Console.WriteLine("State après InCast: "+state);
			return ok;
		}
		public bool isFinish()
		{
			//Console.WriteLine("State avant IsFinish: "+state);
            bool ok = (state == MagieState.None);
			//Console.WriteLine("State après IsFinish: "+state);
			return ok;
		}
		public bool checkForOtherCast()
		{
            //TODO
			/*for(int i = 0; i < m_owner.SortNubiaList.Length; i++)
			{
				if( ( m_owner.SortNubiaList[i].InCast() ) && (m_owner.SortNubiaList[i] != this) )
				{
					//Console.WriteLine("Technique déjà en execution: "+m_owner.SortNubiaList[i].Nom+ "   "+m_owner.SortNubiaList[i].state);
					return false;
				}
			}*/
			return true;
		}

		public double getRatio()
		{
			double ratio = 1.0;
			if(condition != MagieCondition.None)
				ratio = 1.10;
			if(SortNubiaPere != null)
			{
				if(SortNubiaPere.SortNubiaPere != null)
					ratio = 1.50;
				else
					ratio = 1.15;
				if(SortNubiaPere is SortNubiaTransformation)
					ratio += 0.50;
			}
			return ratio;
		}

		public virtual void StartCast()
		{
			if(Owner == null)
			{
				Console.WriteLine("WARNING: Aucun owner pour le SortNubia "+Nom);
				return;
			}
            NubiaPlayer from = Owner as NubiaPlayer;
			//Console.WriteLine("Debut de SortNubia: "+Nom);
		//	Console.WriteLine("State: "+sta
			
			if( !isFinish() )
			{
				from.PrivateOverheadMessage( MessageType.System, 0,true, "Vous mettez fin au effet du sort", from.NetState);
				EndSortNubia();
				return;
			}
			if( from.isTransfo && (!(this is SortNubiaTao) && !(from.BodyValue == 400 || from.BodyValue == 401)) )
			{
				if(!(condition == MagieCondition.SortNubia && SortNubiaPere == from.GetTransfo()))
				{
					from.PrivateOverheadMessage( MessageType.System, 0,true, "Vous êtes transformé", from.NetState);
					return;
				}
			}
			if( !timeStateOk() && !InCast() && !( from.AccessLevel >= AccessLevel.GameMaster ))
			{
				from.PrivateOverheadMessage( MessageType.System, 0,true, "Vous ne pouvez pas encore utilser cette technique", from.NetState);
				//EndSortNubia();
				return;
			}
			if( !checkForOtherCast() && !( from.AccessLevel >= AccessLevel.GameMaster ) )
			{
				from.PrivateOverheadMessage( MessageType.System, 0,true, "Vous être en train d'executez un SortNubia", from.NetState);
				//EndSortNubia();
				return;
			}
			if(!canCast(Owner) && !( from.AccessLevel >= AccessLevel.GameMaster ))
				return;

			//Private/public Regular/Spell
			//from.PublicOverheadMessage(  MessageType.Emote, 0,true, "*Forme une série de signes*");
			if(isGestuel)
			{
				from.Emote("*Forme une série de signes*");
				from.FixedParticles( 0x376A, 1, (int)m_timeToCast*13, 0x251D, from.ChakraColor, 0, EffectLayer.Waist );
			}
			else
				from.SendMessage("Vous préparez une technique sans gestuel");
					
			m_disturb = MagieDisturb.None;
			m_state = MagieState.InCast;
			InternalTimer timer = new InternalTimer(true, this,(m_timeToCast/2.0));
			timer.Start();
			
		}
		public override void OnDoubleClick( Mobile f )
		{
			if( f is NubiaPlayer )
			{
				SortNubia cop = (SortNubia)NubiaHelper.CopyItem(this);
				((NubiaPlayer)f).Magie.addSort(cop);
				f.SendMessage("Sort {0} assimilé", Name );
				Delete();
			}
		}
		public virtual bool canCast(NubiaPlayer from)
		{
			return canCast(from, true);
		}

        public virtual bool canCast(NubiaPlayer from, bool checkCondition)
		{
			//Console.WriteLine("CanCast de SortNubia: "+Nom);
			if(Owner == null)
				return false;

			if( !CheckCondition() && checkCondition )
			{
				Owner.PrivateOverheadMessage( MessageType.Emote, 2117,true,  "Toute les conditions ne sont pas rempli pour ce sort", Owner.NetState);
				return false;
			}
            //TODO: Compétences de magie
			if( /*from.getValueFor( categorie ) < miniCategorie
			 || from.getValueFor( competence ) < miniCompetence
			 || from.Skills[skill].Base < miniSkill
			 ||*/ from.ManaMax < chakra )
			{
				Owner.PrivateOverheadMessage( MessageType.System, 0,true,  "Il vous manque de la puissance ou des connaissances pour ce sort", Owner.NetState);
				return false;
			}
			
			if( from.Mana < chakra )
			{
				Owner.PrivateOverheadMessage( MessageType.System, 0,true,  "Vous manquez de Chakra", Owner.NetState);
				m_disturb = MagieDisturb.Mana;
				return false;
			}

			return true;

		}
		public virtual void EndSortNubia() //Pour les timers général sur le timer Turn du Konoha Player
		{
			//Console.WriteLine("End de SortNubia: "+Nom);
			m_state = MagieState.None;
			m_disturb = MagieDisturb.None;
			
			if(Owner == null)
				return;
			//Fin des fils
			for(int i = 0; i < Owner.Magie.Sorts.Count; i++)
			{
				if( Owner.Magie.Sorts[i] is SortNubia )
				{
                    SortNubia jut = Owner.Magie.Sorts[i] as SortNubia;
					if(jut.SortNubiaPere == this)
						jut.EndSortNubia();
				}
			}
		}
		public virtual bool Cast()
		{
			//Console.WriteLine("Cast de SortNubia: "+Nom);
			LastUse = DateTime.Now;

			if( m_owner == null)
				return false;

			if( m_owner.Mana < chakra && !( m_owner.AccessLevel >= AccessLevel.GameMaster ))
				m_disturb = MagieDisturb.Mana;

			if(!( m_owner.AccessLevel >= AccessLevel.GameMaster ))
				m_owner.Mana -= chakra;

			if(isDisturb())
				return false;

			m_state = MagieState.WaitEnd;
			
			if(mustCrier)
			{
				m_owner.PublicOverheadMessage(  MessageType.Regular, 0,true, Nom+"!");
				//m_owner.Say(Nom+"!");
			}
			else
				m_owner.SendMessage("Vous executez votre sort: "+Nom);


			if( m_owner.AccessLevel >= AccessLevel.GameMaster )
				Maitrise = 120.0;
			
			if(Maitrise >= 120.0)
					return true;
			
			double tempo = Maitrise;
			
			if( Utility.RandomMinMax( 0,(int)Maitrise ) < 50 )
			{
				if(Maitrise > 80)
					m_maitrise += (double)((double)Utility.RandomMinMax(10,5)/10.0);
				else if(Maitrise > 70)
					m_maitrise += (double)((double)Utility.RandomMinMax(20,10)/10.0);
				else if(Maitrise > 60)
					m_maitrise += (double)((double)Utility.RandomMinMax(40,20)/10.0);
				else if(Maitrise > 50)
					m_maitrise += (double)((double)Utility.RandomMinMax(70,100)/10.0);
				else
					m_maitrise += (double)((double)Utility.RandomMinMax(100,150)/10.0);
			}

			if(tempo < Maitrise)
				Owner.SendMessage("Maitrise de "+m_name+": "+m_maitrise+" %");
			return true;
		}

		public bool CheckCondition()
		{
			//Console.WriteLine("Check condition");
			if( m_condition == MagieCondition.None )
				return true;
			if ( Owner == null )
				return false;
			else if( m_condition == MagieCondition.MainNue )
			{
				Item handOne = Owner.FindItemOnLayer( Layer.OneHanded );
				Item handTwo = Owner.FindItemOnLayer( Layer.TwoHanded );
				//Console.WriteLine("Main nue");
				if ( handTwo is BaseWeapon )
					handOne = handTwo;

				if( handOne == null && handTwo == null )
					return true;
				else
					return false;
			}
			else if( m_condition == MagieCondition.ObjetEquiper )
			{
				if(m_Object == null)
				{
					Owner.PrivateOverheadMessage( MessageType.System, 0,true, "[ERREUR] Cette technique requiere un objet, mais il est Inconnu", Owner.NetState);
					return false;
				}
				
				Item itemEquiped = Owner.FindItemOnLayer( m_Object.Layer );
				
				bool ok = ( itemEquiped.ItemID == m_Object.ItemID );
				if(mustConsume)
					itemEquiped.Delete();

				return ok;
			}
			else if( m_condition == MagieCondition.ObjetAlentour )
			{
				if(m_Object == null)
				{
					Owner.PrivateOverheadMessage( MessageType.System, 0,true, "[ERREUR] Cette technique requiere un objet, mais il est Inconnu", Owner.NetState);
					return false;
				}
				
				Map map = Owner.Map;

				if ( map == null )
					return false;

				bool ok = false;
				IPooledEnumerable eable = map.GetItemsInRange( Owner.Location, 10 );

				foreach ( Item item in eable )
				{
					Type type = item.GetType();
					if( type == m_Object.GetType() )
						ok = true;
				}

				eable.Free();
				return ok;
			}
			else if( m_condition == MagieCondition.MobileAlentour )
			{
				if(m_Mobile == null)
				{
					Owner.PrivateOverheadMessage( MessageType.System, 0,true, "[ERREUR] Cette technique requiere un mobile, mais il est Inconnu", Owner.NetState);
					return false;
				}
				
				Map map = Owner.Map;

				if ( map == null )
					return false;

				bool ok = false;
				IPooledEnumerable eable = map.GetMobilesInRange( Owner.Location, 10 );

				foreach ( Mobile mob in eable )
				{
					Type type = mob.GetType();
					if( type == m_Mobile.GetType() )
						ok = true;
				}

				eable.Free();
				return ok;
			}
			else if( m_condition == MagieCondition.SortNubia )
			{
				if(m_SortNubia == null)
				{
					Owner.PrivateOverheadMessage( MessageType.System, 0,true, "[ERREUR] Cette technique requiere un SortNubia, mais il est Inconnu", Owner.NetState);
					return false;
				}
				bool ok = false;
				for(int i = 0; i < Owner.Magie.sortList.Length; i++)
				{
                    SortNubia jut = Owner.Magie.sortList[i];
					if( (jut == m_SortNubia && jut.state == MagieState.WaitEnd) || (jut is SortNubiaTransformation && m_SortNubia is SortNubiaTransformation) )
					{
						ok = true;
					}
				}
				return ok;
			}
			return false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version
			writer.Write( (Mobile) m_owner );
			writer.Write( (string) m_createur );
			writer.Write( (string)  m_name);
			writer.Write( (double)  m_time);
			writer.Write( (double)  m_timeToCast);

			writer.Write( (double)  m_maitrise);
			writer.Write( (int)  m_distance);
			writer.Write( (int)  m_energie);
			//writer.Write( (int)  m_skill);
			writer.Write( (string)  m_emote);

			writer.Write( (int)  m_couleur);
			writer.Write( (int)  m_state);
			writer.Write( (int)  m_disturb);

			writer.Write( (int)  m_condition);
			writer.Write( (Item)  m_Object);
			writer.Write( (Mobile)  m_Mobile);
			writer.Write( (Item)  m_SortNubia);
			
			//Console.WriteLine("Serialize SortNubia: " +Nom);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			m_owner = (NubiaPlayer)reader.ReadMobile();
			m_createur = reader.ReadString();
			m_name = reader.ReadString();
			m_time = reader.ReadDouble();
			m_timeToCast = reader.ReadDouble();

			m_maitrise = reader.ReadDouble();
			m_distance = reader.ReadInt();
			m_energie = (SortEnergie)reader.ReadInt();
		//	m_skill = (SkillName)reader.ReadInt();
			m_emote = reader.ReadString();

			m_couleur = (MagieColor)reader.ReadInt();
			m_state = (MagieState)reader.ReadInt();
			m_disturb = (MagieDisturb)reader.ReadInt();

			m_condition = (MagieCondition)reader.ReadInt();
			m_Object = (Item)reader.ReadItem();
			m_Mobile = (Mobile)reader.ReadMobile();
			m_SortNubia = (SortNubia)reader.ReadItem();

			if(m_owner != null)
				m_owner.Magie.addSort(this);

			//Console.WriteLine("Deserialize SortNubia: " +Nom);
				
		}
		
	}

}