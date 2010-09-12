using System;
using System.Collections.Generic;

using System.Text;
using Server.Mobiles;
using Server.Items;

namespace Server.Gumps
{
    public class GumpBlessure : GumpNubia
    {
        private NubiaPlayer mOwner;
        private NubiaPlayer mViewer;
        private bool hasKit = false;

        public GumpBlessure(NubiaPlayer _owner, NubiaPlayer _viewer)
            : base("Blessures de " + _owner.Name, 275, _owner.BlessureList.Count*95 + 20)
        {
            Closable = true;
            mOwner = _owner;
            mViewer = _viewer;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 95;
            int decal = 5;

            x += 5;
            y += 7;
            bool isMedecin = mViewer.Competences[CompType.Chirurgie].getPureMaitrise() >= 2;
            hasKit = false;
            if (isMedecin && mViewer != null)
                hasKit = mViewer.Backpack.FindItemByType(typeof(MedecineKit)) != null;
            for (int i = 0; i < mOwner.BlessureList.Count; i++ )
            {
                NubiaBlessure blessure = (NubiaBlessure)mOwner.BlessureList[i];
                AddBackground(x, y + line * scale, 255, 90, 5120);

                AddImage(x + 5, y + line * scale + 5, 10461);
                AddImage(x + 18, y + line * scale + 18, getIcone(blessure.BType));
                AddImage(x + 80, y + line * scale + 10, 2440);
                AddLabel(x + 87, y + line * scale + 10, ColorTextYellow, blessure.BType.ToString() + " " + blessure.GetStringGravite());
                AddLabel(x + 80, y + line * scale + 30, ColorTextLight, "Localisation: " + blessure.GetStringLocalisation());
                bool hemo = blessure.Hemo;
                if (hemo)
                    AddLabel(x + 80, y + line * scale + 50, ColorTextLight, "Hémoragique: " + (hemo ? "oui" : "non"));
                if (isMedecin)
                {
                    AddSimpleButton(x + 80, y + line * scale + 70, 100 + i, "Soigner. " + blessure.SoinStatut + "% effectué");
                }
                line++;
            }

        }
        public int getIcone(BlessureType type)
        {
            switch (type)
            {
                case BlessureType.Brulure: return 20482;
                case BlessureType.Entaille: return 20993;
                case BlessureType.Fracture: return 2247;
                case BlessureType.Hemoragie: return 20481;
                case BlessureType.Perforation: return 21018;
            }
            return 0;
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int id = info.ButtonID;

            if (id >= 100 && id < 200)
            {
                if( mOwner.BlessureList.Count > id-100 )
                {
                    NubiaBlessure blessure = (NubiaBlessure)mOwner.BlessureList[id-100];
                    if( blessure != null )
                    {
                        if (mViewer != mOwner)
                            mViewer.Emote("*commence à soigner {0}*", mOwner.Name);
                        else
                            mViewer.Emote("*commence à se soigner*");
                        int malus = 0;
                        if (!hasKit)
                        {
                            malus = -4;
                            mViewer.SendMessage("Vous n'avez pas de trousse de medecin et subissez donc un malus de circonstance de " + malus.ToString());
                        }
                        new InternalTimer(mOwner, mViewer, blessure, malus).Start();


                    }
                    else
                        mViewer.SendMessage("Cette blessure à été soignée ou s'est dissipée");

                }
            }
        }
        private class InternalTimer : Timer
        {
            private NubiaPlayer mOwner;
            private NubiaPlayer mViewer;
            private NubiaBlessure mBlessure;
            private int malus = 0;

            public InternalTimer(NubiaPlayer _owner, NubiaPlayer _viewer, NubiaBlessure _blessure, int _malus)
                : base(WorldData.TimeTour())
            {
                mOwner = _owner;
                mViewer = _viewer;
                mBlessure = _blessure;
                malus = _malus;
            }
            protected override void OnTick()
            {
                if (mOwner != null && mViewer != null && mBlessure != null)
                {
                    if (mViewer.Competences[CompType.Chirurgie].roll(mBlessure.DD + malus))
                    {
                        int val = DndHelper.rollDe(De.vingt) + (int)DndHelper.GetCaracMod(mViewer, DndStat.Sagesse) 
                            + (int)( DndHelper.GetCaracMod(mViewer, DndStat.Intelligence)/2)
                            + (int)( DndHelper.GetCaracMod(mViewer, DndStat.Dexterite) /2);
                        mBlessure.SoinStatut += val;
                        mViewer.SendMessage("Vous soignez {0} avez succès", mOwner.Name);
                        if (mOwner != mViewer)
                            mViewer.SendMessage("{0} vous soigne avez succès", mOwner.Name);

                        mViewer.GiveXP(50);
                    }
                    else
                    {
                        if (Utility.Random(20) + (int)DndHelper.GetCaracMod(mOwner, DndStat.Constitution) < mBlessure.DD)
                        {
                            int degat = DndHelper.rollDe(De.quatre) + (int)mBlessure.BGravite;
                            if (mBlessure.SoinStatut > 5)
                                mBlessure.SoinStatut -= 5;
                            mOwner.SendMessage("Les soins vous font affreusement souffrir!");

                            mOwner.Damage(degat, mViewer);

                            if (mViewer.Backpack != null && Utility.Random(50) == 1)
                            {
                                MedecineKit kit = (MedecineKit)mViewer.Backpack.FindItemByType(typeof(MedecineKit));
                                if (kit != null)
                                {
                                    mViewer.SendMessage("Vous cassez vous outils");
                                    kit.Delete();
                                }
                            }
                        }
                        else
                            mOwner.SendMessage("Les soins sont raté, mais vous encaissez la douleur");

                        if (mOwner != mViewer)
                            mViewer.SendMessage("Vous ratez vos soins");
                        mViewer.GiveXP(25);

                        if( mOwner.BlessureList.Count > 0 )
                            mViewer.SendGump(new GumpBlessure(mOwner, mViewer));
                    }
                }
            }
        }
    }
}
