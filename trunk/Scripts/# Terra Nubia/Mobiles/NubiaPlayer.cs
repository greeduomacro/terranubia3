using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using System.Collections;
using Server.Gumps;
using Server.Spells;
using System.Reflection;
using Server.Regions;

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
        private int mXP = 0;

        #region Vie & Compagnie
        public override int HitsMax
        {
            get
            {
                int max = 4;
                foreach (Classe c in GetClasses())
                {
                    max = c.GetDV * c.Niveau;
                }
                max += (int)(DndHelper.GetCaracMod(this, DndStat.Constitution, true) * Niveau);

                switch (this.CurrentMoral)
                {
                    case Moral.Depression: max -= max / 4; break;
                    case Moral.Deprime: max -= max / 10; break;
                    case Moral.Bas: max -= max / 20; break;
                }
                if (max < 4)
                    max = 4;
                // max *= 5;
                return max;
            }
        }
        public override int ManaMax
        {
            get
            {
                int max = 20;

                switch (this.CurrentMoral)
                {
                    case Moral.Depression: max -= max / 4; break;
                    case Moral.Deprime: max -= max / 10; break;
                    case Moral.Bas: max -= max / 20; break;
                }
                if (max < 4)
                    max = 4;
                return max;
            }
        }
        public override int StamMax
        {
            get
            {
                int max = 10 + Niveau;

                max += (int)(DndHelper.GetCaracMod(this, DndStat.Constitution, true) * Niveau);
                switch (this.CurrentMoral)
                {
                    case Moral.Depression: max -= max / 4; break;
                    case Moral.Deprime: max -= max / 10; break;
                    case Moral.Bas: max -= max / 20; break;
                }
                if (max < 4)
                    max = 4;

                return max;
            }
        }
        #endregion

        public override int[] BonusAttaque
        {
            get
            {
                //On compte déjà le nbr de coup bonus.
                int maxCoup = 1;

                int buffbonus = base.BonusAttaque[0];

                foreach (Classe c in GetClasses())
                {
                    if (DelugeDeCoup && c is ClasseMoine)
                    {
                        ClasseMoine cmoine = c as ClasseMoine;
                        if (cmoine.DelugeCoup[c.Niveau].Length > maxCoup)
                            maxCoup = cmoine.DelugeCoup[c.Niveau].Length;
                    }
                    else if (c.BonusAttaque[c.Niveau].Length > maxCoup)
                        maxCoup = c.BonusAttaque[c.Niveau].Length;
                }
                int[] bonii = new int[maxCoup];
                //initialisation
                for (int n = 0; n < bonii.Length; n++)
                    bonii[n] = buffbonus;
                //Config
                foreach (Classe c in GetClasses())
                {
                    if (DelugeDeCoup && c is ClasseMoine)
                    {
                        ClasseMoine cmoine = c as ClasseMoine;
                        for (int i = 0; i < cmoine.DelugeCoup[c.Niveau].Length; i++)
                            bonii[i] += cmoine.DelugeCoup[c.Niveau][i];
                    }
                    else
                    {
                        for (int i = 0; i < c.BonusAttaque[c.Niveau].Length; i++)
                            bonii[i] += c.BonusAttaque[c.Niveau][i];
                    }
                }
              

                return bonii;
            }
        }
        public override int getBonusReflexe()
        {
            return getBonusReflexe(MagieEcole.None);
        }
        public override int getBonusReflexe(MagieEcole ecole)
        {

            int bonus = base.getBonusReflexe(ecole);


                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusReflexe[c.Niveau];
                }
                return bonus;
            
        }
        public override int getBonusVigueur()
        {
            return getBonusVigueur(MagieEcole.None);
        }
        public override int getBonusVigueur(MagieEcole ecole)
        {

            int bonus = base.getBonusVigueur(ecole);

                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusVigueur[c.Niveau];
                }
                if (ecole == MagieEcole.Enchantement && hasDon(DonEnum.Serenite))
                    bonus += 2;
                return bonus;
            
        }
        public override  int getBonusVolonte()
        {
            return getBonusVolonte(MagieEcole.None);
        }
        public override  int getBonusVolonte(MagieEcole ecole)
        {
            int bonus = base.getBonusVolonte(ecole);

                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusVolonte[c.Niveau];
                }
                if (ecole == MagieEcole.Enchantement && hasDon(DonEnum.Serenite))
                    bonus += 2;
                return bonus;
            
        }

        private Dictionary<Type, Classe> m_Classes = new Dictionary<Type, Classe>();
        private ClasseType m_lastClasse = ClasseType.Maximum;

        [CommandProperty(AccessLevel.GameMaster)]
        public override int Niveau { get { return XPHelper.GetLevelForXP(mXP); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int XP { get { return mXP; } }

        public void ResetXP()
        {
            GiveXP(-mXP);
        }


        public int getNiveauClasse(ClasseType cl)
        {
            int niv = 0;
            foreach (Classe c in GetClasses())
            {
                if (c.CType == cl)
                {
                    niv = c.Niveau;
                    break;
                }
            }
            return niv;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual double CA
        {
            get
            {
                double ca = base.CA;
                double armureMod = DndHelper.GetArmorCA(this);

                double bouclierMod = 0.0; //ToDO
                if (getBouclier() != null)
                    bouclierMod = getBouclier().CA;

                // CA DU MOINE
                if (hasClasse(ClasseType.Moine))
                {
                    if (armureMod < 1 && bouclierMod <= 0)
                    {
                        double sagCA = DndHelper.GetCaracMod(this, DndStat.Sagesse);
                        if (sagCA > 0)
                            armureMod += sagCA;

                        armureMod += (int)(getNiveauClasse(ClasseType.Moine) / 5);

                    }
                }
                return ca;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string StringClasses
        {
            get
            {
                if (GetClasses().Count > 0)
                {
                    string cs = "";
                    foreach (Classe c in GetClasses())
                    {
                        cs += c.CType.ToString();
                        cs += " / ";
                    }
                    return cs;
                }
                else
                    return "Aucune";
            }
        }

       
        public bool MakeClasse(Type type, int niveau)
        {
            if (type == null)
                return false;
            bool ok = false;
            if (niveau > 20)
                niveau = 20;
            //Console.WriteLine("Make Classe: "+type+" * "+niveau );
            if (m_Classes.ContainsKey(type))
            {
                if (niveau <= 0)
                {
                    SendMessage(53, "Vous perdez la classe {0}", m_Classes[type].CType.ToString());

                    m_Classes.Remove(type);
                }
                else
                {
                    m_Classes[type].Niveau = niveau;
                    SendMessage(82, "Vous êtes maintenant " + m_Classes[type].CType.ToString() + " niveau " + m_Classes[type].Niveau);
                    if (m_Classes[type] is ClasseArtisan)
                    {
                        ClasseArtisan nca = m_Classes[type] as ClasseArtisan;
                        for (int cc = 0; cc < nca.ClasseCompetences.Length; cc++)
                        {
                            Competences.LearnCompetence(nca.ClasseCompetences[cc]);
                        }
                        for (int ctl = 0; ctl < nca.CompToLearn.Length; ctl++)
                        {
                            Competences.LearnCompetence(nca.CompToLearn[ctl]);
                        }
                    }
                }
                ok = true;
            }
            else if (m_Classes.Count < 2)
            {
                Classe classe = Activator.CreateInstance(type) as Classe;
                if (classe != null)
                {
                    classe.Niveau = niveau;
                    m_Classes.Add(type, classe);
                    ok = true;
                    SendMessage("(Changement de Classe)");
                    SendMessage(82, "Vous êtes maintenant " + m_Classes[type].CType.ToString() + " niveau " + m_Classes[type].Niveau);

                }
                else
                {
                    SendMessage(2, "Impossible de créer la classe {0} oppération annulée", type.ToString());
                    ok = false;
                }
            }
            else
                SendMessage("Vous ne pouvez pas multiclasser plus de deux fois !");
            if (ok)
                AfterMakeClasse();
            return ok;
        }
        public int getAchats()
        {
            int achats = 0;
            for (int i = 0; i < (int)CompType.Maximum; i++)
                achats += Competences[(CompType)i].Achat;
            return achats;
        }

        public int getAchatCap()
        {
            int total = (int)DndHelper.GetCaracMod(this, DndStat.Intelligence) * Niveau;
            foreach (Classe c in GetClasses())
                total += c.PtComp * c.Niveau;
            if (total < 0)
                total = 0;
            return total;
        }


        public ICollection<Classe> GetClasses()
        {
            return m_Classes.Values;
        }
        public Classe getClasse(ClasseType type)
        {
            if (hasClasse(type))
            {
                foreach (Classe c in GetClasses())
                {
                    if (c.CType == type)
                        return c;
                }
            }
            return null;
        }
        public void ResetClasse()
        {
            m_lastClasse = ClasseType.Maximum;
            m_Classes = new Dictionary<Type, Classe>();
        }

        public bool hasClasse(ClasseType cl)
        {
            foreach (Classe c in GetClasses())
            {
                if (c.CType == cl)
                    return true;
            }
            return false;
        }

        public Dictionary<Type, Classe> Classes { get { return m_Classes; } }
        public ClasseType LastClasse { get { return m_lastClasse; } set { m_lastClasse = value; } }


        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaArmorType ArmorAllow
        {
            get
            {
                NubiaArmorType tCan = NubiaArmorType.None;
                foreach (Classe c in GetClasses())
                    if (c.ArmorAllow > tCan)
                        tCan = c.ArmorAllow;
                return tCan;
            }
        }

     

        public override bool getCanDoOpportunite()
        {

            if (Weapon is Fists && !hasDon(DonEnum.ScienceDuCombatAMainsNues)) //Pas d'attaque d'opportunité sans arts martiaux;
                return false;
            return base.getCanDoOpportunite();

        }

        public override int ResistanceMagie
        {
            get
            {
                int res =  base.ResistanceMagie;

                if (hasClasse(ClasseType.Moine) && hasDon(DonEnum.AmeDiamant))
                {
                    res += 10 + getNiveauClasse(ClasseType.Moine);
                }

                return res;
            }
        }

        public override void DamageMagic(int amount, Mobile from, MagieEcole ecole)
        {
            if (hasDon(DonEnum.PerfectionEtre))
                amount = Math.Max(amount - 10, 0);
            base.DamageMagic(amount, from, ecole);
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (hasDon(DonEnum.ReductionDegat))
            {
                int reduc = getDonNiveau(DonEnum.ReductionDegat);
                if( from is NubiaPlayer )
                {
                    if( ((NubiaPlayer)from).hasDon(DonEnum.FrappeKi) )
                    {
                        reduc -= ((NubiaPlayer)from).getDonNiveau(DonEnum.FrappeKi);
                        if( reduc < 0 )
                            reduc = 0;
                    }
                }
                amount -= reduc;
            }
          

            if (amount > 0)
                base.OnDamage(amount, from, willKill);
        }

        

        #region Dons
        //Deluge de coup du moin
        public bool DelugeDeCoup = false;


        protected Dictionary<DonEnum, int> mDons = new Dictionary<DonEnum, int>();

        protected Dictionary<DonEnum, int> mDonsUses = new Dictionary<DonEnum, int>();
        protected DateTime mNextDonUse = DateTime.Now;

        public bool canUseDon(BaseDon don)
        {
            if (mNextDonUse > DateTime.Now)
            {
                SendMessage("Il est encore trop tôt pour utiliser un don");
                return false;
            }
            if (hasDon(don.DType))
            {
                if (don.LimiteDayUse)
                {
                    if (!mDonsUses.ContainsKey(don.DType))
                    {
                        mDonsUses.Add(don.DType, 1);
                        return true;
                    }
                    else
                    {
                        int uses = mDonsUses[don.DType];
                        if (uses >= getDonNiveau(don.DType))
                        {
                            SendMessage("Vous ne pouvez plus utiliser ce don (Utilisé déjà {0} fois ce jour)", uses);
                            return false;
                        }
                        else
                        {
                            uses++;
                            mDonsUses[don.DType] = uses;
                            return true;
                        }

                    }
                }
                else
                    return true;
            }
            return false;
        }

        public ICollection Dons
        {
            get
            {
                return mDons.Keys;
            }
        }

        public int getDonNiveau(DonEnum don)
        {
            if (mDons.ContainsKey(don))
            {
                return mDons[don];
            }
            return 0;
        }

        public bool hasDon(DonEnum don)
        {
            if (mDons.ContainsKey(don))
                return true;
            return false;
        }
        #endregion

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

        #region Magie ! 

        private Dictionary<ClasseType, MagieList> mMagieLists = new Dictionary<ClasseType, MagieList>();
  //      public DateTime LastSortCast = DateTime.Now;

        private DateTime mNextMagieRestart = DateTime.Now;

        public DateTime NextMagieRestart
        {
            get { return mNextMagieRestart; }
            set { mNextMagieRestart = value; }
        }

        public void MagieRestart()
        {
            foreach (MagieList ml in mMagieLists.Values)
            {
                ml.Restart();
            }
        }

        public MagieList getMagieOf(ClasseType type)
        {
            if (hasClasse(type))
            {
                if (mMagieLists.ContainsKey(type))
                {
                    return mMagieLists[type];
                }
                else
                {
                    Classe cl = getClasse(type);
                    if (cl.Mage != MageType.None)
                    {
                        mMagieLists.Add(type, new MagieList(this, type));
                    }
                }
            }
            return null;
        }

        #endregion

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
       
        public void GiveXP(int Xp)
        {
            if (AccessLevel <= AccessLevel.Player)
            {

                if (DateTime.Now < mTimeXpDelock)
                    return;
                if (mXPJournalier > XPHelper.getMaximumXPJour((int)Cote))
                {
                    mXPJournalier = 0;
                    mTimeXpDelock = DateTime.Now + TimeSpan.FromHours(24);
                    SendMessage("Vous avez atteind votre limite journalière d'XP");
                    return;
                }
                double dXp = (double)Xp;
                dXp *= XPHelper.getXPFactor((int)Cote);
                Xp = (int)dXp;
                if (Xp < 1)
                    Xp = 1;
                mXPJournalier += Xp;
            }

            int niv = Niveau;
            mXP += Xp;
            if (niv < Niveau)
            {
                SendMessage(58, "Vous avez gagnez un niveau !");
                SendMessage("Vous êtes niveau " + Niveau);
                OnLevelChange();
            }
            else if (niv > Niveau)
            {
                SendMessage(58, "Vous avez perdu un niveau !");
                SendMessage("Vous êtes niveau " + Niveau);
            }
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
        public bool isRunning = false;
        protected override bool OnMove(Direction d)
        {
            
            if (AccessLevel != AccessLevel.Player)
                return true;


            isRunning = (d & Direction.Running) != 0;



            if (isRunning)
            {
                if (NextSortCast > DateTime.Now)
                {
                    InterruptCast(this, mLastSortClasse);
                }
                Stam -= (int)((double)TotalWeight / 100.0);
                if (AttaqueParTour != 1)
                {
                    AttaqueParTour = 1;
                    SendMessage("Vous retournez à une attaque par tour");
                }

            }
            else
            {
                if (NextSortCast > DateTime.Now)
                {
                    if (!Competences[CompType.Concentration].check(15, 0))
                    {
                        PrivateOverheadMessage(Server.Network.MessageType.Regular, GumpNubia.ColorTextRed, false, "Vous perdez votre concentration", this.NetState);
                        InterruptCast(this, mLastSortClasse);
                    }
                }
            }

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
                                if (LightCycle.ComputeLevelFor(this) > 10)
                                    NuitModus -= 5;
                                else if (LightCycle.ComputeLevelFor(this) < 10)
                                    NuitModus += 5;
                            }
                            else
                            {
                                if (this.LightLevel > 10)
                                    NuitModus -= 5;
                                else if (this.LightLevel < 10)
                                    NuitModus += 5;
                            }

                            int hideDD = observateur.Competences[CompType.PerceptionAuditive].pureRoll(0);
                            if (isRunning)
                                hideDD += 10;
                            bool reussite = Competences[CompType.DeplacementSilencieux].check(hideDD,0);
                            SendMessage("Jet réussi: {0} DD={1}", reussite, hideDD);

                            if (reussite)
                            {
                                if (observateur is NubiaPlayer)
                                {
                                    observateur.SendMessage("Vous perdez de vue " + Name);
                                    ((PlayerMobile)this).VisibilityList.Remove(observateur);
                                }
                            }
                            else
                            {
                                if (m is NubiaCreature)
                                {
                                    m.Emote("*Révèle {0}", Name);
                                    ((NubiaMobile)this).ActionRevelation();
                                }
                                else if (m is NubiaPlayer)
                                {
                                    List<Mobile> list = ((PlayerMobile)this).VisibilityList;
                                    if (!(list.Contains(((PlayerMobile)m))))
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
            if (Turn % 112 == 0)
            {
                int AutoXP = WorldData.XpGain;
                AutoXP /= 2;
                if (this.Region != null)
                {
                    if (Region is BaseNubiaRegion )
                    {
                        BaseNubiaRegion nubiaRegion = this.Region as BaseNubiaRegion;
                        if (nubiaRegion.CanAutoXP)
                            AutoXP = WorldData.XpGain;
                    }
                }
                GiveXP( (int)AutoXP );
            }
            if (Alive)
            {
                
                if (Turn % 20 == 0)
                {
                    if (mNextMagieRestart <= DateTime.Now)
                    {
                        mNextMagieRestart = DateTime.Now + WorldData.SpellDay();
                        MagieRestart();
                        SendMessage("Vous vous sentez reposez... c'est un nouveau jour qui commence");
                    }
                }
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

            base.OnTurn();

            lock (DebuffList)
            {
                CloseGump(typeof(GumpDebuff));
                if (DebuffList.Count > 0 && Alive)
                {
                    SendGump(new GumpDebuff(this));
                }
            }
            lock (BuffList)
            {
                CloseGump(typeof(GumpBuff));
                if (BuffList.Count > 0 && Alive)
                {
                    SendGump(new GumpBuff(this));
                }
            }            

            
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

        public void AfterMakeClasse()
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

                        if (don == DonEnum.PerfectionEtre)
                            CreatureType = MobileType.Exterieur;

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
            this.CreatureType = MobileType.Humanoide;
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
        private static string getStringBlessure(BlessureGravite g)
        {
            switch (g)
            {
                case BlessureGravite.Legere: return "Légèrement blessé";
                case BlessureGravite.Normal: return "Blessé";
                case BlessureGravite.Grave: return "Gravement blessé";
                case BlessureGravite.TresGrave: return "Très gravement blessé";
                case BlessureGravite.ExtremeGrave: return "Extrêmement blessé";
                case BlessureGravite.DivinGrave: return "Mourrant";
            }
            return "Inconnue";
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


            string infos = "";
            if (BlessureList.Count > 0)
            {
                BlessureGravite highter = BlessureGravite.Legere;
                for (int i = 0; i < BlessureList.Count; i++)
                {
                    if (BlessureList[i] != null)
                    {
                        NubiaBlessure blessure = BlessureList[i] as NubiaBlessure;
                        if (blessure.BGravite > highter)
                            highter = blessure.BGravite;
                    }
                }
                infos += getStringBlessure(highter) + "\n";
            }
            infos += String.Format("{0}, {1}",
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

            writer.Write((int)mXP);
            writer.Write((int)m_lastClasse);

            writer.Write((int)GetClasses().Count);
            foreach (Classe c in GetClasses())
            {
                writer.Write((int)c.CType);
                writer.Write((int)c.Niveau);
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
            mXP = reader.ReadInt();
            m_lastClasse = (ClasseType)reader.ReadInt();

            int countCl = reader.ReadInt();
            for (int cl = 0; cl < countCl; cl++)
            {
                ClasseType ct = (ClasseType)reader.ReadInt();
                int niv = reader.ReadInt();

                Type t = Classe.GetClasse(ct);
                MakeClasse(t, niv);
            }
        }
    }
}
