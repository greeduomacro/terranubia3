using System;
using System.Collections.Generic;
using Server.Mobiles;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles.Dons
{
    public class DonCompagnonAnimal : BaseDon
    {
        public DonCompagnonAnimal()
            : base(DonEnum.CompagnonAnimal, "Compagnon Animal", true)
        {
            mAchatMax = 1;
            mLimiteDayUse = false;
        }

        public override void OnUse(NubiaPlayer p)
        {
         /*   if (p.Competences[CompType.Representation].getMaitrise() < 15)
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
            */
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
