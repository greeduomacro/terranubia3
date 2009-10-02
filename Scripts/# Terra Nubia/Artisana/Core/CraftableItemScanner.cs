using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Server.Items;
using Server.Commands;

namespace Server.Engines
{
    public class CraftableItemScanner
    {
        public static void scanItems()
        {
            Console.WriteLine(".");
            Console.WriteLine("Scans des items pour la liste de craft");
            string space = "Server.Items";
            List<string> classes = NubiaHelper.getAllClasses(space);
            Console.WriteLine("Début du scan");
            foreach (string clstr in classes)
            {
               // Console.WriteLine(" - "+clstr);
                Type cltype = Type.GetType(space+"."+clstr);
               // Console.WriteLine("Type: " + cltype);
                if ( cltype != null)
                {
                 /*   Type[] interfaces = cltype.GetInterfaces();
                    for (int i = 0; i < interfaces.Length; i++)
                    {
                        Console.WriteLine("interface: "+interfaces[i]);
                    }
                    if (cltype.GetInterface(typeof(IEntity).ToString()) != null)
                    {
                        Console.WriteLine(" Match IEntity: " + clstr);
                    }*/
                    if (cltype.GetInterface( typeof(INubiaCraftable).ToString() ) != null)
                    {
                        Console.WriteLine(" Match INubiaCraftable: " + clstr);
                    }
                }
            }
            
            Console.WriteLine("Fin de scan");
        }

        
    }
}
