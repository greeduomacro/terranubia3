using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Targeting;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;

namespace Server.Gumps
{
	public class SortCreationChoixCondition : Gump
	{
		private NubiaPlayer m_owner;
		private SortNubia m_SortNubia;

        public SortCreationChoixCondition(NubiaPlayer _owner, SortNubia _SortNubia)
            : base(50, 50)
		{
			m_owner = _owner;
			m_SortNubia = _SortNubia;

			int largeur = 300;
			int hauteur = 300;
			int _x = 50;
			int _y = 50;
			AddBackground( _x, _y, _x+largeur,_y+hauteur, 0x13BE );
			AddBackground( _x+10, _y+10, _x+largeur-20,_y+hauteur-15, 0x0DAC );
			AddImage( 0,0, 0x28C8 );
			AddImage( largeur+70,0, 0x28C9 );
			AddImage( (largeur/2)-10,30, 0x28D4 );
			

			int y = 45+_y;
			int line = 4;
			int scale = 22;
			int col = 35+_y;
			//18lignes max ;)
			AddLabel( col, (line*scale), 2224, "Création d'un nouveau SortNubia");
			line++;
			//AddButton( col, (line*scale), 0xFAB, 0xFAC, 998, GumpButtonType.Reply, 0 );
			AddLabel( col, line*scale, 2116, "Actuelle: "+m_SortNubia.condition.ToString() );
			line++;
			line++;

			AddLabel( col, (line*scale), 2224, "Choix d'une condition:");
			line++;
		
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 100, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "Aucune" );
			line++;
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 101, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "Mains nues/Mains libres" );
			line++;
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 102, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "Objet équipé (Type d'objet)" );
			line++;
			/*AddButton( col, (line*scale), 0xFAB, 0xFAC, 100, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "Objet aux alentour (Type d'objet)" );
			line++;*/
			AddButton( col, (line*scale), 0xFAB, 0xFAC, 103, GumpButtonType.Reply, 0 ); 
			AddLabel( col+40, line*scale, 0, "SortNubia 'Père' actif" );
			line++;

			AddButton( col, (line*scale), 0xFAB, 0xFAC, 999, GumpButtonType.Reply, 0 );
			AddLabel( col+40, line*scale, 0, "Annuler" );
			line++;
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

			if(info.ButtonID == 101) //Main nue
			{
				m_SortNubia.condition = MagieCondition.MainNue;
			}
			if(info.ButtonID == 102) //Objet equiper
			{
				m_SortNubia.condition = MagieCondition.None;
				from.Target = new EquipObjectTarget(m_SortNubia);
			}
			if(info.ButtonID == 103) //SortNubia père
			{
				m_SortNubia.condition = MagieCondition.None;
				from.CloseGump(typeof(SortCreationChoixCondition));
				from.SendGump(new SortCreationChoixPere(m_owner, m_SortNubia) );
				//from.Target = new EquipObjectTarget(m_SortNubia);
			}
			
			if(info.ButtonID != 102 && info.ButtonID != 103 )
			{	
				from.CloseGump(typeof(SortCreationChoixCondition));
				from.SendGump(new SortCreationGump(m_owner, m_SortNubia) );
			}
		}

		private class EquipObjectTarget : Target
		{
			private SortNubia m_Owner;

			public EquipObjectTarget( SortNubia owner ) : base( owner.distance, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile f, object o )
			{
                NubiaPlayer from = f as NubiaPlayer;
				if ( o is Item )
				{
					Item item = o as Item;
					if( item is BaseClothing )
					{
						from.SendMessage("Habits non autorisé");
						from.CloseGump(typeof(SortCreationChoixCondition));
                        from.SendGump(new SortCreationChoixCondition(from, m_Owner));
						return;
					}
					m_Owner.ObjectToEquip = item;
					from.SendMessage(item.Name + " Selectionner en condition d'équipement");
                    from.CloseGump(typeof(SortCreationChoixCondition));
					from.SendGump(new SortCreationGump(from, m_Owner) );
					return;
				}
				from.SendMessage("Cible invalide pour la condition 'L'Objet doit être équipé'");
                from.CloseGump(typeof(SortCreationChoixCondition));
                from.SendGump(new SortCreationChoixCondition(from, m_Owner));
			}
		}

	}
}