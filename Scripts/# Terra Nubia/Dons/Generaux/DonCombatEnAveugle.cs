using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCombatEnAveugle : BaseDon
    {
        public override int Icone { get { return 2283; } }
        public override string Description
        {
            get
            {
                return "Avantage. Lors d’un combat au corps à corps, chaque fois que le personnage rate son adversaire en raison du camouflage de ce dernier, il peut jeter une nouvelle fois 1d100 afin de voir s’il touche (voir Camouflage).<br>"+
"Un assaillant invisible ne bénéficie d’aucun avantage offensif contre le personnage. Autrement dit, ce dernier ne perd pas son bonus de Dextérité à la CA et son adversaire n’a pas droit au bonus habituel de +2 des créatures invisibles. Un assaillant invisible conserve cependant ses avantages pour les attaques à distance.<br>"+
"En cas de mauvaises conditions de visibilité, la vitesse de déplacement du personnage est deux fois moins réduite que la normale. Dans l’obscurité, il progresse donc à 75 % de sa vitesse de déplacement normale, au lieu de 50 % pour les autres créatures.<br>"+
"Normal. Les aventuriers n’ayant pas ce don subissent les handicaps habituels contre les adversaires invisibles et en cas de mauvaise visibilité ou d’obscurité.<br>"+
"Spécial. Ce don n’est d’aucune utilité contre un personnage affecté par le sort clignotement.<br>" +
"Un guerrier peut choisir Combat en aveugle en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonCombatEnAveugle()
            : base(DonEnum.CombatEnAveugle, "Combat en aveugle", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
}