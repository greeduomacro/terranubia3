using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;

namespace Server.Mobiles
{
    public class WelcomeClassePNJ : BaseWelcomePNJ
    {
        public override string[] Paroles
        {
            get
            {
                return new string[] {
                "Halte là ! Ne croyez pas que je ne vous vois pas !",
                "On veu faire le malin? ça ne marchera pas avec moi !",
                "Alors dites moi... hum... *regard suspicieux*",
                "Vous êtes un 'barbare' ou un 'guerrier'.. A moin que...",
                ".. Vous ne soyez un de ces 'roublard', 'barde' ou autre 'rodeur' trainant...",
                "Vous pourriez tout aussi bien être 'moine', 'prêtre', 'paladin' ou encore un 'druide'",
                "que ça serait pareil pour moi ! Hummm ! Je sais...",
                "vous êtes sans-doute un 'ensorceleur' ou un de ces 'magicien' !",
                "Bon... allez vous me dire... Qui êtes vous ?"
                };
            }
        }
        public override void OnSpeech(SpeechEventArgs e)
        {
            base.OnSpeech(e);

            if (EnTrainDeParler)
                return;
           
            if (e.Mobile is NubiaPlayer)
            {
                NubiaPlayer player = e.Mobile as NubiaPlayer;
                ClasseType classe = ClasseType.Barbare;
                bool classeOk = false;

                if (e.Speech.ToLower().Contains("barbare"))
                {
                    Say("Un barbare? Une de ces grosse brutes ? Si vous l'dites !");
                    classe = ClasseType.Barbare;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("barde"))
                {
                    Say("Un Barde?! Hahaha ! Un barde...");
                    classe = ClasseType.Barde;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("druide"))
                {
                    Say("Un druide... z'avez pas de bestioles avec vous j'espère !");
                    classe = ClasseType.Druide;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("ensorceleur"))
                {
                    Say("Ensorceleur ? Vous savez, moi et la magie...");
                    classe = ClasseType.Ensorceleur;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("guerrier"))
                {
                    Say("Un guerrier ! Voila de quoi ce monde à besoin !! Héhé !");
                    classe = ClasseType.Guerrier;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("magicien"))
                {
                    Say("Un magicien ! Pas de magie sur la nef, sinon je vous met une décullotée!");
                    classe = ClasseType.Magicien;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("moine"))
                {
                    Say("Un moine? Vous n'en avez pas l'air...");
                    classe = ClasseType.Moine;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("paladin"))
                {
                    Say("Un paladin... Paladin qu'il me dit l'autre... bah... qu'est-ce que j'en ai a faire moi ?");
                    classe = ClasseType.Paladin;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("prêtre"))
                {
                    if (player.Female)
                        Say("Une prêtresse? Oh, pardon... je voulais pas être impoli m'dame !");
                    else
                        Say("Un prêtre? Oh, pardon... je voulais pas être impoli mon père");

                    classe = ClasseType.Pretre;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("rodeur"))
                {
                    Say("Un Rodeur? Et faites quoi ici? Vous rodez ?");

                    classe = ClasseType.Rodeur;
                    classeOk = true;
                }
                else if (e.Speech.ToLower().Contains("roublard"))
                {
                    Say("Un Roublard?! Je vous ai à l'oeil, vermine !");

                    classe = ClasseType.Roublard;
                    classeOk = true;
                }

                if (classeOk)
                {


                    Type type = null;
                    try
                    {
                        type = Server.Classe.GetClasse(classe);
                    }
                    catch (Exception ex)
                    {
                        player.SendMessage(ex.Message);
                    }
                    if (type != null)
                    {
                        player.ResetClasse();
                        player.LastClasse = classe;
                        int classeNiv = 1;
                        foreach (Classe cl in player.GetClasses())
                            if (cl.CType == player.LastClasse)
                                classeNiv = cl.Niveau + 1;
                        //if (creation)
                        //from.GiveNiveau(0);

                        player.MakeClasse(type, classeNiv);

                        Say("Allez circulez, l'autre vous attend !");
                        //  from.GiveNiveau(from.Niveau + 1);

                    }
                }
            }
        }
        [Constructable]
        public WelcomeClassePNJ()
        {
            Name = "Norbert Effab";
            Title = "le mercenaire";
            AddItem(new ChainChest());

            AddItem(new PlateArms());
            AddItem(new PlateLegs());

        }
        [Constructable]
        public WelcomeClassePNJ(Serial s)
            : base(s)
        {
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class WelcomeSexePNJ : BaseWelcomePNJ
    {
        public override string[] Paroles
        {
            get
            {
                return new string[] {
                "Approchez, approchez... je suis aveugle mais je vous entend marcher.",
                "Alors dites moi, êtes vous un 'homme' ou une 'femme' ?"
                };
            }
        }
        public override void OnSpeech(SpeechEventArgs e)
        {
            base.OnSpeech(e);
            if (EnTrainDeParler)
                return;

            if (e.Speech.ToLower().Contains("homme"))
            {
                Say("Un homme... bien sûr... Vous pouvez aller dans la prochaine salle...");
                e.Mobile.Female = false;
                e.Mobile.BodyValue = 400;
            }
            else if (e.Speech.ToLower().Contains("femme"))
            {
                Say("Un femme... je le savais... Vous pouvez aller dans la prochaine salle...");
                e.Mobile.Female = true;
                e.Mobile.BodyValue = 401;
            }
        }
        [Constructable]
        public WelcomeSexePNJ()
        {
            Name = "Korg";
            Title = "l'aveugle";
            AddItem(new Robe(Utility.RandomSnakeHue()));
            AddItem(new ShortPants(Utility.RandomRedHue()));
            AddItem(new Sandals());

        }
        [Constructable]
        public WelcomeSexePNJ(Serial s)
            : base(s)
        {
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public class WelcomePNJ : BaseWelcomePNJ
    {
        public override string[] Paroles
        {
            get
            {
                return new string[] {
                "Bienvenue sur Terra Nubia. Votre aventure commence ici.",
                "Mes collègues et moi même allons vous guider pour vos premiers pas",
                "Chacune des salles que vous allez franchir est une étape pour mieu vous connaitre",
                "Quand vous aurez franchit toutes les salles, vous pourrez poser les pieds sur nos terres",
                "Quand moi ou un de mes collèges met un mot entre guillement...",
                "... c'est que c'est un mot clé. Voila un 'exemple'.",
                "Avancez maintenant dans la seconde salle",
                "Si vous n'avez pas tout entendu, vous pouvez nous demander de 'répéter'"
                };
            }
        }
        [Constructable]
        public WelcomePNJ()
        {
            Name = "Altémus";
            Title = "le matelot";
            AddItem(new Shirt());
            AddItem(new ShortPants(Utility.RandomRedHue()));
            AddItem(new Sandals());

        }
        [Constructable]
        public WelcomePNJ(Serial s): base(s)
        {

        }
        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);
            for (int i = 0; i < m.Skills.Length && m is NubiaPlayer; i++)
            {
                m.Skills[i].Cap = 0.0;
                m.Skills[i].Base = 0.0;
            }
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
    }
    public abstract class BaseWelcomePNJ : NubiaCreature
    {
        public virtual string[] Paroles 
        {
            get
            {
                return new string[] { "Bienvenue" };
            }
        }
        private int mParolesIndex = -1;
        private Mobile mLastMobile = null;
        public BaseWelcomePNJ()
            : base(AIType.AI_Animal, FightMode.None, 5, 1, 1, 1)
        {
            BodyValue = 400;
            Female = false;
            Name = "Marcel 'La folle'";
            Frozen = true;
            Hue = Utility.RandomSkinHue();

            Container pack = Backpack;

            if (pack == null)
            {
                pack = new Backpack();
                pack.Movable = false;

                AddItem(pack);
            }

        }
        public BaseWelcomePNJ(Serial s) : base(s) 
        {
            Frozen = true;
        }

        public bool EnTrainDeParler { get { return mParolesIndex != -1; } }

        public override void OnSpeech(SpeechEventArgs e)
        {

            base.OnSpeech(e);
            if (EnTrainDeParler)
                return;
            if (e.Speech.Contains("répéter") ||
                e.Speech.Contains("répété") ||
                e.Speech.Contains("répétez"))
            {
                if (mParolesIndex == -1)
                    mParolesIndex = 0;
            }
        }
        
        public override void  OnMovement(Mobile m, Point3D oldLocation)
        {
            base.OnMovement(m, oldLocation);
            if (mParolesIndex == -1 && m is NubiaPlayer)
            {
                if (m != mLastMobile && m.InRange(this.Location, 5) )
                {
                    mParolesIndex = 0;
                    mLastMobile = m;
                }
            }
        }

        public override void OnTurn()
        {
            base.OnTurn();
            if (mParolesIndex >= 0)
            {
                if (mParolesIndex >= Paroles.Length)
                    mParolesIndex = -1;
                else
                {
                    Say(Paroles[mParolesIndex]);
                    mParolesIndex++;
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
