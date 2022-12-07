using System.Security;

namespace AdventOfCode2022;

internal class Directory
{
    public Directory(string name, Directory? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; set; }
    public int Size => Directories.Sum(dir => dir.Size) + Files.Sum(file => file.Value);
    public List<Directory> Directories { get; set; } = new List<Directory>();
    public Dictionary<string, int> Files { get; set; } = new Dictionary<string, int>();
    public Directory? Parent { get; set; }
}

internal static class Day7
{
    private static Directory ExecuteLine(string line, Directory dir, Directory rootdir)
    {
        var info = line.Split(" ", StringSplitOptions.TrimEntries);
        if (info[0] == "$")
        {
            if (info[1] == "cd")
            {
                if (info[2] == "/")
                    return rootdir;
                else if (info[2] == "..")
                    return dir.Parent ?? rootdir;
                else
                    return dir.Directories.FirstOrDefault(dir => dir.Name == info[2]) ?? rootdir;
            }
        }
        else
        {
            if (info[0] == "dir")
                dir.Directories.Add(new Directory(info[1], dir));
            else
                dir.Files.Add(info[1], int.Parse(info[0]));
        }
        return dir;
    }

    private static Directory GetFileSystem(Directory rootdir)
    {
        var currentdir = rootdir;
        var output = File.ReadAllLines(@"..\..\..\Day7Input.txt").ToList();
        output.ForEach(line => currentdir = ExecuteLine(line, currentdir, rootdir));
        return rootdir;
    }

    private static int SumSize(int limit, Directory dir)
    {
        var sum = dir.Size > limit ? 0 : dir.Size;
        sum += dir.Directories.Select(dir => SumSize(limit, dir)).Sum();
        return sum;
    }

    private static int MinSize(int minspace, Directory dir)
    {
        var min = dir.Size < minspace ? 0 : dir.Size;
        dir.Directories.ForEach(subdir =>
        {
            var submin = MinSize(minspace, subdir);
            min = submin > 0 && submin < min ? submin : min;
        });
        return min;
    }

    public static int ExecutePart1()
    {
        var filesystem = GetFileSystem(new Directory(@"/"));
        return SumSize(100000, filesystem);
    }

    public static int ExecutePart2()
    {
        var filesystem = GetFileSystem(new Directory(@"/"));
        var minspace = 30000000 - (70000000 - filesystem.Size);
        return MinSize(minspace, filesystem);
    }
}