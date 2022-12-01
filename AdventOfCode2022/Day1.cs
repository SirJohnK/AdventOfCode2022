namespace AdventOfCode2022;

internal class Day1
{
    private static List<int> CaloriesByElf()
    {
        return File.ReadAllLines(@"..\..\..\Day1Input.txt").Aggregate(new List<int> { 0 },
                                           (list, value) =>
                                           {
                                               if (!string.IsNullOrEmpty(value))
                                                   list[list.Count - 1] += int.Parse(value);
                                               else
                                                   list.Add(0);
                                               return list;
                                           });
    }

    public static int ExecutePart1()
    {
        return CaloriesByElf().Max();
    }

    public static int ExecutePart2()
    {
        return CaloriesByElf().OrderDescending().Take(3).Sum();
    }
}