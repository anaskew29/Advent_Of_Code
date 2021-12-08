using System;
using System.IO;

class Program {
  public static void Main (string[] args) {
    StreamReader reader = new StreamReader("input.txt");
    using(reader)
    {
      int horizontal = 0;
      int depth = 0;
      int aim = 0;
      while (!reader.EndOfStream)
      {
        string[] str = reader.ReadLine().Split(' ');
        switch(str[0])
        {
          case "forward":
            horizontal += int.Parse(str[1]);
            depth += aim*int.Parse(str[1]);
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
      Console.WriteLine(horizontal*depth);
    }

  }
}