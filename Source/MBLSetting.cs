using Verse;

namespace MoreBiotechLetters
{
    public class MBLSettings : ModSettings
    {
        public bool sendLetterGenesRegrowFinished;

        public bool pauseGenesRegrowFinished;

        public bool sendLetterGenesExtracted;

        public bool pauseGenesExtracted;

        public bool sendRomanceableAge;

        public bool pauseRomanceableAge;

        public bool sendGestationComplete;

        public bool pauseGestationComplete;

        public bool debug;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref sendLetterGenesRegrowFinished, "sendLetterGenesRegrowFinished", true, false);
            Scribe_Values.Look(ref pauseGenesRegrowFinished, "pauseGenesRegrowFinished", true, false);
            Scribe_Values.Look(ref sendLetterGenesExtracted, "sendLetterGenesExtracted", true, false);
            Scribe_Values.Look(ref pauseGenesExtracted, "pauseGenesExtracted", true, false);
            Scribe_Values.Look(ref sendRomanceableAge, "sendRomanceableAge", true, false);
            Scribe_Values.Look(ref pauseRomanceableAge, "pauseRomanceableAge", true, false);
            Scribe_Values.Look(ref sendGestationComplete, "sendGestationComplete", true, false);
            Scribe_Values.Look(ref pauseGestationComplete, "pauseGestationComplete", true, false);
            Scribe_Values.Look(ref debug, "debug", false, false);
            base.ExposeData();
        }
    }
}
