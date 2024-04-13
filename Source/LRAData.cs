using Verse;

namespace MoreBiotechLetters
{
    public readonly struct LRAData
    {
        public Pawn Pawn { get; }

        public LRAData(ref Pawn pawn)
        {
            Pawn = pawn;
        }
    }
}
