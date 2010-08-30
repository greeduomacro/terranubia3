using System;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using Server.Engines;
using Server.Items;

namespace Server.Gumps
{
    class GumpArtisan : GumpNubia
    {
        private CraftSystemNubia mSystem = null;
        private NubiaPlayer mOwner = null;
        private int mCategorie = -1;
        private CraftEntry mEntry = null;
        private int mItemSelect = -1;
        private BaseToolNubia mTool = null;
        private int mPage = 0;

        private void addCategorie(int x, int y, int buttonid, bool check, string categorie)
        {
            //Alternative (parch button): 9792
            if (check)
            {
                AddImage(x+2, y, 2472);
            }
            else
            {
                AddButton(x, y, 9727, 9728, buttonid, GumpButtonType.Reply, 0);
            }
            AddLabel(x + 35, y+5, ColorText, categorie);
        }

        //Button fleche = 4005
        //button parch = 4011


        public GumpArtisan(BaseToolNubia tool, CraftSystemNubia system, NubiaPlayer owner)
            : this(tool, system, owner, 0, 0, -1)
        {
        }
        public GumpArtisan(BaseToolNubia tool, CraftSystemNubia system, NubiaPlayer owner, int Categorie, int page, int itemSelect)
            : base(system.Name, 560, 450, 210)
        {
            Closable = true;
            mOwner = owner;
            mSystem = system;
            mCategorie = Categorie;
            mItemSelect = itemSelect;
            mTool = tool;
            mPage = page;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 24;
            int decal = 5;

            if (itemSelect >= 0 && itemSelect < mSystem.List.Entrys.Length)
            {
                if( mSystem.List.Entrys[itemSelect].Categorie == mCategorie )
                    mEntry = mSystem.List.Entrys[itemSelect];            
            }
            /*Menu de gauche*/

            AddBackground(x, y, 210, 435, 3500); //3500 = parch déco ; 3000 = parch; 3600=pierre noire ; 5120 =pierrenoire 2
            AddBackground(x + 220, y, 315, 300, 3500);
            AddBackground(x + 220, y + 250, 315, 185, 3600);
            line++;
            AddLabel(x + 20, y + line * scale, ColorTextYellow, "Catégories");

            AddImageTiled(x + 206, y-6, 17, 440, 10150); //Bande verticale
            AddImageTiled(x+212, y+234, 320, 18, 0x280A); //Bande 2
        //    AddImage(x + 177, y + 420, 10204); //Fin de bande
            line++;

            for (int c = 0; c < mSystem.List.Categorie.Length; c++) //50+
            {
                addCategorie(x+25, y + line * scale, 50 + c, (mCategorie == c ? true : false), mSystem.List.Categorie[c]);
                line++;
            }

            scale = 22;
            if (system.GetType() == typeof(CraftCoutureSystem))
            {
                line = 14;
                AddSimpleButton(x + 20, y + line * scale, 39, (mTool.Tissu == null ? "Choisir Tissu" : "Tissu: " + mTool.Tissu.Ressource.ToString()));
            }
            line = 15;
            if (system.GetType() != typeof(CraftEruditionSystem))
            {
                AddSimpleButton(x + 20, y + line * scale, 35, (mTool.Metal == null ? "Choisir Metal" : "Metal: " + mTool.Metal.Ressource.ToString()));
                line++;
                AddSimpleButton(x + 20, y + line * scale, 36, (mTool.Cuir == null ? "Choisir Cuir" : "Cuir: " + mTool.Cuir.Ressource.ToString()));
                line++;
                AddSimpleButton(x + 20, y + line * scale, 37, (mTool.Os == null ? "Choisir Os" : "Os: " + mTool.Os.Ressource.ToString()));
                line++;
                AddSimpleButton(x + 20, y + line * scale, 38, (mTool.Bois == null ? "Choisir Bois" : "Bois: " + mTool.Bois.Ressource.ToString()));
            }

            /*Liste de droite*/
            x = XCol;
            line = 1;
            int maxNbItems = 8;
            int curNbItems = 1;
            bool pageSuivante = false;

            for (int i = 0; i < mSystem.List.Count; i++) //100+
            {
                if (mSystem.List.Entrys[i].Categorie == mCategorie /*&& cando*/ )
                {
                    if (curNbItems > mPage * maxNbItems && curNbItems <= (mPage + 1) * maxNbItems)
                    {
                        //AddSimpleButton(x+20, y + line * scale, 100 + i, mSystem.List.Entrys[i].Name);
                        AddButton(x + 20, y + line * scale, 4011, 4012, 100 + i, GumpButtonType.Reply, 0);
                        AddLabel(x + 55, y + line * scale, (i == itemSelect ? ColorTextGreen : ColorText), mSystem.List.Entrys[i].Name);
                        line++;
                    }
                    if (curNbItems++ == (mPage + 1) * maxNbItems + 1)
                    {
                        pageSuivante = true;
                        break;
                    }
                }
            }
            if (mPage > 0)
                AddButton(x + 20, y + 200, 4014, 4015, 42, GumpButtonType.Reply, 0);
            if (pageSuivante)
                AddButton(x + 200, y + 200, 4007, 4006, 41, GumpButtonType.Reply, 0);

            /*Fiche de description & Craft Button*/
           
            if (mEntry != null)
            {
                y = 360;
                x += 25;
                line = 2;
                scale = 20;

                Item item = null;
                try { item = mEntry.ToCraft.GetConstructor(Type.EmptyTypes).Invoke(null) as Item; }
                catch { }
           
                if (item != null) //Apperçu
                    AddItem(x + 150, y + 40, item.ItemID);
                AddLabel(x, y+20, ColorTextYellow, mEntry.Name);

             /*   string infos = "";

                infos += "<i>Mini skill</i>: " + mEntry.MinValue.ToString();
                infos += "<br><i>Difficulté(Moy.10)</i>: " + mEntry.Diff.ToString();
                infos += "<br>";
                for (int r = 0; r < mEntry.Ressource.Length; r++)
                    infos += "<br><i>" + mEntry.Ressource[r].RType.GetType().ToString() + "</i>: " + mEntry.Ressource[r].Number.ToString();
                */
                AddLabel(x, y + line * scale, ColorTextGreen, "Comp. Requise: " + mEntry.MinValue.ToString());
                line++;
                AddLabel(x, y + line * scale, ColorTextGreen, "Difficulté: " + mEntry.Diff.ToString());
              //  line++;
                string res = "";
                for (int r = 0; r < mEntry.Ressource.Length; r++)
                {
                    line++;
                    string stype = mEntry.Ressource[r].RType.Name;
                    if (stype == "BaseMetal")
                        stype = "Métal";
                    else if (stype == "BaseBois")
                        stype = "Bois";
                    else if (stype == "BaseCuir")
                        stype = "Cuir";
                    else if (stype == "BaseOs")
                        stype = "Os";
                    else if (stype == "BaseTissu")
                        stype = "Tissu";
                    else
                    {
                        try
                        {
                            Item ires = mEntry.Ressource[r].RType.GetConstructor(Type.EmptyTypes).Invoke(null) as Item;
                            if (ires != null)
                            {
                                if (ires.Name != null)
                                    stype = ires.Name;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    res = mEntry.Ressource[r].Number.ToString() + " " + stype;
                    AddLabel(x, y + line * scale, ColorText, res);
                    
                }
               // line++;
               // AddSimpleButton(x + 8, y + line * scale, 40, "Créer cet objet");
                AddButton(x + 130, y + line * scale, 4005, 4006, 40, GumpButtonType.Reply, 0);
                AddLabel(x + 165, y+2 + line * scale, ColorTextYellow, "Créer");
                if (item != null)
                    item.Delete();
            }


        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID >= 50 && info.ButtonID < 100) //Changement de catégorie
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, info.ButtonID - 50, 0, -1));
            }
            else if (info.ButtonID >= 100 && info.ButtonID < 500) //Selection d'item
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, info.ButtonID - 100));
            }
            else if (info.ButtonID == 35) //Choix du métal
            {
                if (mTool != null)
                    mTool.GetNewMetal(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, mItemSelect));
            }
            else if (info.ButtonID == 36) //Choix du Cuir
            {
                if (mTool != null)
                    mTool.GetNewCuir(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, mItemSelect));
            }
            else if (info.ButtonID == 37) //Choix du Os
            {
                if (mTool != null)
                    mTool.GetNewOs(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, mItemSelect));
            }
            else if (info.ButtonID == 38) //Choix du Bois
            {
                if (mTool != null)
                    mTool.GetNewBois(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, mItemSelect));
            }
            else if (info.ButtonID == 39) //Choix du Tissu
            {
                if (mTool != null)
                    mTool.GetNewTissu(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage, mItemSelect));
            }
            else if (info.ButtonID == 40) //Craft !
            {
                mSystem.TryCraft(mOwner, mTool, mEntry);
            }
            else if (info.ButtonID == 41) //Page suivante
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage + 1, -1));
            }
            else if (info.ButtonID == 42) //Page précédente
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mPage - 1, -1));
            }
        }
    }
}
