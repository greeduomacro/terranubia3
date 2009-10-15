using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server.Spells
{
    public abstract class BaseSort
    {
        private string mName = "Nom du sort";
        protected int mRange = 15;

        public virtual bool ComposanteVerbal { get { return true; } }
        public virtual bool ComposanteGestuelle { get { return true; } }
        public virtual Item[] ComposanteMaterielle { get { return null; } }
        public virtual Item ComposanteFocaliseur { get { return null; } }
        public virtual MagieEcole Ecole { get { return MagieEcole.Abjuration; } }
        public virtual MagieType Type { get { return MagieType.Profane; } }
        public virtual SortAction Action { get { return SortAction.Neutral; } }
        public virtual SortTarget Target { get { return SortTarget.TargetSimple; } }


        public virtual TimeSpan Delay { get { return WorldData.TimeTour(); } }
        

        public BaseSort(string name)
        {
            mName = name;
        }

        public void Cast(NubiaMobile caster)
        {
            if (caster == null)
                return;
            if (!caster.Alive)
                return;

            List<Object> targets = new List<Object>();

            if (Target == SortTarget.Zone)
            {
                IPooledEnumerable eable = caster.GetMobilesInRange(mRange);
                
                foreach (NubiaMobile m in eable)
                {
                    if (m != null && m.Alive)
                        targets.Add(m);
                }
                new CastTimer(caster, this, targets.ToArray());
            }
        }

        protected virtual bool Execute(NubiaMobile caster, Object[] Args)
        {
            return true;
        }

        private class CastTimer : Timer
        {
            NubiaMobile mCaster = null;
            BaseSort mSort = null;
            Object[] mArgs = new Object[0];
            public CastTimer(NubiaMobile caster, BaseSort sort, Object[] Args)
                : base(sort.Delay)
            {
                mCaster = caster;
                mSort = sort;
                mArgs = Args;
            }
            protected override void OnTick()
            {
                if (mSort != null && mCaster != null)
                {

                    mSort.Execute(mCaster, mArgs);
                }
            }
        }
    }
}
