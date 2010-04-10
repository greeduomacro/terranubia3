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
    public class RessourceNeed
    {
        private Type m_type;
        private int m_number;
        public Type RType { get { return m_type; } }
        public int Number { get { return m_number; } }
        public RessourceNeed(Type _typeressource, int _number)
        {
            m_type = _typeressource;
            m_number = _number;
        }
    }
}
