using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Spells
{
    public abstract class BaseSort
    {
        private string mName = "Nom du sort";

        private bool frizzle = false;

        public string Name { get { return mName; } }

        public virtual bool ComposanteVerbal { get { return true; } }
        public virtual bool ComposanteGestuelle { get { return true; } }
        public virtual Type[] ComposanteMaterielle { get { return null; } }
        public virtual Item ComposanteFocaliseur { get { return null; } }
        public virtual MagieEcole Ecole { get { return MagieEcole.Abjuration; } }
        public virtual MagieType Type { get { return MagieType.Profane; } }
        public virtual SortAction Action { get { return SortAction.Neutral; } }
        public virtual NSortTarget STarget { get { return NSortTarget.TargetSimple; } }

        public static TimeSpan AnimateDelay { get { return TimeSpan.FromMilliseconds(1500); } }
        public virtual TimeSpan Delay { get { return WorldData.TimeTour(); } }

        public virtual SauvegardeEnum Sauvegarde { get { return SauvegardeEnum.Vigueur; } }

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
        public virtual int getRange(NubiaMobile caster, int casterNiveau, DndStat stat)
        {
            return 15;
        }
        public static double getCoteEchec(double cote, int cercle)
        {
            double cercleMax = cote - 10;
            if (cercle <= cercleMax)
                return 0;
            else if (cercle <= cercleMax + 1)
                return 25;
            else if (cercle <= cercleMax + 2)
                return 50;
            else if (cercle <= cercleMax + 3)
                return 75;
            else
                return 100;
        }
        public static bool CheckCast(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle)
        {
            double echecPercent = 0;
            NubiaArmor armor = DndHelper.GetBiggerArmor(caster);
            
            if (armor != null)
                echecPercent = armor.PercentEchecSort;

            if ( caster is NubiaPlayer)
            {
                NubiaPlayer player = caster as NubiaPlayer;
                if (player.Frozen && !player.Competences[CompType.Concentration].check(15,0) )
                {
                    echecPercent += 100;
                }
                if (cercle > 0)
                {
                    echecPercent += getCoteEchec(player.Cote, cercle);
                   // caster.SendMessage("Echec du a la cote: " + echecPercent + "%");
                }
                if ((player.BodyValue != 400 && player.BodyValue != 401) && !player.hasDon(DonEnum.IncantationAnimale))
                {
                    echecPercent += 100;
                    player.SendMessage("Vous ne pouvez pas incanter sous cette forme");
                }
            }
            echecPercent /= 100;
            return echecPercent < Utility.RandomDouble();
        }
        public void Cast(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle)
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
                    IPooledEnumerable eable = caster.GetMobilesInRange(getRange(caster, casterNiveau, stat));

                    foreach (NubiaMobile m in eable)
                    {
                        if (m != null && m.Alive)
                            targets.Add(m);
                    }
                    new CastTimer(caster, this, casterNiveau, stat, cercle, targets.ToArray()).Start();
                }
                else if (STarget == NSortTarget.TargetSimple)
                {
                    caster.SendMessage("Selectionnez la cible de " + Name);
                    caster.Target = new SortTarget(caster, this, casterNiveau, stat, cercle);
                }
        }
        

        public virtual void DoFizzle(NubiaMobile m_Caster)
        {
            m_Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, false, "Le sort échoue"); // The spell fizzles.

                if (Core.AOS)
                    m_Caster.FixedParticles(0x3735, 1, 30, 9503, EffectLayer.Waist);
                else
                    m_Caster.FixedEffect(0x3735, 6, 30);

                m_Caster.PlaySound(0x5C);
            
        }
        protected virtual bool CheckResiste(NubiaMobile caster, NubiaMobile cible, int cercle, DndStat stat)
        {
            if (Action == SortAction.Benefic)
                return true;
            bool sauve = false;
            int DD = 10 + cercle + (int)DndHelper.GetCaracMod(caster, stat);            
            if (caster is NubiaPlayer)
            {
                NubiaPlayer playerCaster = caster as NubiaPlayer;
                if (Ecole == MagieEcole.Abjuration && playerCaster.hasDon(DonEnum.EcoleRenforceAbjuration))
                    DD++;
                else if (Ecole == MagieEcole.Divination && playerCaster.hasDon(DonEnum.EcoleRenforceDivination))
                    DD++;
                else if (Ecole == MagieEcole.Enchantement && playerCaster.hasDon(DonEnum.EcoleRenforceEnchantement))
                    DD++;
                else if (Ecole == MagieEcole.Evocation && playerCaster.hasDon(DonEnum.EcoleRenforceEvocation))
                    DD++;
                else if (Ecole == MagieEcole.Illusion && playerCaster.hasDon(DonEnum.EcoleRenforceIllusion))
                    DD++;
                else if (Ecole == MagieEcole.Ivocation && playerCaster.hasDon(DonEnum.EcoleRenforceInvocation))
                    DD++;
                else if (Ecole == MagieEcole.Necromancie && playerCaster.hasDon(DonEnum.EcoleRenforceNecromancie))
                    DD++;
                else if (Ecole == MagieEcole.Transmutation && playerCaster.hasDon(DonEnum.EcoleRenforceTransmutation))
                    DD++;

                if (Ecole == MagieEcole.Abjuration && playerCaster.hasDon(DonEnum.EcoleSuperieureAbjuration))
                    DD++;
                else if (Ecole == MagieEcole.Divination && playerCaster.hasDon(DonEnum.EcoleSuperieureDivination))
                    DD++;
                else if (Ecole == MagieEcole.Enchantement && playerCaster.hasDon(DonEnum.EcoleSuperieureEnchantement))
                    DD++;
                else if (Ecole == MagieEcole.Evocation && playerCaster.hasDon(DonEnum.EcoleSuperieureEvocation))
                    DD++;
                else if (Ecole == MagieEcole.Illusion && playerCaster.hasDon(DonEnum.EcoleSuperieureIllusion))
                    DD++;
                else if (Ecole == MagieEcole.Ivocation && playerCaster.hasDon(DonEnum.EcoleSuperieureInvocation))
                    DD++;
                else if (Ecole == MagieEcole.Necromancie && playerCaster.hasDon(DonEnum.EcoleSuperieureNecromancie))
                    DD++;
                else if (Ecole == MagieEcole.Transmutation && playerCaster.hasDon(DonEnum.EcoleSuperieureTransmutation))
                    DD++;
            }

            int roll = DndHelper.rollDe(De.vingt);
            switch (Sauvegarde)
            {
                case SauvegardeEnum.Reflexe: roll += cible.getBonusReflexe(this.Ecole); break;
                case SauvegardeEnum.Vigueur: roll += cible.getBonusVigueur(this.Ecole); break;
                case SauvegardeEnum.Volonte: roll += cible.getBonusVolonte(this.Ecole); break;
            }
            sauve = roll > DD;
            if (sauve)
            {
                cible.PrivateOverheadMessage(MessageType.Emote, Gumps.GumpNubia.ColorTextGreen, false, "*Sauvegarde*", cible.NetState);
                cible.PrivateOverheadMessage(MessageType.Emote, Gumps.GumpNubia.ColorTextGreen, false, "*Sauvegarde*", caster.NetState);
                caster.SendMessage("{0} réussi un jet de {2} contre {1}", cible.Name, Name, Sauvegarde.ToString());
                cible.SendMessage("Vous réussissez un jet de {1} contre {0}", Name, Sauvegarde.ToString());
            }
            return sauve;
        }

        protected virtual bool CheckRM(NubiaMobile mobile, NubiaMobile cible, int casterNiveau)
        {
            /*t. Pour déterminer si un sort ou un pouvoir magique 
             * fonctionne contre la créature, celui qui l’utilise 
             * doit effectuer un test de niveau de lanceur de sorts 
             * (1d20 + niveau de lanceur de sorts).*/
            int casterBonus = 0;
            if (mobile is NubiaPlayer)
            {
                if (((NubiaPlayer)mobile).hasDon(DonEnum.EfficaciteDesSortsAccrue))
                    casterBonus += 2;
                if (((NubiaPlayer)mobile).hasDon(DonEnum.EfficaciteDesSortsSuperieure))
                    casterBonus += 2;
            }
            if (cible.ResistanceMagie < 20 + casterNiveau)
            {
                int mageRoll = DndHelper.rollDe(De.vingt) + casterNiveau + casterBonus;
                bool resist = cible.ResistanceMagie > mageRoll;

                if (resist)
                {
                    cible.Emote("*Resiste*");
                    return true;
                }
            }
            else
            {
                cible.Emote("*Insensible*");
                return true;
            }

            return false;
        }
        
        protected virtual bool Execute(NubiaMobile caster, int casterNiveau, DndStat stat, int cercle, Object[] Args)
        {
            if (frizzle)
                caster.SendMessage("Votre sort à été interrompu");
           
            return !frizzle;
        }
        public class SortTarget : Target
        {
            BaseSort mSort = null;
            int mCasterNiveau = 0;
            DndStat mStat = DndStat.Charisme;
            int mCercle = 0;
            public SortTarget(NubiaMobile caster, BaseSort sort, int casterNiveau, DndStat stat, int cercle)
                : base(sort.getRange(caster, casterNiveau, stat), true, TargetFlags.None)
            {
                mSort = sort;
                mCasterNiveau = casterNiveau;
                mStat = stat;
               
                mCercle = cercle;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted != null && from != null && mSort != null)
                {
                    new CastTimer(from as NubiaMobile, mSort, mCasterNiveau, mStat, mCercle, new Object[]{targeted} ).Start();
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
            int mCasterNiveau = 0;
            DndStat mStat = DndStat.Charisme;
            int mCercle = 0;
            public CastTimer(NubiaMobile caster, BaseSort sort,int casterNiveau, DndStat stat, int cercle, Object[] Args)
                : base(sort.Delay)
            {
                mCaster = caster;
                mSort = sort;
                mArgs = Args;
                mCasterNiveau = casterNiveau;
                mStat = stat;
                mCercle = cercle;

                mCaster.ExposeToOpportunite();
                //mCaster.beginCast(sort, ClasseType.Barde, mCercle);
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
                    if (CheckCast(mCaster, mCasterNiveau,mStat, mCercle))
                    {
                        mSort.Execute(mCaster, mCasterNiveau, mStat, mCercle, mArgs);
                    }
                    else
                        mSort.DoFizzle(mCaster);
                }
            }
        }
    }
}
