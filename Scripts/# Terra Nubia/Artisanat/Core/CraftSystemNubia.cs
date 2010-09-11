using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Engines.Harvest;
using Server.Misc;
using Server.Engines.Craft;
namespace Server.Engines
{
    public class CraftSystemNubia
    {
        protected CraftList mList = new ListForge();
        protected CompType mComp = CompType.Forge;
        protected string mName = "Craft System";


        public CraftList List
        {
            get
            {
                return mList;
            }
        }


        public CompType Comp { get { return mComp; } }
        public string Name { get { return mName; } }
        public CraftSystemNubia()
        {
        }
        public void TryCraft(NubiaPlayer crafter, BaseToolNubia tool, CraftEntry entry)
        {
            if (entry == null || crafter == null || tool == null)
            {
                Console.WriteLine("WARNING: Null dans TryCraft ou index invalid");
                return;
            }
            Item newitem = null;

            if (entry.MinValue > crafter.Competences[mComp].getPureMaitrise() )
            {
                crafter.SendMessage("Vous n'êtes pas encore assez doué pour ça...");
                return;
            }
           

            if (crafter.Backpack == null)
            {
                crafter.SendMessage("vous n'avez pas de sac à dos");
                return;
            }

            

            bool allressource = false;
            ArrayList ressourceslist = new ArrayList();
            for (int r = 0; r < entry.Ressource.Length; r++)
            {
                Type type = entry.Ressource[r].RType;
                int nbr = entry.Ressource[r].Number;
                int nbrTrouve = 0;
                int nbrConsume = 0;

                bool badselect = false;
                if (type == typeof(BaseMetal) && nbr > 0)
                {
                    if (tool.Metal != null)
                        type = tool.Metal.GetType();
                    else
                    {
                        crafter.SendMessage(2118, "Vous devez selectionner le Métal");
                        badselect = true;
                    }
                }
                else if (type == typeof(BaseCuir) && nbr > 0)
                {
                    if (tool.Cuir != null)
                        type = tool.Cuir.GetType();
                    else
                    {
                        crafter.SendMessage(2118, "Vous devez selectionner le Cuir");
                        badselect = true;
                    }
                }
                else if (type == typeof(BaseBois) && nbr > 0)
                {
                    if (tool.Bois != null)
                        type = tool.Bois.GetType();
                    else
                    {
                        crafter.SendMessage(2118, "Vous devez selectionner le Bois");
                        badselect = true;
                    }
                }
                else if (type == typeof(BaseOs) && nbr > 0)
                {
                    if (tool.Os != null)
                        type = tool.Os.GetType();
                    else
                    {
                        crafter.SendMessage(2118, "Vous devez selectionner les Os");
                        badselect = true;
                    }
                }
                else if (type == typeof(BaseTissu) && nbr > 0)
                {
                    if (tool.Tissu != null)
                        type = tool.Tissu.GetType();
                    else
                    {
                        crafter.SendMessage(2118, "Vous devez selectionner le Tissu");
                        badselect = true;
                    }
                }
                if (badselect)
                    return;


                bool resIsNotRaffine = false;
                Item notRaffineRes = null;
                BaseRessource itAdd = null;
                foreach (Item ritem in crafter.Backpack.Items)
                {
                    Console.WriteLine("Ritem="+ritem+" :: type="+type);
                    if (ritem.GetType().IsSubclassOf(type) || ritem.GetType() == type)
                    {
                        ConstructorInfo rtor = ritem.GetType().GetConstructor(Type.EmptyTypes);
                        Object robj = rtor.Invoke(null);
                        //itAdd = robj as Item;
                        Console.WriteLine("Same Type");
                        if (ritem is BaseRessource)
                        {
                            Console.WriteLine(((BaseRessource)ritem).isRaffine);
                            if (!((BaseRessource)ritem).isRaffine)
                            {
                                resIsNotRaffine = true;
                                notRaffineRes = ritem;
                                continue;
                            }
                            else
                                itAdd = ritem as BaseRessource;
                        }
                        if (ritem.Amount == 1)
                        {
                            //ritem.Delete();
                            nbrTrouve++;
                        }
                        else if (ritem.Amount < nbr - nbrTrouve)
                        {
                            nbrTrouve += ritem.Amount;
                            //ritem.Delete();
                        }
                        else
                        {
                            nbrTrouve = nbr;
                            //ritem.Amount -= nbr-nbrTrouve;
                        }
                    }
                    if (nbr - nbrTrouve <= 0)
                        break;
                }
                if (itAdd != null)
                    ressourceslist.Add(itAdd);
                if (nbrTrouve < nbr)
                {
                    if(resIsNotRaffine)
                        crafter.SendMessage(2118, "Vous devez raffiner votre {0} avant tout", notRaffineRes.Name);
                    else
                        crafter.SendMessage("Il vous manque des matériaux...");
                    allressource = false;
                }
                else
                {
                    allressource = true;
                    /*Type[] types = new Type[ressourceslist.ToArray().Length];
                    for(int t = 0; t < types.Length; t++)
                        types[t] = ((Item)ressourceslist[t]).GetType();
                    int[] quatitys = new int[entry.Ressource.Length];
                    for(int q = 0; q < quatitys.Length; q++)
                        quatitys[q] = entry.Ressource[q].Number;*/


                }
                if (!allressource)
                    return;
            }
            
            int rollResult = crafter.Competences[mComp].intRoll();
            //crafter.Competences.wait(1);
            if (rollResult > entry.Diff)
            {
                
                newitem = null;

                Console.WriteLine("Craft réussi");

                crafter.GiveXP(50);

                try
                {
                    ConstructorInfo constructor = entry.ToCraft.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        Object obj = constructor.Invoke(null);
                        newitem = obj as Item;
                    }
                    else
                        Console.WriteLine("constructor null dans trycraft");
                }
                catch (Exception ex) { 
                    Console.WriteLine("TryCraft: " + ex.Message);
                    return;
                }

                if (newitem == null)
                {
                    Console.WriteLine("ERROR: newitem == null dans TryCraft");
                    return;
                }
                crafter.SendMessage("Vous reussissez votre création!!");
                if (newitem is INubiaCraftable)
                {
                    Console.WriteLine("Attribution de parametre INubiaCraftable");
                    INubiaCraftable nubitem = newitem as INubiaCraftable;

                    NubiaQualityEnum quality = NubiaQualityEnum.Normale;

                    int delta = rollResult - entry.Diff;
                    if (delta < 5)
                        quality = NubiaQualityEnum.Mauvaise;
                    else if (delta >= 30)
                        quality = NubiaQualityEnum.Maitre;
                    else if (delta >= 20)
                        quality = NubiaQualityEnum.Excellente;
                    else if (delta >= 10)
                        quality = NubiaQualityEnum.Bonne;

                    Console.WriteLine("Quality: " + quality);
                    Console.WriteLine("DELTA = " + delta);

                    nubitem.Artisan = crafter;
                    nubitem.TRessourceList.Clear();
                    bool colored = false;
                    for (int i = 0; i < ressourceslist.Count; i++)
                    {
                     //   Console.WriteLine("Ressources: " + ressourceslist[i].ToString());
                        if (ressourceslist[i] is BaseRessource)
                        {
                            BaseRessource res = ressourceslist[i] as BaseRessource;
                            if (!colored && res.Infos != null)
                            {
                                newitem.Hue = res.Infos.Hue;
                                colored = true;
                            }
                            Console.WriteLine("Ressource enregistrée: " + res.Ressource.ToString());
                           // nubitem.AddRessource((NubiaRessource)res.Ressource);                   
                            nubitem.TRessourceList.Add(res.Ressource);
                        }
                    }
                    Console.WriteLine("After Craft");
                    nubitem.AfterCraft(quality);
                 //   nubitem.ComputeRessourceBonus();
                }
                if (newitem != null && crafter.Backpack != null)
                    crafter.Backpack.AddItem(newitem);
                else if (newitem != null)
                    newitem.MoveToWorld(crafter.Location, crafter.Map);
            }
            else
                crafter.SendMessage("Vous n'arrivez a rien, de la matière première à été perdue");

            Console.WriteLine("Consume Quantity:  ");
            for (int r2 = 0; r2 < entry.Ressource.Length; r2++)
            {
                Type type2 = entry.Ressource[r2].RType;
                int nbr2 = entry.Ressource[r2].Number;
                CraftSystemNubia.ConsumeQuantity(crafter.Backpack, type2, nbr2, tool);
            }
            Console.Write("Ok !");
        }
        public static void ConsumeQuantity(Container cont, Type types, int amounts, BaseToolNubia tool)
        {
            Type type = null;
            if (tool == null)
                return;
            if (types == typeof(BaseMetal))
                type = tool.Metal.GetType();
            else if (types == typeof(BaseCuir))
                type = tool.Cuir.GetType();
            else if (types == typeof(BaseBois))
                type = tool.Bois.GetType();
            else if (types == typeof(BaseOs))
                type = tool.Os.GetType();
            else if (types == typeof(BaseTissu))
                type = tool.Tissu.GetType();
            else
                type = types;
            Item itAdd = null;

            if (type == null)
                return;

            ArrayList targets = new ArrayList();

            foreach (Item ritem in cont.Items)
            {
                //Console.WriteLine("Ritem="+ritem+" :: type="+type);
                if (ritem.GetType().IsSubclassOf(type) || ritem.GetType() == type)
                {
                    targets.Add(ritem);
                }
            }

            for (int i = 0; i < targets.Count; ++i)
            {
                Item ritem = (Item)targets[i];
                ConstructorInfo rtor = ritem.GetType().GetConstructor(Type.EmptyTypes);
                Object robj = rtor.Invoke(null);
                itAdd = robj as Item;
                //Console.WriteLine("Same Type");
                if (ritem is BaseRessource)
                {
                    //	Console.WriteLine("BaseRessource trouvée");
                    //	Console.WriteLine(((BaseRessource)ritem).isRaffine);
                    if (!((BaseRessource)ritem).isRaffine)
                        continue;
                }
                if ((ritem.Amount > amounts) && amounts > 0)
                {
                    ritem.Amount -= amounts;
                    amounts = 0;
                }
                else if ((ritem.Amount == amounts) && amounts > 0)
                {
                    ritem.Delete();
                    amounts = 0;
                }
                else if ((ritem.Amount < amounts) && amounts > 0)
                {
                    amounts -= ritem.Amount;
                    ritem.Delete();
                }
            }


            /*if ( types.Length != amounts.Length )
                throw new ArgumentException();*/

            /*	for ( int i = 0; i < types.Length; ++i )
                {
				
                    int deleted= 0;
                    foreach(Item itemb in cont.Items)
                    {
                        if(itemb.GetType() == types[i] )
                        {
                            if(itemb.Amount <= amounts[i]-deleted){
                                deleted = itemb.Amount;
                                //itemb.Consume();
                            }
                            else{
                                itemb.Amount -= amounts[i]-deleted;
                                deleted = amounts[i];
                            }
                        }
                        if(deleted >= amounts[i])
                            break;
                    }
                }*/
        }

    }
    public class CraftForgeSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftForgeSystem()
        {
            mList = new ListForge();
            mComp = CompType.Forge;
            mName = "Forge d'armure";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if( mSingleton == null )
                    mSingleton = new CraftForgeSystem();
                return mSingleton;
             }
         }
    }

    public class CraftForgeArmeSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftForgeArmeSystem()
        {
            mList = new ListForge();
            mComp = CompType.Forge;
            mName = "Forge d'arme";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if (mSingleton == null)
                    mSingleton = new CraftForgeArmeSystem();
                return mSingleton;
            }
        }
    }

    public class CraftEruditionSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftEruditionSystem()
        {
            mList = new ListErudition();
            mComp = CompType.Erudition;
            mName = "Ecriture";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if (mSingleton == null)
                    mSingleton = new CraftEruditionSystem();
                return mSingleton;
            }
        }
    }

    public class CraftIngenSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftIngenSystem()
        {
            mList = new ListIngen();
            mComp = CompType.Ingenierie;
            mName = "Ingénierie";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if (mSingleton == null)
                    mSingleton = new CraftIngenSystem();
                return mSingleton;
            }
        }
    }

    public class CraftCoutureSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftCoutureSystem()
        {
            mList = new ListCouture();
            mComp = CompType.Couture;
            mName = "Couture";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if (mSingleton == null)
                    mSingleton = new CraftCoutureSystem();
                return mSingleton;
            }
        }
    }

    public class CraftAlchimieSystem : CraftSystemNubia
    {
        private static CraftSystemNubia mSingleton = null;

        private CraftAlchimieSystem()
        {
            mList = new ListAlchimie();
            mComp = CompType.Chimie;
            mName = "Chimie";
        }
        public static CraftSystemNubia Singleton
        {
            get
            {
                if (mSingleton == null)
                    mSingleton = new CraftAlchimieSystem();
                return mSingleton;
            }
        }
    }

}
