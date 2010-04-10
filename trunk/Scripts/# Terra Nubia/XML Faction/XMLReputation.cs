using System;
using Server;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;
using Server.Nubia;


//## Nexam - 05/10/2007
//Objet stocké dans la List de XMLFaction

namespace Server.XmlFactions
{
	public class XMLReputation
	{
		//Variable
		private object m_Object = null;
		private int m_Value = 0;

		//Methode Get/Set
		public object Obj{get{return m_Object;}set{m_Object = value;}}
		
		public XMLReputation( object _Object, int _Value )
		{
			m_Object = _Object;
			m_Value = _Value;
		}

		public XMLReputationEnum Reputation
		{
			get
			{
				XMLReputationEnum reput = XMLReputationEnum.AllieAncestral;
				for( int i = 0; i < (int)XMLReputationEnum.Maximum; i++ )
				{
					if( m_Value < XMLFactionHelper.ValForLevel((XMLReputationEnum)i) )
						reput = (XMLReputationEnum)i;
				}
				return reput;
			}
		}
	}
}