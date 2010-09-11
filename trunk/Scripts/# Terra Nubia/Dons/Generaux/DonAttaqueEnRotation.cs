using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonAttaqueEnRotation : BaseDon
    {
        public override int Icone { get { return 21006; } }
        public override string Description
        {
            get
            {
                return "Conditions. Int 13, Dex 13, Attaque éclair, Esquive, Expertise du combat, Souplesse du serpent, bonus de base à l’attaque de +4.<br>"+
"Avantage. Lors d’une action d’attaque à outrance, le personnage peut sacrifier ses attaques normales pour porter à la place une attaque de corps à corps avec son bonus de base maximal à l’attaque contre chacun de ses adversaires dans sa zone de contrôle.<br>"+
"Un personnage qui effectue une attaque en rotation sacrifie aussi toutes les attaques supplémentaires dont il bénéficie habituellement, quelle que soit leur origine (comme le don Enchaînement ou le sort rapidité).<br>" +
"Spécial. Un guerrier peut choisir Attaque en rotation en tant que don supplémentaire.";
            }
        }
       // public override bool WarriorDon { get { return true; } }
        public DonAttaqueEnRotation()
            : base(DonEnum.AttaqueEnRotation, "Attaque en rotation", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawInt >= 13 && mob.RawDex >= 13 
                && mob.hasDon(DonEnum.AttaqueEclair) 
                && mob.hasDon(DonEnum.Esquive)
             //   && mob.hasDon(DonEnum.ExpertiseDuCombat)
                && mob.hasDon(DonEnum.SouplesseDuSerpent)
                && mob.BonusAttaque[0] >= 4 );
        }
        public override void OnUse(NubiaPlayer p)
        {
            if( !(p.Weapon is BaseRanged) )
                p.NewActionCombat(ActionCombat.AttaqueEnRotation);
        }
    }
}