using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEsquive : BaseDon
    {
        public override int Icone { get { return 2261; } }
        public override string Description
        {
            get
            {
                return "Condition. Dex 13.<br>"+
"Avantage. Au cours de son tour de jeu, le personnage choisit un adversaire. Il bénéficie aussitôt d’un bonus d’esquive de +1 à la CA contre les attaques portées par cet adversaire.<br>"+
"Il perd automatiquement ce bonus s’il se trouve dans une situation lui faisant perdre son bonus de Dextérité à la CA. Contrairement à la plupart des types de bonus, le bonus d’esquive se cumule avec lui-même (il peut par exemple s’ajouter à celui dont les nains bénéficient naturellement contre les géants).<br>" +
"Spécial. Un guerrier peut choisir Esquive en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonEsquive()
            : base(DonEnum.Esquive, "Esquive", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.RawDex >= 13;
        }
    }
}