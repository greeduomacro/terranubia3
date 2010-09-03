using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Engines;

namespace Server.Items
{
    public class NubiaSpecialBois : NubiaSpecialHarvest
    {
        private Item foliage = null;
        [Constructable]
        public NubiaSpecialBois()
            : base(3277)
        {
            Ressource = NubiaRessource.Vela;
            mItemEmpty = 3671;
            foliage = new Item(3278);
            foliage.Name = "Feuillage";
            foliage.Weight = 255;
            foliage.Movable = false;
            MoveToWorld(this.Location, this.Map);
        }

        public override void MoveToWorld(Point3D location)
        {
            base.MoveToWorld(location);
            foliage.MoveToWorld(location);
        }
        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);
            foliage.MoveToWorld(Location);
        }
        public override void OnMapChange()
        {
            base.OnMapChange();
            foliage.Map = Map;
        }

        public override void OnDelete()
        {
            if (foliage != null)
                foliage.Delete();
            base.OnDelete();
        }

        public override void RessourceConsume()
        {
            Charges--;
            if (Empty)
            {

            //    Console.WriteLine("Foliage: " + foliage);
             //   Console.WriteLine("this: " + this);
                if (foliage != null)
                {
             //       Console.WriteLine("Consume Foliage");
            //        Console.WriteLine("this: " + this + " ID: " + this.ItemID);
                    foliage.Delete();
                }
                ItemID = mItemEmpty;
                new DeleteTimer(this).Start();
               
            }
           
        }

        public override bool checkRessource(NubiaRessource res)
        {
            return NubiaInfoRessource.GetRessourceType(res) == NubiaRessourceType.Bois;
        }

        [Constructable]
        public NubiaSpecialBois(Serial s)
            : base(s)
        {
            Ressource = NubiaRessource.Vela;
            mItemEmpty = 6005;
        }

        protected override void updateName()
        {
            Name = "Arbre (" + NubiaInfoRessource.GetInfoRessource(Ressource).Name + ")";
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.WriteItem<Item>(foliage);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            foliage = reader.ReadItem();
        }
    }
    public class NubiaSpecialMineral : NubiaSpecialHarvest
    {
        [Constructable]
        public NubiaSpecialMineral()
            : base(0x17BC)
        {
            Ressource = NubiaRessource.Verdan;
            mItemEmpty = 6005;
        }

        public override void RessourceConsume()
        {
            base.RessourceConsume();
            if (Empty)
                Hue = 0;
        }

        public override bool checkRessource(NubiaRessource res)
        {
            return NubiaInfoRessource.GetRessourceType(res) == NubiaRessourceType.Metal;
        }

        [Constructable]
        public NubiaSpecialMineral(Serial s)
            : base(s)
        {
            Ressource = NubiaRessource.Verdan;
            mItemEmpty = 6005;
        }

        protected override void updateName()
        {
            Name = "Filon (" + NubiaInfoRessource.GetInfoRessource(Ressource).Name+")";
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public abstract class NubiaSpecialHarvest : Item
    {

        public virtual void doHarvestEffect(Mobile from, Item tool)
        {
            from.Direction = from.GetDirectionTo(Location);

            int sound = Utility.RandomList( new int[]{ 0x125, 0x126} );
            int anim = 11;

            if (tool is BaseAxe)
            {
                sound = 0x13E;
                anim = 13;
            }

            from.PlaySound(sound);

            if (!from.Mounted)
                from.Animate(anim, 5, 1, true, false, 0);
        }

        private bool checkTool(NubiaPlayer from, Item tool)
        {
            if (NubiaInfoRessource.GetRessourceType(Ressource) == NubiaRessourceType.Metal
                && tool is Pickaxe)
            {
                if (((Pickaxe)tool).UsesRemaining > 0)
                    return true;
            }
            else if (NubiaInfoRessource.GetRessourceType(Ressource) == NubiaRessourceType.Bois
                && tool is BaseAxe)
            {
                if (((BaseAxe)tool).UsesRemaining > 0)
                 return true;
            }

            from.SendMessage("Votre outil semble inadapté");
            return false;
        }

        public virtual bool checkRange(Mobile from, Item tool)
        {
            bool inRange = (from.Map == Map && from.InRange(Location, 1));

            if (!inRange)
                from.SendMessage("Vous êtes trop loin pour exploiter la ressource");

            return inRange;
        }
        public void BeginSpecialHarvest(NubiaPlayer from, Item tool)
        {

            if (Empty)
            {
                from.SendMessage("Il n'y a plus rien à exploiter ici");
                return;

            }
            
            if (checkTool(from, tool) && checkRange(from, tool)  )
            {
                if (from.Competences.mustWait())
                {
                    from.SendMessage("Vous devez attendre avant d'exploiter cette ressource");
                    return;
                }
                //fake
                from.Competences[CompType.Concentration].check(0, 1);

                doHarvestEffect(from, tool);
                new HarvestTimer(this, tool, from).Start();
            }
        }
        private void FinishSpecialHarvest(NubiaPlayer from, Item tool)
        {
            doHarvestEffect(from, tool);

            NubiaInfoRessource infos = NubiaInfoRessource.GetInfoRessource(Ressource);

            CompType comp = CompType.Minage;
            if (NubiaInfoRessource.GetRessourceType(Ressource) == NubiaRessourceType.Bois)
                comp = CompType.Buchage;

            bool check = from.Competences[comp].check(infos.Diff, 0);

            if (tool is IUsesRemaining)
            {
                IUsesRemaining utool = tool as IUsesRemaining;
                utool.UsesRemaining--;
                if (utool.UsesRemaining <= 0)
                    tool.Consume();
            }

            if (check)
            {
                if (from.Competences[comp].check(infos.Diff - 5, 0))
                {
                    RessourceConsume();
                    from.SendMessage("Vous exploitez la ressource avec succès");
                    Item special = BaseRessource.getRessource(Ressource);
                    if (special != null)
                    {
                        if (from.Backpack != null)
                            from.Backpack.AddItem(special);
                        else
                            special.MoveToWorld(from.Location, from.Map);
                    }
                    else
                    {
                        from.SendMessage("BUG: la ressource n'a pas de class correspondante. Contactez l'équipe");
                    }
                }
                else
                {
                    from.SendMessage("Vous n'arrivez pas à extraire la ressource spéciale");

                    Item normal = null;

                    if (NubiaInfoRessource.GetRessourceType(Ressource) == NubiaRessourceType.Bois)
                        normal = new BoisNormal();
                    else
                        normal = new MetalFer();

                    if (from.Backpack != null)
                        from.Backpack.AddItem(normal);
                    else
                        normal.MoveToWorld(from.Location, from.Map);
                }
            }
            else
            {
                if (!from.Competences[comp].check(infos.Diff - 5, 0))
                {
                    RessourceConsume();
                    from.SendMessage("Une partie de la ressource est saccagée");
                    from.Emote("*Saccage*");
                }
                from.SendMessage("Vous n'arrivez pas à exploiter correctement la ressource");
            }
        }

        private class HarvestTimer : Timer
        {
            NubiaSpecialHarvest item = null;
            Item tool = null;
            NubiaPlayer from = null;
            public HarvestTimer(NubiaSpecialHarvest i, Item t, NubiaPlayer f)
                : base(TimeSpan.FromSeconds(5))
            {
                item = i;
                tool = t;
                from = f;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if (item != null)
                    item.FinishSpecialHarvest(from, tool);
            }
        }

        protected class DeleteTimer : Timer
        {
            NubiaSpecialHarvest item = null;
            public DeleteTimer(NubiaSpecialHarvest i)
                : base(TimeSpan.FromMinutes(30))
            {
                item = i;
            }
            protected override void OnTick()
            {
                base.OnTick();
                if (item != null)
                    item.Delete();
            }
        }

        private NubiaRessource mRessource = NubiaRessource.Fer;
        private int mCharge = Utility.RandomMinMax(1, 4);
        protected int mItemEmpty = 6005;


        public NubiaSpecialHarvest(int itemid)
            : base(itemid)
        {
            Movable = false;
            Weight = 255;
        }

        public virtual void RessourceConsume()
        {
            mCharge--;
            if (Empty)
            {
                ItemID = mItemEmpty;
                new DeleteTimer(this).Start();
            }
        }

        public NubiaSpecialHarvest(Serial s)
            : base(s)
        {
            if (Empty)
                new DeleteTimer(this).Start();
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Empty
        {
            get { return mCharge <= 0; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get { return mCharge; }
            set { mCharge = value; 
            }
        }

        protected virtual void updateName()
        {
            Name = "Ressource de " + NubiaInfoRessource.GetInfoRessource(mRessource).Name;
        }

        public virtual bool checkRessource(NubiaRessource res)
        {
            return false;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public NubiaRessource Ressource
        {
            get { return mRessource; }
            set {
                if (checkRessource(value))
                {
                    mRessource = value;
                    NubiaInfoRessource info = NubiaInfoRessource.GetInfoRessource(mRessource);
                    this.Hue = info.Hue;


                    updateName();
                }
                else
                    InvalidateProperties();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((int)mRessource);
            writer.Write((int)mCharge);
            writer.Write((int)mItemEmpty);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            mRessource = (NubiaRessource)reader.ReadInt();
            mCharge = reader.ReadInt();
            mItemEmpty = reader.ReadInt();
        }
    }
}
