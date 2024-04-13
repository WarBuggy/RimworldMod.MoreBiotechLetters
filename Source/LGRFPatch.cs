using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreBiotechLetters
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(HediffComp_Disappears), "CompPostPostRemoved")]
    public class LGRFPatch
    {
        public static void Prefix(HediffComp_Disappears __instance, out LGRFData __state)
        {
            Pawn pawn = Traverse.Create(__instance).Property("Pawn").GetValue<Pawn>();
            HediffDef def = Traverse.Create(__instance).Property("Def").GetValue<HediffDef>();
            __state = new LGRFData(ref pawn, ref def);
        }

        public static void Postfix(LGRFData __state)
        {
            Pawn pawn = __state.Pawn;
            HediffDef def = __state.Def;
            if (!PawnUtility.ShouldSendNotificationAbout(pawn))
            {
                return;
            }
            if (def != HediffDefOf.XenogermReplicating)
            {
                return;
            }

            bool sendLetter = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().sendLetterGenesRegrowFinished;
            bool pause = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().pauseGenesRegrowFinished;
            bool debug = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().debug;

            string labelShort = pawn.LabelShort;
            if (sendLetter)
            {
                TaggedString letterLabel = "LGRF_Letter_Label".Translate();
                TaggedString letterMessage = "LGRF_Letter_Text".Translate(labelShort);
                LookTargets lookTarget = new LookTargets(pawn);
                ChoiceLetter letter = LetterMaker.MakeLetter(letterLabel, letterMessage, LetterDefOf.NeutralEvent, lookTarget, (Faction)null, (Quest)null, (List<ThingDef>)null);
                Find.LetterStack.ReceiveLetter((Letter)(object)letter, (string)null);
            }
            if (pause)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
            }
            if (debug)
            {
                Log.Message($"LetterGenesRegrowFinished: Pawn: {pawn.LabelShort}, HediffDef: {def.defName}.");
            }
            return;
        }
    }
}