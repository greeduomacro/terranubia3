using System;
using Server;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;
using Server.Nubia;
using System.Xml;


//## Nexam - 05/10/2007

namespace Server.XmlFactions
{
	public interface iXMLFaction
	{
		string Name{ get; set; }
		Mobile Owner{ get; set; }
		bool PlayerFaction{ get; set; }
		
		List<XMLReputation> Reputations{ get; set; }
		ArrayList Members{get;set;}

		void Save( XmlTextWriter xml );
		
	}
}