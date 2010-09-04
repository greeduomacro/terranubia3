using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonEnemiJureAberration : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureAberration()
            : base(DonEnum.EnemiJureAberration, "Enemi juré: Aberration", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureAnimal : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureAnimal()
            : base(DonEnum.EnemiJureAnimal, "Enemi juré: Animal", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureCreatureArticifielle : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureCreatureArticifielle()
            : base(DonEnum.EnemiJureCreatureArticifielle, "Enemi juré: Créature articifielle", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureDragon : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureDragon()
            : base(DonEnum.EnemiJureDragon, "Enemi juré: Dragon", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureElementaire : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureElementaire()
            : base(DonEnum.EnemiJureElementaire, "Enemi juré: Elémentaire", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureGeant : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureGeant()
            : base(DonEnum.EnemiJureGeant, "Enemi juré: Géant", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureHumanoide : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureHumanoide()
            : base(DonEnum.EnemiJureHumanoide, "Enemi juré: Humanoïde", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureMagique : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureMagique()
            : base(DonEnum.EnemiJureMagique, "Enemi juré: Creatures magiques", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureMortVivant : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureMortVivant()
            : base(DonEnum.EnemiJureMortVivant, "Enemi juré: Morts-vivants", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJurePlante : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJurePlante()
            : base(DonEnum.EnemiJurePlante, "Enemi juré: Plantes", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class DonEnemiJureVermine : BaseDon
    {
        //public override bool WarriorDon { get { return true; } }
        public DonEnemiJureVermine()
            : base(DonEnum.EnemiJureVermine, "Enemi juré: Vermines", false)
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