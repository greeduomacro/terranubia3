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
	public class SortNubiaSub : SortNubia
	{
		public override int GetCercle()
		{
				/*int niveau = (m_minDegat+m_maxDegat)/2; //Moyenne de degat
				niveau /= 4; //Un niveau tout les 4 dégats
				niveau += (m_number-1);
				if(distance < 10)
					niveau += (distance-10)/2;
				else
					niveau += (distance-10);
				if(m_canCible)
					niveau += 1;*/
				return (int)3;
		}

        public override SortDomaine Domaine { get { return SortDomaine.Chimere; } }
		public override bool mustConsume{ get{return false;}} //Pour consommer un Mobile/Item de condition;
		public override bool playEffect{ get	{	return false;	}} //Calibrer les effets dans la création
		public override bool isGestuel{ get{return false;}}
		public override bool mustCrier{ get{return false;}}
		public override bool isUnique{ get{return true;}}

		public override bool canBePere{ get{return false;}}

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
		public SortNubiaSub() : base ("Substitution")
		{
			distance = 1;
			Delay = 30.0;
			TimeToCast = 2.0;
		}
		[Constructable]
		public SortNubiaSub( Serial serial ) : base (serial)
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
			base.EndSortNubia();
		}
		public override bool Cast()
		{
			if(!base.Cast())
				return false;
			
			bool asSub = false;
			
			ArrayList Targets = new ArrayList();
			foreach ( Mobile m in Owner.GetMobilesInRange( 6 ) )
			{
				if(m is BaseCreature)
					Targets.Add(m);
			}
			if(Targets.Count > 0)
			{
				BaseCreature sb = null;
				foreach (BaseCreature c in Targets)
				{
					if( c.AI == AIType.AI_Animal /*&& c.ControlMaster != null && !c.Controlled*/ )
						sb = c;
				}
				if(sb != null)
				{
					KonohaClone clone = new KonohaClone( Owner, 0,0, 15.0 );
					clone.MoveToWorld(Owner.Location, Owner.Map);
					clone.substitute = sb;
					clone.Direction = Owner.Direction;
					if( Owner.Combatant != null )
					{
						clone.Combatant = Owner.Combatant;
						if(Owner.Combatant.Combatant == Owner)
							Owner.Combatant.Combatant = clone;
						Owner.Combatant = null;
					}
					Owner.Hidden = true;
					asSub = true;
				}
			}

			if(asSub)
			{
				return true;
				EndSortNubia();
			}
			ArrayList objetTargets = new ArrayList();
			foreach ( Item item in Owner.GetItemsInRange( 6 ) )
			{
				if(item.Movable)
					objetTargets.Add(item);
			}
			if(objetTargets.Count > 0)
			{
				int ind = Utility.RandomMinMax(0,objetTargets.Count-1);
				Item it = objetTargets[ind] as Item;
				KonohaClone clone = new KonohaClone( Owner, 0,0, 15.0 );
				clone.subItem = it;
				clone.MoveToWorld(Owner.Location, Owner.Map);
				clone.Direction = Owner.Direction;
				if( Owner.Combatant != null )
				{
					clone.Combatant = Owner.Combatant;
					if(Owner.Combatant.Combatant == Owner)
						Owner.Combatant.Combatant = clone;
					Owner.Combatant = null;
				}
				Owner.Hidden = true;
				asSub = true;
			}

			if(!asSub)
			{
				Owner.SendMessage("Impossible de trouver un objet ou un poulet pour la substitution");
			}

			EndSortNubia();
			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}		
	}

}