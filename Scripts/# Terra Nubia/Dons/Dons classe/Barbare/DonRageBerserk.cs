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
            if (p.hasDon(DonEnum.RageMaitreBerserker))
                new RageMaitreBerserkBuff(p);
            else if (p.hasDon(DonEnum.RageGrandBerserker))
                new RageGrandBerserkBuff(p);
            else
                new RageBerserkBuff(p);
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
    }
    public class RageMaitreBerserkBuff : BaseBuff
    {
        public RageMaitreBerserkBuff(NubiaMobile caster)
            : base(caster, caster, 20736,
                3 + (int)DndHelper.GetCaracMod(caster, DndStat.Constitution, true), "Rage de Maitre Berserker")
        {
            mStr = 8;
            mCons = 8;
            mVolonte = 4;

            mCA = -2;

            if (caster.hasDon(DonEnum.VolonteIndomptable))
                mVolonte += 2;

            m_descrip = "bonus de +8 en Force et en Constitution ainsi qu’un bonus de moral de +" + mVolonte + " aux jets de Volonté, mais subit dans le même temps un malus de –2 à la classe d’armure.";
        }
        public RageMaitreBerserkBuff(Serial s)
            : base(s)
        {
        }
        public override void End()
        {
            if (Caster != null && Caster.Alive)
            {
                if (!Caster.hasDon(DonEnum.RageSansFatigue))
                    new RageFatigueDebuff(Caster);
            }
            base.End();
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
    public class RageGrandBerserkBuff : BaseBuff
    {
        public RageGrandBerserkBuff(NubiaMobile caster)
            : base(caster, caster, 20736,
                3 + (int)DndHelper.GetCaracMod(caster, DndStat.Constitution, true), "Rage de Grand Berserker")
        {
            mStr = 6;
            mCons = 6;
            mVolonte = 3;

            mCA = -2;

            if (caster.hasDon(DonEnum.VolonteIndomptable))
                mVolonte += 2;

            m_descrip = "bonus de +6 en Force et en Constitution ainsi qu’un bonus de moral de +"+mVolonte+" aux jets de Volonté, mais subit dans le même temps un malus de –2 à la classe d’armure.";
        }
        public RageGrandBerserkBuff(Serial s)
            : base(s)
        {
        }
        public override void End()
        {
            if (Caster != null && Caster.Alive)
            {
                if( !Caster.hasDon(DonEnum.RageSansFatigue) )
                    new RageFatigueDebuff(Caster);
            }
            base.End();
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
    public class RageBerserkBuff : BaseBuff
    {
        public RageBerserkBuff(NubiaMobile caster)
            : base(caster, caster, 20736,
                3 + (int)DndHelper.GetCaracMod(caster, DndStat.Constitution, true), "Rage Berserker")
        {
            mStr = 4;
            mCons = 4;
            mVolonte = 2;

            mCA = -2;
            m_descrip = "bonus de +4 en Force et en Constitution ainsi qu’un bonus de moral de +2 aux jets de Volonté, mais subit dans le même temps un malus de –2 à la classe d’armure.";
        }
        public RageBerserkBuff(Serial s)
            : base(s)
        {
        }
        public override void End()
        {
            if (Caster != null && Caster.Alive)
            {
                if (!Caster.hasDon(DonEnum.RageSansFatigue))
                    new RageFatigueDebuff(Caster);
            }
            base.End();
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

    public class RageFatigueDebuff : BaseDebuff
    {
        public RageFatigueDebuff(NubiaMobile caster)
            : base(caster, caster, 2247, 20, "Fatigue")
        {
            mDex = -2;
            mDex = -2;

            m_descrip = "Votre rage vous à épuisé. Vous subissez -2 en force et dexterité";
        }
        public RageFatigueDebuff(Serial s)
            : base(s)
        {
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
