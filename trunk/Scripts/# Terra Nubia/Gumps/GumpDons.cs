using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;
using System.Collections.Generic;
namespace Server.Gumps
{
    public class GumpDons : GumpNubia
    {
        private NubiaPlayer m_owner;
        private NubiaPlayer m_viewer;
        public GumpDons(NubiaPlayer _owner, NubiaPlayer _viewer)
            : base("Dons de " + _owner.Name, 640, 480)
        {
            m_owner = _owner;
            m_viewer = _viewer;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 110;
            int decal = 30;

            int col = 0;
            int coldecal = 310;

            int limit = 8;

            if (m_owner.Dons == null)
                return;

            int page = 1;


            AddPage(page);

            int nbrPage = (int)Math.Truncate( (double)m_owner.Dons.DonsEntrys.Count-1 / 8.0) ;
            //int dsup = 0;
           /* for (int i = -1; i < (int)ClasseType.Maximum; i++)
            {

                if (m_owner.DonCredits.ContainsKey((ClasseType)i))
                {
                    if (m_owner.DonCredits[(ClasseType)i] > 0)
                    {
                        dsup += m_owner.DonCredits[(ClasseType)i];
                    }
                }

            }*/
          /*  if (dsup > 0)
            {
                AddButtonPageSuivante(x, y, 10);
                AddLabel(x + 50, y, ColorTextGreen, "Choisir un nouveau don");
                AddLabel(x + 200, y, ColorTextGray, "( " + dsup + " don" + (dsup > 1 ? "" : "s") + " à choisir )");
            }*/
            if (nbrPage > 0)
            {
                
                //AddButton(x+500, y, 4014, 4015, 5, GumpButtonType.Page, page - 1);
                
                AddButton(x+550, y, 4005, 4006, 6, GumpButtonType.Page, page + 1);
            }
            List<DonEnum> display = new List<DonEnum>();

            Console.WriteLine("Nombre de dons au total: " + m_owner.Dons.DonsEntrys.Count);
            for(int e = 0; e < m_owner.Dons.DonsEntrys.Count; e++)
            {
                DonEntry entry = m_owner.Dons.DonsEntrys[e];
                DonEnum donEnum = entry.Don;
                bool canView = true;
                if (display.Contains(donEnum) && donEnum != DonEnum.DonSupClasse)
                    canView = false;
                if ( entry.Don == DonEnum.DonSupClasse && entry.Choosen )
                    canView = false;
               // Console.WriteLine("Don: " + donEnum.ToString());
                if ( canView)
                {
                    display.Add(donEnum);
                    BaseDon don = BaseDon.getDon(donEnum);
                  //  Console.WriteLine("Don entry: " + entry);
                 //   Console.WriteLine("Don: " + don);
                    int ly = y + line * scale + 30;
                    int lx = x  + col * coldecal;

                   
                        AddBackground(lx, ly, 300, 50, 9400);
                        AddLabel(lx + 5, ly + 2, ColorTextYellow, BaseDon.getDonName(donEnum));


                        int cd = 200;
                        if (entry.Classe > ClasseType.Roublard)
                            cd -= 55;
                        AddLabel(lx + 5 + cd, ly + 2, ColorTextLight, (entry.Classe == ClasseType.None ? "Général" : Classe.GetNameClasse(entry.Classe)));
                        AddLabel(lx + 5 + 250, ly + 2, ColorText, "Niv " + entry.GiveAtLevel.ToString());

                        AddBackground(lx, ly + 25, 300, 80, 9200);

                    

                    if (entry.Don == DonEnum.DonSupClasse && !entry.Choosen)
                    {
                        //AddImage(lx + 10, ly + 40, 2277);
                        AddButton(lx + 10, ly + 40, 2277, 2277, (int)e+100, GumpButtonType.Reply, 0);
                        String desc =  "<BASEFONT COLOR=#EE0000>Choississez votre don en cliquant sur l'icone</BASEFONT>";
                      
                        AddHtml(lx + 60, ly + 35, 235, 60, desc, true, true);
                    }
                    else  if (don != null)
                    {
                        AddImage(lx + 10, ly + 40, don.Icone);
                        if (m_owner.Dons.getDonNiveau(donEnum) > 1)
                            AddLabel(lx + 10, ly + 80, ColorTextYellow, "Rang:"+m_owner.Dons.getDonNiveau(donEnum) );
                        String desc = don.Description;
                        if (don.CanUse)
                        {
                            desc += "<br>(Utilisation: .don " + don.ToString() + ")";
                        }
                        AddHtml(lx + 60, ly + 35, 235, 60, desc, true, true);
                    }

                    line++;

                    if (line >= 4)
                    {
                        col++;
                        line = 0;
                    }
                    if (col > 1)
                    {
                        col = 0;
                        line = 0;
                        page++;
                        AddPage(page);
                        AddButton(x + 500, y, 4014, 4015, 5, GumpButtonType.Page, page - 1);
                        if( nbrPage > page )
                            AddButton(x + 550, y, 4005, 4006, 6, GumpButtonType.Page, page + 1);
                    }
                }
            }

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            int id = info.ButtonID;

            if (id >= 100)
            {
                DonEntry entry = m_owner.Dons.DonsEntrys[id - 100];
                from.SendGump(new GumpNewDonChoix(from, entry.Classe, entry.GiveAtLevel, entry.Don, 0));
            }
        }
    }
}
