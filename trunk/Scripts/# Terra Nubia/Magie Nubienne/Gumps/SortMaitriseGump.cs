using System;
using System.Collections.Generic;

using System.Text;
using Server.Mobiles;
using Server.Items;
using Server.Spells;

namespace Server.Gumps
{
    public class SortMaitriseGump : GumpNubia
    {
        private NubiaPlayer mOwner;
        private SortDomaine mDomaine = SortDomaine.All;
        private SortEnergie mEnergie = SortEnergie.All;
        private MageSpe mMageSpecialise = MageSpe.Generaliste;

        public SortMaitriseGump(NubiaPlayer _owner)
            : this(_owner, SortDomaine.All, SortEnergie.All,MageSpe.Normal)
        {
        }

        public SortMaitriseGump(NubiaPlayer _owner, SortDomaine domaine, SortEnergie energie, MageSpe amplitude)
            : base("Choix des affinités magiques", 380, 365)
        {
            Closable = true;
            mOwner = _owner;
            mDomaine = domaine;
            mEnergie = energie;
            mMageSpecialise = amplitude;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 22;
            int decal = 5;


            int xoffset = x+20;
            int yoffset = y + 20;
            //Onglets


            //CERCLE
            //Domaines
            int a = 0;
            AddLabel(x, y + line * scale, ColorTextYellow, "Domaines: ");
            line++;
       //     Console.WriteLine("-- CALCUL DOMAINE --");
            for (int d = (int)SortDomaine.All + 1; d < (int)SortDomaine.Maximum; d++)
            {
                int col = ColorTextGray;
                double p = 0;
                if (mDomaine != SortDomaine.All)
                {
                    
                    p = SortNubiaHelper.calculMaitriseDomaine((SortDomaine)d, mDomaine, mMageSpecialise);
                    col = SortNubiaHelper.getHueForPercent((int)p);
                }
                AddSimpleButton(x, y + line * scale, 50 + d, SortNubiaHelper.getDomaineString(((SortDomaine)d) ) + " " +  (p > 0 ? p.ToString() +"%" : ""), col);
               line++;
               a++;
            }

            line = 0;
            AddLabel(x+200, y + line * scale, ColorTextYellow, "Energies: ");
            line++;
          //  Console.WriteLine("-- CALCUL ENERGIE --");
            for (int d = (int)SortEnergie.All + 1; d < (int)SortEnergie.Maximum; d++)
            {
                int col = ColorTextGray;
                double p = 0;
                if (mEnergie != SortEnergie.All)
                {

                    p = SortNubiaHelper.calculMaitriseEnergie((SortEnergie)d, mEnergie, mMageSpecialise);
                    col = SortNubiaHelper.getHueForPercent((int)p);
                }
                AddSimpleButton(x + 200, y + line * scale, 100 + d, SortNubiaHelper.getEnergieString((SortEnergie)d) + " " + p.ToString() + "%", col);
                line++;
                a++;
            }

            
            AddBackground(x, y + line * scale, 300, 25, 3000);
            AddLabel(x + 5, y + line * scale, ColorTextYellow, "Votre choix: ");
            
            AddLabel(x + 100, 1+y + line * scale, ColorTextLight, (mDomaine != SortDomaine.All ? SortNubiaHelper.getDomaineString(mDomaine) : "???") + " / " +
                (mEnergie != SortEnergie.All ? SortNubiaHelper.getEnergieString(mEnergie) : "???"));
            line++;
            line++;

            AddButtonTrueFalse(x, y + line * scale, 501, mMageSpecialise == MageSpe.Generaliste, "Amplitude: Généraliste");
    
            line++;
            AddButtonTrueFalse(x, y + line * scale, 502, mMageSpecialise == MageSpe.Normal, "Amplitude: Normal");
            line++;
            AddButtonTrueFalse(x, y + line * scale, 503, mMageSpecialise == MageSpe.Specialiste, "Amplitude: Spécialisé");
            line++;

            line++;
            if (mDomaine != SortDomaine.All && mEnergie != SortEnergie.All)
            {
                AddSimpleButton(x, y + line * scale, 5, "Je choisi définitivement ces affinités");
            }
            //Description



        }


        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            NubiaPlayer player = sender.Mobile as NubiaPlayer;
            int id = info.ButtonID;
            if (id == 5)
            {
                player.SendMessage("Vous possédez maintenant les affinités " + (mDomaine != SortDomaine.All ? SortNubiaHelper.getDomaineString(mDomaine) : "???") + " / " +
                (mEnergie != SortEnergie.All ? SortNubiaHelper.getEnergieString(mEnergie) : "???"));
                player.Domaine = mDomaine;
                player.Energie = mEnergie;
                
            }
            else if (id >= 501)
            {
                sender.Mobile.SendGump(new SortMaitriseGump((NubiaPlayer)sender.Mobile, mDomaine, mEnergie, (MageSpe)(id - 500)));
            }
            else if (id >= 100)
            {
                SortEnergie ener = (SortEnergie)(id - 100);
                sender.Mobile.SendGump(new SortMaitriseGump((NubiaPlayer)sender.Mobile, mDomaine, ener, mMageSpecialise));
            }   
            else if (id >= 50)
            {
                SortDomaine dom = (SortDomaine)(id-50);
                sender.Mobile.SendGump(new SortMaitriseGump((NubiaPlayer)sender.Mobile, dom, mEnergie, mMageSpecialise));
            }
            
              
        }
    }
}
