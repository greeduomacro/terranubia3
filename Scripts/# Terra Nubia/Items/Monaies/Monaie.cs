using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public enum MonaieType
    {
        Cuivre = 0, 
        Argent = 1,
        Or = 2
    }
    public class MonaieCuivre : NubiaMonaie
    {
        public override MonaieType Monaie { get { return MonaieType.Cuivre; } }
        [Constructable]
		public MonaieCuivre() : this( 1 )
		{

		}

		[Constructable]
		public MonaieCuivre( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public MonaieCuivre( int amount ) : base( 0xEED )
		{
            Name = "pièce de cuivre";
			Stackable = true;
			Amount = amount;
		}

        [Constructable]
        public MonaieCuivre(Serial serial)
            : base(serial)
		{
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
    public abstract class NubiaMonaie : Item
    {
        private static void optimizeSomme(int cuivre, int argent, int or,
            out int outcuivre, out int outargent, out int outor )
        {
            outcuivre = cuivre;
            outargent = argent;
            outor = or;
        }
        public abstract MonaieType Monaie{ get;}

        public static int getMonaieTotale(Container c)
        {
            int val = 0;
            lock (c.Items)
            {
                foreach (Item i in c.Items)
                {
                    if (i is NubiaMonaie)
                    {
                        val += ((NubiaMonaie)i).Amount * ((NubiaMonaie)i).valeur;
                    }
                    else if (i is Container)
                    {
                        val += getMonaieTotale(c);
                    }
                }
            }
            return val;
        }
        
        public int valeur 
        {
            get {
                switch (Monaie)
                {
                    case MonaieType.Cuivre: return 1;
                    case MonaieType.Argent: return 100;
                    case MonaieType.Or: return 10000;
                    default: return 1;
                }
            } 
        }
        public static void optimizeContainer(Container c)
        {

        }

        //[Constructable]
		public NubiaMonaie() : this( 1 )
		{

		}

		//[Constructable]
		public NubiaMonaie( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		//[Constructable]
		public NubiaMonaie( int amount ) : base( 0xEED )
		{
			Stackable = true;
			Amount = amount;
		}

        public NubiaMonaie(Serial serial)
            : base(serial)
		{
		}

		public override int GetDropSound()
		{
			if ( Amount <= 1 )
				return 0x2E4;
			else if ( Amount <= 5 )
				return 0x2E5;
			else
				return 0x2E6;
		}

		protected override void OnAmountChange( int oldValue )
		{
			int newValue = this.Amount;

			UpdateTotal( this, TotalType.Gold, newValue - oldValue );
		}

		public override int GetTotal( TotalType type )
		{
			int baseTotal = base.GetTotal( type );

			if ( type == TotalType.Gold )
				baseTotal += this.Amount;

			return baseTotal;
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
