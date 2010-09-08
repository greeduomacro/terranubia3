using System;
using System.Collections.Generic;
using System.Collections;
using Server.Mobiles;
using System.Text;

namespace Server.Gumps
{
    public class GumpDonChoix : GumpNubia
    {
        private NubiaPlayer mOwner = null;
        private ArrayList list = new ArrayList();
        private ClasseType cl = ClasseType.None;
        public GumpDonChoix(NubiaPlayer owner, ClasseType c)
            : base("Choix de don", 300, 450)
        {
            Closable = true;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 25;
            int decal = 5;
            mOwner = owner;
            cl = c;
           

            int page = 0;
          /*  int xprev = 0;
            int linePerPage = 19;
            int totalPage = totalLines / 19 + page;
            int donsDispo = DndHelper.getDonTotal(mOwner.Niveau);*

          /*  if (line == 1)
            {
                AddPage(page);
                AddButton(xprev, yprevnext, 4014, 4015, 5, GumpButtonType.Page, page - 1);
                if (page < totalPage)
                    AddButton(xnext, yprevnext, 4005, 4006, 6, GumpButtonType.Page, page + 1);
                else
                    AddButton(xnext, yprevnext, 4005, 4006, 6, GumpButtonType.Page, page);

                AddLabel(XCol, y + line * scale, ColorTextYellow, "Dons du personnage");
                line++;
                if (donsDispo > 0 || mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
                {
                    AddSimpleButton(XCol, y + line * scale, 90, "Choisir un don ( " + donsDispo + " disponibles )", ColorTextGreen);
                    line++;
                }
            }*/
            AddPage(0);
            if ( mOwner.DonCredits.ContainsKey(cl) )
            {
                if (cl != ClasseType.None)
                {

                    if (mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
                    {
                        DonEntry entry = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse];
                        AddLabel(x, y, ColorTextYellow, "Don supplémentaire de " + Classe.GetNameClasse(cl) + " niveau " + entry.GiveAtLevel);
                        line++;
                        DonEnum[] dispos = owner.getClasse(entry.Classe).getCustomDon(mOwner, entry.GiveAtLevel);
                        for (int d = 0; d < dispos.Length; d++)
                        {
                            if (BaseDon.DonBank.ContainsKey(dispos[d].ToString().ToLower()) && !mOwner.hasDon(dispos[d]))
                            {
                                BaseDon don = BaseDon.DonBank[dispos[d].ToString().ToLower()];
                                list.Add(don.DType);

                            }
                        }
                    }
                    else
                    {
                   //     mOwner.SendMessage("BUG PAGEZ (Demandez Nexam. Bug N°01");
                    }
                }
                else if (cl == ClasseType.None)
                {

                    //  int libre = DndHelper.getDonTotal(owner.Niveau);
                    //    if (libre > 0)
                    if (mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
                    {
                        AddLabel(x, y, ColorTextGreen, "Dons Disponible : " + mOwner.DonCredits[ClasseType.None]);
                        for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
                        {
                            if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString().ToLower()) && !mOwner.hasDon(((DonEnum)d)))
                            {
                                BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString().ToLower()];
                                if (don.hasConditions(mOwner))
                                {
                                    list.Add(don.DType);

                                }
                            }
                        }
                    }
                    else
                    {
                //        mOwner.SendMessage("BUG PAGEZ (Demandez Nexam. Bug N°02");
                    }
                }

                int xnext = x + 200, xprev = x + 10, yprevnext = y + scale;
                int linePerPage = 15;

                int totalPage = list.Count / linePerPage + 1;

                page = 1;
                line = 1;
                AddPage(1);
                for (int d = 0; d < list.Count; d++)
                {

                    if (line == 1)
                    {
                        AddPage(page);
                        if (page > 1)
                            AddButton(xprev, yprevnext, 4014, 4015, 5, GumpButtonType.Page, page - 1);

                        if (page < totalPage)
                            AddButton(xnext, yprevnext, 4005, 4006, 6, GumpButtonType.Page, page + 1);
                        //  else
                        //       AddButton(xnext, yprevnext, 4005, 4006, 6, GumpButtonType.Page, page);

                    }
                    line++;

                    DonEnum don = (DonEnum)list[d];
                    string dname = "";
                    if (BaseDon.DonBank.ContainsKey(don.ToString().ToLower()))
                        dname = BaseDon.DonBank[don.ToString().ToLower()].Name;
                    else
                        dname = don.ToString();

                    AddSimpleButton(x + 10, y + line * scale, d + 500, dname);

                    if (line > linePerPage)
                    {
                        page++;
                        AddPage(page);
                        line = 1;
                    }


                }
            }
           
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {

            if (info.ButtonID >= 500)
            {
                int id = info.ButtonID - 500;
                Console.WriteLine(" ID = " + id);
                if (id < list.Count)
                {

                    DonEnum don = (DonEnum)list[id];
                    int niv = -1;
                    ClasseType ctype = ClasseType.None;
                    if (mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
                    {
                        niv = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse].GiveAtLevel;
                        ctype = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse].Classe;
                        mOwner.Dons.DonsEntrys.Remove(DonEnum.DonSupClasse);
                    }
                    mOwner.Dons.DonsEntrys.Add(don, new DonEntry(don, ctype, niv));
                    mOwner.SendMessage("Vous apprennez le don {0}", BaseDon.getDonName(don));
                    if (mOwner.DonCredits.ContainsKey(cl))
                    {
                        mOwner.DonCredits[cl]--;
                    }
                }
            }
            mOwner.SendGump(new GumpFichePerso(mOwner, mOwner));
           
        }
    }
}
