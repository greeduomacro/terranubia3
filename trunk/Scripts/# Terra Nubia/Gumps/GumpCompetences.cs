using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Spells;

namespace Server.Gumps
{
    public class GumpCompetences : GumpNubia
    {
        private const double Width = 97;

        private NubiaPlayer mOwner;
        private NubiaPlayer mViewer;
        private bool showCap = false;
        public GumpCompetences(NubiaPlayer _owner, NubiaPlayer _viewer)
            : this(_owner, _viewer, false)
        {
           
        }
        private GumpCompetences(NubiaPlayer _owner, NubiaPlayer _viewer, bool _showcap)
            : base("Competences de "+_owner.Name, 540, 400, 260)
        {
            Closable = true;
            mOwner = _owner;
            mViewer = _viewer;
            showCap = _showcap;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 22;
            int decal = 5;

            AddLabel(x, line * scale + y, ColorTextLight, "Pts d'achats: " + mOwner.getAchats() + "/" + mOwner.getAchatCap());
            line++;
            if( showCap )
                AddButton(x, line * scale + y, 211,210,  5, GumpButtonType.Reply, 0);
            else
                AddButton(x, line * scale + y, 210, 211, 5, GumpButtonType.Reply, 0);
            AddLabel(x+20, line * scale + y, ColorText, "Voir les maximales");
            line++;
            
            for (int i = 0; i < (int)CompType.Maximum; i++)
            {
                NubiaCompetence com = mOwner.Competences[(CompType)i];
                if ( !(com is NullCompetence))
                {
                  
                    int colComp = ColorTextGray;
                    if (com.Achat > 0)
                        colComp = ColorText;
                    if (com.isCompetenceClasse)
                        colComp = ColorTextYellow;

                    if (mOwner.getAchats() < mOwner.getAchatCap() && mViewer == mOwner && com.canRaise() )
                        AddSimpleButton(x, y + line * scale, 50 + i, com.Name, colComp);
                    else
                        AddLabel(x, y + line * scale, colComp, com.Name);

                    AddImage(x+150, line * scale + y - 3, 2445);

                    int colval = ColorText;
                    if (com.Achat > 0)
                        colval = ColorTextLight;

                    if (showCap)
                    {
                        AddLabel(x + 190, y + line * scale, colval, com.getMaitrise().ToString());
                        AddLabel(x + 220, y + line * scale, colval, "/ " + com.getCap().ToString());
                    }
                    else
                    {
                        if (com.Achat > 0)
                            AddLabel(x + 165, y + line * scale, ColorTextGray, com.Achat.ToString());

                       
                        string symbol = "";
                        double maitrise = com.getMaitrise();
                        if (maitrise > 0)
                            symbol = "+";
                        int synergie = (int)(maitrise - com.getPureMaitrise());
                        AddLabel(x + 190, y + line * scale, colval, symbol + maitrise.ToString());
                        if (synergie > 0)
                            AddLabel(x + 220, y + line * scale, ColorTextGreen, "(+" + synergie + ")");
                    }
                    line++;
                }
                if (Hauteur < scale * line + scale && x == XBase)
                {
                    x = XCol;
                    line = 0;
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
            if (info.ButtonID == 5)
            {
                showCap = !showCap;
                mViewer.SendGump(new GumpCompetences(mOwner, mViewer, showCap));
            }
            else if (info.ButtonID >= 50)
            {
                from.Competences[(CompType)info.ButtonID - 50].Achat++;
                mViewer.SendGump(new GumpCompetences(mOwner, mViewer, showCap));
            }
        }

    }
}
