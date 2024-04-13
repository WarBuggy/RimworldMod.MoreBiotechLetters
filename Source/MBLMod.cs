using UnityEngine;
using Verse;

namespace MoreBiotechLetters
{
    public class MBLMod : Mod
    {
        private readonly MBLSettings MBLSettings;

        public MBLMod(ModContentPack content)
            : base(content)
        {
            MBLSettings = base.GetSettings<MBLSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            listingStandard.Label("LGRF_Option".Translate());
            listingStandard.CheckboxLabeled("LGRF_Option_Letter".Translate(), ref MBLSettings.sendLetterGenesRegrowFinished);
            listingStandard.CheckboxLabeled("LGRF_Option_Pause".Translate(), ref MBLSettings.pauseGenesRegrowFinished);
            listingStandard.Gap();

            listingStandard.Label("LGE_Option".Translate());
            listingStandard.CheckboxLabeled("LGE_Option_Letter".Translate(), ref MBLSettings.sendLetterGenesExtracted);
            listingStandard.CheckboxLabeled("LGE_Option_Pause".Translate(), ref MBLSettings.pauseGenesExtracted);
            listingStandard.Gap();

            listingStandard.Label("LRA_Option".Translate());
            listingStandard.CheckboxLabeled("LRA_Option_Letter".Translate(), ref MBLSettings.sendRomanceableAge);
            listingStandard.CheckboxLabeled("LRA_Option_Pause".Translate(), ref MBLSettings.pauseRomanceableAge);
            listingStandard.Gap();

            listingStandard.Label("MBL_Option".Translate());
            listingStandard.CheckboxLabeled("MBL_Option_Debug".Translate(), ref MBLSettings.debug);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "MBL_Option_Mod_Name".Translate();
        }
    }
}