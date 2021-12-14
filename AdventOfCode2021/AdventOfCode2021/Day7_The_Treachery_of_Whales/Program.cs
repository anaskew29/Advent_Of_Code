using Day7_The_Treachery_of_Whales;
using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        string[] inputs;
        List<int[]> subs = new List<int[]>();
        using (StreamReader reader = new StreamReader("input.txt"))
        //using (StreamReader reader = new StreamReader("example.txt"))
        {
            // input only has one line
            inputs = (reader.ReadLine() ?? "").Split(',');
        }

        Console.WriteLine("Part1 = " + Part1(inputs));
        Console.WriteLine("Part2 = " + Part2(inputs));
    }

    public static int Part1(string[] inputs)
    {
        int result = 0;
        int maxPosition = 0;
        int[] positions;
        for (int i = 0; i < inputs.Length; i++)
        {
            int position = int.Parse(inputs[i]);
            if (position > maxPosition)
                maxPosition = position;
        }
        positions = new int[maxPosition+1];

        // calculate the fuel cost for each position from each position in input
        for (int pos = 0; pos < positions.Length; pos++)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                int fuelCost = Math.Abs(int.Parse(inputs[i]) - pos);
                positions[pos] += fuelCost;
            }
        }

        result = positions[0];
        foreach(int pos in positions)
        {
            if (pos < result)
                result = pos;
        }
        return result;

    }

    public static int Part2(string[] inputs)
    {
        int result = 0;
        int maxPosition = 0;
        int[] positions;
        for (int i = 0; i < inputs.Length; i++)
        {
            int position = int.Parse(inputs[i]);
            if (position > maxPosition)
                maxPosition = position;
        }
        positions = new int[maxPosition + 1];

        // calculate the fuel cost for each position from each position in input
        for (int pos = 0; pos < positions.Length; pos++)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                int fuelCost = CalculateTriangularNumber(Math.Abs(int.Parse(inputs[i]) - pos));
                positions[pos] += fuelCost;
            }
        }

        result = positions[0];
        foreach (int pos in positions)
        {
            if (pos < result)
                result = pos;
        }
        return result;

    }

    public static int CalculateTriangularNumber(int val)
    {
        float n = float.Parse(val.ToString());
        return Convert.ToInt32(n * ((n + 1) / 2));
    }
}