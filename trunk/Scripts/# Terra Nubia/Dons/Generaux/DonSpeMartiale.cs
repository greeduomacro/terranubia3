using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonSpeMartialeBaton : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>"+
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>"+
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>"+
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeBaton()
            : base(DonEnum.SpecialisationMartialeBaton, "Spécialisation martiale: Baton", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {

            return ( mob.hasDon(DonEnum.ArmeDePredilectionBaton) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeMasse : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeMasse()
            : base(DonEnum.SpecialisationMartialeMasse, "Spécialisation martiale: Masse", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionMasse) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeEpee : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeEpee()
            : base(DonEnum.SpecialisationMartialeEpee, "Spécialisation martiale: Epée", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionEpee)  && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeHache : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeHache()
            : base(DonEnum.SpecialisationMartialeHache, "Spécialisation martiale: Hache", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionHache) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeLance : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeLance()
            : base(DonEnum.SpecialisationMartialeLance, "Spécialisation martiale: Lance", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionLance) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeHast : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeHast()
            : base(DonEnum.SpecialisationMartialeHast, "Spécialisation martiale: Hast", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionHast)  && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeDague : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeDague()
            : base(DonEnum.SpecialisationMartialeDague, "Spécialisation martiale: Dague", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionDague) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeArc : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeArc()
            : base(DonEnum.SpecialisationMartialeArc, "Spécialisation martiale: Arc", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionArc) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeArbalete : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeArbalete()
            : base(DonEnum.SpecialisationMartialeArbalete, "Spécialisation martiale: Arbalète", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionArbalete) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialeJet : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
        "Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
        "Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
        "Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
        "Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialeJet()
            : base(DonEnum.SpecialisationMartialeJet, "Spécialisation martiale: Arme de jet", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionJet) && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
    public class DonSpeMartialePoing : BaseDon
    {
        public override int Icone { get { return 20483; } }
        public override string Description
        {
            get
            {
                return "Le personnage choisit une arme pour laquelle il possède le don Arme de prédilection. Il peut aussi choisir les attaques à mains nues ou la lutte.<br>" +
"Conditions. Maniement de l’arme choisie, Arme de prédilection pour l’arme choisie, guerrier de niveau 4.<br>" +
"Avantage. Le personnage obtient un bonus de +2 sur les jets de dégâts de l’arme choisie.<br>" +
"Spécial. Ce don peut être choisi plusieurs fois, mais ses effets ne se cumulent pas. Il s’applique à chaque fois à une nouvelle arme.<br>" +
"Un guerrier peut choisir Spécialisation martiale en tant que don supplémentaire.";
            }
        }
        public override bool WarriorDon { get { return true; } }
        public DonSpeMartialePoing()
            : base(DonEnum.SpecialisationMartialePoing, "Spécialisation martiale: Poings", false)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return (mob.hasDon(DonEnum.ArmeDePredilectionPoing)  && mob.getNiveauClasse(ClasseType.Guerrier) >= 4);
        }
    }
}
