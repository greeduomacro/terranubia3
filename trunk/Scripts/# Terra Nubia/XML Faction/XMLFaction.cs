using System;
using Server;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;
using Server.Nubia;
using System.Xml;
using Server.Commands;

//## Nexam - 05/10/2007

namespace Server.XmlFactions
{
	public class XMLFaction : iXMLFaction, IComparable, IComparable<XMLFaction>
	{
		//Variable
		private string m_Name = "Faction de base";
		private Mobile m_Owner = null;
		private bool m_PlayerFaction = false;
		private List<XMLReputation> m_Reputations = new List<XMLReputation>(); //Stock des Réputations envers Mobile ou Faction
		private ArrayList m_Members = new ArrayList();
		private DateTime m_CreationDate = DateTime.Now;
		private AccessLevel m_Access = AccessLevel.Player;

		//Methodes Get/Set
		[CommandProperty( AccessLevel.GameMaster )]
		public string Name{get{return m_Name;}set{m_Name = value;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Owner{get{return m_Owner;}set{m_Owner = value;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public bool PlayerFaction{get{return m_PlayerFaction;}set{m_PlayerFaction = value;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public List<XMLReputation> Reputations{get{return m_Reputations;}set{m_Reputations = value;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public ArrayList Members{get{return m_Members;}set{m_Members = value;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime CreationDate{get{return m_CreationDate;}}
		[CommandProperty( AccessLevel.GameMaster )]
		public AccessLevel Access{get{return m_Access;}}

		public int Count
		{
			get
			{
				return m_Members.Count;
			}
		}
		public void RemoveMember( object o )
		{
			m_Members.Remove( o );
			if( o is PlayerMobile )
				FactionMessage( ((PlayerMobile)o).Name + " ne fait plus partie de votre faction." );

		}

		public void AddMember( object o )
		{
			m_Members.Add( o );
			if( o is PlayerMobile )
				FactionMessage( ((PlayerMobile)o).Name + " rejoint votre faction." );

		}

		public void FactionMessage( string msg  )
		{
			foreach( object o in m_Members )
				if( o is PlayerMobile )
					((PlayerMobile)o).SendMessage(msg);
		}

		public void Delete()
		{
			if( Owner != null )
				Owner.SendMessage("Votre faction {0} viens d'être effacée");
			CommandHandlers.BroadcastMessage( AccessLevel.GameMaster, 1333, String.Format( "(GM)La faction de '{0}' nommée '{1}' à été effacée", ( Owner == null ? "Personne" : Owner.Name ), Name) );
			XMLFactions.Remove( m_Name );
		}

			
		public XMLFaction(string _Name, Mobile _owner)
		{
			m_Name = _Name;
			m_Owner = _owner;
			

			if( m_Owner != null )
			{
				m_Access = m_Owner.AccessLevel;
				m_PlayerFaction = ( m_Owner.AccessLevel <= AccessLevel.Player );
			}

			bool CanCreate = true;
			foreach ( XMLFaction f in XMLFactions.GetFactions() )
			{
				if( CompareTo( f ) == 0 )
					CanCreate = false;
			}
			if( !CanCreate )
			{
				if( m_Owner != null )
					m_Owner.SendMessage(133, "Impossible de créer votre faction: Le nom est déjà pris");
				return; //N'étant pas ajouté a XMLFactions.m_Factions, l'objet ne sera pas save et sera Delete comme un Grand.
				// Ne surtout pas utiliser Delete ici, on effacerai la faction existante du même nom ^^
			}
			
			CommandHandlers.BroadcastMessage( AccessLevel.Player, 133, String.Format( "La faction {0} viens de voir le jour", Name) );
			CommandHandlers.BroadcastMessage( AccessLevel.GameMaster, 0, String.Format( "(GM)Faction crée par: {0}", ( Owner == null ? "Personne" : Owner.Name )) );

			XMLFactions.Add( this );
		}

		public int CompareTo( XMLFaction other )
		{
			if ( other == null )
				return -1;

			return m_Name.CompareTo( other.Name );
		}

		public int CompareTo( object obj )
		{
			if ( obj is XMLFaction )
				return this.CompareTo( (XMLFaction) obj );

			throw new ArgumentException();
		}

		public XMLFaction( XmlElement node )
		{
		}
		
		public void Save( XmlTextWriter xml )
		{
		}
	}
}