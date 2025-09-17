using HarmonyLib;
using Verse;

namespace FailproofRituals
{
    public class FailproofRitualsMod : Mod
    {
        public FailproofRitualsMod(ModContentPack pack) : base(pack)
        {
            new Harmony("FailproofRitualsMod").PatchAll();
        }
    }
}