using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

namespace RockMixtapeTweaker.Patches;

/// <summary>
/// Patch <see cref="PerceivedLoudnessPerLevelModel.GetLoudnessCorrectionByLevelId"/> so it allows loudness correction up to 10 from the default 0.
/// </summary>
[HarmonyPatch(typeof(PerceivedLoudnessPerLevelModel), nameof(PerceivedLoudnessPerLevelModel.GetLoudnessCorrectionByLevelId))]
internal static class PerceivedLoudnessPerLevelModel_GetLoudnessCorrectionByLevelId
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instr in instructions)
        {
            // replace Mathf.Min(0f, ...) with Mathf.Min(10f, ...)
            if (instr.opcode == OpCodes.Ldc_R4 && (float)instr.operand == 0f)
            {
                yield return new CodeInstruction(OpCodes.Ldc_R4, 10f);
            }
            else
            {
                yield return instr;
            }
        }
    }
}
