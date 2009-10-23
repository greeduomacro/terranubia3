using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Spells;
using System.Text;

namespace Server.Gumps
{
    public class GumpLivreMagie : GumpNubia
    {
        private ClasseType mClasse = ClasseType.Barbare;
        private MagieList mMagieList = null;
        public GumpLivreMagie(NubiaPlayer owner, ClasseType classe)
            : base("Magie de "+Classe.GetNameClasse(classe), 300,400)
        {
            

            int x = XBase;
            int y = YBase;
            int line = 2;
            int scale = 25;


            for (int page = 1; page <= 10; page++)
            {
                int prevPage = page - 1;
                if (prevPage < 1)
                    prevPage = 1;
                int nextPage = page + 1;
                if (nextPage > 10)
                    nextPage = 10;

                int cercle = page - 1;

                mMagieList = owner.getMagieOf(classe);
                line = 1;

                if (mMagieList == null)
                {
                    AddLabel(x + 115, y, GumpNubia.ColorTextRed, "Pas de magie pour " + classe);
                }
                else{

                    AddPage(page);
                    AddButton(x, y, 4014, 4015, 1, GumpButtonType.Page, prevPage);
                    AddButton(x + 250, y, 4005, 4006, 2, GumpButtonType.Page, nextPage);

                    AddLabel(x + 115, y, GumpNubia.ColorTextLight, "Cercle " + cercle);

                    if (mMagieList.InstinctMagie)
                    {
                        AddLabel(x, y + line * scale, ColorTextGreen, "Sorts disponibles: " + mMagieList.getSortDispo(cercle));
                        line++;
                    }

                    for (int i = 0; i < mMagieList.Sorts.Length; i++)
                    {
                        SortEntry entry = mMagieList.Sorts[i];
                        if (entry.Cercle == cercle)
                        {
                            bool canCast = mMagieList.canCast(entry.Sort.GetType());
                            //Launch
                            if (canCast)
                                AddButton(x, y + line * scale, 4029, 4031, 500 + i, GumpButtonType.Reply, 0);
                            else
                                AddImage(x, y + line * scale, 4029, ColorTextRed);
                            //Name
                            AddBackground(x + 32, y + line * scale, 130, 25, 3000);
                            AddLabel(x+35, y + line * scale, ( canCast ? ColorTextGreen : ColorTextGray ), entry.Sort.Name);
                            //Ecole
                            AddBackground(x + 167, y + line * scale, 90, 25, 3000);
                            AddLabel(x + 170, y + line * scale, ColorText, entry.Sort.Ecole.ToString());
                            
                            line++;
                        }
                    }
                }
            }
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            base.OnResponse(sender, info);
            int id = info.ButtonID;
            if (id >= 500 && mMagieList != null)
            {
                SortEntry entry = null;
                int sortid = id - 500;
                if (mMagieList.Sorts.Length > sortid)
                {
                    entry = mMagieList.Sorts[sortid];
                    if (entry.Sort != null)
                    {
                        mMagieList.Cast(entry.Sort.GetType());
                    }
                }
            }
        }
    }
}
