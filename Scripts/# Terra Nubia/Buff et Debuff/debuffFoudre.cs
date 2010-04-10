using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Nubia;
using Server.Items;

namespace Server.Nubia
{

		public class FoudreDebuff : BaseDebuff
		{
			//## CONSTRUCTEUR
			public FoudreDebuff( NubiaMobile _caster ) : base(_caster, _caster, 0x8E9, 450 /*Une heure*/,"Foudroyé !")
			{
				//Name = "Crash!";
			/*	m_diffModus = -10;
				m_hitsModus = -10;
				m_stamModus = -10;*/
				m_descrip = "Vous avez reçu la foudre!";// Vous sentez encore la puissante décharge vous parcourir<br> <i> Malus de "+m_diffModus+" à tout les jets; Vie et stam réduite de "+m_hitsModus+" points";
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
}