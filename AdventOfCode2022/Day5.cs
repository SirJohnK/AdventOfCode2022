namespace AdventOfCode2022;

internal static class Day5
{
    private static void MoveCrates<T>(this List<Stack<T>> stacks, int count, int fromStack, int toStack, bool bulkmove = false)
    {
        if (count-- > 0)
        {
            var crate = stacks[fromStack].Pop();
            if (!bulkmove) stacks[toStack].Push(crate);
            stacks.MoveCrates(count, fromStack, toStack, bulkmove);
            if (bulkmove) stacks[toStack].Push(crate);
        }
    }

    private static List<Stack<string>> GetStacks()
    {
        return File.ReadAllLines(@"..\..\..\Day5Input.txt").TakeWhile(line => !line.TrimStart().StartsWith("1"))
            .Select(line => line.Chunk(4))
            .Select(chunkgroup => chunkgroup.Select(chunk => (new string(chunk)).Trim(new char[] { ' ', '[', ']' })))
            .SelectMany(crategroup => crategroup.Select((crate, index) => new { Index = index, Crate = crate }))
            .GroupBy(crateinfo => crateinfo.Index)
            .Select(stack => stack.Reverse())
            .Select(stack => new Stack<string>(stack.Where(crateinfo => !string.IsNullOrEmpty(crateinfo.Crate)).Select(crateinfo => crateinfo.Crate)))
            .ToList();
    }

    private static List<(int Count, int From, int To)> GetProcedure()
    {
        return File.ReadAllLines(@"..\..\..\Day5Input.txt")
            .SkipWhile(line => !line.StartsWith("move"))
            .Select(line => line.Split(" "))
            .Select(info => (int.Parse(info[1]), int.Parse(info[3]) - 1, int.Parse(info[5]) - 1))
            .ToList();
    }

    public static string ExecutePart1()
    {
        var stacks = GetStacks();
        var procedure = GetProcedure();
        procedure.ForEach(move => stacks.MoveCrates(move.Count, move.From, move.To));
        return string.Join(string.Empty, stacks.Select(stack => stack.Pop()));
    }

    public static string ExecutePart2()
    {
        var stacks = GetStacks();
        var procedure = GetProcedure();
        procedure.ForEach(move => stacks.MoveCrates(move.Count, move.From, move.To, true));
        return string.Join(string.Empty, stacks.Select(stack => stack.Pop()));
    }
}