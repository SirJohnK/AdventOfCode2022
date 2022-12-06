namespace AdventOfCode2022;

internal static class Day6
{
    private static int GetStartOfDistinctSequence(int length)
    {
        var signal = File.ReadAllText(@"..\..\..\Day6Input.txt");
        return signal.Select((character, index) => new { Index = index, Sequence = signal.Skip(index).Take(length) })
            .First(sequenceinfo => sequenceinfo.Sequence.Distinct().Count() == length)
            .Index + length;
    }

    public static int ExecutePart1() => GetStartOfDistinctSequence(4);

    public static int ExecutePart2() => GetStartOfDistinctSequence(14);
}