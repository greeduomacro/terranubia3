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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme. Il peut aussi choisir les attaques à mains nues, la lutte ou les rayons.<br>" +
"Conditions. Maniement de l’arme choisie, bonus de base à l’attaque de +1.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise son arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection en tant que don supplémentaire. Un guerrier ne peut se choisir le don Spécialisation martiale que pour une de ses armes de prédilection.";
            }
        }
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
