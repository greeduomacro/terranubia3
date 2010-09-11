using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCourse : BaseDon
    {
        public override int Icone { get { return 2248; } }
        public override string Description
        {
            get
            {
                return "Avantage. Lorsqu’il court, l’aventurier couvre une distance égale à cinq fois sa vitesse de déplacement normale (s’il ne porte aucune armure ou une armure légère et qu’il transporte un poids léger ou moins) ou quatre fois sa vitesse de déplacement (s’il porte une armure intermédiaire ou lourde ou s’il transporte un poids intermédiaire ou lourd). Lorsqu’il exécute un saut avec élan (voir la compétence Saut), il bénéficie d’un bonus de +4 sur son test de Saut. Enfin, le personnage conserve son bonus de Dextérité à la CA lorsqu’il court.<br>"+
"Normal. On court habituellement à quatre fois sa vitesse de déplacement (si l’on ne porte ni une armure lourde, ni une charge lourde) ou trois fois sa vitesse de déplacement (si l’on porte une armure lourde ou une charge lourde), et l’on perd son bonus de Dextérité à la CA pendant une course.";
            }
        }
        //public override bool WarriorDon { get { return true; } }
        public DonCourse()
            : base(DonEnum.Course, "Course", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }
        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
        public override void OnUse(NubiaPlayer p)
        {
            if (DndHelper.GetBiggerArmor(p) == null || DndHelper.GetBiggerArmor(p).ModelType < ArmorModelType.Maille)
            {
                new SpeedContext(p, SpeedContext.SpeedState.Fast, "Course");
                new InternalTimer(p).Start();
            }
            else
                p.SendMessage("Votre armure est trop encombrante pour courir");
        }
        private class InternalTimer : Timer
        {
            NubiaPlayer owner = null;
            public InternalTimer(NubiaPlayer o): base(WorldData.TimeTour() )
            {
                owner = o;
            }
            protected override void  OnTick()
            {
                if (owner != null)
                    SpeedContext.RemoveContext(owner, "Course");
 	             base.OnTick();
            }
        }
    }
}