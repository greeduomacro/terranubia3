using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Items;

namespace Server.Spells
{
    public class SortLumiere : BaseSort
    {
        public override bool ComposanteVerbal { get { return true; } }
        public override bool ComposanteGestuelle { get { return true; } }
        public override MagieEcole Ecole { get { return MagieEcole.Enchantement; } }
        public override MagieType Type { get { return MagieType.Profane; } }
        public override SortAction Action { get { return SortAction.Benefic; } }
        public override NSortTarget STarget { get { return NSortTarget.TargetSimple; } }
        public override Type[] ComposanteMaterielle
        {
            get
            {
                return new Type[]{typeof(SulfurousAsh) };
            }
        }

        public SortLumiere()
            : base("Lumière")
        {
           
        }
        public override int getRange(NubiaMobile caster, int casterNiveau, DndStat stat)
        {
            return 1;
        }
        protected override bool Execute(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle, object[] Args)
        {
            if (base.Execute(caster, casterNiveau, stat, cercle, Args))
            {
                //caster.Emote("*Chante une berceuse*");
                for (int a = 0; a < Args.Length; a++)
                {
                    if (Args[a] is NubiaMobile)
                    {
                        NubiaMobile targ = Args[a] as NubiaMobile;

                        if (targ.BeginAction(typeof(LightCycle)))
                        {
                            new LightCycle.NightSightTimer(targ).Start();
                            int level = (int)(LightCycle.DungeonLevel * 100  );

                            if (level < 0)
                                level = 0;

                            targ.LightLevel = level;

                            //targ.FixedParticles(0x376A, 9, 32, 5007, EffectLayer.Waist);
                            targ.PlaySound(0x1E3);

                            BuffInfo.AddBuff(targ, new BuffInfo(BuffIcon.NightSight, 1075643));	//Night Sight/You ignore lighting effects
                        }
                        else
                        {
                            caster.SendMessage("{0} est déjà sous un effet similaire.", targ.Name);
                        }                 
                    }
                }
            }
            return false;
        }
        

    }

}
