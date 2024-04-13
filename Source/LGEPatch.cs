using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreBiotechLetters
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(Building_GeneExtractor), "Finish")]
    public class LGEPatch
    {
        public static void Prefix(Building_GeneExtractor __instance, out LGEData __state)
        {
            Pawn containedPawn = Traverse.Create(__instance).Property("ContainedPawn").GetValue<Pawn>();
            __state = new LGEData(ref containedPawn);
        }

        public static void Postfix(LGEData __state)
        {
            Pawn containedPawn = __state.ContainedPawn;

            bool sendLetter = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().sendLetterGenesExtracted;
            bool pause = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().pauseGenesExtracted;
            bool debug = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().debug;

            //string message = "LGE_Letter_Text".Translate(containedPawn.LabelShort) + ": " + genesToAdd.Select((GeneDef x) => x.label).ToCommaList().CapitalizeFirst();
            string message = "LGE_Letter_Text".Translate(containedPawn.LabelShort);
            if (sendLetter)
            {
                TaggedString letterLabel = "LGE_Letter_Label".Translate();
                LookTargets lookTarget = new LookTargets(containedPawn);
                ChoiceLetter letter = LetterMaker.MakeLetter(letterLabel, message, LetterDefOf.NeutralEvent, lookTarget, (Faction)null, (Quest)null, (List<ThingDef>)null);
                Find.LetterStack.ReceiveLetter((Letter)(object)letter, (string)null);
            }
            if (pause)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
            }
            if (debug)
            {
                Log.Message($"LetterGenesExtracted: Pawn: {containedPawn.LabelShort}.");
            }
        }
    }
}