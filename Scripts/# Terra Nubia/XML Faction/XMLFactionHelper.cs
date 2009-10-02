using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Nubia;


//## Nexam - 05/10/2007
//Objet stocké dans l'ArrayList de XMLFaction

namespace Server.XmlFactions
{
	public class XMLFactionHelper
	{
		public static int ValForLevel( XMLReputationEnum r )
		{
			int rep = (int)r;
			return rep*rep*1000;
		}
	}
}