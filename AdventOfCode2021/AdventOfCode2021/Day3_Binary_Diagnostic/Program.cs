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

            Console.WriteLine("Part1 = " + Part1(input));
            Console.WriteLine("Part2 = " + Part2(input));
            //Part2(input);
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

    public static int Part2(List<string> input)
    {
        int result = 0;
        try
        {
            result = GetOxygenGeneratorRating(input) * GetCO2ScrubberRating(input);
        }
        catch (Exception e)
        {
            throw new Exception("An unexpected error occurred in Part 2: " + e.Message + ": " + e.StackTrace);
        }
        return result;
    }

    // To find oxygen generator rating, determine the most common value (0 or 1) in the current bit position, and keep only numbers with that bit in that position.
    // If 0 and 1 are equally common, keep values with a 1 in the position being considered.
    public static int GetOxygenGeneratorRating(List<string> input)
    {
        int result = 0;
        try
        {
            List<string> remaining = new List<string>(input);
            int count = 0;
            while (remaining.Count > 1)
            //while (count < 4)
            {
                int ones = 0;
                int zeroes = 0;
                for (int i = 0; i < remaining.Count; i++)
                {
                    if (remaining[i][count] == '1')
                        ones++;
                    else if (remaining[i][count] == '0')
                        zeroes++;
                }
                char remove = ones >= zeroes ? '0' : '1';
                foreach(string item in input)
                {
                    if (item[count] == remove)
                        remaining.Remove(item);
                }
                count++;
            }

            bool[] oxygenGeneratorRating = new bool[remaining[0].Length];
            for (int i = 0; i < remaining[0].Length; i++)
            {
                if (remaining[0][i] == '1')
                    oxygenGeneratorRating[i] = true;
                else
                    oxygenGeneratorRating[i] = false;
            }

            BitArray oxygenGeneratorRatingBA = new BitArray(oxygenGeneratorRating);

            result = getIntFromBitArray(oxygenGeneratorRatingBA);
        }
        catch
        {
            throw;
        }
        return result;
    }

    // To find CO2 scrubber rating, determine the least common value (0 or 1) in the current bit position, and keep only numbers with that bit in that position.
    // If 0 and 1 are equally common, keep values with a 0 in the position being considered.
    public static int GetCO2ScrubberRating(List<string> input)
    {
        int result = 0;
        try
        {
            List<string> remaining = new List<string>(input);
            int count = 0;
            while (remaining.Count > 1)
            {
                int ones = 0;
                int zeroes = 0;
                for (int i = 0; i < remaining.Count; i++)
                {
                    if (remaining[i][count] == '1')
                        ones++;
                    else if (remaining[i][count] == '0')
                        zeroes++;
                }
                char remove = zeroes > ones ? '0' : '1';
                foreach (string item in input)
                {
                    if (item[count] == remove)
                        remaining.Remove(item);
                }
                count++;
            }

            bool[] cO2ScrubberRating = new bool[remaining[0].Length];
            for (int i = 0; i < remaining[0].Length; i++)
            {
                if (remaining[0][i] == '1')
                    cO2ScrubberRating[i] = true;
                else
                    cO2ScrubberRating[i] = false;
            }

            BitArray cO2ScrubberRatingBA = new BitArray(cO2ScrubberRating);

            result = getIntFromBitArray(cO2ScrubberRatingBA);
        }
        catch
        {
            throw;
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