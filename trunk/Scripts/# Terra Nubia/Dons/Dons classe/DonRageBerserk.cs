using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;

namespace Server.Mobiles.Dons
{
    public class DonRageBerserk : BaseDon
    {
        public DonRageBerserk() : base(DonEnum.RageBerserker, "Rage Berserker", true) 
        {
            mAchatMax = 5;
            mLimiteDayUse = true;
        }

        public override void OnUse(NubiaPlayer p)
        {
            p.Emote("*s'enrage*");
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class RageBerserkBuff : BaseBuff
    {
        public RageBerserkBuff(NubiaPlayer caster)
            : base(caster, caster, 20736, false,
                3 + (int)DndHelper.GetCaracMod(caster, DndStat.Constitution, true), "Rage Berserker")
        {
            m_descrip = "bonus de +4 en Force, un bonus de +4 en Constitution ainsi qu’un bonus de moral de +2 aux jets de Volonté, mais subit dans le même temps un malus de –2 à la classe d’armure.";
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
