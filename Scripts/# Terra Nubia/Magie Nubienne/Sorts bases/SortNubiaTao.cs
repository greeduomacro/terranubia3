using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class SortNubiaTao : SortNubia
	{
		public override int GetCercle()
		{
				int niv = 0;
				niv += m_degats/4;
				niv += (int)m_stun*2;
				if(m_rapide)
					niv += m_Turn*2;
				else
					niv += m_Turn/2;
				return (int)niv;
		}

        public override string DefaultName { get { return "Tao"; } }
        public override SortDomaine Domaine { get { return SortDomaine.Entrave; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return false;}}
		public override bool mustCrier{ get{return false;}}

		private int m_degats = 0;
		private double m_stun = 0;
		private bool m_rapide = false;
		private int m_Turn = 0;
		private int m_CurrentTurn = 0;


        public override SortEnergie[] allowCompetence 
		{ 
			get
			{
                return new SortEnergie[] 
				{
					SortEnergie.All
				};
			}
		}

		[Constructable]
		public SortNubiaTao() : base ("Tao")
		{
			distance = 1;
			Delay = 30.0;
			TimeToCast = 2.0;
		}
		[Constructable]
        public SortNubiaTao(Serial serial)
            : base(serial)
		{
		}

		public override void StartCast()
		{
			base.StartCast();
		}

		public override bool canCast(NubiaPlayer from)
		{
			return base.canCast(from);
		}
		
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			Owner.SendMessage("Tao '{0}' activé au prochain tour", Nom );
			m_CurrentTurn = m_Turn;
			Owner.GetTaoList().Add(this); // Le reste c'est dans BaseWeapon

			
			/*m_degats = (int)(m_degats*getRatio());
			m_stun = (double)(m_stun*getRatio());
			m_rapideTurn = (int)(m_rapideTurn*getRatio());*/

			
			
			return true;
		}

		
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version
			writer.Write( (int)m_degats );
			writer.Write( (double) m_stun );
			writer.Write( (int) m_Turn );
			writer.Write( (bool) m_rapide );
			writer.Write( (int)m_CurrentTurn );
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			m_degats = reader.ReadInt();
			m_stun = reader.ReadDouble();
			m_Turn = reader.ReadInt();
			m_rapide = reader.ReadBool();
			m_CurrentTurn = reader.ReadInt();
		}		
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int degats
		{
			get{ return m_degats; }
			set{ m_degats = value; InvalidateProperties(); }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public double stun
		{
			get{ return m_stun; }
			set{ m_stun = value; InvalidateProperties(); }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public int currentTurn
		{
			get{ return m_CurrentTurn; }
			set{ m_CurrentTurn = value; InvalidateProperties(); }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public int turn
		{
			get{ return m_Turn; }
			set{ m_Turn = value; InvalidateProperties(); }
		}
		[CommandProperty( AccessLevel.GameMaster )]
		public bool rapide
		{
			get{ return m_rapide; }
			set{ m_rapide = value; InvalidateProperties(); }
		}
	}

}