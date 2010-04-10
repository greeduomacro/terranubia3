using System;
using Server;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;
using Server.Nubia;
using System.IO;
using System.Xml;

//## Nexam - 05/10/2007
//Class Générale qui gère toutes les factions et tout ça :)

namespace Server.XmlFactions
{
	public class XMLFactions
	{
		
		private static Dictionary<string, iXMLFaction> m_Factions = new Dictionary<string, iXMLFaction>();


		/// <summary>
		/// Methode pour obtenir la faction d'appartenance d'un Objet
		/// </summary>
		public static XMLFaction GetFaction(Object o)
		{
			XMLFaction faction = null;
			foreach( XMLFaction f in GetFactions() )
			{
				foreach( object ob in f.Members )
				{
					if( ob == o )
						faction = f;
				}
			}
			return faction;
		}

		public static void Add( iXMLFaction a )
		{
			m_Factions[a.Name] = a;
		}
		
		public static void Remove( string name )
		{
			m_Factions.Remove( name );
		}


		public static void ChangeFaction( Object o, string name )
		{
			XMLFaction faction = null;
			foreach ( XMLFaction f in GetFactions() )
			{
				if( f.Name.ToLower() == name.ToLower() )
					faction = f;
			}
			if( faction != null )
				ChangeFaction( o, faction );
		}

		public static void ChangeFaction( Object o, XMLFaction faction )
		{
			//On le vire de sa faction si il en a une
			if( o == null || faction == null )
				return;
			XMLFaction fac = GetFaction(o);
			if( fac != null )
				fac.RemoveMember( o );

			faction.AddMember( o );
		}

		public static ICollection<iXMLFaction> GetFactions()
		{
			return m_Factions.Values;
		}

		public static void Configure()
		{
			EventSink.WorldLoad += new WorldLoadEventHandler( Load );
			EventSink.WorldSave += new WorldSaveEventHandler( Save );
		}

		static XMLFactions()
		{
		}

		public static void Load()
		{
			m_Factions = new Dictionary<string, iXMLFaction>( 32, StringComparer.OrdinalIgnoreCase );

			string filePath = Path.Combine( "Saves/XMLFactions", "factions.xml" );

			if ( !File.Exists( filePath ) )
				return;

			XmlDocument doc = new XmlDocument();
			doc.Load( filePath );

			XmlElement root = doc["factions"];

			foreach ( XmlElement factionNode in root.GetElementsByTagName( "faction" ) )
			{
				try
				{
					XMLFaction acct = new XMLFaction( factionNode );
				}
				catch
				{
					Console.WriteLine( "Warning: Faction instance load failed" );
				}
			}
		}

		public static void Save( WorldSaveEventArgs e )
		{
			if ( !Directory.Exists( "Saves/XMLFactions" ) )
				Directory.CreateDirectory( "Saves/XMLFactions" );

			string filePath = Path.Combine( "Saves/XMLFactions", "factions.xml" );

			using ( StreamWriter op = new StreamWriter( filePath ) )
			{
				XmlTextWriter xml = new XmlTextWriter( op );

				xml.Formatting = Formatting.Indented;
				xml.IndentChar = '\t';
				xml.Indentation = 1;

				xml.WriteStartDocument( true );

				xml.WriteStartElement( "factions" );

				xml.WriteAttributeString( "count", m_Factions.Count.ToString() );

				foreach ( XMLFaction f in GetFactions() )
					f.Save( xml );

				xml.WriteEndElement();

				xml.Close();
			}
		}
	}
}