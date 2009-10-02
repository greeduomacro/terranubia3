using System;
using Server;
using Server.Mobiles;
using Server.Nubia;

namespace Server.Items
{
	public abstract class BasePlante : Item
	{
		//Variables
		private EnumPlante m_Plante = EnumPlante.Ble;
		private EnumPlanteState m_State = EnumPlanteState.Graine;
		private EnumPlanteTare m_Tare = EnumPlanteTare.Aucune;
		private int m_rollResult = 0;
		private int m_turn = 20; //Tour en heure... de 18 a 24;
		//Constantes
		public virtual EnumPlanteTerrain Terrain { get{return EnumPlanteTerrain.Ferme; }}
		public virtual bool CanEat { get{return false; }} //Savoir si on peu directement manger la récolte
		public virtual int DD { get{return 10; }} //On divise par deux et on ajoute a 40 pour la difficulté. Donc 100 maxi
		
		//getter setter
		[CommandProperty( AccessLevel.GameMaster )]
		public EnumPlante Plante { get{ return m_Plante; } set{ m_Plante = value;} }
		[CommandProperty( AccessLevel.GameMaster )]
		public EnumPlanteState State { get{ return m_State; }set{ m_State = value;} }
		[CommandProperty( AccessLevel.GameMaster )]
		public EnumPlanteTare Tare { get{ return m_Tare; }set{ m_Tare = value;} }
		[CommandProperty( AccessLevel.GameMaster )]
		public int PRollResult { get{ return m_rollResult; }set{ m_rollResult = value;} }

		public void InitialTurn()
		{
			m_turn = Utility.RandomMinMax( 18,24);
		}

		public void HourTurn()
		{
			m_turn--;
			if( m_turn < 0 )
				OnPlanteTurn();
		}

		public BasePlante(EnumPlante _type) : base( 0xF27 )
		{
			Stackable = true;
			m_Plante = _type;
			InitialTurn();
			Name = AgriHelper.GetPlanteString( m_Plante );
			UpdateLook();
		}

		public void OnPlanteTurn()
		{
			int s = (int)m_State;
			s++;
			m_State = (EnumPlanteState)s;
			InitialTurn();

			if( m_State == EnumPlanteState.Morte )
				Delete();

			UpdateLook();
		}

		public void UpdateLook()
		{
			ItemID = AgriHelper.GetPlanteID( m_Plante, m_State );
			if( m_State == EnumPlanteState.GrainePlante )
				Visible = false;
			else
				Visible = true;
			if( m_State == EnumPlanteState.Pourri )
				Hue = 1445;
		}

		public override void OnSingleClick( Mobile from )
		{
			if( Amount <= 1 )
				LabelTo(from, Name+", "+AgriHelper.GetStateString(m_State) );
			else
				LabelTo(from, Name+", "+Amount+" "+AgriHelper.GetStateString(m_State)+"s" );
			if( ((NubiaMobile)from).Competences[CompType.Agriculture].getPureMaitrise() > 5 )
				from.SendMessage("Il reste environ {0} heure(s) avant la prochaine phase", m_turn );
		}

		public override void OnDoubleClick( Mobile f )
		{
			NubiaPlayer from = f as NubiaPlayer;
			if( !from.InRange( this.GetWorldLocation(), 1 ) ){
				from.SendMessage("C'est trop loin");
				return;
			}

			if( m_State == EnumPlanteState.Graine )
				CheckPlantation( from );
			else if( m_State == EnumPlanteState.GrainePlante )
			{
				from.Emote("*Ecrase la graine*");
				this.Delete();
			}
			else if( m_State == EnumPlanteState.Naissante )
			{
				from.Emote("*Saccage la plante*");
				this.Delete();
			}
			else if( m_State == EnumPlanteState.Jeune )
			{


                int rollGraine = from.Competences[CompType.Agriculture].pureRoll();
				if( rollGraine <= DD )
				{
					from.Emote("*Saccage la plante*");
					this.Delete();
				}
				else
				{
					from.Emote("*Cueille et récupère les graines*");
					Type type = this.GetType();
					BasePlante plante = (BasePlante)Activator.CreateInstance( type );
					int amount = (int)rollGraine / 5;
                    if (amount < 1)
                        amount = 1;
					from.SendMessage("Vous récupérez {0} graines", amount );
					plante.Amount = amount;
					plante.Hue = Hue;
					if( from.Backpack != null )
						from.Backpack.DropItem( plante );
				}
			}
			else if( m_State == EnumPlanteState.Mature )
			{
                int rollRecolte = from.Competences[CompType.Agriculture].pureRoll();
				if( rollRecolte <= DD )
				{
					from.Emote("*Saccage la plante*");
					this.Delete();
				}
				else
				{
					from.Emote("*Récolte*");
					Item item = AgriHelper.GetRecolteItem( m_Plante );
					if( item == null )
					{
						NubiaRecolte plante = new NubiaRecolte( m_Plante, rollRecolte, CanEat );
						plante.Hue = Hue;
						if( from.Backpack != null )
							from.Backpack.DropItem( plante );
					}
					else{
						if( item.Stackable && (int)m_rollResult > 1 )
							item.Amount = (int)m_rollResult;
						if( from.Backpack != null )
							from.Backpack.DropItem( item );
					}
					this.Delete();
				}
			}
			else if( m_State == EnumPlanteState.Pourri )
			{
				from.Emote("*Déffriche*");
				this.Delete();
			}
		}
		public void CheckPlantation( NubiaPlayer from )
		{
            NubiaCompetence comp = from.Competences[CompType.Agriculture];

			if( comp.getPureMaitrise() <= DD/4 )
			{
				from.SendMessage("Cette plante nessecite minimum {0} de connaissance en agriculture", DD);
				return;
			}
			int diff = 40+(DD/2);
			if( diff > 90 )
				diff = 90;

            int roll = comp.pureRoll();

			bool terrainOk = false;
			if( Terrain == EnumPlanteTerrain.Ferme )
			{
				if( ValidateFarmLand( from.Map, from.X, from.Y ) )
				{
					terrainOk = true;
				}
				else
					from.SendMessage("Vous devez planter cette graine dans une ferme");
			}
			else if( Terrain == EnumPlanteTerrain.Marais ) 
			{
				if( ValidateSpawnLand( from.Map, from.X, from.Y ))
				{
					terrainOk = true;
				}
				else
					from.SendMessage("Vous devez planter cette graine dans un marais");
			}
			else if( Terrain == EnumPlanteTerrain.Sable )
			{
				if( ValidateSandLand( from.Map, from.X, from.Y ))
				{
					terrainOk = true;
				}
				else
					from.SendMessage("Vous devez planter cette graine dans un désert");
			}
			else if( Terrain == EnumPlanteTerrain.Cadavre )
			{
				if( ValidateCorpseLand( from.Map, from.X, from.Y ))
				{
					terrainOk = true;
				}
				else
					from.SendMessage("Vous devez planter cette graine dans un cadavre");
			}

			if( terrainOk )
				PlanteGraine( roll, from );
		}
		public void PlanteGraine( int roll, NubiaPlayer from)
		{
			bool can = true;
			foreach( Item item in from.GetItemsInRange(0) )
			{
				if( item is BasePlante )
					can = false;
			}
			if( !can )
			{
				from.SendMessage("les racines d'une plante autre plante sont déjà plantées à proximité !");
				return;
			}
			else
			{
				if( Amount <= 1 )
				{
					MoveToWorld( from.Location, from.Map );
					Movable = false;
					m_State = EnumPlanteState.GrainePlante;
					m_rollResult = roll;
					Visible = false;
					new InternalTimer( this ).Start();
				}
				else
				{
					Amount--;
					Type type = this.GetType();
					BasePlante plante = (BasePlante)Activator.CreateInstance( type );
					plante.Amount = 1;
					plante.MoveToWorld( from.Location, from.Map );
					plante.Movable = false;
					plante.State = EnumPlanteState.GrainePlante;
					plante.PRollResult = roll;
					plante.Visible = false;
					plante.StartTimer();
					
					
				}
				UpdateLook();
				from.Emote("*Plante*");
			}
		}
		public void StartTimer()
		{
			new InternalTimer( this ).Start();
		}

		public static int[] FarmTiles = new int[]
		{
			0x32C9, 0x32CA, 0x31F4, 0x31F5,
			0x31F6, 0x31F7, 0x31F8, 0x31F9,
			0x31FA, 0x31FB, 9
			
		};

		public static int[] SwampTiles = new int[]
		{
			//0x7DC, 0x808, 
			0x3DC1, 0x3DC2, 
			0x3DD9, 0x3EF0,
			0x3DEA, 0x3DEB, 0x3DEC, 0x3DE9
		};

		public static int[] SandTiles = new int[]
		{
			0x016, 0x019, 
			0x033, 0x03E, 
			0x1A8, 0x1AB, 
			0x282, 0x291, 
			0x335, 0x35C, 
			0x3B7, 0x3CA, 
			0x5A7, 0x5BA, 
			0x64B, 0x66A, 
			0x66F, 0x672, 
			0x7D5, 0x7D8, 
		};

		public static bool ValidateFarmLand( Map map, int x, int y )
		{
			bool ground = false;
			
			// Test for Dynamic Item
			IPooledEnumerable eable = map.GetItemsInBounds( new Rectangle2D( x, y, 1, 1 ) );
			foreach( Item item in eable )
			{
				for ( int di = 0; di < FarmTiles.Length; ++di )
				{
					if ( item.ItemID == FarmTiles[di] )
						ground = true;
				}
				if(ground)
					break;
			}
			eable.Free();

			// Test for Frozen into Map
			if ( !ground )
			{
				Tile[] tiles = map.Tiles.GetStaticTiles( x, y );
				for ( int i = 0; i < tiles.Length; ++i )
				{
					for ( int di2 = 0; di2 < FarmTiles.Length; ++di2 )
					{
						if ( tiles[i].ID == FarmTiles[di2] )
							ground = true;
					}
					if(ground)
						break;
				}
			}

			if( !ground )
			{
				int tileID = map.Tiles.GetLandTile( x, y ).ID & 0x3FFF;
				
				for ( int il = 0; !ground && il < FarmTiles.Length; il += 2 )
					ground = ( tileID == FarmTiles[il] );
			}

			return ground;
		}

		public static bool ValidateSpawnLand( Map map, int x, int y )
		{
			bool ground = false;
			
			// Test for Dynamic Item
			IPooledEnumerable eable = map.GetItemsInBounds( new Rectangle2D( x, y, 1, 1 ) );
			foreach( Item item in eable )
			{
				for ( int di = 0; di < SwampTiles.Length; ++di )
				{
					if ( item.ItemID == SwampTiles[di] )
						ground = true;
				}
				if(ground)
					break;
			}
			eable.Free();

			// Test for Frozen into Map
			if ( !ground )
			{
				Tile[] tiles = map.Tiles.GetStaticTiles( x, y );
				for ( int i = 0; i < tiles.Length; ++i )
				{
					for ( int di2 = 0; di2 < SwampTiles.Length; ++di2 )
					{
						if ( tiles[i].ID == SwampTiles[di2] )
							ground = true;
					}
					if(ground)
						break;
				}
			}
			if( !ground )
			{
				int tileID = map.Tiles.GetLandTile( x, y ).ID & 0x3FFF;
				
				for ( int il = 0; !ground && il < SwampTiles.Length; il += 2 )
					ground = ( tileID >= SwampTiles[il]/* && tileID <= SwampTiles[il + 1] */);
			}

			return ground;
		}

		public static bool ValidateSandLand( Map map, int x, int y )
		{
			bool ground = false;
			
			// Test for Dynamic Item
			IPooledEnumerable eable = map.GetItemsInBounds( new Rectangle2D( x, y, 1, 1 ) );
			foreach( Item item in eable )
			{
				for ( int di = 0; di < SandTiles.Length; ++di )
				{
					if ( item.ItemID == SandTiles[di] )
						ground = true;
				}
				if(ground)
					break;
			}
			eable.Free();

			// Test for Frozen into Map
			if ( !ground )
			{
				Tile[] tiles = map.Tiles.GetStaticTiles( x, y );
				for ( int i = 0; i < tiles.Length; ++i )
				{
					for ( int di2 = 0; di2 < SandTiles.Length; ++di2 )
					{
						if ( tiles[i].ID == SandTiles[di2] )
							ground = true;
					}
					if(ground)
						break;
				}
			}

			return ground;
		}
		public static bool ValidateCorpseLand( Map map, int x, int y )
		{
			bool ground = false;
			
			// Test for Dynamic Item
			IPooledEnumerable eable = map.GetItemsInBounds( new Rectangle2D( x, y, 1, 1 ) );
			Item todelete = null;
			
			foreach( Item item in eable )
			{
				if ( item is Corpse )
				{
					CorpsCultivable newcorps = new CorpsCultivable(  item.Amount );
					newcorps.MoveToWorld( item.Location, item.Map );
					todelete = item;
					ground = true;
				}
				if(ground)
					break;
			}
			eable.Free();
			if( todelete != null )
				todelete.Delete();
			return ground;
		}

		
		public BasePlante( Serial serial ) : base( serial )
		{
			if( m_State >= EnumPlanteState.GrainePlante )
			new InternalTimer( this ).Start();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			/*private EnumPlante m_Plante = EnumPlante.Ble;
		private EnumPlanteState m_State = EnumPlanteState.Graine;
		private EnumPlanteTare m_Tare = EnumPlanteTare.Aucune;
		private RollResult m_rollResult = RollResult.Reussite;*/
		
			writer.Write( (int)m_Plante );
			writer.Write( (int)m_State );
			writer.Write( (int)m_Tare );
			writer.Write( (int)m_rollResult );
			writer.Write( (int) m_turn );
		
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Plante = (EnumPlante)reader.ReadInt();
			m_State = (EnumPlanteState)reader.ReadInt();
			m_Tare = (EnumPlanteTare)reader.ReadInt();
			m_rollResult = reader.ReadInt();
			m_turn = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private BasePlante m_BasePlante;

			public InternalTimer( BasePlante plante ) : base( TimeSpan.FromHours( 1 ) )
			{
				Priority = TimerPriority.OneMinute;
				
				m_BasePlante = plante;
			}

			protected override void OnTick()
			{
				if(m_BasePlante != null){
					m_BasePlante.HourTurn();
					new InternalTimer(m_BasePlante).Start();
				}
			}
		}
	}
}
