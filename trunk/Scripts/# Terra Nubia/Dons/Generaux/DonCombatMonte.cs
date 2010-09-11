using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCombatMonte : BaseDon
    {
        public override int Icone { get { return 20745; } }
        public override string Description
        {
            get
            {
                return "Condition. Degré de maîtrise de 1 en Équitation.<br>"+
"Avantage. Lorsque sa monture est frappée au combat (dans la limite d’une fois par round), le personnage peut tenter d’annuler le coup en réussissant un test d’Équitation. C’est une réaction, pas une action. Le coup est annulé à condition que le test de compétence du personnage soit supérieur au jet d’attaque de l’adversaire. (Le test d’Équitation devient en quelque sorte la CA de la monture).<br>" +
"Spécial. Un guerrier peut choisir Combat monté en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonCombatMonte()
            : base(DonEnum.CombatMonte, "Combat monté", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.Competences[CompType.Equitation].getPureMaitrise() >= 1;
        }
    }
}