using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Gumps
{
	public class SortCreationChoixSort : GumpNubia
	{
		private NubiaPlayer m_owner;
		private SortNubia m_SortNubia;

        private SortNubia[] m_sorts = new SortNubia[] { 
                new SortNubiaDestruction(),
                new SortNubiaCharme(),
                new SortNubiaInvocation(),
                new SortNubiaInvocationArme(),
                new SortNubiaMur(),
                new SortNubiaParalyze(),
                new SortNubiaPoison(),
                new SortNubiaSoin(),
                new SortNubiaTao(),
                new SortNubiaTransformation()
            };

        public SortCreationChoixSort(NubiaPlayer _owner, SortNubia _SortNubia)
            : base("Tissage de sort", 270, 270)
		{
			m_owner = _owner;
			m_SortNubia = _SortNubia;
			if( m_owner == null || m_SortNubia == null )
			{
                Console.WriteLine("GROS WARNING: SortCreationTypeGump proprio ou SortNubia null");
				return;
			}
			int x = XBase;
			int y = YBase;
			
            int line = 0;
			int scale = 22;

			//18lignes max ;)

            AddLabel(x, (y + line * scale), ColorTextYellow, "Choix du sort de base");
            line++;

            AddLabel(x, y + line * scale, ColorTextGreen, "Actuel: " + SortNubiaHelper.formatName(_SortNubia));
			line++;

            for (int s = 0; s < m_sorts.Length; s++)
            {
                if (SortNubiaHelper.calculMaitriseDomaine(m_sorts[s].Domaine, m_owner.Domaine) > 0)
                {
                    AddButton(x, y + line * scale, 0xFAB, 0xFAC, 50+s, GumpButtonType.Reply, 0); //Voir
                    AddLabel(x + 40, y + line * scale, ColorText, SortNubiaHelper.formatName(m_sorts[s]));
                    line++;
                }
            }
		
		
            line++;
			AddButton( x, y +line * scale, 0xFAB, 0xFAC, 1, GumpButtonType.Reply, 0 ); //Voir
			AddLabel( x+40, y+line*scale, ColorTextRed, "Annuler" );
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            int id = info.ButtonID;
            if (id >= 50)
            {
                int s = id - 50;
                m_SortNubia = m_sorts[s];
                for (int i = 0; i < m_sorts.Length; i++)
                {
                    if (i != s)
                        m_sorts[i].Delete();
                }
            }


			from.CloseGump(typeof(SortCreationChoixSort));
			from.SendGump(new SortCreationGump(m_owner, m_SortNubia) );
		}

	}
}