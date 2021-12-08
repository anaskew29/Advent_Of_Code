using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("input.txt");

        Console.WriteLine("Part1 = " + Part1(reader));
        Console.WriteLine("Part2 = " + Part2(reader));
    }

    public static int Part1(StreamReader reader)
    {
        reader.BaseStream.Position = 0;
        int horizontal = 0;
        int depth = 0;
        while (!reader.EndOfStream)
        {
            string[] str = reader.ReadLine().Split(' ');
            switch (str[0])
            {
                case "forward":
                    horizontal += int.Parse(str[1]);
                    break;
                case "up":
                    depth -= int.Parse(str[1]);
                    break;
                case "down":
                    depth += int.Parse(str[1]);
                    break;
                default:
                    break;
            }
        }
        return horizontal * depth;
    }

    public static int Part2(StreamReader reader)
    {
        reader.BaseStream.Position = 0;
        int horizontal = 0;
        int depth = 0;
        int aim = 0;
        while (!reader.EndOfStream)
        {
            string[] str = reader.ReadLine().Split(' ');
            switch (str[0])
            {
                case "forward":
                    horizontal += int.Parse(str[1]);
                    depth += aim * int.Parse(str[1]);
                    break;
                case "up":
                    aim -= int.Parse(str[1]);
                    break;
                case "down":
                    aim += int.Parse(str[1]);
                    break;
                default:
                    break;
            }
        }
        return horizontal * depth;
    }
}