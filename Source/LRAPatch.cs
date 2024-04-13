using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreBiotechLetters
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(Pawn_AgeTracker), "BirthdayBiological")]
    public class LRAPatch
    {
        public static void Prefix(Pawn_AgeTracker __instance, out LRAData __state)
        {
            Pawn pawn = Traverse.Create(__instance).Field("pawn").GetValue<Pawn>();
            __state = new LRAData(ref pawn);
        }
        
        public static void Postfix(int birthdayAge, LGRFData __state)
        {
            Pawn pawn = __state.Pawn;
            if (!pawn.IsColonist && !pawn.IsPrisonerOfColony)
            {
                return;
            }
            if (birthdayAge != 16)
            {
                return;
            }
            
            bool sendLetter = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().sendRomanceableAge;
            bool pause = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().pauseRomanceableAge;
            bool debug = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().debug;

            string labelShort = pawn.LabelShort;
            if (sendLetter)
            {
                TaggedString letterLabel = "LRA_Letter_Label".Translate();
                TaggedString letterMessage = "LRA_Letter_Text".Translate(labelShort);
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
                Log.Message($"LetterRomanceableAge: Pawn: {pawn.LabelShort}, AgeBiologicalYears: {pawn.ageTracker.AgeBiologicalYears}");
            }
            return;
        }
    }
}