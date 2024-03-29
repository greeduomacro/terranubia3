using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public abstract class GumpNubia : Gump
    {
        public static int ColorTitre = 2123;
        public static int ColorText  = 2100;
        public static int ColorTextGreen = 2210;
        public static int ColorTextLight = 2122;
        public static int ColorTextGray = 2403;
        public static int ColorTextYellow = 2212;
        public static int ColorTextRed = 2117;

        public static int RealXBase = 50;
        public static int RealYBase = 50;

        private int m_Largeur;
        private int m_Hauteur;
        private int m_Colonne;

        public int Colone { get { return m_Colonne - 10; } }
        public bool AsColonne { get { return m_Colonne > 50; } }
        public int Largeur { get { return m_Largeur - 10; } }
        public int Hauteur { get { return m_Hauteur - 17; } }
        public static int XBase {get{return RealXBase+20;}}
        public static int YBase { get { return RealYBase+60; } }
        public int XCol { get { return XBase + m_Colonne + 5; } }

        public int LargeurColonne1 { get { return m_Colonne-15; } }
        public int LargeurColonne2 { get { return (Largeur - m_Colonne) - 15; } }

        
        public GumpNubia(string titre, int largeur, int hauteur)
            : this(titre, largeur, hauteur,0)
        {

        }
        public GumpNubia(string titre, int largeur, int hauteur, int colonne)
            : base(20, 20)
        {
            m_Largeur = largeur;
            m_Hauteur = hauteur;
            m_Colonne = colonne;

            int _x = RealXBase;
            int _y = RealYBase;

            int col = _x+m_Colonne;


            AddBackground(_x, _y, m_Largeur, 48, 0x2454); //Parchemin

            AddBackground(_x, _y + 50,  m_Largeur, m_Hauteur, 0x1400); //Fond Pierre

            AddImageTiled(_x, _y, m_Largeur, 18, 0x280A); //Bande 2
            AddImageTiled(_x, _y + 35, m_Largeur, 18, 0x280A); //Bande 1



            if (AsColonne)
            {
                AddAlphaRegion(_x + 5, _y + 56,
                    m_Colonne - 5,  m_Hauteur -10);
                AddAlphaRegion(m_Colonne + _x +5 , _y + 56,
                    (m_Largeur - m_Colonne)-10 , m_Hauteur-10);
            }
            else
                AddAlphaRegion(_x+5, _y + 56,
                   m_Largeur - 10, m_Hauteur - 10);

            AddImage(0, _y-10, 0x28a0); //Dragon
            if( Hauteur >= 250 )
                AddImage(0, _y +150, 0x28a1); //Dragon
            if (Hauteur >= 350)
                AddImage(0, _y +320, 0x28a2); //Dragon
            AddImage(m_Largeur + 18, 46, 0x1582); //Sigle UO

            AddLabel(_x + 30, _y+17, ColorTitre, titre);

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
           
        }

        public void AddValidButton(int x, int y, int id, bool green, string text)
        {
            if (green)
                AddButton(x, y, 0x2c89, 0x2c8a, id, GumpButtonType.Reply, 0);
            else
                AddButton(x, y, 0x2c93, 0x2c94, id, GumpButtonType.Reply, 0);
            AddLabel(x + 20, y-3, (green ? ColorTextLight : ColorTextGray), text);
        }
        public static int[] ButtonID = new int[] { 0x4b9, 0x4ba };
        public void AddButtonTrueFalse(int x, int y, int id, bool select, string text)
        {
            if (select)
                AddImage(x, y, ButtonID[1], 2118);
            else
                AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
            AddLabel(x + 20, y - 3, (select ? ColorTextLight : ColorTextGray), text);
        }
        public void AddSimpleButton(int x, int y, int id, string text)
        {
            AddSimpleButton(x, y, id, text, ColorText);
        }
        public void AddSimpleButton(int x, int y, int id, string text, int color)
        {
            AddButton(x, y, ButtonID[0], ButtonID[1], id, GumpButtonType.Reply, 0);
            AddLabel(x + 20, y - 3, color, text);
        }
        public void AddButtonPageSuivante(int x, int y, int id)
        {
            AddButton(x, y, 4005, 4007, id, GumpButtonType.Reply, 0);
        }
        public void AddButtonPagePrecedante(int x, int y, int id)
        {
            AddButton(x, y, 4014, 4016, id, GumpButtonType.Reply, 0);
        }
    }
}
