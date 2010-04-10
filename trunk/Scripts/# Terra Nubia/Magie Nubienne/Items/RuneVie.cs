using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{

	public class RuneVie : Item
	{

		private NubiaCreature m_creature = null;

		[CommandProperty( AccessLevel.GameMaster )]
		public NubiaCreature creature
		{
			get{ return m_creature; }
			set{ m_creature = NubiaHelper.CopyCreature(value); InvalidateProperties(); }
		}
		
		[Constructable]
		public RuneVie() : base( 0x23F )
		{
			Name = "Rune de vie";
		}
		[Constructable]
		public RuneVie( Serial serial ) : base( serial )
		{
		}

		/*public override void OnDoubleClick( Mobile from )
		{
			//if ( !from.CanBeginAction( typeof( LivreEtude ) ) )
			//	return;
			if( !(from.InRange(this.GetWorldLocation(), 1) ))
			{
				from.SendMessage("Vous êtes trop loin");
				return;
			}

			if( DateTime.Now < (LastUse)+ TimeSpan.FromSeconds( 5.0 ) )
			{
				from.SendMessage("Vous ne pouvez pas encore utiliser ce livre");
				return;
			}
			if( (from.Skills[m_skill].Base + m_ratio) > from.Skills[m_skill].Cap )
			{
				from.SendMessage("Vous êtes cappé pour le moment dans cette competence");
				return;
			}
			if(m_max > from.Skills[m_skill].Base )
				from.Skills[m_skill].Base += m_ratio;
			else
				from.SendMessage("Ce livre ne pourra rien vous apprendre de plus");

			LastUse = DateTime.Now;
			
		}*/

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0  );

			writer.Write( (Mobile)m_creature );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

				m_creature = (NubiaCreature)reader.ReadMobile();
				
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			string ls = "vide";
			if(creature != null)
				list.Add(creature.Name+"\n " /*TODO: Energies reliées*/);

//			list.Add(m_skill.ToString());
		}
		
	}

}