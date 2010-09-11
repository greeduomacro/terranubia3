using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonArmePredilectionSupBaton : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupBaton()
            : base(DonEnum.ArmeDePredilectionSupBaton, "Arme de prédilection Sup: Baton", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionBaton) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupMasse : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupMasse()
            : base(DonEnum.ArmeDePredilectionSupMasse, "Arme de prédilection Sup: Masse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionMasse) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupEpee : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupEpee()
            : base(DonEnum.ArmeDePredilectionSupEpee, "Arme de prédilection Sup: Epée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionEpee) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupHache : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupHache()
            : base(DonEnum.ArmeDePredilectionSupHache, "Arme de prédilection Sup: Hache", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionHache) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupLance : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupLance()
            : base(DonEnum.ArmeDePredilectionSupLance, "Arme de prédilection Sup: Lance", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionLance) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupHast : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupHast()
            : base(DonEnum.ArmeDePredilectionSupHast, "Arme de prédilection Sup: Hast", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionHast) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupDague : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupDague()
            : base(DonEnum.ArmeDePredilectionSupDague, "Arme de prédilection Sup: Dague", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionDague) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupArc : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupArc()
            : base(DonEnum.ArmeDePredilectionSupArc, "Arme de prédilection Sup: Arc", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionArc) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupArbalete : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupArbalete()
            : base(DonEnum.ArmeDePredilectionSupArbalete, "Arme de prédilection Sup: Arbalète", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionArbalete) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupJet : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupJet()
            : base(DonEnum.ArmeDePredilectionSupJet, "Arme de prédilection Sup: Arme de jet", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionJet) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
    public class DonArmePredilectionSupPoing : BaseDon
    {
        public override int Icone { get { return 21000; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 8.<br>" +
"Avantage. Le personnage bénéficie d’un bonus de +1 à tous ses jets d’attaque lorsqu’il utilise l’arme choisie. Ce bonus se cumule avec tous les autres bonus aux jets d’attaque, y compris celui du don Arme de prédilection.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Arme de prédilection supérieure en tant que don supplémentaire. Un guerrier ne peut choisir le don Spécialisation martiale supérieure que pour l’une de ses armes de prédilection supérieures.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonArmePredilectionSupPoing()
            : base(DonEnum.ArmeDePredilectionSupPoing, "Arme de prédilection Sup: Poings", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionPoing) && mob.getNiveauClasse(ClasseType.Guerrier) >= 8);
        }
    }
}
