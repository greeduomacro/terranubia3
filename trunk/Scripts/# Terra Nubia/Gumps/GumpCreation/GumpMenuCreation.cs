using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;
using Server.HuePickers;
using Server.Items;

namespace Server.Gumps
{
    public class GumpMenuCreation : GumpNubia
    {
        private NubiaPlayer m_owner;

        public GumpMenuCreation(NubiaPlayer _owner)
            : base("Menu de création...", 480,290,275)
        {
            m_owner = _owner;
         //   Closable = false;
            
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 30;
            int decal = 5;

            string description = "<center>Création de personnage</center><p>Bienvenue sur Terra Nubia. Vous devez à présent créer votre personnage.<br>Toutes les étapes doivent passer 'verte' afin de valider votre création et de débuter le jeu.";
            AddHtml(x, y, LargeurColonne1, Hauteur, description, false, true);

            x = XCol;

            AddValidButton(x, y + line * scale, 1, RaceValide(m_owner), ( m_owner.Race == null ? "Votre race" : "Race: "+m_owner.Race.Name ));
            line++;
            AddValidButton(x, y + line * scale, 7, CouleurValide(m_owner), "Couleur de peau");
            line++;
            AddValidButton(x, y + line * scale, 2, BeauteValide(m_owner), (m_owner.Beaute == Apparence.Hideux ? "Votre Apparence" : "Apparence: "+m_owner.GetBeaute()));
            line++;
            AddValidButton(x, y + line * scale, 3, ClasseValide(m_owner), (m_owner.LastClasse == ClasseType.Maximum ? "Votre classe" : "Classe: "+m_owner.LastClasse.ToString() ));
            line++;
          
           /* AddValidButton(x, y + line * scale, 4, AlignementValide(m_owner), (m_owner.Align == Alignement.None ? "Votre Alignement" : "Alignement: "+AlignHelper.GetName(m_owner.Align)));
            line++;*/
            if (m_owner.Race != null)
            {
                if (m_owner.Race.AllowHair)
                {
                    AddButtonTrueFalse(x, y + line * scale, 8, false, "Coupe de cheveux");
                    line++;
                }
                if (m_owner.Race.AllowFacialHair && !m_owner.Female)
                {
                    AddButtonTrueFalse(x, y + line * scale, 9, false, "Pilosité");
                    line++;
                }
                AddValidButton(x, y + line * scale, 10, true, "Couleur des cheveux");
                line++;
            }

            if (AllIsValide(m_owner))
            {
                //AddLabel( _x, y, 0, "Continuer");
                AddButton(x, y + (line * scale), 0x850, 0x851, 99, GumpButtonType.Reply, 0);
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            NubiaPlayer from = f as NubiaPlayer;
            int id = info.ButtonID;
            if (id == 1)
            {
                from.HairItemID = 0;
                from.FacialHairItemID = 0;
                from.SendGump(new GumpChoixRace(from, -1));
            }
            else if (id == 2)
                from.SendGump(new GumpBeaute(from, -1));
            else if (id == 3)
            {
                from.ResetClasse();
                from.SendGump(new GumpChoixClasse(from, true));
            }
            else if (id == 4)
            {
                if (from.Race != null)
                {
                    //from.SendGump(new GumpAlignement(from, -1));
                }
                else
                {
                    from.SendMessage(43, "Choisissez une race avant tout");
                    from.SendGump(new GumpMenuCreation(from));
                }
            }
            else if (id == 7)
            {
                if (from.Race != null)
                {
                    from.SendGump(new CustomHuePickerGump(from, from.Race.HuePicker, new CustomHuePickerCallback(SetRaceHue), null));
                }
                else
                {
                    from.SendMessage(43, "Choisissez une race avant tout");
                    from.SendGump(new GumpMenuCreation(from));
                }
            }
            else if (id == 8)
                from.SendGump( new GumpChoixCheveux(from, -1,0));
            else if (id == 9)
                from.SendGump(new GumpChoixBarbe(from, -1, 0));
            else if (id == 10)
            {
                from.SendGump(new GumpCouleurCheveux());
               
            }
            else if (id == 99)
            {
                from.RawStr = 8;
                from.RawDex = 8;
                from.RawInt = 8;
                from.RawCha = 8;
                from.RawCons = 8;
                from.RawSag = 8;
                from.resetCompetences();
                from.GiveXP(50);
                from.SendMessage(99, "Bienvenue sur Terra Nubia");
              //  from.SendMessage("De la teinture pour cheveux à été placée dans votre sac");
              //  from.Backpack.AddItem(new HairDye());

                from.Dons.Reset();
                from.DonCredits.Clear();
                from.DonCredits.Add(ClasseType.None, 1);
                if (from.Race is RaceHumain)
                    from.DonCredits.Add(ClasseType.None, 1);
                Classe classe = null;
                foreach (Classe c in from.GetClasses())
                {
                    classe = c;
                    break;
                }
                if( classe != null )
                    from.Dons.LearnDonClasse(classe, 1);

                from.Frozen = false;

                // ZONE DE DEPART : 
                from.Map = Map.Trammel;
                //from.MoveToWorld(new Point3D(3508, 2766, 0), Map.Felucca);
                from.MoveToWorld(new Point3D(1200, 1132, -25), Map.Ilshenar);
                from.Hits = from.HitsMax;
            }

        }
        private static void SetRaceHue(Mobile from, object state, int hue)
        {
            from.Hue = hue;
          /*  foreach (Item item in from.Items)
            {
                if (item is IRaceSkin)
                {
                    ((IRaceSkin)item).Color(from);
                    break;
                }
            }*/
            from.SendGump(new GumpMenuCreation(from as NubiaPlayer));
        }

        public bool AllIsValide(NubiaPlayer from)
        {
            return (
                RaceValide(from) 
                && BeauteValide(from) 
              //  && AlignementValide(from) 
                && ClasseValide(from) 
                && CouleurValide(from)
            );
        }

        public static bool CouleurValide(NubiaPlayer from)
        {
            if (from.Race == null)
                return false;
            for (int i = 0; i < from.Race.HuePicker.Groups.Length; i++)
            {
                for (int j = 0; j < from.Race.HuePicker.Groups[i].Hues.Length; j++)
                {
                    int hue = from.Race.HuePicker.Groups[i].Hues[j];
                    if (hue == from.Hue)
                        return true;
                }
            }
            return false;
        }

        public static bool RaceValide(NubiaPlayer from)
        {
            return (from.Race != null);
        }
        public static bool BeauteValide(NubiaPlayer from)
        {
            bool ok = (from.Beaute != Apparence.None);
            if (ok)
            {
                BaseRace race = from.Race;
                ok = (from.Beaute <= from.Race.ApparenceMaxi && from.Beaute >= from.Race.ApparenceMini);
            }
            return ok;
        }
        public static bool ClasseValide(NubiaPlayer from)
        {
            return (from.LastClasse != ClasseType.Maximum);
        }
     /*   public static bool AlignementValide(NubiaPlayer from)
        {
            if (!RaceValide(from) || from.Align == Alignement.None)
                return false;
            return AlignementValide(from.Align, from.Race);
        }
        public static bool AlignementValide(Alignement al, INubiaRace race)
        {

            bool alignBon = (al < Alignement.LoyalNeutre);
            bool alignNeutre = (al >= Alignement.LoyalNeutre && al < Alignement.LoyalMauvais);
            bool alignMauvais = (al >= Alignement.LoyalMauvais);

            //Tout alignement
            if (race is RaceHumain || race is RaceNain)
                return true;
            //Alignement Bon
            else if (race is RaceDrow)
                return (alignMauvais);
            else if (race is RaceElfe)
                return (alignBon);
            else if (race is RaceGaya)
                return (alignBon || alignNeutre);
            else if (race is RaceGobelin)
                return (alignMauvais || alignNeutre);
            else if (race is RaceOrque)
                return (alignMauvais || alignNeutre);
            else if (race is RaceSeth)
                return (alignMauvais || alignNeutre);
            else
                return false;
        }*/

       

       

    }
}
