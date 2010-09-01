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
            new HairDef("Chauve", 0, 0),
            new HairDef("Court", 8251, 10),
            new HairDef("Long", 8252, 10),
            new HairDef("Queue de cheval", 8253, 10),
            new HairDef("Mohawk", 8260, 10),
            new HairDef("Noble", 8261, 10),
            new HairDef("Burn", 8262, 10),
            new HairDef("Affro", 8263, 10 ),
            new HairDef("Rasé", 8264, 10 ),
            new HairDef("Deux Couettes", 8265, 10),
            new HairDef("Krisna", 8266, 10 ),
            //New :)
            new HairDef("Toupet", 19750, 20),
            new HairDef("Lisse & Court", 13751, 20),
            new HairDef("Grande couette", 13752, 20),
            new HairDef("Ancestral", 13964, 20),
            new HairDef("Long & plaqués", 13965, 20),
            new HairDef("Long & raides", 13968, 20),
            new HairDef("Long cache-visage", 13966, 20),
            new HairDef("Couette fillette", 13967, 20),
            new HairDef("Court & plat", 13980, 20),
            new HairDef("Court en pétard", 13981, 20),
        };
        //Barbes
        //Barbes
        public static HairDef[] FacialHairDefList = new HairDef[]{
            new HairDef("Imberbe / Rasé", 0, 0),
            new HairDef("Barbe courte & Moustache", 8267, 10),
            new HairDef("Barbe longue & Moustace", 8268, 10),
            new HairDef("Bouc", 8269, 10),
            new HairDef("Barbiche", 8256, 10),
            new HairDef("Moustache", 8257, 10),
            new HairDef("Barbe longue", 8254, 10),
            new HairDef("Barbe courte", 8255, 10),
            //New :)
            new HairDef("Mal rasé", 13969, 20),
            new HairDef("Barbe ancestrale", 13970, 20),
            new HairDef("Barbe fine", 13971, 20),
            new HairDef("Barbe tressée", 13972, 20),
            new HairDef("Moustache tressée", 13973, 20),
            new HairDef("Barbe tressée", 13972, 20),
            new HairDef("'Mouske'", 13972, 20),
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
