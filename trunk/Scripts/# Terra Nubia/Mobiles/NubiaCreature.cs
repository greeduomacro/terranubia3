using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;
using Server.Spells;

namespace Server.Mobiles
{
    public class NubiaCreature : BaseCreature
    {

        /** CONFIGURATION CREATURE
         * */
        #region Creature Config
        protected int mMonsterHits = 4;
        protected int mMonsterCA = 8;
        protected int[] mMonsterAttaques = new int[] { 0, 0 };
        protected int mMonsterReflexe = 4;
        protected int mMonsterVigueur = 2;
        protected int mMonsterVolonte = 1;
        private int mMonsterNiveau = 4;
        protected SortEnergie mEnergie = SortEnergie.Vie;

        protected void AddCompetence(CompType c, int value)
        {
            if (Competences[c] is NullCompetence)
            {
                Competences.LearnCompetence(c);
            }
            Competences[c].Achat = value;
        }
        #endregion


        private bool mIsElite = false; //Pour les dégat et leur réduction, voir le NubiaWeapon

        private Dictionary<OrderType, double> mOrdersLearned = new Dictionary<OrderType, double>();
        private FactionEnum mFaction = FactionEnum.None;

        public void makeWeapon()
        {
            Item f = FindItemOnLayer(Layer.TwoHanded);
            if (f != null && f is Fists)
            {
                f.Delete();
                Server.Items.Fists griffes = new Server.Items.Fists();
                griffes.De = De.quatre;
                griffes.NbrLance = mMonsterNiveau / 4;
                griffes.BonusDegatStatic = mMonsterNiveau / 8;
                griffes.Movable = false;
                EquipItem(griffes);
            }
            
        }
        public override int Niveau
        {
            get
            {
                return mMonsterNiveau;
            }
        }
        public int NiveauCreature
        {
            get
            {
                return mMonsterNiveau;
            }
            set
            {
                mMonsterNiveau = value;
               

                int[][] att =  new int[][] 
                { 
                    new int[] { 0 }, //0
                    new int[] { 1 }, //1
                    new int[] { 2 }, //2
                    new int[] { 3 }, //3
                    new int[] { 4 }, //4
                    new int[] { 5 }, //5
                    new int[] { 6,1 }, //6
                    new int[] { 7,2 }, //7
                    new int[] { 8,3 }, //8
                    new int[] { 9,4 }, //9
                    new int[] { 10,5 }, //10
                    new int[] { 11,6,1 }, //11
                    new int[] { 12,7,2 }, //12
                    new int[] { 13,8,3 }, //13
                    new int[] { 14,9,4 }, //14
                    new int[] { 15,10,5 }, //15
                    new int[] { 16,11,6,1 }, //16
                    new int[] { 17,12,7,2 }, //17
                    new int[] { 18,13,8,3 }, //18
                    new int[] { 19,14,9,4 }, //19
                    new int[] { 20,15,10,5 } //20
                };

                mMonsterAttaques = att[Math.Min(mMonsterNiveau, 20)];
                makeWeapon();

                RawStr = Niveau  + 10;
                RawDex = Niveau + 10;
                RawCons = Niveau + 10;
                RawCha = Niveau/2 + 5;
                RawInt = Niveau / 2 + 5;
                RawSag = Niveau / 2 + 5;

                mMonsterCA = 12 + (int)( Niveau / 1.5);

                mMonsterHits = Niveau + DndHelper.rollDe(De.douze) * Niveau;

                Hits = HitsMax;
            }
        }

        public override int getBonusReflexe(SortEnergie ecole)
        {           
   
            int[] reflex = new int[]
                {
                    0, //0
                    0, //1
                    0, //2
                    1, //3
                    1, //4
                    1, //5
                    2, //6
                    2, //7
                    2, //8
                    3, //9
                    3, //10
                    3, //11
                    4, //12
                    4, //13
                    4, //14
                    5, //15
                    5, //16
                    5, //17
                    6, //18
                    6, //19
                    6 //20
                };


            return reflex[Math.Min(mMonsterNiveau, 20)] +  mMonsterReflexe;
        }
        public override int getBonusVigueur(SortEnergie ecole)
        {
             int[] vig = new int[]
                {
                   0, //0
                    2, //1
                    3, //2
                    3, //3
                    4, //4
                    4, //5
                    5, //6
                    5, //7
                    6, //8
                    6, //9
                    7, //10
                    7, //11
                    8, //12
                    8, //13
                    9, //14
                    9, //15
                    10, //16
                    10, //17
                    11, //18
                    11, //19
                    12 //20
                };


            return vig[Math.Min(mMonsterNiveau, 20)] + mMonsterVigueur;
        }
        public override int getBonusVolonte(SortEnergie ecole)
        {
            int[] vol = new int[]
                {
                   0, //0
                    0, //1
                    1, //2
                    1, //3
                    1, //4
                    1, //5
                    2, //6
                    2, //7
                    2, //8
                    3, //9
                    3, //10
                    3, //11
                    4, //12
                    4, //13
                    4, //14
                    5, //15
                    5, //16
                    5, //17
                    6, //18
                    6, //19
                    6 //20
                };


            return vol[Math.Min(mMonsterNiveau, 20)] + mMonsterVolonte;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public SortEnergie Energie
        {
            get { return mEnergie; }
            set { mEnergie = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public FactionEnum Faction
        {
            get { return mFaction; }
            set { mFaction = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsElite
        {
            get { return mIsElite; }
            set { mIsElite = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override bool IsParagon
        {
            get { return mIsElite; }
            set
            {
                if (mIsElite == value)
                    return;
              /*  if( para
                    Paragon.UnConvert(this);

                m_Paragon = value;*/

                mIsElite = value;

                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override int HitsMax
        {
            get
            {
                if (mIsElite)
                    return mMonsterHits * 5;
                return mMonsterHits;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override double CA
        {
            get
            {
                return Math.Min(mMonsterCA, 18);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DressageDD
        {
            get
            {
                return Niveau*2;
            }
        }


        public NubiaCreature(AIType ai, FightMode fightmode, int viewRange, int attackRange, double activSpeed, double passivSpeed)
            : base(ai, fightmode, viewRange, attackRange, activSpeed, passivSpeed)
        {
            Hits = 10;
        }
        public NubiaCreature(Serial s)
            : base(s)
        {
        }

        public void learnOrder(OrderType order)
        {
            if ( !mOrdersLearned.ContainsKey(order))
            {
                mOrdersLearned.Add(order, 50.0);
            }
        }

       

        public bool canDoOrder(OrderType order)
        {
            bool can = false;
            double value = 0;

            if (ControlMaster != null)
            {
                if (ControlMaster.AccessLevel >= AccessLevel.GameMaster)
                    return true;
            }

            if (order == OrderType.Unfriend)
                order = OrderType.Friend;
            if (this.Summoned)
                value = 95;
            else if (order == OrderType.Release ||
                order == OrderType.Transfer)
            {
                return true;
            }
            else if (mOrdersLearned.ContainsKey(order))
            {
                if (mOrdersLearned[order] < 100.0)
                    mOrdersLearned[order] += Math.Round(Utility.RandomDouble(), 2);

                if (mOrdersLearned[order] > 100)
                    mOrdersLearned[order] = 100.0;
                value = mOrdersLearned[order];

            }
            else if( ControlMaster != null )
            {
                NubiaMobile master = ControlMaster as NubiaMobile;
                if (!master.Competences.mustWait())
                {
                    int orderDD = 10;
                    switch (order)
                    {
                        case OrderType.Guard:
                        case OrderType.Attack:
                            orderDD = 20;
                            break;
                        case OrderType.Friend:
                        case OrderType.Patrol:
                        case OrderType.Drop: orderDD = 15; break;

                    }
                    if (master.Competences[CompType.Dressage].check(orderDD)/* && Utility.RandomDouble() > 0.05*/)
                    {
                        PrivateOverheadMessage(Server.Network.MessageType.Emote, 0, false, "*Apprend l'ordre*", ControlMaster.NetState);
                        master.SendMessage("Votre créature à appris un nouvel ordre: " + order.ToString());
                        learnOrder(order);
                        return true;
                    }
                    else
                    {
                        PrivateOverheadMessage(Server.Network.MessageType.Emote, 0, false, "*Ne semble pas vous comprendre*", ControlMaster.NetState);
                        master.SendMessage("Vous échouez à apprendre ce nouvel ordre à votre créature");
                        return false;
                    }
                }
                else
                {
                    master.SendMessage("Attendez pour tenter un apprentissage");
                    return false;
                }
            }
            can = Utility.RandomMinMax(1, 100) <= value;

            if (!can && this.ControlMaster != null)
                PrivateOverheadMessage(Server.Network.MessageType.Emote, 0, false, "*vous regarde sans comprendre l'ordre*", ControlMaster.NetState);

            return can;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            if (mIsElite)
            {
                list.Add("-Elite-");
            }
        }
       

        public override bool OnBeforeDeath()
        {
            //XP Gains
          /*  if (AI != AIType.AI_Animal)
            {*/
                foreach (AggressorInfo ainf in Aggressors)
                {
                    if (ainf.Attacker is NubiaPlayer)
                    {
                        NubiaPlayer agg = ainf.Attacker as NubiaPlayer;
                        int xp = 30;
                        int dif = Niveau - agg.Niveau;
                        if (dif < -5)
                            dif = -5;
                        else if (dif > 5)
                            dif = 5;
                        xp += dif * dif;
                        if (IsElite)
                            xp *= 10;
                        xp *= 10;
                        agg.GiveXP(xp);

                        if (mFaction != FactionEnum.None)
                        {
                            agg.ReputationStack.IncReputation(mFaction, -5);

                            for (int f = 0; f < (int)FactionEnum.Maximum; f++)
                            {
                                BaseFaction faction = FactionHelper.getFaction((FactionEnum)f);
                                if (faction != null)
                                {
                                    for (int e = 0; e < faction.Enemies.Length; e++)
                                    {
                                        if (faction.Enemies[e] == mFaction)
                                        {
                                            agg.ReputationStack.IncReputation(faction.Faction, 1);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
          //  }
            return base.OnBeforeDeath();
        }

      

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); //Version
            writer.Write((bool)mIsElite);
            writer.Write((int)mEnergie);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mIsElite = reader.ReadBool();
            if (version >= 1)
            {
                mEnergie = (SortEnergie)reader.ReadInt();
            }
        }
    }
}
