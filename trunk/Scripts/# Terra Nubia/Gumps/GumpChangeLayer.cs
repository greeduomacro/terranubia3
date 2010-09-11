using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpChangeLayer : GumpNubia
    {
        private NubiaPlayer m_owner;
        private Item m_item;

        public static bool isLayerTorse(Layer layer)
        {
            switch (layer)
            {
                case Layer.Shirt: return true;
                case Layer.OuterTorso: return true;
                case Layer.MiddleTorso: return true;
                case Layer.Waist: return true;
                case Layer.InnerTorso: return true;
            }
            return false;
        }
        public GumpChangeLayer(NubiaPlayer _owner, Item _item)
            : base("Choix du layer", 250, 400)
        {
            m_owner = _owner;
            m_item = _item;

            int y = YBase;
            int x = XBase;
            int line = 1;
            int scale = 30;
            int decal = 5;

            int col = 0;
            int coldecal = 200;

            int limit = 8;

            if (m_item == null || m_owner == null)
                return; 

            bool raceSkin = false;
            Item skin = m_owner.FindItemOnLayer(Layer.Shirt);
            if (skin != null)
            {
                if ( !skin.Movable)
                    raceSkin = true;
            }

            AddLabel(x, y + line * scale, ColorTextGreen, "Layer actuel: " + m_item.Layer.ToString());
            line++;

            if (!raceSkin)
            {
                AddSimpleButton(x, y + line * scale, 50, "Shirt");
                line++;
            }
            AddSimpleButton(x, y + line * scale, 51, "Inner torso");
            line++;
            AddSimpleButton(x, y + line * scale, 52, "Middle torso");
            line++;
            AddSimpleButton(x, y + line * scale, 53, "Outer torso");
            line++;
            AddSimpleButton(x, y + line * scale, 54, "Waist");
            line++;
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
            bool hair = true;

            int id = info.ButtonID;
            if (m_item == null || m_owner == null)
                return; 
            Layer layer = m_item.Layer;

            if (id == 50)
                m_item.Layer = Layer.Shirt;
            else if (id == 51)
                m_item.Layer = Layer.InnerTorso;
            else if (id == 52)
                m_item.Layer = Layer.MiddleTorso;
            else if (id == 53)
                m_item.Layer = Layer.OuterTorso;
            else if (id == 54)
                m_item.Layer = Layer.Waist;
        }
    }
}
