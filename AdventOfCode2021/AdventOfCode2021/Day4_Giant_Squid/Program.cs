using System;
using System.Collections;
using System.IO;
using Day4_Giant_Squid;

class Program
{
    public static void Main(string[] args)
    {
        List<string> input = new List<string>();
        string[] winningNums;
        int boardSize = 5;
        try
        {
            // Format:
            // First line is comma delimited order of "read"
            // Then empty line followed by 5 lines of 5 numbers each, followed by empty lines between each board
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                winningNums = (reader.ReadLine()??"").Split(',');
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine() ?? "";
                    if (String.IsNullOrEmpty(line))
                        continue;
                    input.Add(line);
                }
            }

            Console.WriteLine("Part1 = " + Part1(input, winningNums, boardSize));
            Console.WriteLine("Part2 = " + Part2(input, winningNums, boardSize));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static int Part1(List<string> input, string[] winningNums, int boardSize)
    {
        int result = 0;
        string[,,] boards;
        int winningBoard = -1;
        int finalWinningNumber = -1;
        int sumOfWinningBoard = 0;
        try
        {
            // figure out how many boards there are and prototyping the boards array
            boards = InitializeBoard(input, boardSize);

            PlayBingo(ref boards, winningNums, boardSize, ref winningBoard, ref finalWinningNumber);

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (boards[winningBoard, row, col] != "-")
                        sumOfWinningBoard += int.Parse(boards[winningBoard, row, col]);
                }
            }

            //PrintBoards(boards, boardSize);
            result = sumOfWinningBoard * finalWinningNumber;
        }
        catch (Exception e)
        {
            throw new Exception("An unexpected error occurred in Part 1: " + e.Message + ": " + e.StackTrace);
        }
        return result;
    }

    public static string[,,] InitializeBoard (List<string> input, int boardSize)
    {
        string[,,] boards = new string[input.Count / boardSize, boardSize, boardSize];
        // loop for each board
        for (int i = 0; i < input.Count / boardSize; i++)
        {
            // loop for each row
            for (int row = 0; row < boardSize; row++)
            {
                string[] inputRow = input[(i * boardSize) + row].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                // loop for each column
                for (int col = 0; col < boardSize; col++)
                {
                    boards[i, row, col] = inputRow[col];
                }
            }
        }
        return boards;
    }

    public static void PlayBingo(ref string[,,] boards, string[] winningNums, int boardSize, ref int winningBoard, ref int finalWinningNumber)
    {
        for(int num = 0; num < winningNums.Count(); num++)
        {
            // cycle through each board
            for (int i = 0; i < boards.GetLength(0); i++)
            {
                int[] rowMarked = new int[boardSize];
                int[] colMarked = new int[boardSize];
                // cycle through each row
                for (int row = 0; row < boardSize; row++)
                {
                    // cycle through each column
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (boards[i, row, col] == "-")
                        {
                            rowMarked[row]++;
                            colMarked[col]++;
                        }
                        else if (boards[i, row, col] == winningNums[num])
                        {
                            boards[i, row, col] = "-";
                            rowMarked[row]++;
                            colMarked[col]++;
                        }
                        if (rowMarked[row] == boardSize || colMarked[col] == boardSize)
                        {
                            winningBoard = i;
                            finalWinningNumber = int.Parse(winningNums[num]);
                            return;
                        }
                    }
                }
            }
        }
    }

    public static int Part2(List<string> input, string[] winningNums, int boardSize)
    {
        int result = 0;
        string[,,] boards;
        int winningBoard = -1;
        int finalWinningNumber = -1;
        int sumOfWinningBoard = 0;
        try
        {
            // figure out how many boards there are and prototyping the boards array
            boards = InitializeBoard(input, boardSize);

            PlayLastBingo(ref boards, winningNums, boardSize, ref winningBoard, ref finalWinningNumber);

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (boards[winningBoard, row, col] != "-")
                        sumOfWinningBoard += int.Parse(boards[winningBoard, row, col]);
                }
            }

            result = sumOfWinningBoard * finalWinningNumber;
        }
        catch (Exception e)
        {
            throw new Exception("An unexpected error occurred in Part 1: " + e.Message + ": " + e.StackTrace);
        }
        return result;
    }

    public static void PlayLastBingo(ref string[,,] boards, string[] winningNums, int boardSize, ref int winningBoard, ref int finalWinningNumber)
    {
        bool[] boardsWon = new bool[boards.GetLength(0)];
        int numberOfBoardsWon = 0;
        for (int num = 0; num < winningNums.Count(); num++)
        {
            // cycle through each board
            for (int i = 0; i < boards.GetLength(0); i++)
            {
                if (boardsWon[i])
                    continue;

                int[] rowMarked = new int[boardSize];
                int[] colMarked = new int[boardSize];
                // cycle through each row
                for (int row = 0; row < boardSize; row++)
                {
                    if (boardsWon[i])
                        continue;
                    // cycle through each column
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (boardsWon[i])
                            continue;
                        if (boards[i, row, col] == "-")
                        {
                            rowMarked[row]++;
                            colMarked[col]++;
                        }
                        else if (boards[i, row, col] == winningNums[num])
                        {
                            boards[i, row, col] = "-";
                            rowMarked[row]++;
                            colMarked[col]++;
                        }
                        if (rowMarked[row] == boardSize || colMarked[col] == boardSize)
                        {
                            boardsWon[i] = true;
                            numberOfBoardsWon++;
                            if (numberOfBoardsWon == boards.GetLength(0))
                            {
                                winningBoard = i;
                                finalWinningNumber = int.Parse(winningNums[num]);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

}