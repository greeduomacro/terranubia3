using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server;
using Server.Misc;
using System.Collections;
using Server.Spells;

namespace Server.Mobiles
{
    public enum TailleMob
    {
        Colossal = -8,
        Gigantesque = -4,
        TresGrand = -2,
        Grand = -1,
        Moyen = 0,
        Petit = +1,
        TresPetit = +2,
        Minuscule = +4,
        Infime = +8
    }
    public enum ActionCombat
    {
        None = 0,
        Defense = 1, //+2 CA
        DefenseTotale = 2, //+4 CA. +10 avec pavois. Annulé si on bouge
    }
    /**"Il est possible de se contenter de se déplacer en se défendant, 
     * ce qui constitue une action simple. 
     * Dans ce cas, le personnage se trouve dans l'incapacité d'attaquer 
     * ou de faire quoi que ce soit d'autre que se déplacer 
     * d'une distance égale à sa vitesse de déplacement,
     * mais il bénéficie d'un bonus d'esquive de +4 à la CA pour 1 round. 
     * Sa CA s'améliore dès le début de son action ; 
     * 
     * il profite donc du bonus contre les attaques d'opportunité 
     * qu'il pourrait encourir en se déplaçant"
 donc il peut se défendre avec ce qu'il veut...
     * c'est simplement le fait de se défendre sans attaquer
 sinon, comme je disais, combat sur la défensive, lui,
     * a les bonus et les malus que tu y inscrivais...
     * mais étant une "sous-catégorie" du truc sur l'attaque à outrance
 ça c'est le type d'attaque qu'on peut faire 
     * avec plus d'une attaque par round...
     * avec 2 armes ou arme double surtout, ou magie qui te rend plus rapide je crois
 ouais ça, ou un haut lvl qui te permet d'avoir plus d'une attaque par action
 et l'attaque à outrane entre dans les actions complexes
 mais je sais pas si t'as les trucs qui expliquent les actions simples et complexes..
 mais bon, j'ai un cours qui commence dans 20 min alors je te laisse là dessus*/


    public class NubiaMobile : Mobile
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int Niveau { get { return 1; } }

        #region Magie !
        public DateTime NextSortCast = DateTime.Now;
        protected BaseSort mLastSort = null;
        protected ClasseType mLastSortClasse = ClasseType.Barde;



        public void beginCast(BaseSort sort, ClasseType classe)
        {
            mLastSort = sort;
            mLastSortClasse = classe;
        }

        public void InterruptCast(NubiaMobile from, ClasseType classe) //ContreSort/Chant
        {
            if (mLastSort != null)
            {
                if (mLastSortClasse == classe)
                    mLastSort.Interrupt();
            }
        }

        #endregion


        private TailleMob mTaille = TailleMob.Moyen;
        private MobileType m_CreatureType = MobileType.Animal;
        private List<MobileSousType> m_SousTypes = new List<MobileSousType>();
        private CompetenceStack mCompetences = null;
        private ArrayList m_blessureList = new ArrayList();

        

        //BUFF

       // private List<Blessure> m_blessureList = new List<Blessure>();
        private List<AbstractBaseBuff> m_buffList = new List<AbstractBaseBuff>();
        private List<BaseDebuff> m_debuffList = new List<BaseDebuff>();

        public List<AbstractBaseBuff> BuffList { get { return m_buffList; } }
        public List<BaseDebuff> DebuffList { get { return m_debuffList; } }

        public ArrayList BlessureList { get { return m_blessureList; } }


        public int getDegatBonus()
        {
            int d = 0;
            foreach (AbstractBaseBuff buff in BuffList)
                d += buff.DegatBonus;

            foreach (AbstractBaseBuff debuff in DebuffList)
                d += debuff.DegatBonus;
            return d;
        }

        //Nouvelles stats:
        private int mRawSag = 8, mRawCha = 8, mRawCons = 8;

        
        private int mTurn = 0;
        private int mAttaqueParTour = 1;

        public int AttaqueParTour
        {
            get { return mAttaqueParTour; }
            set { mAttaqueParTour = value; }
        }

        //######### BLESSURES #########
        public void AddBlessure(NubiaBlessure blessure)
        {
            m_blessureList.Add(blessure);
            //if(blessure.BType != TypeBlessure.Hemoragie)
            Emote("*{0}!*", blessure.BType.ToString());
        }
        public void ResetBlessure()
        {
            m_blessureList = new ArrayList();
        }
        public override bool OnBeforeDeath()
        {
            lock (BlessureList)
            {
                foreach (NubiaBlessure blessure in BlessureList)
                {
                    blessure.StopHemo();
                }
            }

            lock (BuffList)
            {
                foreach (AbstractBaseBuff buff in BuffList)
                    buff.End();
            }

            lock (DebuffList)
            {
                foreach (AbstractBaseBuff debuff in DebuffList)
                    debuff.End();
            }

            m_buffList = new List<AbstractBaseBuff>();
            m_debuffList = new List<BaseDebuff>();

            return true;
        }

       


       public virtual void OnTurn() {
			//Console.WriteLine("NubiaMobile :: Tour");
           m_turn++;
           if (m_turn > 1000)
               m_turn = 0;
           NubiaBlessure toRemov = null;

           foreach (NubiaBlessure blessure in BlessureList)
           {
               blessure.OnTurn(this);
               if (blessure.TimeEnd <= DateTime.Now)
               {
                   toRemov = blessure;
                   break;
               }
           }
           if( toRemov != null )
                BlessureList.Remove(toRemov);

            List<AbstractBaseBuff> buffRemoveList = new List<AbstractBaseBuff>();

        
                foreach (AbstractBaseBuff buff in BuffList)
                {
                    if (Alive)
                        buff.OnTurn();
                    if (buff.Turn < 1)
                        buffRemoveList.Add( buff );
                }
            
          
                foreach (AbstractBaseBuff debuff in DebuffList)
                {
                    if (debuff == null)
                        continue;
                    if (Alive)
                        debuff.OnTurn();
                    if (debuff.Turn < 1)
                        buffRemoveList.Add(debuff);
                }
            
            while (buffRemoveList.Count > 0)
            {
                AbstractBaseBuff r = buffRemoveList[0];
                Console.WriteLine("Remove: " + r.Name);
                if (r.IsDebuff)
                    DebuffList.Remove(r as BaseDebuff);
                else
                    BuffList.Remove(r);
                buffRemoveList.RemoveAt(0);
            }
		}
		private class TourTimer : Timer
		{
            private NubiaMobile m_Mobile;

            public TourTimer(NubiaMobile mob)
                : base(WorldData.TimeTour())
			{
				Priority = TimerPriority.OneSecond;
				m_Mobile = mob;
			}

			protected override void OnTick()
			{
				m_Mobile.OnTurn();
				new TourTimer( m_Mobile ).Start();
				Stop();
			}
		}


		public NubiaMobile()
		{
            new TourTimer(this).Start();
		}
        public NubiaMobile(Serial s)
            : base(s)
		{
            new TourTimer(this).Start();
        }

        #region Action spécial durant le tour de combat

        public virtual void DamageMagic(int amount, Mobile from, MagieEcole ecole)
        {
            Damage(amount, from, true);
        }
        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            for (int i = 0; i < DebuffList.Count; i++)
            {
                BaseDebuff deb = DebuffList[i];
                if (deb is Spells.SortSommeil.SommeilDebuff)
                {
                    Frozen = false;
                    DebuffList.Remove(deb);
                    deb.End();
                    break;
                }
            }
            base.OnDamage(amount, from, willKill);
        }

        private DateTime mOpportuniteExposeTime = DateTime.Now;
        private DateTime mLastOpportuniteAction = DateTime.Now;
        private DateTime mLastEtourdiTime = DateTime.Now;

        private ActionCombat mActionCombat = ActionCombat.None;
        public ActionCombat GetActionCombat() { return mActionCombat; }

        public bool IsEtourdi
        {
            get { return mLastEtourdiTime > DateTime.Now - WorldData.TimeTour(); }
        }


        public bool Etourdir(NubiaMobile attacker)
        {
            if (attacker == null)
                mLastEtourdiTime = DateTime.Now;
            else
            {
                //Jet de force contre jet de vigueur.
                int agRoll = Utility.RandomMinMax(1, 20) + (int)DndHelper.GetCaracMod(attacker, DndStat.Force);
                int defRoll = Utility.RandomMinMax(1, 20) + getBonusVigueur();
                if (agRoll > defRoll)
                {
                    mLastEtourdiTime = DateTime.Now;
                    Stam -= agRoll - defRoll;
                    Freeze(WorldData.TimeTour());
                }
                else
                    return false;
            }
            return true;

        }
        public virtual bool getCanDoOpportunite()
        {
           
              
                return mLastOpportuniteAction < DateTime.Now - WorldData.TimeTour();
            
        }


        public bool CheckForOpportunite()
        {
            //D'autre condition créant une opportunité peuvent être répartie dans les scripts
            //Par exemple dans le OnMove() pour le déplacement

            //Pour d'arme a distance ou combat aux point contre une arme sans arts martiaux
            if (Weapon is BaseRanged || Weapon is Fists)
                ExposeToOpportunite();
            

            bool CanOpp = mOpportuniteExposeTime > DateTime.Now;
            return CanOpp;
        }

        public int CheckForOpportuniteResult(NubiaMobile agressor) //Attention, agressor peut être null
        {
            if (!agressor.getCanDoOpportunite())
                return 0;

            //Backstab !
            if (NubiaHelper.LookAt(agressor, this) &&
                  (NubiaHelper.GetDirectionFrom((int)Direction) == NubiaHelper.GetDirectionFrom((int)agressor.Direction) ||
                        agressor.Hidden))
                    {
                        ExposeToOpportunite();
                    }
            if (CheckForOpportunite() && agressor != null)
            {

                    /*1d20 + Bonus Reflexes + Modificateur dexterité
                        contre
                        1d20 + Bonus Reflexes + Modificateur dexterité - 8 */
                    int rollDef = Utility.RandomMinMax(1, 20);
                    int rollAgr = Utility.RandomMinMax(1, 20);

                    if (agressor.Weapon is BaseRanged)
                        rollAgr -= 10;

                    int difference = (rollAgr + agressor.getBonusReflexe() + (int)DndHelper.GetCaracMod(agressor, DndStat.Dexterite))
                                    -
                                    (rollDef + getBonusReflexe() + (int)DndHelper.GetCaracMod(this, DndStat.Dexterite) - 8);

                    agressor.mLastOpportuniteAction = DateTime.Now;
                    if (difference <= 0)
                        agressor.SendMessage("Vous ratez une attaque d'opportunité");

                    return difference;
            }
            else
                return 0;
        }

        public void ExposeToOpportunite()
        {
            mOpportuniteExposeTime = DateTime.Now + WorldData.TimeTour();
        }
        public ActionCombat getActionCombat()
        {
            return mActionCombat;
        }
        public void NewActionCombat(ActionCombat act)
        {
            if (!Warmode)
            {
                SendMessage("Vous devez être en warmod pour effectuer une action de combat");
                mActionCombat = ActionCombat.None;
                return;
            }
            if (act == ActionCombat.Defense && mActionCombat != ActionCombat.Defense)
            {
                mActionCombat = ActionCombat.Defense;
                Emote("*Denfense*");
            }
            else if (act == ActionCombat.DefenseTotale && mActionCombat != ActionCombat.DefenseTotale)
            {
                mActionCombat = ActionCombat.DefenseTotale;
                if (getBouclier() != null)
                {
                    if (getBouclier().BType == BouclierType.Pavois || getBouclier().BType == BouclierType.GrandPavois)
                        Emote("*s'accroupit derrière son bouclier*");
                    else
                        Emote("*Defense totale*");
                }
                else
                    Emote("*Defense totale*");
            }
            else
            {
                SendMessage("Vous ne maintenez plus d'action de combat particulière");
                mActionCombat = ActionCombat.None;
            }

        }
        public virtual int getBonusRoll()
        {
            int bonus = 0;
            //Action défense
            if (getActionCombat() == ActionCombat.Defense)
                bonus -= 4;
            else if (getActionCombat() == ActionCombat.DefenseTotale)
                bonus -= 6;

            return bonus;
        }
        protected override bool OnMove(Direction d)
        {
            //Attaque d'opportunité au mouvement sur les joueurs
            if (!(this is BaseCreature))
            {
                if (LastMoveTime >= DateTime.Now - WorldData.TimeTour())
                    ExposeToOpportunite();
            }

            if (mActionCombat == ActionCombat.DefenseTotale)
            {
                if (getBouclier() != null)
                  if (getBouclier().BType == BouclierType.Pavois || getBouclier().BType == BouclierType.GrandPavois)
                       Emote("*s'accroupit derrière son bouclier*");

                mActionCombat = ActionCombat.None;
            }
            else if( mActionCombat == ActionCombat.Defense )
                mActionCombat = ActionCombat.None;

            return base.OnMove(d);
        }

        public void ActionRevelation()
        {
            if (this.Hidden)
            {
                if (AccessLevel != AccessLevel.Player)
                    return;
                this.Hidden = false;
                this.SendMessage("Vous sortez de l'ombre.");

                Spells.Sixth.InvisibilitySpell.RemoveTimer(this);

                if (this is NubiaPlayer)
                {
                    List<Mobile> list = new List<Mobile>(((PlayerMobile)this).VisibilityList);

                    ((PlayerMobile)this).VisibilityList.Clear();

                    for (int i = 0; i < list.Count; ++i)
                    {
                        Mobile m = list[i];

                        if (!m.CanSee(((PlayerMobile)this)) && Utility.InUpdateRange(m, ((PlayerMobile)this)))
                            m.Send(((PlayerMobile)this).RemovePacket);
                    }
                }
            }

        }

        public NubiaShield getBouclier()
        {
            Item ibouc = FindItemOnLayer(Layer.TwoHanded);
            if (ibouc != null && ibouc is BaseShield)
            {
                NubiaShield bouclier = ibouc as NubiaShield;
                return bouclier;
            }
            return null;
        }
        public void DoAttackTurn()
        {
            if (mActionCombat != ActionCombat.DefenseTotale)
            {
                mActionCombat = ActionCombat.None;
            }
            mTourAttaque++;
        }

        #endregion

        #region Bonus & Tour d'attaque
        private int mTourAttaque = 0; // Pour savoir où l'on en est dans les bonus d'attaque a appliquer


        public int GetAttackTurn()
        {
            //On vérifie que le mTourAttaque soit pas plus haut que le tableau
            if (mTourAttaque >= mAttaqueParTour)
                mTourAttaque = 0;
            return mTourAttaque;
        }

        public virtual int ResistanceMagie
        {
            get { return 0; }
        }

        public virtual int[] BonusAttaque
        {
            get
            {

                int buffbonus = 0;
                foreach (BaseBuff b in BuffList)
                    buffbonus += b.getSauvegarde(SauvegardeEnum.Attaque, MagieEcole.None);
                foreach (BaseDebuff d in DebuffList)
                    buffbonus += d.getSauvegarde(SauvegardeEnum.Attaque, MagieEcole.None);

                return new int[] { buffbonus };
            }
        }
        public virtual int getBonusReflexe()
        {
            return getBonusReflexe(MagieEcole.None);
        }
        public virtual int getBonusReflexe(MagieEcole ecole)
        {
           
                int bonus = 0;

                foreach (BaseBuff b in BuffList)
                    bonus += b.getSauvegarde(SauvegardeEnum.Reflexe, ecole);
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.getSauvegarde(SauvegardeEnum.Reflexe, ecole);

                return bonus;
            
        }
        public virtual int getBonusVigueur()
        {
            return getBonusVigueur(MagieEcole.None);
        }
        public virtual int getBonusVigueur(MagieEcole ecole)
        {
            
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.getSauvegarde(SauvegardeEnum.Vigueur, ecole);
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.getSauvegarde(SauvegardeEnum.Vigueur, ecole);

                return bonus;
            
        }
        public virtual  int getBonusVolonte()
        {
            return getBonusVolonte(MagieEcole.None);
        }
        public virtual  int getBonusVolonte(MagieEcole ecole)
        {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.getSauvegarde(SauvegardeEnum.Volonte, ecole);
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.getSauvegarde(SauvegardeEnum.Volonte, ecole);

            
                return bonus;
            
        }

        #endregion
        private int m_turn = 0;

     



        //Classe sur le Nubia Mobile car elles influance bcp l'attaque, les reflexe, etc...
        //Donc il sera important de l'avoir pour les Streums
        #region Classes & Comps

        public void resetCompetences()
        {
            mCompetences = new CompetenceStack(this);            
        }
       
        
        #endregion




        #region Methodes Get & Set
        [CommandProperty(AccessLevel.GameMaster)]
        public TailleMob Taille
        {
            get { return mTaille; }
            set { mTaille = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public CompetenceStack Competences
        {
            get
            {
                if (mCompetences == null)
                {
                    mCompetences = new CompetenceStack(this);
                }
                return mCompetences;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Cha
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Cha;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Cha;
                return mRawCha + bonus;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int RawCha
        {
            get
            {
                return mRawCha;
            }
            set
            {
                mRawCha = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Cons
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Cons;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Cons;
                return mRawCons + bonus;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int RawCons
        {
            get
            {
                return mRawCons;
            }
            set
            {
                mRawCons = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Sag
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Sag;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Sag;
                return mRawSag + bonus;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int RawSag
        {
            get
            {
                return mRawSag;
            }
            set
            {
                mRawSag = value;
            }
        }

        public override int Str
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Str;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Str;
                return base.Str + bonus;
            }
            set
            {
                base.Str = value;
            }
        }
        public override int Int
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Int;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Int;
                return base.Int + bonus;
            }
            set
            {
                base.Int = value;
            }
        }
        public override int Dex
        {
            get
            {
                int bonus = 0;
                foreach (BaseBuff b in BuffList)
                    bonus += b.Dex;
                foreach (BaseDebuff d in DebuffList)
                    bonus += d.Dex;
                return base.Dex + bonus;
            }
            set
            {
                base.Dex = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool InCombat
        {
            get
            {
                if (Combatant != null || Aggressors.Count >= 1)
                    return true;
                return false;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual double CA 
        {
            get
            {
                double armureMod = DndHelper.GetArmorCA(this); //Attention, elle est déjà  + Bouclier
                
                double bouclierMod = 0.0; //ToDO
                if (getBouclier() != null)
                    bouclierMod = getBouclier().CA;

                double dexMod = DndHelper.GetCaracMod(this, DndStat.Dexterite);
                double TailleMod = ((int)mTaille);

                

                //Bouclier Total :
                if (getBouclier() != null && mActionCombat == ActionCombat.DefenseTotale)
                {
                    if (getBouclier().BType == BouclierType.Pavois || getBouclier().BType == BouclierType.GrandPavois)
                        armureMod += 10.0; //Normalement c'est une protection total, mais bon ^^
                    else
                        armureMod += 4;
                }
                else if (mActionCombat == ActionCombat.DefenseTotale)
                {
                    armureMod += 4;
                }
                else if (mActionCombat == ActionCombat.Defense) //-4 a tout les jets
                {
                    armureMod += 2;
                }

                


                int buffBonus = 0;
                foreach (BaseBuff b in BuffList)
                    buffBonus += b.CA;
                foreach (BaseDebuff d in DebuffList)
                    buffBonus += d.CA;


                return 10+armureMod + bouclierMod + dexMod + TailleMod + buffBonus;
            }

        }

        public List<MobileSousType> SousTypes { get { return m_SousTypes; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public string CreatureSousTypes
        {
            get
            {
                string list = "";
                foreach (MobileSousType st in SousTypes)
                {
                    list += st.ToString() + " ";
                }
                return list;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public MobileType CreatureType { get { return m_CreatureType; } set { m_CreatureType = value; } }

        
        public virtual void OnLevelChange()
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Turn { get { return m_turn; } }
        #endregion

       

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)2);//version;
           

            writer.Write((int)m_CreatureType);
            writer.Write((int)m_SousTypes.Count);
            for (int st = 0; st < m_SousTypes.Count; st++)
            {
                MobileSousType mst = m_SousTypes[st];
                writer.Write((int)mst);
            }
            

            //Charac additionelles
            writer.Write((int)mRawCha);
            writer.Write((int)mRawCons);
            writer.Write((int)mRawSag);

            //Compétences
            writer.Write((int)Competences.Lenght);
            for (int i = 0; i < (int)CompType.Maximum; i++)
            {
                if (!(Competences[(CompType)i] is NullCompetence))
                {
                    writer.Write((int)i); //Comptype
                    writer.Write((int)Competences[(CompType)i].Achat);
                }
            }


            //#Blessure
            writer.Write((int)m_blessureList.Count);
            for (int i = 0; i < m_blessureList.Count; i++)
            {
                NubiaBlessure blessure = m_blessureList[i] as NubiaBlessure;
                writer.Write((DateTime)blessure.TimeEnd);
                writer.Write((int)blessure.BType);
                writer.Write((int)blessure.BGravite);
                writer.Write((bool)blessure.Hemo);
                writer.Write((int)blessure.CurrentHemo);
                writer.Write((int)blessure.SoinStatut);
                writer.Write((int)blessure.Localisation);
            }
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            

            m_CreatureType = (MobileType)reader.ReadInt();
            int countSt = reader.ReadInt();
            for (int st = 0; st < countSt; st++)
            {
                MobileSousType mst = (MobileSousType)reader.ReadInt();
                m_SousTypes.Add(mst);
            }
           

            if (version >= 1)
            {
                //Charac additionelles
                mRawCha = reader.ReadInt();
                mRawCons = reader.ReadInt();
                mRawSag = reader.ReadInt();

                //Compétences
                int lenght = reader.ReadInt();
                mCompetences = new CompetenceStack(this);
                for (int i = 0; i < lenght; i++)
                {
                    CompType comp = (CompType)reader.ReadInt();
                    int achats = reader.ReadInt();
                    if (mCompetences[comp] is NullCompetence)
                        mCompetences.AddCompetence(comp);
                    mCompetences[comp].Achat = achats;
                }
            }
            if (version >= 2)
            {
                //### Blessures
                m_blessureList = new ArrayList();
                int count2 = reader.ReadInt();
                for (int i = 0; i < count2; i++)
                {
                    DateTime btime = reader.ReadDateTime();
                    BlessureType btype = (BlessureType)reader.ReadInt();
                    BlessureGravite bgrav = (BlessureGravite)reader.ReadInt();
                    bool bhemo = reader.ReadBool();
                    int bhemoc = reader.ReadInt();
                    int sta = reader.ReadInt();
                    BlessureLocalisation bloc = (BlessureLocalisation)reader.ReadInt();
                    NubiaBlessure blessure = new NubiaBlessure(bhemo, bgrav, btype, bhemoc);
                    blessure.SoinStatut = sta;
                    blessure.setTimeEnd(btime);
                    blessure.setLocalisation(bloc);
                    m_blessureList.Add(blessure);
                }
            }
        }
    }
}
