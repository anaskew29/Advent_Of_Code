using System;
using System.Collections;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        List<string> input = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    input.Add(reader.ReadLine());
                }
            }

            Part1(input);
            Console.WriteLine("Part1 = " + Part1(input));
            //Console.WriteLine("Part2 = " + Part2(reader));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static int Part1(List<string> input)
    {
        int result = 0;
        try
        {
            int[] ones;
            int[] zeroes;
            bool[] gamma;
            bool[] epsilon;
            if (input == null || input.Count < 1)
            {
                return 0;
            }
            ones = new int[input[0].Length];
            zeroes = new int[input[0].Length];
            gamma = new bool[input[0].Length];
            epsilon = new bool[input[0].Length];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '1')
                        ones[j]++;
                    else if (input[i][j] == '0')
                        zeroes[j]++;
                }
            }
            for (int i = 0; i < ones.Length; i++)
            {
                if (ones[i] > zeroes[i])
                    gamma[i] = true;
                else if (zeroes[i] > ones[i])
                    epsilon[i] = true;
            }

            BitArray gammaBA = new BitArray(gamma);
            BitArray epsilonBA = new BitArray(epsilon);

            result = getIntFromBitArray(gammaBA) * getIntFromBitArray(epsilonBA);
        }
        catch (Exception e)
        {
            throw new Exception("An unexpected error occurred in Part 1: " + e.Message + ": " + e.StackTrace);
        }
        return result;
    }

    public static int getIntFromBitArray(BitArray bitArray)
    {
        int result = 0;

        if (bitArray.Length > 32)
            throw new ArgumentException("Bit Array shall not exceed 32 bits.");

        for (int i = 0; i < bitArray.Count; i++)
        { 
            if (bitArray[i])
                result += Convert.ToInt16(Math.Pow(2, bitArray.Count - i - 1));
        }

        return result;
    }
}