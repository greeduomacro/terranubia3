using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonTirRapide : BaseDon
    {
        public override int Icone { get { return 21016; } }
        public override string Description
        {
            get
            {
                return "Conditions. Dex 13, Tir à bout portant.<br>" +
"Avantage. Lorsqu’il entreprend une action d’attaque à outrance avec une arme à distance, le personnage a droit à une attaque supplémentaire. Cette attaque se fait avec son bonus de base à l’attaque maximal, mais toutes les attaques du round subissent un malus de –2 (l’attaque supplémentaire y compris).<br>" +
"Spécial. Un guerrier peut choisir Tir rapide en tant que don supplémentaire.<br>" +
"Un rôdeur de niveau 2 ne portant aucune armure ou une armure légère et ayant choisi le style de combat à distance peut se battre comme s’il possédait ce don, même s’il n’en remplit pas les conditions.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonTirRapide()
            : base(DonEnum.TirRapide, "Tir rapide", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.RawDex >= 13 && mob.hasDon(DonEnum.TirABoutPortant));
        }

    }

}
