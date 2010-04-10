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
	public class SortNubiaTransformation : SortNubia
	{
		public override int GetCercle()
		{
				if(m_toClone == null)
					return 1;
                int niv = m_toClone.Niveau;//KonohaSkillHelper.getCreatureNiveau(m_toClone);
				return (int)niv;
		}

        public override string DefaultName { get { return "Transformation"; } }
        public override SortDomaine Domaine { get { return SortDomaine.Chimere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool canBePere{ get{return true;}}

		public override bool isGestuel{ get{return true;}}
		public override bool mustCrier{ get{return true;}}

		private Timer m_timer = null;
		private NubiaCreature m_toClone = null;
		private int m_bonusStr = 0;
		private int m_bonusDex = 0;
		private int m_bonusInt = 0;
		private double m_bonusSkill = 0.0;
		private string m_nom = "Villageois";
		private ArrayList m_listItem = new ArrayList();

        public NubiaCreature toClone
		{
			get
			{
				return m_toClone;
			}
			set
			{
                m_toClone = (NubiaCreature)value;
			}
		}

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
		public SortNubiaTransformation() : base ("Transformation no SortNubia")
		{
			distance = 6;
			Delay = 160.0;
			TimeToCast = 2.0;
		}
		[Constructable]
		public SortNubiaTransformation( Serial serial ) : base (serial)
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
		public override void EndSortNubia()
		{
			/*foreach (KonohaClone clone in m_clones)
			{
				if(clone != null)
					clone.Delete();
			}
			base.EndSortNubia();*/

            NubiaPlayer m = Owner as NubiaPlayer;

			Owner.BodyValue = Owner.Female ? 401 : 400;
			Owner.HueMod = -1;
			
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );

			m.PlaySound( 0x228 );


			for(int i = 0; i < m_listItem.Count; i++)
			{
				((Item)m_listItem[i]).Delete();
			}
			m_listItem = new ArrayList();

			//SSortNubiaHelper.makeBigSmoke(Owner);

			

			Owner.Str -= m_bonusStr;
			Owner.Dex -= m_bonusDex;
			Owner.Int -= m_bonusInt;

		/*	SkillName[] sk = TransfoHelper.getSkillBonus(competence);
			for(int i = 0; i < sk.Length; i++)
			{
				Owner.Skills[sk[i]].Cap -= m_bonusSkill;
				Owner.Skills[sk[i]].Base -= m_bonusSkill;
			}*/
			Owner.Name = m_nom;
			Owner.NameMod = m_nom;
			Owner.clearTransfo();
			//m_timer.Stop();
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;

			double time = (int)(Owner.Niveau)*(Maitrise/2.0);
			time *= getRatio();

			if(m_toClone == null)
				return false;

			if(!Owner.makeTransfo(this))
			{
				Owner.SendMessage("Vous êtes déjà sous l'effet d'une transformation");
				return true;
			}

            NubiaPlayer m = Owner as NubiaPlayer;

			Owner.BodyValue = m_toClone.BodyValue;
			Owner.HueMod = m_toClone.Hue;
			m_nom = Owner.Name;
			if(m_toClone.Name != "noname")
				Owner.NameMod = m_toClone.Name;
			
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y, m.Z - 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z + 4 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X, m.Y + 1, m.Z - 4 ), m.Map, 0x3728, 13 );

			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 11 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 7 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z + 3 ), m.Map, 0x3728, 13 );
			Effects.SendLocationEffect( new Point3D( m.X + 1, m.Y + 1, m.Z - 1 ), m.Map, 0x3728, 13 );

			m.PlaySound( 0x228 );

			m_listItem = new ArrayList();

			for( int i = 0; i < m_toClone.Items.Count; i++ )
			{
				Item item =  NubiaHelper.CopyItem( m_toClone.Items[i] );
				Owner.AddItem(item);
				item.Movable = false;
				m_listItem.Add(item);
			}

            int level = m_toClone.Niveau;// KonohaSkillHelper.getCreatureNiveau(m_toClone);
			m_bonusStr = (int)((level*2)*TransfoHelper.getModusStr(energie));
            m_bonusDex = (int)((level * 2) * TransfoHelper.getModusDex(energie));
            m_bonusInt = (int)((level * 2) * TransfoHelper.getModusInt(energie));
			
			m_bonusStr = (int)(m_bonusStr*getRatio());
			m_bonusDex = (int)(m_bonusDex*getRatio());
			m_bonusInt = (int)(m_bonusInt*getRatio());
			
			m_bonusSkill = (level*2);
			m_bonusSkill *= getRatio();

			Owner.Str += m_bonusStr;
			Owner.Dex += m_bonusDex;
			Owner.Int += m_bonusInt;

/*SkillName[] sk = TransfoHelper.getSkillBonus(competence);
			for(int i = 0; i < sk.Length; i++)
			{
				Owner.Skills[sk[i]].Cap += m_bonusSkill;
				Owner.Skills[sk[i]].Base += m_bonusSkill;
			}*/
			m_timer = new InternalTimer(this, time);
			m_timer.Start();
			return true;
		}

		private class InternalTimer : Timer
		{
			private SortNubiaTransformation m_Item;
			private double m_t = 0.0;

			public InternalTimer(SortNubiaTransformation item, double t ) : base( TimeSpan.FromSeconds( t ) )
			{
				Priority = TimerPriority.OneSecond;
				m_Item = item;
				m_t = t;
			}

			protected override void OnTick()
			{
				if(m_Item == null)
					return;
				if(m_Item.state == MagieState.WaitEnd)
					m_Item.EndSortNubia();
				Stop();
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 1 ); // version
			writer.Write( (Mobile) m_toClone );
			writer.Write( (int)m_bonusStr );
			writer.Write( (int)m_bonusDex );
			writer.Write( (int)m_bonusInt );
			writer.Write( (double) m_bonusSkill );
			writer.Write( (string) m_nom );
			writer.Write( (int)m_listItem.Count );
			for(int i = 0; i < m_listItem.Count; i++)
			{
				writer.Write( (Item)m_listItem[i] );
			}
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			
			m_toClone = (NubiaCreature)reader.ReadMobile();
			m_bonusStr = reader.ReadInt();
			m_bonusDex = reader.ReadInt();
			m_bonusInt = reader.ReadInt();
			m_bonusSkill = reader.ReadDouble();
			m_nom = reader.ReadString();
			if(version > 0 )
			{
				int count = reader.ReadInt();
				for(int i = 0; i < count; i++)
				{
					m_listItem.Add(reader.ReadItem());
				}
			}
		}		
	}

}