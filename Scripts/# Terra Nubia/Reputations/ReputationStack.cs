using System;
using System.Collections.Generic;
using Server.Mobiles.NubiaFaction;
using System.Text;

namespace Server.Mobiles
{
    public class ReputationStack
    {
        //STATIC PART
        public static void Configure()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("## Réputation configuration ##");
            FactionsBank = new Dictionary<FactionEnum, BaseFaction>();
            string space = "Server.Mobiles.NubiaFaction";
            List<string> classes = NubiaHelper.getAllClasses(space);
            foreach (string clstr in classes)
            {
                // Console.WriteLine(" - "+clstr);
                Type cltype = Type.GetType(space + "." + clstr);
                // Console.WriteLine("Type: " + cltype);
                if (cltype != null)
                {
                    if ( cltype.IsSubclassOf(typeof(BaseFaction) ) )
                    {
                        try
                        {
                            BaseFaction fac = (BaseFaction)cltype.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                            FactionsBank.Add(fac.Faction, fac);
                            Console.WriteLine("- Faction: " + fac.Name + " (FactionEnum." + fac.Faction.ToString() + ")");
                            fac = null;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            Console.ResetColor();

        }
        private static Dictionary<FactionEnum, BaseFaction> FactionsBank = new Dictionary<FactionEnum, BaseFaction>();

        //INSTANCE PART
        private NubiaPlayer mOwner = null;
        private Dictionary<FactionEnum, int> mReputations =
                                new Dictionary<FactionEnum, int>();
        public ReputationStack(NubiaPlayer owner)
        {
            mOwner = owner;
        }

        private BaseFaction getFaction(FactionEnum fe)
        {
            if (mOwner == null)
                return null;
            if ( !FactionsBank.ContainsKey(fe) )
                return null;
            if ( !mReputations.ContainsKey(fe) )
            {
                mOwner.SendMessage("Vous rencontrez une nouvelle faction: " + FactionsBank[fe].Name);
                mReputations.Add(fe, 0);
            }
            return FactionsBank[fe];
        }

        public int getReputation(FactionEnum fe)
        {
            if (fe == FactionEnum.None)
                return 0;
            BaseFaction fac = getFaction(fe);
            if (fac != null)
                return mReputations[fac.Faction] + fac.ComputeBonus(mOwner);
            return 0;
        }


    }
}
