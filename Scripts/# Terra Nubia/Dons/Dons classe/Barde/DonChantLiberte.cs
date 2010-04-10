using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonChantLiberte : BaseDon
    {
        public DonChantLiberte()
            : base(DonEnum.ChantLiberte, "Chant de liberté", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
            if (p.Competences[CompType.Representation].getMaitrise() < 15)
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


            f.SendMessage("Qui voulez vous libérer ?");

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
                    mInstrument.PlayInstrumentWell(mOwner);
                    cible.SendMessage("Vous vous sentez libéré de toutes entraves magiques");
                    foreach (BaseDebuff debuff in cible.DebuffList)
                    {
                        if (debuff.Freeze)
                            debuff.End();
                    }
                    if (cible.Frozen)
                        cible.Frozen = false;
                }
            }
        }
    }
    
}
