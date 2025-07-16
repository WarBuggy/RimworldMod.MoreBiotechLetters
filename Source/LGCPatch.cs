using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace MoreBiotechLetters
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(Building_MechGestator), "Notify_FormingCompleted")]
    public class LGCPatch
    {
        public static void Postfix()
        {
            bool sendLetter = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().sendGestationComplete;
            bool pause = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().pauseGestationComplete;
            bool debug = ((Mod)LoadedModManager.GetMod<MBLMod>()).GetSettings<MBLSettings>().debug;

            string message = "GestationComplete".Translate();
            if (sendLetter)
            {
                TaggedString letterLabel = message;
                ChoiceLetter letter = LetterMaker.MakeLetter(letterLabel, message, LetterDefOf.PositiveEvent, null, (Faction)null, (Quest)null, (List<ThingDef>)null);
                Find.LetterStack.ReceiveLetter((Letter)(object)letter, (string)null);
            }
            if (pause)
            {
                Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
            }
            if (debug)
            {
                Log.Message($"LetterGenesExtracted: Gestation completed.");
            }
        }
    }
}
