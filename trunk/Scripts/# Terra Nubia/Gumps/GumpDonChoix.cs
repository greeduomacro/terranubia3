using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Gumps
{
    public class GumpDonChoix : GumpNubia
    {
        private NubiaPlayer mOwner = null;
        private DonEnum[] list = new DonEnum[10000];
        public GumpDonChoix(NubiaPlayer owner)
            : base("Choix de don", 300, 450)
        {
            Closable = true;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 25;
            int decal = 5;
            mOwner = owner;

            list.Initialize();

            int page = 0;
            if (mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
            {
                DonEntry entry = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse];
                AddLabel(x, y, ColorTextYellow ,"Don supplémentaire de " + Classe.GetNameClasse(entry.Classe) + " niveau " + entry.GiveAtLevel);
                line++;
                DonEnum[] dispos = owner.getClasse(entry.Classe).getCustomDon(mOwner, entry.GiveAtLevel);
                for (int d = 0; d < dispos.Length; d++)
                {
                    if( BaseDon.DonBank.ContainsKey(dispos[d].ToString().ToLower() ) && !mOwner.hasDon(dispos[d] ) )
                    {
                        BaseDon don = BaseDon.DonBank[ dispos[d].ToString().ToLower()  ];
                        list[d] = don.DType;
                        AddSimpleButton(x, y + line * scale, 500 + d, don.Name);
                        line++;
                    }
                }
            }
            else
            {

                int libre = DndHelper.getDonTotal(owner.Niveau);
                if (libre > 0)
                    AddLabel(x, y, ColorTextGreen, "Dons Disponible : " + libre.ToString());
                for (int d = (int)DonEnum.AffiniteMagique; d < (int)DonEnum.Maximum; d++)
                {
                    if (BaseDon.DonBank.ContainsKey(((DonEnum)d).ToString().ToLower()) && !mOwner.hasDon(((DonEnum)d)))
                    {
                        BaseDon don = BaseDon.DonBank[((DonEnum)d).ToString().ToLower()];
                        if (don.hasConditions(mOwner))
                        {
                            list[d] = don.DType;
                            AddSimpleButton(x, y + line * scale, 500 + d, don.Name);
                            line++;
                        }
                    }
                }
            }
        }
        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {

            if (info.ButtonID >= 500)
            {
                int id = info.ButtonID - 500;
                Console.WriteLine(" ID = " + id);
                if (id < list.Length)
                {
                    
                    DonEnum don = list[id];
                    int niv = -1;
                    ClasseType ctype = ClasseType.None;
                    if (mOwner.Dons.DonsEntrys.ContainsKey(DonEnum.DonSupClasse))
                    {
                        niv = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse].GiveAtLevel;
                        ctype = mOwner.Dons.DonsEntrys[DonEnum.DonSupClasse].Classe;
                        mOwner.Dons.DonsEntrys.Remove(DonEnum.DonSupClasse);
                    }
                    mOwner.Dons.DonsEntrys.Add(don, new DonEntry(don, ctype, niv));
                    mOwner.SendMessage("Vous apprennez le don {0}", BaseDon.getDonName(don));
                }
            }
            mOwner.SendGump(new GumpFichePerso(mOwner, mOwner));
           
        }
    }
}
