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
    public class CraftEntry
    {
        private Type m_toCraft;
        private int m_categorie;
        private int m_minValue;
        private int m_diff;
        private RessourceNeed[] m_ressources;
        private string m_name;
        private Type m_artisannat;

        public int Categorie { get { return m_categorie; } }
        public string Name { get { return m_name; } }
        public Type ToCraft { get { return m_toCraft; } }
        public int MinValue { get { return m_minValue; } }
        public int Diff { get { return m_diff; } }
        public RessourceNeed[] Ressource { get { return m_ressources; } }
        public Type Artisannat { get { return m_artisannat; } }

        public CraftEntry(Type _art, string _name, int _cat, Type _toCraft, int _minValue, int _diff, RessourceNeed[] _ressources)
        {
            m_artisannat = _art;
            m_categorie = _cat;
            m_toCraft = _toCraft;
            m_minValue = _minValue;
            m_diff = _diff;
            m_ressources = _ressources;
            m_name = _name;
        }
    }
}
