using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpNewDonChoix : GumpNubia
    {
        private NubiaPlayer m_owner;
        private DonEnum mDonView = DonEnum.DonSupClasse;
        private ClasseType m_classe;
        private int m_niveau;
        private int m_page;

        private void addDonChoix(int x, int y, DonEnum don, bool dispo)
        {
            if (mDonView == don)
                AddImage(x + 10, y, 2153);
            else if( dispo )
                AddButton(x + 10, y, 2151, 2152, (int)don+100, GumpButtonType.Reply, 0);
            else
                AddButton(x + 10, y, 2472, 2473, (int)don+100, GumpButtonType.Reply, 0);
            AddLabel(x + 45, y, ColorText, BaseDon.getDonName(don));

        }
        public GumpNewDonChoix(NubiaPlayer _owner, ClasseType c, int niveauClasse, DonEnum donView, int page)
            : base("Dons de " + _owner.Name, 640, 480)
        {
            m_owner = _owner;
            mDonView = donView;
            m_classe = c;
            m_niveau = niveauClasse;
            m_page = page;

            int y = YBase;
            int x = XBase;
            int line = 4;
            int scale = 25;
            int decal = 10;

            int col = 0;
            int coldecal = 310;

            int limit = 16;

            if (m_owner.Dons == null)
                return;



            List<BaseDon> donDispo = new List<BaseDon> ();

            int nbrPage = BaseDon.DonBank.Values.Count / (limit * 2);
            if( page > 0 )
                AddButton(x + 500, y, 4014, 4015, 5, GumpButtonType.Reply, page - 1);
            if( page < nbrPage )
                AddButton(x + 550, y, 4005, 4006, 6, GumpButtonType.Reply, page + 1);

            if (mDonView != DonEnum.DonSupClasse)
            {
                AddBackground(x, y, 300, 50, 9400);
                AddLabel(x + 5, y + 2, ColorTextYellow, BaseDon.getDonName(mDonView));


                int cd = 200;
                if (m_classe > ClasseType.Roublard)
                    cd -= 55;
                AddLabel(x + 5 + cd, y + 2, ColorTextLight, (m_classe == ClasseType.None ? "Général" : Classe.GetNameClasse(m_classe)));
                AddLabel(x + 5 + 250, y + 2, ColorText, "Niv " + m_niveau.ToString());

                AddBackground(x, y + 25, 300, 80, 9200);
                BaseDon don = BaseDon.getDon(mDonView);

                if (don != null)
                {
                    AddImage(x + 10, y + 40, don.Icone);
                  //  AddLabel(x + 10, y + 80, ColorTextYellow, "Rang:" + m_owner.Dons.getDonNiveau(don));
                    String desc = don.Description;
                    if (don.CanUse)
                    {
                        desc += "<br>(Utilisation: .don " + don.ToString() + ")";
                    }
                    AddHtml(x + 60, y + 35, 235, 60, desc, true, true);

                    if (don.hasConditions(m_owner))
                    {
                        AddButtonPageSuivante(x + coldecal, y, 9);
                        AddLabel(x + coldecal + 60, y, ColorTextYellow, "Apprendre ce don");
                    }
                }

              
            }


            if (c == ClasseType.None)
            {
                BaseDon[] donArray = new BaseDon[BaseDon.DonBank.Values.Count];
                BaseDon.DonBank.Values.CopyTo(donArray, 0);
                int mini = page * limit * 2;
                int count = 0;
                for (int b = 0; b < donArray.Length; b++)
                {
                    BaseDon don = donArray[b];
                    if ((int)don.DType >= 1000 && !( m_owner.hasDon(don.DType)&&don.AchatMax <= 1 ) )
                    {
                        count++;
                        if (count  < mini )
                            continue;
                        if (donDispo.Count < limit * 2)
                            donDispo.Add(don);
                        else
                            break;
                    }
                  /*  if (donDispo.Count > limit * 2)
                        break;*/
                }

                foreach (BaseDon d in donDispo)
                {
                    if (d != null)
                    {
                        addDonChoix(x + col * coldecal, decal + y + line * scale, d.DType, d.hasConditions(m_owner));
                        if (line > limit)
                        {
                            line = 0;
                            col++;
                            if (col >= 2)
                                break;
                        }
                        line++;
                    }
                }
            }
            else
            {
                DonEnum[] enumlist = m_owner.getClasse(m_classe).getCustomDon(m_owner, m_niveau);
                BaseDon[] donArray = new BaseDon[enumlist.Length];


              int mini = page * limit * 2;
              int count = 0;
                for (int b = 0; b < enumlist.Length; b++)
                {
                    BaseDon don = BaseDon.getDon(enumlist[b]);
                    if( don == null )
                        continue;

                    if ((int)don.DType >= 1000 && !(m_owner.hasDon(don.DType) && don.AchatMax <= 1))
                    {
                        count++;
                        if (count  < mini)
                            continue;
                        if (donDispo.Count < limit * 2)
                            donDispo.Add(don);
                        else
                            break;


                        count++;
                    }
                    /*  if (donDispo.Count > limit * 2)
                          break;*/
                }

                foreach (BaseDon d in donDispo)
                {
                    if (d != null)
                    {
                        addDonChoix(x + col * coldecal, decal + y + line * scale, d.DType, d.hasConditions(m_owner));
                        if (line > limit)
                        {
                            line = 0;
                            col++;
                            if (col >= 2)
                                break;
                        }
                        line++;
                    }
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            int id = info.ButtonID;
            if( id == 5 )
                from.SendGump(new GumpNewDonChoix(from, m_classe, m_niveau, (DonEnum)(mDonView), --m_page));
            else if( id == 6 )
                from.SendGump(new GumpNewDonChoix(from, m_classe, m_niveau, (DonEnum)(mDonView), ++m_page ));
            else if (id > 100)
            {
                from.SendGump(new GumpNewDonChoix(from, m_classe, m_niveau, (DonEnum)(id-100), m_page));
            }
            else if (id == 9)
            {
                from.Dons.DonsEntrys.Add(new DonEntry(mDonView, m_classe, m_niveau, true));
                for (int d = 0; d < from.Dons.DonsEntrys.Count; d++)
                {
                    DonEntry entry = from.Dons.DonsEntrys[d];
                    if (entry.Don == DonEnum.DonSupClasse && entry.GiveAtLevel == m_niveau && entry.Classe == m_classe)
                    {
                        entry.Choosen = true;
                        break;
                    }
                }
                from.Dons.ComputeDons();
                from.SendMessage("Vous avez appri le don {0}", BaseDon.getDonName(mDonView));
                from.SendGump(new GumpDons(m_owner, m_owner));
            }

        }
    }
}
