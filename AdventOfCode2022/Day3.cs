namespace AdventOfCode2022;

internal class Day3
{
    private static int GetPriority(int value) => value >= 97 ? value - 96 : value - 38;

    public static int ExecutePart1()
    {
        return File.ReadAllLines(@"..\..\..\Day3Input.txt")
            .Select(line => (int)(line.Substring(0, line.Length / 2).Intersect(line.Substring(line.Length / 2)).First()))
            .Select(value => GetPriority(value))
            .Sum();
    }

    public static int ExecutePart2()
    {
        return File.ReadAllLines(@"..\..\..\Day3Input.txt").Chunk(3)
            .Select(rucksacks => (int)(rucksacks[0].Intersect(rucksacks[1].Intersect(rucksacks[2])).First()))
            .Select(value => GetPriority(value))
            .Sum();
    }
}