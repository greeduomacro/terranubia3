using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Items;
using Server.Gumps;
using Server.Spells;
namespace Server.Mobiles
{
	public class BaseDebuff : AbstractBaseBuff
	{
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
	}

	public class BaseBuff : AbstractBaseBuff
	{
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
	}

	public abstract class AbstractBaseBuff
	{
		protected NubiaMobile m_caster;
		protected NubiaMobile m_cible;
		protected bool m_isDebuff = false;
		protected int m_hitsBonus = 0;
		protected int m_manaBonus = 0;
		protected int m_stamBonus = 0;
		protected int m_DamageReflect = 0;
		protected int m_icone = 2242;
		protected string m_descrip = "";
		protected int m_turn = 10; //Nbr de tour avant le delect
		protected bool m_BodyModif = false;
        protected int mStr, mInt, mDex, mCons, mSag, mCha;
        protected int mDegatBonus = 0;
        protected List<SauvegardeMod> mSauvegardes = new List<SauvegardeMod>();
        protected List<CompetenceMod> mCompetences = new List<CompetenceMod>();
        protected bool m_Freeze = false;
        protected int mCA;
        protected string mName = "buff";

		//## GETTER & SETTER
        public string Name { get { return mName; } }
		public NubiaMobile Caster{get{return m_caster;}}
		public NubiaMobile Cible{get{return m_cible;}}
		public bool IsDebuff{get{return m_isDebuff;}}
		public int DamageReflect{get{return m_DamageReflect;}}
		public int HitsBonus{get{return m_hitsBonus;}}
		public int ManaBonus{get{return m_manaBonus;}}
		public int StamBonus{get{return m_stamBonus;}}
		public int Icone{get{return m_icone;}}
		public bool BodyModif {get{return m_BodyModif;}	}
		public int Turn{get{return m_turn;}}

        public int DegatBonus { get { return mDegatBonus; } }
        public int Str { get { return mStr; } }
        public int Int { get { return mInt; } }
        public int Dex { get { return mDex; } }
        public int Cons { get { return mCons; } }
        public int Sag { get { return mSag; } }
        public int Cha { get { return mCha; } }
        public List<SauvegardeMod> Sauvegardes { get { return mSauvegardes; } }
        public List<CompetenceMod> Competences { get { return mCompetences; } }
        public int CA { get { return mCA; } }
        public bool Freeze { get { return m_Freeze; } }

        public int getCompetence(CompType comp)
        {
            int val = 0;
            foreach (CompetenceMod mod in mCompetences)
            {
                if (mod.Comp == CompType.All || mod.Comp == comp)
                {
                    val = mod.Value;
                    break;
                }
            }
            return val;
        }

        public int getSauvegarde(SauvegardeEnum sauvegarde, SortEnergie ecole)
        {
            int save = 0;
            foreach (SauvegardeMod mod in mSauvegardes)
            {
                if (mod.Sauvegarde != sauvegarde)
                    continue;
                if (mod.Ecoles.Length == 0)
                    save += mod.Value;
                else
                {
                    for (int e = 0; e < mod.Ecoles.Length && ecole != SortEnergie.All; e++)
                    {
                        if (mod.Ecoles[e] == ecole)
                        {
                            save += mod.Value;
                            break;
                        }
                    }
                }
            }
            return save;
        }

		public string Descrip
		{
			get
			{
                return m_descrip + getModusDescript() + "<br><i>Tours restants: </i> " + m_turn;
			}
		}

        public string getModusDescript()
        {

            string des = "<br>";
            if (m_Freeze)
                des += "<br>Paralisant !";
            if( mStr != 0 )
                des += "<br><i>Force:</i> " + (mStr > 0 ? "+" : "") + mStr + "";
            if (mDex != 0)
                des += "<br><i>Dexterité:</i> " + (mDex > 0 ? "+" : "") + mDex + "";
            if (mInt != 0)
                des += "<br><i>Intelligence:</i> " + (mInt > 0 ? "+" : "") + mInt + "";
            if (mSag != 0)
                des += "<br><i>Sagesse:</i> " + (mSag > 0 ? "+" : "") + mSag + "";
            if (mCons != 0)
                des += "<br><i>Constitution:</i> " + (mCons > 0 ? "+" : "") + mCons + "";
            if (mCha != 0)
                des += "<br><i>Charisme:</i> " + (mCha > 0 ? "+" : "") + mCha + "";

            if( mDegatBonus != 0 )
                des += "<br><i>Bonus de dégat:</i> " + (mDegatBonus > 0 ? "+" : "") + mDegatBonus + "";
            for(int s = 0; s < (int)SauvegardeEnum.Reflexe; s++)
            {

                SauvegardeEnum save = (SauvegardeEnum)s;
                int generalVal = -999;
                for (int i = 0; i <= (int)SortEnergie.Mental; i++)
                {
                    SortEnergie ecole = (SortEnergie)i;
                    int val = getSauvegarde(save, ecole);
                    if (ecole == SortEnergie.All)
                        generalVal = val;
                    if (val != 0 && (val != generalVal || ecole == SortEnergie.All))
                    {
                        des += "<br><i>" + save.ToString() + ":</i> "+( val > 0 ? "+": "") + val;
                        if (ecole != SortEnergie.All)
                            des += " <i>( " + ecole.ToString() + " )</i>";                        
                    }
                    

                }
            }
            
            int compVal = -999;
            for (int c = -1; c < (int)CompType.Maximum; c++)
            {
                CompType comp = (CompType)c;
                int val = getCompetence(comp);
                if (comp == CompType.All)
                    compVal = val;
                if (val != 0 && ( val != compVal || comp == CompType.All) )
                {

                    string compName = comp.ToString();
                    if( ! (m_caster.Competences[comp] is NullCompetence ) )
                        compName =  m_caster.Competences[comp].Name;

                    if (comp == CompType.All)
                        compName = "Compétences";
                    des += "<br><i>" + compName + ":</i> " + (val > 0 ? "+" : "") + val;
                }
            }
            return des;
        }

		//## CONSTRUCTEUR
		public AbstractBaseBuff(NubiaMobile _caster, NubiaMobile _cible, int ico, bool _isDebuff, int _duration, string _name)
		{
			m_caster = _caster;
			m_cible = _cible;
			m_isDebuff = _isDebuff;
			m_icone = ico;
			m_turn = _duration;
            mName = _name;

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

		public virtual bool OnTurn()
		{
			if( m_cible == null || m_caster == null )
			{
				return false;
			}
			if( !m_cible.Alive  )
				return false;
            if (Freeze)
                m_cible.Freeze(WorldData.TimeTour());
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
			Console.WriteLine("Endbuff dans buff");
			if ( m_cible != null && m_caster != null)
				m_caster.SendMessage("{0} prend fin sur {1}", Name, m_cible.Name);
			
			if( m_BodyModif &&  m_cible != null){
				m_cible.BodyMod = 0;
				m_cible.HueMod = -1;
				m_cible.NameMod = null;
			}
		/*	if( m_isDebuff && m_cible != null)
			{
				lock(m_cible.DebuffList)
					m_cible.DebuffList.Remove(this as BaseDebuff);
			}
			else if( m_cible != null )
			{
				lock(m_cible.BuffList)
					m_cible.BuffList.Remove(this as BaseBuff);
			}*/
         /*   m_cible.CloseGump(typeof(GumpBuff));
            m_cible.CloseGump(typeof(GumpDebuff));
            if (m_cible.BuffList.Count > 0 && m_cible is NubiaPlayer)
                m_cible.SendGump(new GumpBuff(m_cible as NubiaPlayer));
            if (m_cible.DebuffList.Count > 0 && m_cible is NubiaPlayer)
                m_cible.SendGump(new GumpDebuff(m_cible as NubiaPlayer));*/
			m_turn = -1;
		}
		
	}
}
