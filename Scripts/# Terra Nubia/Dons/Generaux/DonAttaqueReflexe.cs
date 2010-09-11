using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueReflexe : BaseDon
    {
        public override int Icone { get { return 21539; } }
        public override string Description
        {
            get
            {
                return "Avantage. Chaque round, le personnage a droit un nombre d’attaques d’opportunité supplémentaires égal à son bonus de Dextérité. Il ne peut pas porter plus d’une attaques d’opportunité par opportunité.<br>"+
"Le personnage peut exécuter des attaques d’opportunité même s’il est pris au dépourvu.<br>"+
"Normal. Un personnage ne possédant pas ce don n’a droit qu’à une attaques d’opportunité par round et ne peut pas la placer s’il est pris au dépourvu.<br>"+
"Spécial. Ce don ne permet pas à un roublard d’utiliser son pouvoir spécial d’opportunisme plus d’une fois par round.<br>"+
"Un guerrier peut choisir Attaques réflexes en tant que don supplémentaire.<br>" +
"Un moine peut choisir Attaques réflexes en tant que don supplémentaire au niveau 2.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonAttaqueReflexe()
            : base(DonEnum.AttaquesReflexes, "Attaques reflexes", false)
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