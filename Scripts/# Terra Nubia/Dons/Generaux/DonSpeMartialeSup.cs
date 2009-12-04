using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSpeMartialeSupBaton : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupBaton()
            : base(DonEnum.SpecialisationMartialeSupBaton, "Spécialisation martiale supérieure: Baton", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {

            return ( mob.hasDon(DonEnum.ArmeDePredilectionSupBaton) && mob.hasDon(DonEnum.SpecialisationMartialeBaton) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupMasse : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupMasse()
            : base(DonEnum.SpecialisationMartialeSupMasse, "Spécialisation martiale supérieure: Masse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupMasse) && mob.hasDon(DonEnum.SpecialisationMartialeMasse) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupEpee : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupEpee()
            : base(DonEnum.SpecialisationMartialeSupEpee, "Spécialisation martiale supérieure: Epée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupEpee) && mob.hasDon(DonEnum.SpecialisationMartialeEpee) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupHache : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupHache()
            : base(DonEnum.SpecialisationMartialeSupHache, "Spécialisation martiale supérieure: Hache", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupHache) && mob.hasDon(DonEnum.SpecialisationMartialeHache) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupLance : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupLance()
            : base(DonEnum.SpecialisationMartialeSupLance, "Spécialisation martiale supérieure: Lance", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupLance) && mob.hasDon(DonEnum.SpecialisationMartialeLance) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupHast : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupHast()
            : base(DonEnum.SpecialisationMartialeSupHast, "Spécialisation martiale supérieure: Hast", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupHast) && mob.hasDon(DonEnum.SpecialisationMartialeHast) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupDague : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupDague()
            : base(DonEnum.SpecialisationMartialeSupDague, "Spécialisation martiale supérieure: Dague", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupDague) && mob.hasDon(DonEnum.SpecialisationMartialeDague) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupArc : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupArc()
            : base(DonEnum.SpecialisationMartialeSupArc, "Spécialisation martiale supérieure: Arc", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupArc) && mob.hasDon(DonEnum.SpecialisationMartialeArc) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupArbalete : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupArbalete()
            : base(DonEnum.SpecialisationMartialeSupArbalete, "Spécialisation martiale supérieure: Arbalète", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupArbalete) && mob.hasDon(DonEnum.SpecialisationMartialeArbalete) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupJet : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupJet()
            : base(DonEnum.SpecialisationMartialeSupJet, "Spécialisation martiale supérieure: Arme de jet", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupJet) && mob.hasDon(DonEnum.SpecialisationMartialeJet) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
    public class DonSpeMartialeSupPoing : BaseDon
    {
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeSupPoing()
            : base(DonEnum.SpecialisationMartialeSupPoing, "Spécialisation martiale supérieure: Poings", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionSupPoing) && mob.hasDon(DonEnum.SpecialisationMartialePoing) && mob.getNiveauClasse(ClasseType.Guerrier) >= 12);
        }
    }
}
