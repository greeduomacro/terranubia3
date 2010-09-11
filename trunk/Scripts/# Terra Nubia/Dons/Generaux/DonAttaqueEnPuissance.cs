using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueEnPuissance : BaseDon
    {
        public override int Icone { get { return 21008; } }
        public override string Description
        {
            get
            {
                return "Condition. For 13.<br>"+
"Avantage. Pendant son tour de jeu et avant d’effectuer ses jets d’attaque, le personnage peut choisir un nombre, qu’il applique en tant que malus à tous ses jets d’attaque au corps à corps et en tant que bonus à tous ses jets de dégâts au corps à corps. La valeur choisie ne peut dépasser son bonus de base à l’attaque. Les modificateurs aux jets d’attaque et aux dégâts s’appliquent jusqu’au prochain tour de jeu du personnage.<br>"+
"Spécial. Si le personnage attaque à l’aide d’une arme à deux mains ou d’une arme à une main tenue à deux mains, il ajoute le double du nombre choisi à ses jets de dégâts. Les armes légères (à l’exception des attaques à mains nues ou des armes naturelles) ne peuvent bénéficier du bonus aux dégâts d’une attaque en puissance, mais le malus sur les jets d’attaque s’applique tout de même. (On considère habituellement une arme double comme une arme à une main couplée à une arme légère. Un personnage qui n’utilise qu’une des deux têtes d’une arme double peut la considérer comme une arme à deux mains en ce qui concerne une attaque en puissance.)<br>" +
"Un guerrier peut choisir Attaque en puissance en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonAttaqueEnPuissance()
            : base(DonEnum.AttaqueEnPuissance, "Attaque en puissance", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawStr >= 13);
        }
        public override void OnUse(NubiaPlayer p)
        {
            p.NewActionCombat(ActionCombat.AttaqueEnPuissance);
        }
    }
}