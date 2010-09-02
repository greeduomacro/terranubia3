using System;

namespace Server.Engines.Harvest
{
	public class HarvestResource
	{
		private Type[] m_Types;
		private int m_DD;
		private object m_SuccessMessage;

		public Type[] Types{ get{ return m_Types; } set{ m_Types = value; } }
        public int DD { get { return m_DD; } set { m_DD = value; } }
		public object SuccessMessage{ get{ return m_SuccessMessage; } }

		public void SendSuccessTo( Mobile m )
		{
			if ( m_SuccessMessage is int )
				m.SendLocalizedMessage( (int)m_SuccessMessage );
			else if ( m_SuccessMessage is string )
				m.SendMessage( (string)m_SuccessMessage );
		}

		public HarvestResource( int dd,object message, params Type[] types )
		{
            m_DD = dd;
			m_Types = types;
			m_SuccessMessage = message;
		}
	}
}