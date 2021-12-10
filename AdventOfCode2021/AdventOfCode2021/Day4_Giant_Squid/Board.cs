using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Giant_Squid
{
    public class Board
    {
        public BoardNumber[,] BoardNumbers;
        public Board (int boardSize)
        {
            BoardNumbers = new BoardNumber[boardSize,boardSize];
        }
    }

    public class BoardNumber
    {
        public string Value { get; set; }
        public bool Marked { get; set; }

        public BoardNumber ()
        {
            Value = "";
            Marked = false;
        }
    }

}
