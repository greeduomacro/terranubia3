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
    public class ListForge : CraftList
    {
        public override string[] Categorie
        {
            get
            {
                return new string[]{
                    "Armures", //0
                    "Epées longues", //1
                    "Epées courtes" //2
                };
            }
        }

        public override void ConstructList()
        {
            //Armures
            AddEntry("Gants d'anneaux", 0, typeof(RingmailGloves), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 5),
                    new RessourceNeed(typeof(BaseCuir), 2) });
            AddEntry("Bras d'anneaux", 0, typeof(RingmailArms), 5, 10,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 10),
                    new RessourceNeed(typeof(BaseCuir), 3) });
            AddEntry("Jambières d'anneaux", 0, typeof(RingmailLegs), 5, 12,
                new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 12),
                    new RessourceNeed(typeof(BaseCuir), 4) });
            AddEntry("Torse d'anneaux", 0, typeof(RingmailChest), 5, 14,
               new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 15),
                    new RessourceNeed(typeof(BaseCuir), 5) });
            //Epées longues
            AddEntry("Epée longue", 1, typeof(Longsword), 5, 14,
              new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 6),
                    new RessourceNeed(typeof(BaseCuir), 2),
                    new RessourceNeed(typeof(BaseBois), 1)});
            AddEntry("Scimitar", 1, typeof(Scimitar), 5, 14,
              new RessourceNeed[]{ 
                    new RessourceNeed(typeof(BaseMetal), 6),
                    new RessourceNeed(typeof(BaseCuir), 2),
                    new RessourceNeed(typeof(BaseBois), 1)});
        }

        public ListForge(): base( typeof( CraftForgeSystem ) )
        {
        }
    }
}