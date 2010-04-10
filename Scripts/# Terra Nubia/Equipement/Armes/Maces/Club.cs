using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13b4, 0x13b3 )]
	public class Club : BaseBashing
	{
	
		[Constructable]
		public Club() : base( 0x13B4 )
		{
            De = De.six;
            ArmeCategorie = ArmeCategorie.Courante;
            CritiqueMulti = 2;
			Weight = 9.0;
		}

		public Club( Serial serial ) : base( serial )
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