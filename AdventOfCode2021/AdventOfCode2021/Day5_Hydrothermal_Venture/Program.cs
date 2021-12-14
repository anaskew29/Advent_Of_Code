using Day5_Hydrothermal_Venture;
using System;
using System.Collections;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        int maxX = 0;
        int maxY = 0;
        List<int[]> inputs = new List<int[]>();
        List<Line> lines = new List<Line>();
        try
        {
            using (StreamReader reader = new StreamReader("input.txt"))
            //using (StreamReader reader = new StreamReader("example.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] coordinates = (reader.ReadLine() ?? "").Split(" -> ");
                    if (coordinates.Length == 2)
                    {
                        int[] input = new int[4];
                        input[0] = int.Parse(coordinates[0].Split(',')[0]);
                        input[1] = int.Parse(coordinates[0].Split(',')[1]);
                        input[2] = int.Parse(coordinates[1].Split(',')[0]);
                        input[3] = int.Parse(coordinates[1].Split(',')[1]);

                        inputs.Add(input);
                        //Line line = new Line(x1, y1, x2, y2);
                        //lines.Add(line);

                        // Figure out the minimum size needed for grid
                        if (input[0] > maxX) maxX = input[0];
                        if (input[1] > maxY) maxY = input[1];
                        if (input[2] > maxX) maxX = input[2];
                        if (input[3] > maxY) maxY = input[3];
                    }
                }
            }

            Console.WriteLine("Part1 = " + Part1(inputs, maxX + 1, maxY + 1));
            Console.WriteLine("Part2 = " + Part2(inputs, maxX + 1, maxY + 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static int Part1(List<int[]> inputs, int sizeX, int sizeY)
    {
        int result = 0;
        int[,] grid;
        List<Line> lines = new List<Line>();
        try
        {
            foreach (int[] input in inputs)
            {
                if (input.Length == 4)
                {
                    Line line = new Line(input[0], input[1], input[2], input[3], false);
                    lines.Add(line);
                }
            }

            grid = InitializeGrid(sizeX, sizeY);
            PlotLines(lines, ref grid);

            //PrintGrid(grid);
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y] > 1)
                        result++;
                }
            }
        }
        catch { throw; }
        return result;
    }

    public static int Part2(List<int[]> inputs, int sizeX, int sizeY)
    {
        int result = 0;
        int[,] grid;
        List<Line> lines = new List<Line>();
        try
        {
            foreach (int[] input in inputs)
            {
                if (input.Length == 4)
                {
                    Line line = new Line(input[0], input[1], input[2], input[3], true);
                    lines.Add(line);
                }
            }

            grid = InitializeGrid(sizeX, sizeY);
            PlotLines(lines, ref grid);

            //PrintGrid(grid);
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y] > 1)
                        result++;
                }
            }
        }
        catch { throw; }
        return result;
    }

    public static int[,] InitializeGrid(int sizeX, int sizeY)
    {
        int[,] grid = new int[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                grid[x, y] = 0;
            }
        }
        return grid;
    }

    public static void PlotLines(List<Line> lines, ref int[,] grid)
    {
        foreach (Line line in lines)
        {
            foreach (Point p in line.Points)
            {
                grid[p.X, p.Y]++;
            }
        }
    }

    public static void PrintGrid(int[,] grid)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                Console.Write(grid[x, y]);
            }
            Console.WriteLine();
        }
    }


}