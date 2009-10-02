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

        public GumpArtisan(BaseToolNubia tool, CraftSystemNubia system, NubiaPlayer owner)
            : this(tool, system, owner, 0, -1)
        {
        }
        public GumpArtisan(BaseToolNubia tool, CraftSystemNubia system, NubiaPlayer owner, int Categorie, int itemSelect)
            : base(system.Name, 400, 450, 180)
        {
            Closable = true;
            mOwner = owner;
            mSystem = system;
            mCategorie = Categorie;
            mItemSelect = itemSelect;
            mTool = tool;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 22;
            int decal = 5;

            if (itemSelect >= 0 && itemSelect < mSystem.List.Entrys.Length)
            {
                if( mSystem.List.Entrys[itemSelect].Categorie == mCategorie )
                    mEntry = mSystem.List.Entrys[itemSelect];            
            }
            /*Menu de gauche*/

            for (int c = 0; c < mSystem.List.Categorie.Length; c++) //50+
            {
                AddButtonTrueFalse(x, y + line * scale, 50 + c, (mCategorie == c ? true : false), mSystem.List.Categorie[c]);
                line++;
            }

            line = 13;
            AddSimpleButton(x, y + line * scale, 35, ( mTool.Metal == null ? "Choisir Metal" : "Metal: "+mTool.Metal.Ressource.ToString() ));
            line++;
            AddSimpleButton(x, y + line * scale, 36, (mTool.Cuir == null ? "Choisir Cuir" : "Cuir: " + mTool.Cuir.Ressource.ToString()));
            line++;
            AddSimpleButton(x, y + line * scale, 37, (mTool.Os == null ? "Choisir Os" : "Os: " + mTool.Os.Ressource.ToString()));
            line++;
            AddSimpleButton(x, y + line * scale, 38, (mTool.Bois == null ? "Choisir Bois" : "Bois: " + mTool.Bois.Ressource.ToString()));


            /*Liste de droite*/
            x = XCol;
            line = 0;

            for (int i = 0; i < mSystem.List.Count; i++) //100+
            {
                if (mSystem.List.Entrys[i].Categorie == mCategorie /*&& cando*/ )
                {
                    AddSimpleButton(x, y + line * scale, 100 + i, mSystem.List.Entrys[i].Name);
                    line++;
                }
            }

            /*Fiche de description & Craft Button*/
           
            if (mEntry != null)
            {
                x = Largeur + 50;
                line = 14;
                int fondLargeur = 150;
                int fondHauteur = 350;
                int hauteurItem = 100;
                Item item = null;
                try { item = mEntry.ToCraft.GetConstructor(Type.EmptyTypes).Invoke(null) as Item; }
                catch { }
                AddBackground(x, y, fondLargeur, fondHauteur, 0x1400); //Fond Pierre
                AddAlphaRegion(x + 5, y + 5, fondLargeur - 10, hauteurItem);//Alpha de l'apperçu d'item
                AddAlphaRegion(x + 5, y + 10 + hauteurItem, fondLargeur - 10, fondHauteur - hauteurItem);//Alpha de la description
                if (item != null) //Apperçu
                    AddItem(x + 20, y + 40, item.ItemID);
                AddLabel(x+8, y+5, ColorTextYellow, mEntry.Name);

                string infos = "";

                infos += "<i>Mini skill</i>: " + mEntry.MinValue.ToString();
                infos += "<br><i>Difficulté(Moy.10)</i>: " + mEntry.Diff.ToString();
                infos += "<br>";
                for (int r = 0; r < mEntry.Ressource.Length; r++)
                    infos += "<br><i>" + mEntry.Ressource[r].RType.GetType().ToString() + "</i>: " + mEntry.Ressource[r].Number.ToString();

                AddHtml(x + 8, y + 15 + hauteurItem, fondLargeur - 10, fondHauteur - hauteurItem - 65, infos, true, false);
                AddSimpleButton(x + 8, y + line * scale, 40, "Créer cet objet");
                if (item != null)
                    item.Delete();
            }


        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID >= 50 && info.ButtonID < 100) //Changement de catégorie
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, info.ButtonID - 50, -1));
            }
            else if (info.ButtonID >= 100 && info.ButtonID < 500) //Selection d'item
            {
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, info.ButtonID - 100));
            }
            else if (info.ButtonID == 35) //Choix du métal
            {
                if (mTool != null)
                    mTool.GetNewMetal(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mItemSelect));
            }
            else if (info.ButtonID == 36) //Choix du Cuir
            {
                if (mTool != null)
                    mTool.GetNewCuir(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mItemSelect));
            }
            else if (info.ButtonID == 37) //Choix du Os
            {
                if (mTool != null)
                    mTool.GetNewOs(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mItemSelect));
            }
            else if (info.ButtonID == 38) //Choix du Bois
            {
                if (mTool != null)
                    mTool.GetNewBois(mOwner);
                mOwner.SendGump(new GumpArtisan(mTool, mSystem, mOwner, mCategorie, mItemSelect));
            }
            else if (info.ButtonID == 40) //Craft !
            {
                mSystem.TryCraft(mOwner, mTool, mEntry);
            }
        }
    }
}
