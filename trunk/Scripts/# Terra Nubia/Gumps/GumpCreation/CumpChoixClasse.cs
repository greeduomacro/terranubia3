using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
	public class GumpChoixClasse : GumpNubia
	{
		private NubiaPlayer m_owner;
		private bool creation = false;
        private int choix = 0;
        public GumpChoixClasse(NubiaPlayer _owner, bool _creation)
            : this(_owner, _creation, 0)
		{}
        public GumpChoixClasse(NubiaPlayer _owner, bool _creation, int _choix)
            : base("Choix de la " + (_creation ? "Première classe" : "classe"), 250, 485)
		{
			//Closable = false;
			m_owner = _owner;
			creation = _creation;
            choix = _choix;
		
			int y = YBase;
			int x = XBase;
			int line = 0;
			int scale = 25;
			int decal = 5;

            ClasseType possClasse = ClasseType.Maximum;
            bool canArtisan = true;

            foreach (Classe c in m_owner.GetClasses())
            {
                possClasse = c.CType;
                if (c is ClasseArtisan)
                    canArtisan = false;
            }
           



			for( int i = 0; i < (int)ClasseType.Maximum; ++i )
			{
                if ((ClasseType)i == possClasse && possClasse != ClasseType.Maximum)
                    continue;

                //Bloquage du multiclassage de Magicien/Ensorceleur
                if (((ClasseType)i == ClasseType.Magicien && possClasse == ClasseType.Ensorceleur) ||
                    ((ClasseType)i == ClasseType.Ensorceleur && possClasse == ClasseType.Magicien))
                    continue;

                if(  (ClasseType)i < ClasseType.ArtisanCouturier || canArtisan  )
                    AddButtonTrueFalse(x, y + (line * scale), i + 100, (choix == i), Classe.GetNameClasse((ClasseType)i));
                line++;
        	}
			AddButton( x , y+(line*scale), 0x850, 0x851,99, GumpButtonType.Reply, 0 );
			
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            if (info.ButtonID == 99)
            {
                int m = choix;

                Type type = null;
                try
                {
                    type = Classe.GetClasse((ClasseType)m);
                }
                catch (Exception ex)
                {
                    from.SendMessage(ex.Message);
                }
                if (type != null)
                {
                    from.LastClasse = (ClasseType)m;
                    int classeNiv = 1;
                    foreach (Classe cl in from.GetClasses())
                        if (cl.CType == from.LastClasse)
                            classeNiv = cl.Niveau + 1;
                    //if (creation)
                        //from.GiveNiveau(0);

                    from.MakeClasse(type, classeNiv);

                     //  from.GiveNiveau(from.Niveau + 1);

                }
                else
                {
                    from.SendGump(new GumpChoixClasse(m_owner, creation));
                    from.SendMessage(43, "Vous devez choisir une classe");
                }

                from.CloseGump(typeof(GumpChoixClasse));
                if (creation)
                {
                    for (int i = 0; i < from.Skills.Length; i++)
                    {
                        from.Skills[i].Cap = 20.0;
                        from.Skills[i].Base = 0.0;
                    }
                    from.Frozen = false;
                    from.SendGump(new GumpMenuCreation(from));
                }
                else
                    from.SendGump(new GumpFichePerso(m_owner, m_owner));
                return;
            }
            else
                choix = info.ButtonID - 100;
			from.CloseGump( typeof( GumpChoixClasse ) );
			from.SendGump( new GumpChoixClasse( m_owner, creation, choix ) );
		}

	}
}
