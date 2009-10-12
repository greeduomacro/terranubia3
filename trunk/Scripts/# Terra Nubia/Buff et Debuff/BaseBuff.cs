using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Items;
using Server.Gumps;
namespace Server.Mobiles
{
	public class BaseDebuff : AbstractBaseBuff
	{
		public BaseDebuff(Serial serial): base(serial){}
		public BaseDebuff(NubiaMobile _caster, NubiaMobile _cible, int ico, int _duration, string _name): base( _caster, _cible, ico, true, _duration, _name)
		{
		}
		public override bool OnTurn()
		{
			return base.OnTurn();
		}

		public override void OnAdd()
		{
			base.OnAdd();
		}

		public override void End()
		{  
			base.End();
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
	}

	public class BaseBuff : AbstractBaseBuff
	{
		public BaseBuff(Serial serial): base(serial){}
		public BaseBuff(NubiaMobile _caster, NubiaMobile _cible, int ico, int _duration, string _name): base( _caster, _cible, ico, false, _duration, _name)
		{
		}
		public override bool OnTurn()
		{
			return base.OnTurn();
		}

		public override void OnAdd()
		{
			base.OnAdd();
		}

		public override void End()
		{  
			base.End();
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
	}

	public abstract class AbstractBaseBuff : Item
	{
		protected NubiaMobile m_caster;
		protected NubiaMobile m_cible;
		protected bool m_isDebuff = false;
		protected int m_diffBonus = 0;
		protected int m_hitsBonus = 0;
		protected int m_manaBonus = 0;
		protected int m_stamBonus = 0;
		protected int m_DamageReflect = 0;
		protected int m_icone = 2242;
		protected string m_descrip = "Description absente";
		protected int m_turn = 10; //Nbr de tour avant le delect
		protected bool m_BodyModif = false;

		//## GETTER & SETTER
		public NubiaMobile Caster{get{return m_caster;}}
		public NubiaMobile Cible{get{return m_cible;}}
		public bool IsDebuff{get{return m_isDebuff;}}
		public int DiffBonus{get{return m_diffBonus;}}
		public int DamageReflect{get{return m_DamageReflect;}}
		public int HitsBonus{get{return m_hitsBonus;}}
		public int ManaBonus{get{return m_manaBonus;}}
		public int StamBonus{get{return m_stamBonus;}}
		public int Icone{get{return m_icone;}}
		public bool BodyModif {get{return m_BodyModif;}	}
		public int Turn{get{return m_turn;}}
		public string Descrip
		{
			get
			{
				return m_descrip+"<br><i>Tours restants: </i> "+m_turn;
			}
		}

		//## CONSTRUCTEUR
		public AbstractBaseBuff(NubiaMobile _caster, NubiaMobile _cible, int ico, bool _isDebuff, int _duration, string _name): base(11)
		{
			m_caster = _caster;
			m_cible = _cible;
			m_isDebuff = _isDebuff;
			m_icone = ico;
			m_turn = _duration;
			Name = _name;

			if( m_caster != null && m_cible != null){
				bool ok = true;
				if( m_BodyModif && m_cible.BodyMod != 0 )
					ok = false;
				Console.WriteLine(m_cible.DebuffList.Count +" :: "+m_cible.BuffList.Count);
				if(m_isDebuff){
					foreach(BaseDebuff debuff in m_cible.DebuffList)
					{
						//Console.WriteLine("Debuff : "+debuff.Name+" : "+this.Name); 
						if( debuff.Name == this.Name )
							ok = false;
					}
					if(ok)
						m_cible.DebuffList.Add( this as BaseDebuff );
				}
				else{
					foreach(BaseBuff buff in m_cible.BuffList)
					{
						//Console.WriteLine("Buff : "+buff.Name+" : "+this.Name); 
						if( buff.Name == this.Name )
							ok = false;
					}
					if(ok)
						m_cible.BuffList.Add( this as BaseBuff);			
				}					
				if(ok)
					OnAdd();
				else
					m_caster.SendMessage("{0} est déjà sous un effet similaire", m_cible.Name);
			}
		}
		public AbstractBaseBuff(Serial serial): base(serial){}

		public virtual bool OnTurn()
		{
			if( m_cible == null || m_caster == null )
			{
				return false;
			}
			if( !m_cible.Alive  )
				return false;
			if( m_turn < 1 )
			{
				End();
				return false;
			}
			m_turn--;
			return true;
		}

		public virtual void OnAdd()
		{
			if( m_cible == null  )
				return;
			if( m_cible is NubiaPlayer && m_isDebuff ){
				m_cible.CloseGump( typeof( GumpDebuff ) );
				m_cible.SendGump( new GumpDebuff( m_cible as NubiaPlayer  ) );
			}
			else if( m_cible is NubiaPlayer ){
				m_cible.CloseGump( typeof( GumpBuff ) );
				m_cible.SendGump( new GumpBuff( m_cible as NubiaPlayer  ) );
			}
		}

		public virtual void End()
		{  
			//Console.WriteLine("Endbuff");
			if ( m_cible != null && m_caster != null)
				m_caster.SendMessage("{0} prend fin sur {1}", Name, m_cible.Name);
			
			if( m_BodyModif &&  m_cible != null){
				m_cible.BodyMod = 0;
				m_cible.HueMod = -1;
				m_cible.NameMod = null;
			}
			if( m_isDebuff && m_cible != null)
			{
				lock(m_cible.DebuffList)
					m_cible.DebuffList.Remove(this as BaseDebuff);
			}
			else if( m_cible != null )
			{
				lock(m_cible.BuffList)
					m_cible.BuffList.Remove(this as BaseBuff);
			}
            m_cible.CloseGump(typeof(GumpBuff));
            m_cible.CloseGump(typeof(GumpDebuff));
            if (m_cible.BuffList.Count > 0 && m_cible is NubiaPlayer)
                m_cible.SendGump(new GumpBuff(m_cible as NubiaPlayer));
            if (m_cible.DebuffList.Count > 0 && m_cible is NubiaPlayer)
                m_cible.SendGump(new GumpDebuff(m_cible as NubiaPlayer));
			m_turn = -1;
		}
		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version

			writer.Write( (Mobile) m_caster );
			writer.Write( (Mobile) m_cible );

			writer.Write( (bool) m_isDebuff );

			writer.Write( (int) m_diffBonus );
			writer.Write( (int) m_hitsBonus );
			writer.Write( (int) m_manaBonus );
			writer.Write( (int) m_stamBonus );
			writer.Write( (int) m_icone );
			writer.Write( (bool) m_BodyModif );

			writer.Write( (string) m_descrip );
			writer.Write( (int) m_turn );

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
				
			m_caster = (NubiaMobile)reader.ReadMobile();
			m_cible =  (NubiaMobile)reader.ReadMobile();

			m_isDebuff = reader.ReadBool();
			m_diffBonus = reader.ReadInt();
			m_hitsBonus = reader.ReadInt();
			m_manaBonus = reader.ReadInt();
			m_stamBonus = reader.ReadInt();
			m_icone = reader.ReadInt();
			m_BodyModif = reader.ReadBool();
			m_descrip = reader.ReadString();
			m_turn = reader.ReadInt();

			if(  m_cible != null && !m_isDebuff && m_turn > 1){
				m_cible.BuffList.Add( this as BaseBuff );
			}
			else if(  m_cible != null && m_isDebuff && m_turn > 1 ){
				m_cible.DebuffList.Add( this as BaseDebuff );
			}
		}
	}
}
