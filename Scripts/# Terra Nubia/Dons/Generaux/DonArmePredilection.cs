using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonArmePredilectionBaton : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionBaton()
            : base(DonEnum.ArmeDePredilectionBaton, "Arme de prédilection: Baton", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Baton) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionMasse : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionMasse()
            : base(DonEnum.ArmeDePredilectionMasse, "Arme de prédilection: Masse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Masse) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionEpee : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionEpee()
            : base(DonEnum.ArmeDePredilectionEpee, "Arme de prédilection: Epée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Masse) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionHache : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionHache()
            : base(DonEnum.ArmeDePredilectionHache, "Arme de prédilection: Hache", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hache) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionLance : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionLance()
            : base(DonEnum.ArmeDePredilectionLance, "Arme de prédilection: Lance", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Lance) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionHast : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionHast()
            : base(DonEnum.ArmeDePredilectionHast, "Arme de prédilection: Hast", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hast) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionDague : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionDague()
            : base(DonEnum.ArmeDePredilectionDague, "Arme de prédilection: Dague", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hast) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionArc : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionArc()
            : base(DonEnum.ArmeDePredilectionArc, "Arme de prédilection: Arc", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hast) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionArbalete : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionArbalete()
            : base(DonEnum.ArmeDePredilectionArbalete, "Arme de prédilection: Arbalète", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hast) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionJet : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionJet()
            : base(DonEnum.ArmeDePredilectionJet, "Arme de prédilection: Arme de jet", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Hast) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
    public class DonArmePredilectionPoing : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionPoing()
            : base(DonEnum.ArmeDePredilectionPoing, "Arme de prédilection: Poings", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.getMaitrise(ArmeTemplate.Poing) > 0 && mob.BonusAttaque[0] >= 1);
        }
    }
}
