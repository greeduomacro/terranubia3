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
    public class CraftList
    {
        private List<CraftEntry> mEntrys = new List<CraftEntry>();
        protected Type mSystem = typeof( CraftForgeSystem );

        public int Count { get { return mEntrys.Count; } }
        public CraftEntry[] Entrys
        {
            get
            {
                CraftEntry[] entrys = new CraftEntry[mEntrys.Count];
                mEntrys.CopyTo(entrys);
                return entrys;
            }
        }

        public virtual string[] Categorie
        {
            get
            {
                return new string[]{
                    "Categorie 0", //0
                    "Categorie 1", //1
                    "Categorie 2" //2
                };
            }
        }

        public CraftList(Type _system)
        {
            mSystem = _system;
            ConstructList();
        }

        public void AddEntry(string _name, int _cat, Type _toCraft, int _minValue, int _diff, RessourceNeed[] _ressources)
        {
            CraftEntry entry = new CraftEntry(mSystem, _name, _cat, _toCraft, _minValue, _diff, _ressources);
            mEntrys.Add(entry);
        }

        public virtual void ConstructList()
        {

        }
    }
}