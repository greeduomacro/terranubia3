using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;

namespace Server.Mobiles
{

    class TNRaceSkinAasimar : TNRaceSkin
    {
        private static int itemID = 0x2290;
        public TNRaceSkinAasimar( ) : this( 0 )
		{
		}
		public TNRaceSkinAasimar( int hue ) : base( itemID, hue )
		{
		}
        public TNRaceSkinAasimar(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
		}
		public override void Deserialize( GenericReader reader )
		{
		}
    }
    
    class TNRaceSkin : BaseShirt
    {
        private void config()
        {
            Layer = Layer.Shirt;
            Movable = false;
            Name = "Peau";
        }
        public TNRaceSkin( int itemID ) : this( itemID, 0 )
		{
            config();
		}

		public TNRaceSkin( int itemID, int hue ) : base( itemID,hue )
		{
            config();
		}

        public TNRaceSkin(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
    }
}
