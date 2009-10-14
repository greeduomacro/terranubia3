using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using System.Collections;
using Server.Gumps;

namespace Server.Mobiles
{
    public enum Apparence
    {
        None = 0,
        Monstrueux = 1,
        Hideux = 2,
        Repoussant = 3,
        Affreux = 4,
        Moche = 5,
        Banal = 6,
        Elegant = 7,
        Seduisant = 8,
        Envoutant = 9,
        Eblouissant = 10
    }
    public enum Moral
    {
        Depression = -3,
        Deprime = -2,
        Bas = -1,
        Normal = 0,
        BonneHumeur = 1,
        SuperHumeur = 2
    }


    public class DeguisementMod
    {
        public string Name = "noname";
        public bool Female = false;
        public RaceType Race = RaceType.None;
        public int Reussite = 0;
        public Dictionary<Serial, DateTime> MobilesChecked = new Dictionary<Serial, DateTime>();
    }

    public class NubiaPlayer : PlayerMobile
    {
        public override int getBonusRoll()
        {
            int bonus = base.getBonusRoll();
            switch (this.CurrentMoral)
            {
                case Moral.Depression: bonus -= 4; break;
                case Moral.Deprime: bonus -= 2; break;
                case Moral.SuperHumeur: bonus += 2; break;
            }
            return bonus;
        }

        

        #region Deguisement
        private DeguisementMod mDeguisementMod = null;

        public void ApplyDeguisement(DeguisementMod deguisement)
        {
            if (mDeguisementMod != null)
            {
                SendMessage("Vous êtes déjà déguisé !");
            }
            else
            {
                mDeguisementMod = deguisement;
                NameMod = mDeguisementMod.Name;
                if( mDeguisementMod.Female != Female )
                    BodyMod = (mDeguisementMod.Female ? 401 : 400);
                if( mDeguisementMod.Race != RaceManager.getRaceType( Race.GetType() ) )
                    HueMod = RaceManager.getRace(mDeguisementMod.Race).HuePicker.Groups[0].Hues[0];
                SendMessage("Vous vous déguisez");
            }
        }
        public void RemoveDeguisement()
        {
            if (mDeguisementMod != null)
            {
                mDeguisementMod = null;
                NameMod = "";
                BodyMod = 0;
                HueMod = 0;
                SendMessage("Vous n'êtes plus déguisé");
            }
        }
        #endregion

        #region MORAL
        private int moralValue = 0; //-100 à 100

        public void changeMoral(int mod)
        {
            Moral oldMoral = Moral.Normal;
           
            oldMoral = this.CurrentMoral;
            moralValue += mod;

            if (moralValue > 100)
                moralValue = 100;
            else if (moralValue < -100)
                moralValue = -100;
           
          
            if (this.CurrentMoral != oldMoral)
            {
                onChangeMoral(oldMoral);
            }
        }

        private void onChangeMoral(Moral oldMoral){
            string old = getMoralString(Female, oldMoral);
            SendMessage("Votre moral à changé vous étiez "+old+" et vous êtes "+MoralString);
        }
        public static string getMoralString(bool female, Moral moral)
        {
            switch (moral)
            {
                case Moral.Depression: return (female ? "dépréssive" : "dépressif");
                case Moral.Deprime: return (female ? "déprimée" : "déprimé");
                case Moral.Bas: return (female ? "légèrement déprimée" : "légèrement déprimé");
                case Moral.Normal: return "en forme";
                case Moral.BonneHumeur: return "de bonne humeur";
                case Moral.SuperHumeur: return "d'excellente humeur";
            }
            return "error";
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public string MoralString
        {
            get
            {
                return getMoralString(Female, this.CurrentMoral);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Moral CurrentMoral
        {
            get
            {
                Moral moral = Moral.Depression;
                if (moralValue < -90)
                    moral = Moral.Depression;
                else if (moralValue < -50)
                    moral = Moral.Deprime;
                else if( moralValue < -10 )
                    moral = Moral.Bas;
                else if( moralValue < 50 )
                    moral = Moral.Normal;
                else if( moralValue < 90 )
                    moral = Moral.BonneHumeur;
                else if( moralValue < 100 )
                    moral = Moral.SuperHumeur;
                return moral;
            }
        }


        #endregion

        #region COTATION SYSTEM & XP

        //Gestion blocage de niveau en fonction de la cote
        public static TimeSpan COTATION_DELAY = TimeSpan.FromHours(65);
        public static TimeSpan COTATION_OFFLINE_DELAY = TimeSpan.FromDays(3);

        public static int HISTORY_SIZE = 100;

        private Dictionary<string, DateTime> mCotationTimes = new Dictionary<string, DateTime>();

        private int mXPJournalier = 0; //Stockage des XP reçu ce jour
        private DateTime mTimeXpDelock = DateTime.Now;
        private double mCote = 10;

        public int getLevelMax()
        {
            return 20;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public double Cote
        {
            get {

                return Math.Round( mCote, 2 );
            }
        }

        public void doCotation(string gmAccount, int value)
        {
            if ( (mCote >= 20 && value > 0) || (mCote <= 1 && value < 0) )
                return;
            if ( isCotable(gmAccount) )
            {
                if (mCotationTimes.ContainsKey(gmAccount))
                    mCotationTimes[gmAccount] = DateTime.Now;
                else
                    mCotationTimes.Add(gmAccount, DateTime.Now);

                mCote += value;
                if (mCote > 20)
                    mCote = 20;
                else if (mCote < 0)
                    mCote = 0;

               // if (value > 0)
               //     SendMessage("Vous avez reçu une cote possitive");
            }
        }

        public bool isCotable(string gmAccount)
        {
            bool iscotable = false;
            if ( !mCotationTimes.ContainsKey( gmAccount ))
                return true;
            
            iscotable = (this.LastOnline + COTATION_OFFLINE_DELAY > DateTime.Now);
            if (iscotable)
            {
                iscotable = mCotationTimes[gmAccount] + COTATION_DELAY < DateTime.Now;
            }
            
            return iscotable;
        }
       
        public override void GiveXP(int Xp)
        {
            if (AccessLevel >= AccessLevel.GameMaster)
            {
                base.GiveXP(Xp);
                return;
            }
            if (DateTime.Now < mTimeXpDelock)
                return;
            if( mXPJournalier > XPHelper.getMaximumXPJour((int)Cote  ))
            {
                mXPJournalier = 0;
                mTimeXpDelock = DateTime.Now + TimeSpan.FromHours(24);
                SendMessage("Vous avez atteind votre limite journalière d'XP");
                return;
            }
            double dXp = (double)Xp;
            dXp *= XPHelper.getXPFactor( (int)Cote );
            Xp = (int)dXp;
            if (Xp < 1)
                Xp = 1;
            mXPJournalier += Xp;
            base.GiveXP(Xp);
        }
        #endregion
        //Variables
        private Apparence m_beaute = Apparence.Banal;
        private RaceType m_race = RaceType.Humain;
        #region Maitrise
        private Dictionary<ArmeTemplate, int> m_maitrises = new Dictionary<ArmeTemplate, int>();

        public void increaseMaitrise(ArmeTemplate t)
        {
            if (!m_maitrises.ContainsKey(t))
                m_maitrises.Add(t, 1);
            else
                m_maitrises[t]++;
        }

        public int PtsMaitriseTotal()
        {
            int t = 0;
            for (int i = 0; i < (int)ArmeTemplate.Maximum; i++)
                if ( m_maitrises.ContainsKey((ArmeTemplate)i) )
                    t += m_maitrises[(ArmeTemplate)i];
            return t;
        }

        public int getMaitrise(ArmeTemplate t)
        {
            if (m_maitrises.ContainsKey(t))
                return m_maitrises[t];
            else
                return -1;
        }

        #endregion
        //HIDE
        //DECTECT PERSONNE CACHE
        protected override bool OnMove(Direction d)
        {
            if (AccessLevel != AccessLevel.Player)
                return true;

            bool running = (d & Direction.Running) != 0;

            if (running)
                Stam -= (int)((double)TotalWeight / 100.0);

            if (Hidden /*&& DesignContext.Find( this ) == null */)	//Hidden & NOT customizing a house
            {
                if (!Mounted /*&& Skills.Stealth.Value >= 25.0*/ )
                {
                        ScruteAlentour();
                        foreach (Mobile m in this.GetMobilesInRange(8))
                        {
                            if (this != m && Hidden && m.AccessLevel == AccessLevel.Player)
                            {
                                NubiaMobile observateur = m as NubiaMobile;
                                //RollResult ReussiteObservateur = ((NubiaMobile)m).RollCompetence(CompType.Perception,70);
                                //int difficulte = (60+(10*((int)ReussiteObservateur)));
                                int NuitModus = 0;
                                if (LightCycle.ComputeLevelFor(this) > this.LightLevel)
                                {
                                    if (LightCycle.ComputeLevelFor(this) > 15)
                                        NuitModus += 5;
                                    else if (LightCycle.ComputeLevelFor(this) < 15)
                                        NuitModus -= 5;
                                }
                                else
                                {
                                    if (this.LightLevel > 15)
                                        NuitModus += 5;
                                    else if (this.LightLevel < 15)
                                        NuitModus -= 5;
                                }

                                int hideDD = observateur.Competences[CompType.PerceptionAuditive].pureRoll();
                                if (running)
                                    hideDD += 20;
                                bool reussite = Competences[CompType.DeplacementSilencieux].check(hideDD);

                                if ( !reussite )
                                {
                                    if (m is NubiaCreature)
                                    {
                                        m.Emote("*Révèle {0}", Name);
                                        ((NubiaMobile)this).ActionRevelation();
                                    }
                                    else if (m is NubiaPlayer)
                                    {
                                        List<Mobile> list = ((PlayerMobile)this).VisibilityList;
                                        if ((list.Contains(((PlayerMobile)m))))
                                        {

                                        }
                                        else
                                        {
                                            list.Add(((PlayerMobile)m));
                                            m.SendMessage("Vous venez de repérer {0} cacher un peu plus loin.", this.Name);
                                            if (Utility.InUpdateRange(m, this))
                                            {
                                                if (m.CanSee(this))
                                                {
                                                    m.Send(new Network.MobileIncoming(m, this));

                                                    if (ObjectPropertyList.Enabled)
                                                    {
                                                        m.Send(this.OPLPacket);

                                                        foreach (Item item in this.Items)
                                                            m.Send(item.OPLPacket);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        
                    }
                }
                else
                {
                    ((NubiaMobile)this).ActionRevelation();
                }
            }

            return true; ;

        }

        public void ScruteAlentour()
        {
            bool Ok;
            List<Mobile> list = this.VisibilityList;
            for (int i = 0; i < list.Count; i++)
            {
                Ok = false;
                ArrayList targets = new ArrayList();
                foreach (Mobile m in this.GetMobilesInRange(10))
                {
                    if (m is PlayerMobile)
                        targets.Add(m);
                }
                for (int d = 0; d < targets.Count; ++d)
                {
                    Mobile m = (Mobile)targets[d];
                    if (m == list[i])
                        Ok = true;
                }
                if (!Ok)
                {
                    list[i].SendMessage("Vous venez de perdre de vue {0}.", this.Name);
                    list[i].Send(this.RemovePacket);
                    list.Remove(list[i]);
                }
            }
        }

        //Equip Armure Gestion
        private bool mArmureEquipAction = false;
        private NubiaArmor mArmureToEquip = null;

        public void FinishArmureEquip() { mArmureEquipAction = false; }
        public void SetArmureToEquip(NubiaArmor a) { mArmureToEquip = a; }



        public override bool OnEquip(Item item)
        {
            if (m_deathTurn <= -1)
            {
                //Attaque d'opportunité a l'équipement
                ExposeToOpportunite();

                if (item is NubiaShield)
                {
                    NubiaShield bouclier = item as NubiaShield;
                    if (bouclier.ParentEntity != this && bouclier.ParentEntity != Backpack)
                    {
                        SendMessage("Le bouclier dois être dans votre sac");
                        return false;
                    }
                    if (bouclier.ArmorType > ArmorAllow)
                    {
                        SendMessage("Vous ne pouvez pas porter ce type de bouclier");
                        return false;
                    }

                }
                if (item is NubiaArmor)
                {
                    NubiaArmor armor = item as NubiaArmor;

                    if (armor.ParentEntity != this && armor.ParentEntity != Backpack)
                    {
                        SendMessage("L'armure dois être dans votre sac");
                        return false;
                    }

                    if (armor.TArmorType > ArmorAllow)
                    {
                        SendMessage("Vous ne pouvez pas porter ce type d'armure");
                        return false;
                    }
                    else if (armor == mArmureToEquip)
                    {
                        mArmureToEquip = null;
                        return true;
                    }
                    else if (mArmureEquipAction)
                    {
                        SendMessage("Vous êtes déjà en train de vous équiper");
                        return false;
                    }
                    else
                    {
                        if (armor.Layer == Layer.InnerTorso || armor.Layer == Layer.Pants || armor.Layer == Layer.Arms)
                        {
                            mArmureEquipAction = true;
                            int turn = 1;
                            if (InCombat)
                            {

                                Emote("*s'harnache avec difficulté*");
                                turn = 2;
                            }
                            else
                            {
                                Emote("*s'harnache*");
                            }
                            new TourEquipArmure(this, armor, turn).Start();
                            return false;
                        }
                        else
                            return true;
                    }

                }
            }
            return base.OnEquip(item);
        }

        private class TourEquipArmure : Timer
        {
            private NubiaPlayer m_Mobile;
            private NubiaArmor mArmor;

            public TourEquipArmure(NubiaPlayer mob, NubiaArmor armor, int nbrTurn)
                : base(TimeSpan.FromSeconds(WorldData.TimeTour().Seconds * nbrTurn))
            {
                Priority = TimerPriority.OneSecond;
                m_Mobile = mob;
                mArmor = armor;
            }

            protected override void OnTick()
            {
                if (m_Mobile != null)
                {
                    m_Mobile.SetArmureToEquip(mArmor);
                    m_Mobile.EquipItem(mArmor);
                    m_Mobile.FinishArmureEquip();
                    m_Mobile.SendMessage("Vous vous équipez");
                }
                Stop();
            }
        }

        public override void OnTurn()
        {
            if (Alive)
            {
                if (Turn % 15 == 0 && mDeguisementMod != null)
                {
                    foreach (PlayerMobile player in GetMobilesInRange(8))
                    {
                        if (mDeguisementMod.MobilesChecked.ContainsKey(player.Serial))
                        {
                            if (mDeguisementMod.MobilesChecked[player.Serial] + TimeSpan.FromMinutes(30) < DateTime.Now)
                                mDeguisementMod.MobilesChecked.Remove(player.Serial);
                        }
                        if (!mDeguisementMod.MobilesChecked.ContainsKey(player.Serial))
                        {
                            mDeguisementMod.MobilesChecked.Add(player.Serial, DateTime.Now);
                            if (player.Competences[CompType.Detection].check(mDeguisementMod.Reussite))
                            {
                                this.PrivateOverheadMessage(Server.Network.MessageType.Regular, 138, false, "*semble déguisé*", player.NetState);
                                player.SendMessage(136, "Vous repérez que {0} est déguisé", NameMod);
                            }
                        }
                    }
                }
            }

            if (m_deathTurn > 0)
            {
                if (Alive)
                {
                    Frozen = false;
                }
                else
                {
                    SendMessage("Vous êtes inconscient pour encore {0} secondes", (6 * m_deathTurn) + 6);
                    Frozen = true;
                }
                m_deathTurn--;
            }
            else if (m_deathTurn <= 0 && !Alive)
            {
                SendMessage("Vous reprennez conscience");
                Resurrect();
                //Emote("*reprend conscience*");
            }

            CloseGump(typeof(GumpDebuff));
            if (DebuffList.Count > 0 && Alive)
            {
                SendGump(new GumpDebuff(this));
            }
            CloseGump(typeof(GumpBuff));
            if (BuffList.Count > 0 && Alive)
            {
                SendGump(new GumpBuff(this));
            }
            base.OnTurn();
        }

        //### MORT ###
        private int m_deathTurn = -1;
        private Corpse m_lastCorpse = null;
        private int m_deathBodySave = 0;
        private DateTime m_lastDeath = DateTime.Now - TimeSpan.FromMinutes(5);
        private ArrayList m_itemToEquip = new ArrayList();
        public override void Resurrect()
        {
            base.Resurrect();
           
            Hits = HitsMax / 10;
            Mana = Mana / 2;
            Stam = StamMax / 2;
            Frozen = false;

            Emote("*Reprend conscience*");
            BodyValue = m_deathBodySave;
            ArrayList itemToPack = new ArrayList();

            foreach (Item item in m_itemToEquip)
            {
                if (item != null)
                {
                    Console.WriteLine("Autoequip: " + item);
                    EquipItem(item);
                }
            }
            if (m_lastCorpse != null)
            {
                if (m_lastCorpse.Items.Count < 1)
                {
                    foreach (Item it in m_lastCorpse.Items)
                    {
                        Console.WriteLine("AutoPackItem (0): " + it);
                        itemToPack.Add(it);
                    }

                    foreach (Item iti in itemToPack)
                    {
                        if (iti != null)
                        {
                            Console.WriteLine("AutoPackItem: " + iti);
                            if (Backpack != null)
                                Backpack.DropItem(iti);
                            else
                                iti.MoveToWorld(Location, Map);
                        }
                    }
                }

                m_lastCorpse.Delete();
            }

            changeMoral(-20);
            m_lastDeath = DateTime.Now;
            m_deathTurn = -1;

          //  Console.WriteLine("End Resurect");

        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);
            if (c is Corpse)
                m_lastCorpse = (Corpse)c;
            Frozen = true;

            //SendGump(new mortGump(this));
        }

        public override bool OnBeforeDeath()
        {
            base.OnBeforeDeath();

            RemoveDeguisement();

            m_itemToEquip = new ArrayList();
            foreach (Item it in Items)
            {
                m_itemToEquip.Add(it);
            }
            if (this.LastKiller != null)
            {
                Mobile kil = this.LastKiller;
                SendMessage("Vous êtes assomé par {0}", kil.Name);
                //kil.Combatant = null;
            }
            //new MortAssomage( this );
           // changeMoral(-20);
            m_deathTurn = Utility.RandomMinMax(2, 4);
            //m_lastDeath = DateTime.Now;
            Frozen = true;
            m_deathBodySave = BodyValue;
            return true;
        }

        public override void AfterMakeClasse()
        {
            //Vérification des dons
            
            //On vire, par sécurité, tout les dons de classe
            List<DonEnum> toRemove = new List<DonEnum>();

                
                foreach (DonEnum d in mDons.Keys)
                {
                    if ( (int)d < 1000) //Don de classe
                        toRemove.Add(d);
                }
                foreach (DonEnum r in toRemove)
                {
                    if (mDons.ContainsKey(r))
                    {
                       // SendMessage("Vous perdez le don: ", r.ToString());
                        mDons.Remove(r);
                    }
                }
            

            foreach ( Classe c in GetClasses() )
            {
                for (int i = 0; i < c.DonClasse.Length && i <= c.Niveau; i++)
                {
                    for (int d = 0; d < c.DonClasse[i].Length; d++)
                    {
                        DonEnum don = c.DonClasse[i][d];
                        if (mDons.ContainsKey(don))
                            mDons[don]++;
                        else
                            mDons.Add(don, 1);

                        if ( !toRemove.Contains(don) )
                        {
                            string dname = "";
                            if (BaseDon.DonBank.ContainsKey(don.ToString().ToLower() ))
                                dname = BaseDon.DonBank[don.ToString().ToLower() ].Name;
                            else
                                dname = don.ToString();
                            SendMessage(2049, "Vous gagnez le don: " + dname + " rang " + mDons[don]);
                        }
                        
                    }
                }
            }

        }

        public NubiaPlayer()
        {
        }
        public NubiaPlayer(Serial s)
            : base(s)
        {
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int NivClassDispo
        {
            get
            {
                int pts = XPHelper.GetClasseNiv(Niveau);
                int nivClass = 0;
                foreach (Classe c in GetClasses())
                {
                    nivClass += c.Niveau;
                }
                return pts - nivClass;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public RaceType RaceType
        {
            get { return m_race; }
        }

        public void changeRace(RaceType newrace)
        {
            m_race = newrace;
        }

        public BaseRace Race
        {
            get { return RaceManager.getRace(m_race); }
        }
        public Apparence Beaute
        {
            get
            {
                return m_beaute;
            }
            set { m_beaute = value; }
        }
        public static string GetBeaute(Apparence app, bool isFemale)
        {
            switch (app)
            {
                case Apparence.Monstrueux: return (isFemale ? "Monstrueuse" : "Monstrueux"); break;
                case Apparence.Hideux: return (isFemale ? "Hideuse" : "Hideux"); break;
                case Apparence.Repoussant: return (isFemale ? "Repoussante" : "Repoussant"); break;
                case Apparence.Affreux: return (isFemale ? "Affreuse" : "Affreux"); break;
                case Apparence.Moche: return (isFemale ? "Moche" : "Moche"); break;
                case Apparence.Banal: return (isFemale ? "Banale" : "Banal"); break;
                case Apparence.Elegant: return (isFemale ? "Elégante" : "Elégant"); break;
                case Apparence.Seduisant: return (isFemale ? "Séduisante" : "Séduisant"); break;
                case Apparence.Envoutant: return (isFemale ? "Envoutante" : "Envoutant"); break;
                case Apparence.Eblouissant: return (isFemale ? "Ebouissante" : "Ebouissant"); break;
            }
            return "Inconnue";
        }
        public string GetBeaute()
        {
            return NubiaPlayer.GetBeaute(this.Beaute, Female);
        }
        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            BaseRace displayRace = Race;
            if (mDeguisementMod != null)
            {
                if( mDeguisementMod.Race != RaceManager.getRaceType(Race.GetType() ) )
                    displayRace = RaceManager.getRace(mDeguisementMod.Race);
            }

            string racename = Female ? displayRace.NameF : displayRace.Name;


            string infos = String.Format("{0}, {1}",
               racename,
                this.GetBeaute()
                );
            Console.WriteLine(infos);
            list.Add(infos);
        }
        public override void OnSingleClick(Mobile from)
        {
//            base.OnSingleClick(from);
            this.PrivateOverheadMessage(Server.Network.MessageType.Regular, 195, false,
                this.Name + ", " + (Female ? Race.NameF : Race.Name),
                from.NetState);
        }

        #region vie & compagnie

        public override int HitsMax
        {
            get
            {
                int hits = base.HitsMax;
                switch (this.CurrentMoral)
                {
                    case Moral.Depression: hits -= hits / 4; break;
                    case Moral.Deprime: hits -= hits / 10; break;
                    case Moral.Bas: hits -= hits / 20; break;
                }
                if (hits < 1)
                    hits = 1;
                return hits;
            }
        }
        public override int ManaMax
        {
            get
            {
                int mana = base.ManaMax;
                switch (this.CurrentMoral)
                {
                    case Moral.Depression: mana -= mana / 4; break;
                    case Moral.Deprime: mana -= mana / 10; break;
                    case Moral.Bas: mana -= mana / 20; break;
                }
                if (mana < 1)
                    mana = 1;

                return mana;
            }
        }
        public override int StamMax
        {
            get
            {
                int stam = base.StamMax;
                switch (this.CurrentMoral)
                {
                    case Moral.Depression: stam -= stam / 4; break;
                    case Moral.Deprime: stam -= stam / 10; break;
                    case Moral.Bas: stam -= stam / 20; break;
                }
                if (stam < 1)
                    stam = 1;

                return stam;
            }
        }
        #endregion
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);//version

            writer.Write((int)m_beaute);
            writer.Write((int)m_race);
            writer.Write((int)m_deathTurn);

            writer.Write((int)mXPJournalier);
            writer.Write((DateTime)mTimeXpDelock);

            writer.Write((int)mCote);
            writer.Write((int)mCotationTimes.Count);
            List<string> gms = new List<string>(mCotationTimes.Keys);
            for (int i = 0; i < gms.Count; i++)
            {
                writer.Write((string)gms[i]);
                writer.Write((DateTime)mCotationTimes[gms[i]]);
            }
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_beaute = (Apparence)reader.ReadInt();
            m_race = (RaceType)reader.ReadInt();
            m_deathTurn = reader.ReadInt();

            mXPJournalier = reader.ReadInt();
            mTimeXpDelock = reader.ReadDateTime();

            if (version >= 1)
            {
                mCote = reader.ReadInt();
                int nbr = reader.ReadInt();
                mCotationTimes = new Dictionary<string, DateTime>();
                for (int i = 0; i < nbr; i++)
                {
                    string gm = reader.ReadString();
                    DateTime time = reader.ReadDateTime();
                    mCotationTimes.Add(gm, time);
                }
            }
        }
    }
}
