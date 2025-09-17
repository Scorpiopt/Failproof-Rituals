using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace FailproofRituals
{
    [HarmonyPatch(typeof(RitualOutcomeEffectWorker_FromQuality), nameof(RitualOutcomeEffectWorker_FromQuality.GetOutcome))]
    public static class RitualOutcomeEffectWorker_FromQuality_GetOutcome_Patch
    {
        public static void Postfix(ref RitualOutcomePossibility __result, float quality, LordJob_Ritual ritual)
        {
            if (!__result.Positive)
            {
                var positiveOutcomes = ritual.Ritual.outcomeEffect.def.outcomeChances
                    .Where(o => o.Positive)
                    .ToList();
                if (positiveOutcomes.Any())
                {
                    __result = positiveOutcomes.RandomElementByWeight(o => RitualOutcomeEffectWorker_FromQuality.ChanceWithQuality(o, quality));
                }
            }
        }
    }
}
