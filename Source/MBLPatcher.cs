using System.Reflection;
using HarmonyLib;
using Verse;

namespace MoreBiotechLetters
{
    [StaticConstructorOnStartup]
    public class MBLPatcher
    {
        static MBLPatcher()
        {
            Harmony val = new Harmony("Buggy.MoreBiotechLetters");
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            val.PatchAll(executingAssembly);
        }
    }
}