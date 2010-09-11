using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonContreChant : BaseDon
    {
        public DonContreChant()
            : base(DonEnum.ContreChant, "Contre-Chant", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = true;            
        }

        public override void OnUse(NubiaPlayer p)
        {
            if (!hasConditions(p))
            {
                p.SendMessage("Vous n'avez pas assez de représentation pour cela");
                return;
            }
            p.Emote("*Chante en opposition*");
            IPooledEnumerable eable = p.GetMobilesInRange(8);
            foreach (NubiaMobile m in eable)
            {
                if (m.Competences[CompType.Representation].intRoll(true) < p.Competences[CompType.Representation].intRoll())
                {
                    m.SendMessage("A venir, dans l'attente de la magie :)");
                  //  m.InterruptCast(p, ClasseType.Barde);
                }
            }
            eable.Free();
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return mob.Competences[CompType.Representation].getMaitrise() >= 3;
        }
    }

}
