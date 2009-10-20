using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells
{
    public abstract class BaseSort
    {
        private string mName = "Nom du sort";

        private bool frizzle = false;

        public string Name { get { return mName; } }

        public virtual bool ComposanteVerbal { get { return true; } }
        public virtual bool ComposanteGestuelle { get { return true; } }
        public virtual Item[] ComposanteMaterielle { get { return null; } }
        public virtual Item ComposanteFocaliseur { get { return null; } }
        public virtual MagieEcole Ecole { get { return MagieEcole.Abjuration; } }
        public virtual MagieType Type { get { return MagieType.Profane; } }
        public virtual SortAction Action { get { return SortAction.Neutral; } }
        public virtual NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public static TimeSpan AnimateDelay { get { return TimeSpan.FromMilliseconds(1500); } }
        public virtual TimeSpan Delay { get { return WorldData.TimeTour(); } }

        public BaseSort()
            : this("Sort Buggé!")
        {
        }
        public BaseSort(string name)
        {
            mName = name;
        }

        public virtual void doVerbal(NubiaMobile caster)
        {
            caster.Emote("*Incante*");
        }

        public void Interrupt()
        {
            frizzle = true;
        }
        public virtual int getRange(NubiaMobile caster, ClasseType classe, int cercle)
        {
            return 15;
        }
        public void Cast(NubiaMobile caster, ClasseType classe, int cercle)
        {
            //Console.WriteLine("Cast...");
            if (caster == null)
                return;
            if (!caster.Alive)
                return;

            frizzle = false;
            caster.NextSortCast = DateTime.Now + Delay;
            List<Object> targets = new List<Object>();

            
            if (STarget == NSortTarget.Zone)
            {
                //Console.WriteLine("Zone...");
                IPooledEnumerable eable = caster.GetMobilesInRange(getRange(caster, classe, cercle) );
                
                foreach (NubiaMobile m in eable)
                {
                    if (m != null && m.Alive)
                        targets.Add(m);
                }
                new CastTimer(caster, this,classe, cercle, targets.ToArray()).Start();
            }
            else if (STarget == NSortTarget.TargetSimple)
            {
                caster.SendMessage("Selectionnez la cible de " + Name);
                caster.Target = new SortTarget(caster, this,classe, cercle);
            }
        }
        public virtual bool CheckResiste(NubiaMobile cible,ClasseType classe, int cercle)
        {
            if (Action == SortAction.Benefic)
                return true;

            int DD = 10 + cible.getNiveauClasse(classe);
            int roll = DndHelper.rollDe(De.vingt) + cible.getBonusVolonte(Ecole);
            bool resist = roll >= DD;
            if (resist)
                cible.SendMessage("Vous resistez à " + Name);
            return resist;
        }
        

        protected virtual bool Execute(NubiaMobile caster,ClasseType classe, int cercle, Object[] Args)
        {
            if (frizzle)
                caster.SendMessage("Votre sort à été interrompu");
            return !frizzle;
        }
        public class SortTarget : Target
        {
            BaseSort mSort = null;
            ClasseType mClasse = ClasseType.Barde;
            int mCercle = 0;
            public SortTarget(NubiaMobile caster, BaseSort sort,ClasseType classe, int cercle)
                : base(sort.getRange(caster, classe, cercle), true, TargetFlags.None)
            {
                mSort = sort;
                mClasse = classe;
                mCercle = cercle;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted != null && from != null && mSort != null)
                {
                    new CastTimer(from as NubiaMobile, mSort, mClasse, mCercle, new Object[]{targeted} ).Start();
                }
            }
        }
        private class AnimTimer : Timer
        {
            private BaseSort m_Spell;
            private NubiaMobile m_Caster = null;
            public AnimTimer(BaseSort spell, NubiaMobile caster,  int count)
                : base(TimeSpan.Zero, AnimateDelay, count)
            {
                m_Spell = spell;
                m_Caster = caster;
                Priority = TimerPriority.FiftyMS;
            }

            protected override void OnTick()
            {
                /*if (m_Spell.State != SpellState.Casting || m_Spell.m_Caster.Spell != m_Spell)
                {
                    Stop();
                    return;
                }*/

            //    if (!m_Spell.Caster.Mounted && m_Spell.Caster.Body.IsHuman && m_Spell.m_Info.Action >= 0)
                m_Caster.Animate(17, 7, 1, true, false, 0);

               /** if (!Running)
                    m_Spell.m_AnimTimer = null;*/
            }
        }

        private class CastTimer : Timer
        {
            NubiaMobile mCaster = null;
            BaseSort mSort = null;
            Object[] mArgs = new Object[0];
            ClasseType mClasse = ClasseType.Barde;
            int mCercle = 0;
            public CastTimer(NubiaMobile caster, BaseSort sort,ClasseType classe, int cercle, Object[] Args)
                : base(sort.Delay)
            {
                mCaster = caster;
                mSort = sort;
                mArgs = Args;
                mClasse = classe;
                mCercle = cercle;


                if (mSort.ComposanteVerbal)
                    mSort.doVerbal(caster);
                if (mSort.ComposanteGestuelle)
                {
                    int count = (int)Math.Ceiling(Delay.TotalSeconds / AnimateDelay.TotalSeconds);
                    new AnimTimer(mSort, caster, count).Start();
                }
                //Console.WriteLine("Timer...");
            }
            protected override void OnTick()
            {
                if (mSort != null && mCaster != null)
                {
                   // Console.WriteLine("Tick!...");
                    mSort.Execute(mCaster,mClasse, mCercle, mArgs);
                }
            }
        }
    }
}
