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
    public class ListAlchimie : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Baumes & Soin", //0
                };
            }
        }

        public override void ConstructList()
        {
            //Livres du savoir
            AddEntry("Baume d'Althaea", 0, typeof(PotionBaume), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(PlanteSauvageAlthaea), 1),
                new RessourceNeed(typeof(Bottle), 1),});
           

        }

        public ListAlchimie()
            : base(typeof(CraftEruditionSystem))
        {
        }
    }
}