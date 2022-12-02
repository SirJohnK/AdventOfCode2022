namespace AdventOfCode2022;

internal class Day2
{
    /// <summary>
    /// A for Rock, B for Paper, and C for Scissors
    /// X for Rock, Y for Paper, and Z for Scissors
    /// Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock
    /// 1 for Rock, 2 for Paper, and 3 for Scissors
    /// 0 if you lost, 3 if the round was a draw, and 6 if you won
    /// </summary>
    private static int GetScore(string shape1, string shape2, bool convertShape = false)
    {
        //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win
        if (convertShape)
        {
            shape2 = (shape1, shape2) switch
            {
                ("A", "X") => "Z", //Lose
                ("A", "Y") => "X", //Draw
                ("A", "Z") => "Y", //Win
                ("C", "X") => "Y", //Lose
                ("C", "Y") => "Z", //Draw
                ("C", "Z") => "X", //Win
                _ => shape2
            };
        }

        return (shape1, shape2) switch
        {
            ("A", "X") => 1 + 3, //Draw
            ("A", "Y") => 2 + 6, //Won
            ("A", "Z") => 3 + 0, //Lost
            ("B", "X") => 1 + 0, //Lost
            ("B", "Y") => 2 + 3, //Draw
            ("B", "Z") => 3 + 6, //Won
            ("C", "X") => 1 + 6, //Won
            ("C", "Y") => 2 + 0, //Lost
            ("C", "Z") => 3 + 3, //Draw
            _ => 0
        };
    }

    public static int ExecutePart1()
    {
        return File.ReadAllLines(@"..\..\..\Day2Input.txt")
            .Select(line => line.Split(" "))
            .Select(shapes => GetScore(shapes[0], shapes[1]))
            .Sum();
    }

    public static int ExecutePart2()
    {
        return File.ReadAllLines(@"..\..\..\Day2Input.txt")
            .Select(line => line.Split(" "))
            .Select(shapes => GetScore(shapes[0], shapes[1], true))
            .Sum();
    }
}