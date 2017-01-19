using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimWorld
{
    public class SpecialThingFilterWorker_Fresh : SpecialThingFilterWorker
    {
        public override bool CanEverMatch(ThingDef def)
        {
            var compProperties = def.GetCompProperties<CompProperties_Rottable>();
            return ((compProperties != null) && !compProperties.rotDestroys);
        }

        public override bool Matches(Thing t)
        {
            var comps = t as ThingWithComps;
            if (comps == null) return false;
            var comp = comps.GetComp<CompRottable>();
            return (((comp != null) && !((CompProperties_Rottable)comp.props).rotDestroys) && (comp.Stage == RotStage.Fresh));
        }
    }
}
