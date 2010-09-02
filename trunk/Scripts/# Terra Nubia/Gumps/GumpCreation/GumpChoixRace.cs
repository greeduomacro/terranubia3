using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class GumpChoixRace : GumpNubia
    {
        private NubiaPlayer m_owner;
        private int choix = 0;
        public GumpChoixRace(NubiaPlayer _owner, int _choix)
            : base("Choix de la race...", 400, 420)
        {
            m_owner = _owner;
            choix = _choix;
            //Closable = true;

            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 30;
            //Humain
            addRaceChoix(x , y + line * scale,  "Humain", 50+(int)RaceType.Humain);
            line++;
            //Demi-Elfe
            addRaceChoix(x , y + line * scale, "Demi-elfe", 50 + (int)RaceType.DemiElf);
            line++;
            //Demi-Orc
            addRaceChoix(x, y + line * scale, "Demi-orc", 50 + (int)RaceType.DemiOrc);
            line++;


            //Halfelin
            addRaceChoix(x , y + line * scale, "Halfelin", 50 + (int)RaceType.Halfelin);
            line++;
            //Elfe lune
            addRaceChoix(x , y + line * scale, "Elfe lunaire", 50 + (int)RaceType.ElfLune);
            line++;
            //Githzerai
            addRaceChoix(x, y + line * scale, "Githzerai", 50 + (int)RaceType.Githzerai);
            line++;

            if (m_owner.CanRaceRestricted)
            {

                   //Elfe
                 addRaceChoix(x, y + line * scale, "Haut Elfe", 50 + (int)RaceType.HautElf);
                line++;
                //Drow
                addRaceChoix(x, y + line * scale, "Elfe Noir", 50 + (int)RaceType.Drow);
                line++;

                //Drakeide
                addRaceChoix(x, y + line * scale, "Drakéïde", 50 + (int)RaceType.Drakeide);
                line++;

                   //ASAMIR
                   addRaceChoix(x, y + line * scale, "Aasimar", 50 + (int)RaceType.Aasimar);
                   line++;
                   //TIEFELIN
                   addRaceChoix(x, y + line * scale, "Tiefelin", 50 + (int)RaceType.Tiefelin);
                   line++;
                   //Changelin
                   addRaceChoix(x, y + line * scale, "Changelin", 50 + (int)RaceType.Changelin);
                   line++;
                   
                  
                   
            }

            if (choix > 0)
            {
                AddSimpleButton(x + 5, y + line * scale +10, 100, "Continuer");
            }

           
        }
        private void addRaceChoix(int x, int y, string race, int ID)
        {
            if (ID == choix)
                AddImage(x + 10, y , 2153);
            else
                AddButton(x + 10, y, 2151, 2152, ID, GumpButtonType.Reply, 0);
            AddLabel(x+ 45, y, ColorText, race);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;

            if (info.ButtonID > 0 && info.ButtonID < 100 || choix <= 0)
            {
                choix = info.ButtonID;
                from.SendGump(new GumpChoixRace(from, choix));
            }
            else if (info.ButtonID == 100)
            {
                from.changeRace((RaceType)choix - 50);
                from.SendGump(new GumpMenuCreation(from));
            }
        }
    }
}
