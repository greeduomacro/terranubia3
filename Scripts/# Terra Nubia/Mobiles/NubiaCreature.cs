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
        protected int mMonsterNiveau = 4;
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

        public override int Niveau
        {
            get
            {
                return mMonsterNiveau;
            }
        }
        public override int getBonusReflexe(SortEnergie ecole)
        {
            return mMonsterReflexe;
        }
        public override int getBonusVigueur(SortEnergie ecole)
        {
            return mMonsterVigueur;
        }
        public override int getBonusVolonte(SortEnergie ecole)
        {
            return mMonsterVolonte;
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
