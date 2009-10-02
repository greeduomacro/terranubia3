using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;

namespace Server.Mobiles
{
    public class NubiaCreature : BaseCreature
    {
        private bool mIsElite = false; //Pour les dégat et leur réduction, voir le NubiaWeapon

        private Dictionary<OrderType, double> mOrdersLearned = new Dictionary<OrderType, double>();

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
                    return base.HitsMax * 5;
                return base.HitsMax;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override double CA
        {
            get
            {
                if (mIsElite)
                    return base.CA + (Niveau / 10);
                return VirtualArmor;
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
        public void ConfigureCreature(int niv, ClasseType clPrim)
        {
            ResetXP();
            GiveXP(XPHelper.GetXpForLevel(niv));


            MakeClasse(Server.Classe.GetClasse(clPrim), niv);
            

            switch (ArmorAllow)
            {
                case NubiaArmorType.None: VirtualArmor = 10; break;
                case NubiaArmorType.Legere: VirtualArmor = 30; break;
                case NubiaArmorType.Intermediaire: VirtualArmor = 60; break;
                case NubiaArmorType.Lourde: VirtualArmor = 80; break;
            }


            Hits += 20000;
            Stam += 20000;
            Mana += 20000;

        }

        public override bool OnBeforeDeath()
        {
            //XP Gains
          /*  if (AI != AIType.AI_Animal)
            {*/
                foreach (AggressorInfo ainf in Aggressors)
                {
                    if (ainf.Attacker is NubiaMobile)
                    {
                        NubiaMobile agg = ainf.Attacker as NubiaMobile;
                        int xp = 30;
                        int dif = Niveau - agg.Niveau;
                        if (dif < -5)
                            dif = -5;
                        else if (dif > 5)
                            dif = 5;
                        xp += dif * dif;
                        if (IsElite)
                            xp *= 10;
                        xp *= 5;
                        agg.GiveXP(xp);
                    }
                }
          //  }
            return base.OnBeforeDeath();
        }

        public override void OnLevelChange()
        {
            int niv = Niveau;

            int statVal = (8 + niv / 4);
            Str = statVal;
            Dex = statVal;
            Int = statVal;

            if (Classe == ClasseType.Barbare ||
                Classe == ClasseType.Paladin)
            {
                Str += 3;
                Dex -= 1;
                Int -= 2;
            }
            else if (Classe == ClasseType.Barde ||
                Classe == ClasseType.Moine ||
                Classe == ClasseType.Rodeur ||
                Classe == ClasseType.Roublard)
            {
                Dex += 3;
                Str -= 2;
                Int -= 1;
            }
            else if (Classe == ClasseType.Druide ||
               Classe == ClasseType.Ensorceleur ||
               Classe == ClasseType.Magicien ||
               Classe == ClasseType.Pretre)
            {
                Int += 3;
                Str -= 2;
                Dex -= 1;
            }


        }

        [CommandProperty(AccessLevel.GameMaster)]
        public ClasseType Classe //Pour le XML Spawner
        {
            get
            {
                int HLvl = 0;
                ClasseType cl = ClasseType.Maximum;
                foreach (Classe c in GetClasses())
                    if (c.Niveau > HLvl)
                        cl = c.CType;

                return cl;
            }
            set
            {
                ClasseType prim = value;
                ConfigureCreature(Niveau, prim);
            }
        }



        [CommandProperty(AccessLevel.GameMaster)]
        public int NiveauCreature //Pour le XML Spawner
        {
            get { return Niveau; }
            set { ConfigureCreature(value, Classe); }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); //Version
            writer.Write((bool)mIsElite);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mIsElite = reader.ReadBool();
        }
    }
}
