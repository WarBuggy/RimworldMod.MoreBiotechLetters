using Verse;

namespace MoreBiotechLetters
{
    public readonly struct LGRFData
    {
        public Pawn Pawn { get; }

        public HediffDef Def { get; }

        public LGRFData(ref Pawn pawn, ref HediffDef def)
        {
            Pawn = pawn;
            Def = def;
        }
    }
}
