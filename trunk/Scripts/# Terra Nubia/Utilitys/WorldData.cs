using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
//using Server.Families;
//ajout cefyl hallucination
using System.Reflection;
using Server.Multis;
using Server.Items;
using Server.Mobiles;
//fin ajout cefyl hallucination

namespace Server
{
    public class HairDef
    {
        public int ItemID = 0;
        public string Name = "Cheveux";
        public double skillReq = 10;
        public HairDef(string name, int id, double skill)
        {
            ItemID = id;
            Name = name;
            skillReq = skill;
        }
    }
    public class WorldData
    {
        public static int XpMultiplier = 4500; //Chiffre de la formue X * (niveau^ 1.45)
        public static int XpGain = 1000; //Gain moyen tout les "XpGainInterval"

        public static TimeSpan TimeTour() { return TimeSpan.FromSeconds(8.0); }
        public static TimeSpan SpellDay() { return TimeSpan.FromHours(5); }

        //Cheveux
        public static HairDef[] HairDefList = new HairDef[]{
            new HairDef("Chauve", 0, 15),
            new HairDef("Court", 8251, 18),
            new HairDef("Long", 8252, 18),
            new HairDef("Queue de cheval", 8253, 18),
            new HairDef("Crête", 8260, 18),
            new HairDef("Précieux", 8261, 18),
            new HairDef("Double chignon", 8262, 18),
            new HairDef("Afro", 8263, 18),
            new HairDef("Rasé", 8264, 18),
            new HairDef("Deux nattes", 8265, 18),
            new HairDef("Queue de rat", 8266, 18),

             new HairDef("Rasta", 8866, 22),
            new HairDef("Queue de cheval", 8857, 25),
            new HairDef("Chignon", 8858, 25),            
            new HairDef("Court et plat", 8860, 25),       
            new HairDef("Court de coté", 8867, 25),
            new HairDef("Grande natte", 8868, 25),
            new HairDef("Deux chignons", 8859, 27),
            new HairDef("Long en volume", 8861, 27),
            new HairDef("Long et décoré", 8862, 27),
            new HairDef("Long et mèche", 8863, 27),
            new HairDef("Longues dreads", 8864, 27),
            new HairDef("Long et horné", 8865, 30),
           
        };
        //Barbes
        //Barbes
        public static HairDef[] FacialHairDefList = new HairDef[]{
            new HairDef("Imberbe / Rasé", 0, 18),
            new HairDef("Barbe courte & Moustache", 8267, 18), //ok
            new HairDef("Barbe courte", 8255, 18), //Ok
            new HairDef("Barbe longue & Moustace", 8268, 18),
            new HairDef("Barbe longue", 8254, 18), //OK           
            new HairDef("Bouc", 8256, 18), //ok
            new HairDef("Barbiche", 8269, 18), //ok
            new HairDef("Moustache", 8257, 18), //ok

            new HairDef("Long Bouc", 8874, 22),
            new HairDef("Barbe attachée", 8877, 22),
            new HairDef("Barbe attachée", 8878, 22),
            new HairDef("Barbe attachée", 8877, 22),
            
            new HairDef("Barbe fournie", 8873, 25),            
            new HairDef("Barbe tressée", 8876, 25),
            new HairDef("Barbe attachée", 8877, 25),
            new HairDef("Barbe ornée", 8879, 27),
            new HairDef("Barbe tressée", 8875, 27),
        };
        public static Map MapDefault { get { return Map.Ilshenar; } }
        public static Point3D PointDepart { get { return new Point3D(723, 1355, -61); } }
    //    public static Map MapDefault { get { return Map.Ilshenar; } }
     //   public static Point3D PointDepart { get { return new Point3D(1200, 1132, -25); } }
        public static TimeSpan NextTownJoin { get { return TimeSpan.FromDays(5.0); } }

        public static void Configure()
        {
            // EventSink.BeforeWorldLoad += new BeforeWorldLoadEventHandler(BeforeLoadWorldData);
            //  EventSink.WorldLoad += new WorldLoadEventHandler( LoadWorldData );
            //	EventSink.WorldSave += new WorldSaveEventHandler( SaveWorldData );
            EventSink.ServerStarted += new ServerStartedEventHandler(serverStarted);
        }

        public static void serverStarted()
        {
         //   Server.Engines.CraftableItemScanner.scanItems();

            NubiaDiagnostic.doDiagnostic();

        }
        /*	public static void LoadWorldData()
            {
            }*/
        public static void SaveWorldData(WorldSaveEventArgs args)
        {
            World.Broadcast(0x35, true, "Optimisation du serveur...");
            Dictionary<Serial, Item> list = new Dictionary<Serial, Item>(World.Items);
            List<Item> toDelete = new List<Item>();
            lock (list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null)
                        continue;
                    /*if( list[i] is BaseBuff )
                    {
                        BaseBuff bb = list[i] as BaseBuff;
                        if( bb.Cible == null || bb.Turn == -1 )
                            toDelete.Add( bb );
                    }*/
                }
            }
            int bcount = toDelete.Count;
            for (int d = 0; d < toDelete.Count; d++)
                if (toDelete[0] != null)
                    toDelete.RemoveAt(0);
            World.Broadcast(0x35, true, "Optimisation terminée!");
        }
    }
}
