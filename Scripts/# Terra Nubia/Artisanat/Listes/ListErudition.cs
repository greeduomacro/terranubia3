using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Engines.Harvest;

namespace Server.Engines
{
    public class ListErudition : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Livres du savoir", //0
                };
            }
        }

        public override void ConstructList()
        {
            //Livres du savoir
            AddEntry("Livre du savoir: Acrobaties", 0, typeof(LivreAcrobaties), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
            AddEntry("Livre du savoir: Art de la magie", 0, typeof(LivreArtMagie), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
            AddEntry("Livre du savoir: Crochetage", 0, typeof(LivreCrochetage), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
           /* AddEntry("Livre du savoir: Decryptage", 0, typeof(LivreDecryptage), 5, 10,
              new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});*/
            AddEntry("Livre du savoir: Désamoçage", 0, typeof(LivreDesamorcage), 5, 10,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
            AddEntry("Livre du savoir: Dressage", 0, typeof(LivreDressage), 5, 10,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
            AddEntry("Livre du savoir: Escamotage", 0, typeof(LivreEscamotage), 5, 10,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
            AddEntry("Livre du savoir: Utilisation d'objet magique", 0, typeof(LivreUtilisationObjetMagique), 5, 10,
             new RessourceNeed[]{ 
                    new RessourceNeed(typeof(NubiaParchemin), 10),});
           
        }

        public ListErudition()
            : base(typeof(CraftEruditionSystem))
        {
        }
    }
}