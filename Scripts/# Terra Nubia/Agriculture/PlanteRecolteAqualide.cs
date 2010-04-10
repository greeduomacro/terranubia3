using System;
using Server;
using Server.Nubia;
using Server.Targeting;

namespace Server.Items
{
	public class PlanteRecolteAqualide : Item
	{
		[Constructable]
		public PlanteRecolteAqualide() : this( 1 )
		{
		}

		[Constructable]
		public PlanteRecolteAqualide(int amount ) : base( 8751 )
		{
			Stackable = true;
			Amount = amount;
			Hue = 2121;
			Name = AgriHelper.GetPlanteString( EnumPlante.Aqualide);
			ItemID = AgriHelper.GetPlanteID( EnumPlante.Aqualide, EnumPlanteState.Recolte );
		}
		[Constructable]
		public PlanteRecolteAqualide( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			from.BeginTarget( 4, false, TargetFlags.None, new TargetCallback( OnTarget ) );
		}

		public virtual void OnTarget( Mobile from, object obj )
		{
			if ( obj is AddonComponent )
				obj = (obj as AddonComponent).Addon;

			IPuficateurLumiere mill = obj as IPuficateurLumiere;

			if ( mill != null )
			{
				int needs = mill.MaxFlour - mill.CurFlour;

				if ( needs > this.Amount )
					needs = this.Amount;

				mill.CurFlour += needs;
				Consume( needs );
			}
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
