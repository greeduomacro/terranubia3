using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpFactions : GumpNubia
    {
        private NubiaPlayer mOwner = null;

        public GumpFactions(NubiaPlayer _owner)
            : base("Factions & Réputations", 380, 405)
        {
            Closable = true;
            mOwner = _owner;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 27;
            int decal = 5;

            if (mOwner == null)
                return;
            if (mOwner.ReputationStack == null)
                return;

            for (int i = 0; i < (int)FactionEnum.Maximum; i++)
            {
                FactionEnum faction = (FactionEnum)i;
                if (mOwner.ReputationStack.Reputations.ContainsKey(faction))
                {
                    BaseFaction fac = FactionHelper.getFaction(faction);
                    if (fac != null)
                    {
                        ReputationEnum reput = ReputationEnum.Neutre ;
                       int val =  mOwner.ReputationStack.getReputation(faction) ;
                       reput = FactionHelper.getReputForVal(val);
                        AddImage(x, line * scale + y - 3, 2440);
                        AddLabel(x+10, y + line * scale, ColorText, fac.Name);

                        AddImage(x + 180, line * scale + y - 3, 2440);
                        AddLabel(x + 190, y + line * scale, FactionHelper.getHueForReput(reput), FactionHelper.getNameForReput(reput));
                        line++;

                    }
                }
            }

           
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int id = info.ButtonID;

        
        }
    }
}
