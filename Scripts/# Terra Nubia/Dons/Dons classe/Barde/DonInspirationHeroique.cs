﻿using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonInspirationHeroique : BaseDon
    {
        public DonInspirationHeroique()
            : base(DonEnum.InspirationHero, "Inspiration Héroïque", true)
        {
            mAchatMax = 5;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
            if (p.Competences[CompType.Representation].getMaitrise() < 13)
            {
                p.SendMessage("Vous n'êtes pas assez doué en représentation pour ce don");
                return;
            }

            p.ActionRevelation();

            if (p.FindItemOnLayer(Layer.TwoHanded) is BaseInstrument)
            {
                p.Target = new InternalTarget(p, p.FindItemOnLayer(Layer.TwoHanded) as BaseInstrument);
            }
            else
                BaseInstrument.PickInstrument(p, new InstrumentPickedCallback(OnPickedInstrument));

        }
        public static void OnPickedInstrument(Mobile f, BaseInstrument instrument)
        {
            NubiaMobile from = f as NubiaMobile;


            f.SendMessage("Qui voulez vous inspirer ?");

            f.Target = new InternalTarget(from, instrument);
        }

        public override bool hasConditions(NubiaPlayer mob)
        {
            return true;
        }
        private class InternalTarget : Target
        {
            NubiaMobile mOwner = null;
            BaseInstrument mInstrument = null;
            public InternalTarget(NubiaMobile f, BaseInstrument instrument)
                : base(12, false, TargetFlags.Beneficial)
            {
                mOwner = f;
                mInstrument = instrument;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is NubiaMobile)
                {

                    NubiaMobile cible = targeted as NubiaMobile;
                    if (cible == from)
                    {
                        from.SendMessage("Vous ne pouvez pas vous inspirer vous même");
                        return;
                    }
                    mInstrument.PlayInstrumentWell(mOwner);
                    new InspirationTalent(mOwner, cible);
                }
            }
        }
    }
    public class InspirationHeroique : BaseBuff
    {
        public InspirationHeroique(NubiaMobile caster, NubiaMobile cible)
            : base(caster, cible, 21008,
                20, "Inspiration Héroïque")
        {
            m_hitsBonus = 2 * 10;
            Sauvegardes.Add(new SauvegardeMod(2, SauvegardeEnum.Attaque));
            Sauvegardes.Add(new SauvegardeMod(1, SauvegardeEnum.Vigueur));
            m_descrip = "La musique et la présence du Barde vous inspire !";
        }
        public override bool OnTurn()
        {
            if (base.OnTurn())
            {
                if ((!m_cible.CanSee(m_caster) || !m_cible.InRange(m_caster.Location, 12)) && m_turn > 5)
                {
                    m_cible.SendMessage("Le barde est trop loin pour vous inspirer");
                    m_turn = 5;
                }
                return true;
            }
            else
                return false;
        }
    }
}
