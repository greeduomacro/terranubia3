using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Nubia;

namespace Server.Engines
{
	/*public enum TissuEnum
	{
		None = -1,
		Lin = 0,
		Coton,
		Soie,
		Laine
	}*/
	public class TissuLin : BaseTissu{
		[Constructable]
		public TissuLin() : base( TissuEnum.Lin ){}
		public TissuLin( Serial s ) : base( s ){}

		public override void Deserialize( GenericReader reader ){
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		public override void Serialize( GenericWriter writer ){
			base.Serialize( writer );			
			writer.Write( (int)0 ); // version
		}
	}

	public class TissuCoton : BaseTissu{
		[Constructable]
		public TissuCoton() : base( TissuEnum.Coton ){}
		public TissuCoton( Serial s ) : base( s ){}

		public override void Deserialize( GenericReader reader ){
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		public override void Serialize( GenericWriter writer ){
			base.Serialize( writer );			
			writer.Write( (int)0 ); // version
		}
	}

	public class TissuSoie : BaseTissu{
		[Constructable]
		public TissuSoie() : base( TissuEnum.Soie ){}
		public TissuSoie( Serial s ) : base( s ){}

		public override void Deserialize( GenericReader reader ){
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		public override void Serialize( GenericWriter writer ){
			base.Serialize( writer );			
			writer.Write( (int)0 ); // version
		}
	}

	public class TissuLaine : BaseTissu{
		[Constructable]
		public TissuLaine() : base( TissuEnum.Laine ){}
		public TissuLaine( Serial s ) : base( s ){}

		public override void Deserialize( GenericReader reader ){
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		public override void Serialize( GenericWriter writer ){
			base.Serialize( writer );			
			writer.Write( (int)0 ); // version
		}
	}
	
}
