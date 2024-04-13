using Verse;

namespace MoreBiotechLetters
{
    public readonly struct LGEData
    {
        public Pawn ContainedPawn { get; }

        public LGEData(ref Pawn containedPawn)
        {
            ContainedPawn = containedPawn;
        }
    }
}
