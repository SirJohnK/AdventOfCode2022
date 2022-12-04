using static System.Collections.Specialized.BitVector32;

namespace AdventOfCode2022;

internal class Day4
{
    public static int ExecutePart1()
    {
        return File.ReadAllLines(@"..\..\..\Day4Input.txt")
            .Select(line => line.Split(","))
            .Select(assignments => (assignments[0].Split("-"), assignments[1].Split("-")))
            .Select(ranges => (int.Parse(ranges.Item1[0]), int.Parse(ranges.Item1[1]), int.Parse(ranges.Item2[0]), int.Parse(ranges.Item2[1])))
            .Count(sections => (sections.Item1 <= sections.Item3 && sections.Item2 >= sections.Item4)
                               || (sections.Item3 <= sections.Item1 && sections.Item4 >= sections.Item2));
    }

    public static int ExecutePart2()
    {
        return File.ReadAllLines(@"..\..\..\Day4Input.txt")
            .Select(line => line.Split(","))
            .Select(assignments => (assignments[0].Split("-"), assignments[1].Split("-")))
            .Select(ranges => (int.Parse(ranges.Item1[0]), int.Parse(ranges.Item1[1]), int.Parse(ranges.Item2[0]), int.Parse(ranges.Item2[1])))
            .Count(sections => Enumerable.Range(sections.Item1, (sections.Item2 - sections.Item1) + 1)
                               .Intersect(Enumerable.Range(sections.Item3, (sections.Item4 - sections.Item3) + 1))
                               .Any());
    }
}