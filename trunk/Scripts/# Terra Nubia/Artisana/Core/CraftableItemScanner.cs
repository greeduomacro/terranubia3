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
        public static void Configure()
        {
            //ScanItems();
        }
        public static void ScanItems()
        {
            Console.WriteLine(".");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("## Scans craftable item ##");
            string space = "Server.Items";
            List<string> classes = NubiaHelper.getAllClasses(space);
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
                        Console.WriteLine("- INubiaCraftable: " + clstr);
                    }
                }
            }
            Console.ResetColor();
        }

        
    }
}
