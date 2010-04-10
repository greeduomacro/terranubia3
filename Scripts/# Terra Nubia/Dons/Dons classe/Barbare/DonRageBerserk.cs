using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;

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
            Sauvegardes.Add(new SauvegardeMod(4, SauvegardeEnum.Volonte));

            mCA = -2;
            if (caster is NubiaPlayer)
            {
                if (((NubiaPlayer)caster).hasDon(DonEnum.VolonteIndomptable))
                    Sauvegardes.Add(new SauvegardeMod(2, SauvegardeEnum.Volonte, new SortEnergie[] { SortEnergie.Mental }));
            }
            m_descrip = "Vous entrez dans une rage folle !";
        }
        public override void End()
        {
            if (Caster != null && Caster.Alive && Caster is NubiaPlayer)
            {
                if (!((NubiaPlayer)Caster).hasDon(DonEnum.RageSansFatigue))
                    new RageFatigueDebuff(Caster);
            }
            base.End();
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
            Sauvegardes.Add(new SauvegardeMod(3, SauvegardeEnum.Volonte));

            mCA = -2;

            if (caster is NubiaPlayer)
            {
                if (((NubiaPlayer)caster).hasDon(DonEnum.VolonteIndomptable))
                    Sauvegardes.Add(new SauvegardeMod(2, SauvegardeEnum.Volonte, new SortEnergie[] { SortEnergie.Mental }));
            }
            m_descrip = "Vous entrez dans une rage folle !";
        }
      
        public override void End()
        {
            if (Caster != null && Caster.Alive && Caster is NubiaPlayer)
            {
                if (!((NubiaPlayer)Caster).hasDon(DonEnum.RageSansFatigue))
                    new RageFatigueDebuff(Caster);
            }
            base.End();
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
            Sauvegardes.Add(new SauvegardeMod(2, SauvegardeEnum.Volonte));

            if (caster is NubiaPlayer)
            {
                if (((NubiaPlayer)caster).hasDon(DonEnum.VolonteIndomptable))
                    Sauvegardes.Add(new SauvegardeMod(2, SauvegardeEnum.Volonte, new SortEnergie[] { SortEnergie.Mental }));
            }

            mCA = -2;
            m_descrip = "Vous entrez dans une rage folle !";
        }
  
        public override void End()
        {
            if (Caster != null && Caster.Alive && Caster is NubiaPlayer)
            {
                if (!((NubiaPlayer)Caster).hasDon(DonEnum.RageSansFatigue))
                    new RageFatigueDebuff(Caster);
            }
            base.End();
        }
      
    }

    public class RageFatigueDebuff : BaseDebuff
    {
        public RageFatigueDebuff(NubiaMobile caster)
            : base(caster, caster, 2247, 20, "Fatigue")
        {
            mDex = -2;
            mDex = -2;

            m_descrip = "Votre rage vous à épuisé.";
        }
      
    }
}
