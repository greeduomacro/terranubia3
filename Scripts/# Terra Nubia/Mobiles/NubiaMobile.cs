using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server;
using Server.Misc;
using System.Collections;

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
        DefenseTotale = 1, //+4 CA. +10 avec pavois. Annulé si on bouge
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


        private TailleMob mTaille = TailleMob.Moyen;
        private MobileType m_CreatureType = MobileType.Animal;
        private List<MobileSousType> m_SousTypes = new List<MobileSousType>();
        private CompetenceStack mCompetences = null;
        private ArrayList m_blessureList = new ArrayList();

        //BUFF

       // private List<Blessure> m_blessureList = new List<Blessure>();
        private List<BaseBuff> m_buffList = new List<BaseBuff>();
        private List<BaseDebuff> m_debuffList = new List<BaseDebuff>();

        public List<BaseBuff> BuffList { get { return m_buffList; } }
        public List<BaseDebuff> DebuffList { get { return m_debuffList; } }

        public ArrayList BlessureList { get { return m_blessureList; } }

        //Nouvelles stats:
        private int mRawSag = 8, mRawCha = 8, mRawCons = 8;

        private int mXP = 0;
        private int mTurn = 0;

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
            foreach (NubiaBlessure blessure in BlessureList)
            {
                blessure.StopHemo();
            }
            foreach (BaseBuff buff in BuffList)
                buff.End();

            foreach (BaseBuff debuff in DebuffList)
                debuff.End();

            m_buffList = new List<BaseBuff>();
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
               }
           }
           BlessureList.Remove(toRemov);

            BaseBuff buffRemove = null;
            foreach (BaseBuff buff in BuffList)
            {
                if (Alive)
                    buff.OnTurn();
                if (buff.Turn < 1)
                    buffRemove = buff;
            }
            if (buffRemove != null)
            {
                //BuffList.Remove(buffRemove);
                buffRemove.End();
                buffRemove.Delete();
            }
            buffRemove = null;
            foreach (BaseBuff debuff in DebuffList)
            {
                if (debuff == null)
                    continue;
                if (Alive)
                    debuff.OnTurn();
                if (debuff.Turn < 1)
                    buffRemove = debuff;
            }
            if (buffRemove != null)
            {
                //DebuffList.Remove(buffRemove);
                buffRemove.End();
                buffRemove.Delete();
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
                int defRoll = Utility.RandomMinMax(1, 20) + BonusVigueur;
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
        public bool CanDoOpportuniteAttack
        {
            get
            {
                if (Weapon is Fists) //Pas d'attaque d'opportunité sans arts martiaux;
                    return false;
                return mLastOpportuniteAction < DateTime.Now - WorldData.TimeTour();
            }
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
            //Backstab !
            if (NubiaHelper.LookAt(agressor, this) &&
                (NubiaHelper.GetDirectionFrom((int)Direction) == NubiaHelper.GetDirectionFrom((int)agressor.Direction) ||
                agressor.Hidden))
            {
                ExposeToOpportunite();
            }
            if (CheckForOpportunite() && agressor != null)
            {
                if (agressor.CanDoOpportuniteAttack)
                {
                    /*1d20 + Bonus Reflexes + Modificateur dexterité
                        contre
                        1d20 + Bonus Reflexes + Modificateur dexterité - 8 */
                    int rollDef = Utility.RandomMinMax(1, 20);
                    int rollAgr = Utility.RandomMinMax(1, 20);

                    if (agressor.Weapon is BaseRanged)
                        rollAgr -= 10;

                    int difference = (rollAgr + agressor.BonusReflexe + (int)DndHelper.GetCaracMod(agressor, DndStat.Dexterite))
                                    -
                                    (rollDef + BonusReflexe + (int)DndHelper.GetCaracMod(this, DndStat.Dexterite) - 8);

                    if (difference > 0)
                        mLastOpportuniteAction = DateTime.Now;

                    return difference;
                }
                else
                    return 0;
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
                return;
            }
            if (act == ActionCombat.Defense)
            {
                mActionCombat = ActionCombat.Defense;
                Emote("*Denfense*");
            }
            else if (act == ActionCombat.DefenseTotale)
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
            if (mTourAttaque >= BonusAttaque.Length)
                mTourAttaque = 0;
            return mTourAttaque;
        }

        public int[] BonusAttaque
        {
            get
            {
                //On compte déjà le nbr de coup bonus.
                int maxCoup = 1;
                foreach (Classe c in GetClasses())
                {
                    if (c.BonusAttaque[c.Niveau].Length > maxCoup)
                        maxCoup = c.BonusAttaque[c.Niveau].Length;
                }
                int[] bonii = new int[maxCoup];
                //initialisation
                for (int n = 0; n < bonii.Length; n++)
                    bonii[n] = 0;
                //Config
                foreach (Classe c in GetClasses())
                {
                    for (int i = 0; i < c.BonusAttaque[c.Niveau].Length; i++)
                        bonii[i] += c.BonusAttaque[c.Niveau][i];
                }

                return bonii;
            }
        }
        public int BonusReflexe
        {
            get
            {
                int bonus = 0;
                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusReflexe[c.Niveau];
                }
                return bonus;
            }
        }
        public int BonusVigueur
        {
            get
            {
                int bonus = 0;
                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusVigueur[c.Niveau];
                }
                return bonus;
            }
        }
        public int BonusVolonte
        {
            get
            {
                int bonus = 0;
                foreach (Classe c in GetClasses())
                {
                    bonus += c.BonusVolonte[c.Niveau];
                }
                return bonus;
            }
        }

        #endregion
        private int m_turn = 0;

        private Dictionary<Type, Classe> m_Classes = new Dictionary<Type, Classe>();
        private ClasseType m_lastClasse = ClasseType.Maximum;

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

        //Classe sur le Nubia Mobile car elles influance bcp l'attaque, les reflexe, etc...
        //Donc il sera important de l'avoir pour les Streums
        #region Classes & Comps

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

        public virtual void AfterMakeClasse()
        {
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
        public ICollection<Classe> GetClasses()
        {
            return m_Classes.Values;
        }
        public void ResetClasse()
        {
            m_lastClasse = ClasseType.Maximum;
            m_Classes = new Dictionary<Type, Classe>();
        }

        public Dictionary<Type, Classe> Classes { get { return m_Classes; } }
        public ClasseType LastClasse { get { return m_lastClasse; } set { m_lastClasse = value; } }

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
                return mRawCha;
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
                return mRawCons;
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
                return mRawSag;
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

        [CommandProperty(AccessLevel.GameMaster)]
        public string StringNivClasses
        {
            get
            {
                if (GetClasses().Count > 0)
                {
                    string cs = "";
                    foreach (Classe c in GetClasses())
                    {
                        cs += "( " + c.Niveau.ToString(); cs += " )";
                    }
                    return cs;
                }
                else
                    return "";
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


                return armureMod + bouclierMod + dexMod + TailleMod;
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

        [CommandProperty(AccessLevel.GameMaster)]
        public int Niveau { get { return XPHelper.GetLevelForXP(mXP); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int XP { get { return mXP; } }

        public void ResetXP()
        {
            GiveXP(-mXP);
        }

        public virtual void GiveXP(int Xp)
        {
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
        public virtual void OnLevelChange()
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Turn { get { return m_turn; } }
        #endregion

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
               // max *= 5;
                return max;
            }
        }
        public override int ManaMax
        {
            get
            {
                int max = 20;
                return max;
            }
        }
        public override int StamMax
        {
            get
            {
                int max = 20;
                return max;
            }
        }
        #endregion

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)2);//version;
            writer.Write((int)mXP);

            writer.Write((int)m_CreatureType);
            writer.Write((int)m_SousTypes.Count);
            for (int st = 0; st < m_SousTypes.Count; st++)
            {
                MobileSousType mst = m_SousTypes[st];
                writer.Write((int)mst);
            }
            writer.Write((int)m_lastClasse);

            writer.Write((int)GetClasses().Count);
            foreach (Classe c in GetClasses())
            {
                writer.Write((int)c.CType);
                writer.Write((int)c.Niveau);
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
            mXP = reader.ReadInt();

            m_CreatureType = (MobileType)reader.ReadInt();
            int countSt = reader.ReadInt();
            for (int st = 0; st < countSt; st++)
            {
                MobileSousType mst = (MobileSousType)reader.ReadInt();
                m_SousTypes.Add(mst);
            }
            m_lastClasse = (ClasseType)reader.ReadInt();

            int countCl = reader.ReadInt();
            for (int cl = 0; cl < countCl; cl++)
            {
                ClasseType ct = (ClasseType)reader.ReadInt();
                int niv = reader.ReadInt();

                Type t = Classe.GetClasse(ct);
                MakeClasse(t, niv);
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
