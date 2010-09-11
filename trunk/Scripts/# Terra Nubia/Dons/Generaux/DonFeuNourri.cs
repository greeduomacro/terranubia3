using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonFeuNourri : BaseDon
    {
        public override int Icone { get { return 21001; } }
        public override string Description
        {
            get
            {
                return "Condition. Dex 17, Tir à bout portant, Tir rapide, bonus de base à l’attaque +6.<br>"+
"Avantage. Au prix d’une action simple, le personnage peut tirer deux flèches sur un adversaire unique situé à 9 mètres ou moins. Le personnage effectue un seul jet d’attaque (avec un malus de –4) qui s’applique aux deux flèches. Les flèches infligent des dégâts normaux (voir Spécial pour les exceptions).<br>"+
"Si son bonus de base à l’attaque est au moins de +11, le personnage peut choisir de tirer trois flèches d’un coup au lieu de deux, mais avec un malus de –6 au lieu de –4. À partir d’un bonus de base à l’attaque de +16, il peut aussi tirer quatre flèches, avec un malus de –8.<br>"+
"Une éventuelle réduction des dégâts ou résistance s’applique séparément sur chaque flèche tirée.<br>"+
"Spécial. Quel que soit le nombre de flèches que tire le personnage, on n’applique d’éventuels dégâts relevant de la précision (comme une attaque sournoise) qu’une seule fois. En cas de coup critique, une seule des flèches inflige des dégâts accrus (au choix du joueur) et toutes les autres infligent des dégâts normaux.<br>"+
"Un guerrier peut choisir Feu nourri en tant que don supplémentaire.<br>" +
"Un rôdeur de niveau 6 ne portant aucune armure ou une armure légère et ayant choisi le style de combat à distance peut se battre comme s’il possédait ce don, même s’il n’en remplit pas les conditions.";
            }
        }
         public override bool WarriorDon { get { return true; } }
         public DonFeuNourri()
            : base(DonEnum.FeuNourri, "Feu nourri", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return ( mob.RawDex >= 17
                && mob.hasDon(DonEnum.TirABoutPortant)
                && mob.hasDon(DonEnum.TirRapide)
                //   && mob.hasDon(DonEnum.ExpertiseDuCombat)
              //  && mob.hasDon(DonEnum.SouplesseDuSerpent)
                && mob.BonusAttaque[0] >= 6);
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (p.Stam >= 10)
            {
                if (p.Weapon is BaseRanged)
                    p.NewActionCombat(ActionCombat.FeuNourri);
                else
                    p.SendMessage("Utilisable seulement avec Arc ou Arbalètes");
            }
            else
                p.SendMessage("Vous n'avez pas assez de souffle pour cela");
        }
    }
}