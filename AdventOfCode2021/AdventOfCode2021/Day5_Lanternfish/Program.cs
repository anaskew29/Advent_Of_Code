using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        string[] inputs;
        int days = -1;
        List<int> lanternfish = new List<int>();
        using (StreamReader reader = new StreamReader("input.txt"))
        //using (StreamReader reader = new StreamReader("example.txt"))
        {
            // input only has one line
            inputs = (reader.ReadLine()??"").Split(',');
        }

        for(int i = 0; i < inputs.Length; i++)
        {
            lanternfish.Add(int.Parse(inputs[i]));
        }

        while (days < 0)
        {
            Console.WriteLine("How many days?");
            if (!int.TryParse(Console.ReadLine(), out days)) 
                days = -1;
        }

        Console.WriteLine("Solution = " + Part2(inputs, days));
    }

    public static int Part1(string[] inputs, int days)
    {
        List<int> lanternfish = new List<int>();
        for (int i = 0; i < inputs.Length; i++)
        {
            lanternfish.Add(int.Parse(inputs[i]));
        }
        for (int i = 0; i < days; i++)
        {
            for(int fish = 0; fish < lanternfish.Count; fish++)
            {
                lanternfish[fish]--;
                if (lanternfish[fish] < 0)
                {
                    lanternfish[fish] = 6;
                    lanternfish.Add(9); // because loop will count down today but new fish shouldn't count down until tomorrow
                }
            }
        }
        return lanternfish.Count;
    }

    public static long Part2(string[] inputs, int days)
    {
        long result = 0;
        long[] status = new long[10];
        for(int i = 0; i < status.Length; i++)
        {
            status[i] = 0;
        }
        foreach(string input in inputs)
        {
            int val = Convert.ToInt32(input);
            if (val >= 0 && val < status.Length)
                status[val]++;
            //for (int i = 0; i < status.Length; i++)
            //{
            //    status[i] = Convert.ToInt64(input);
            //Console.WriteLine("Status " + (val).ToString() + ": " + status[val]);
            //}
        }

        for(int day = 0; day < days; day++)
        {
            for (int i = 0; i < status.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        // all 0s become 7s and then add the same count to 9s because loop will count them down again (should be 6s and 8s)
                        status[7] += status[i];
                        status[9] += status[i];
                        status[i] = 0;
                        break;
                    default:
                        // all other numbers simply decrease in count (going from 0 to n, so the lower number has already been "moved down"
                        status[i-1] = status[i];
                        status[i] = 0;
                        //Console.WriteLine("Status " + (i - 1).ToString() + ": " + status[i - 1]);
                        break;
                }
            }
        }
        foreach(long cnt in status)
        {
            result += cnt;
        }
        return result;
    }
}