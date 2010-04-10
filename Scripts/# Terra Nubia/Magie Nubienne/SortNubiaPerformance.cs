using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class SortNubiaPerformance
	{
        private SortDomaine m_SortNubia = SortDomaine.Evocation;
		private int m_percent = 0;
        public SortNubiaPerformance(SortDomaine SortNubia, int percent)
		{
			m_SortNubia = SortNubia;
			m_percent = percent;
		}
		public int percent
		{
			get
			{
				return m_percent;
			}
			set
			{
				m_percent = value;
			}
		}
        public SortDomaine SortNubia
		{
			get
			{
				return m_SortNubia;
			}
			set
			{
				m_SortNubia = value;
			}
		}
	}

}