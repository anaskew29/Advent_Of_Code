using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_The_Treachery_of_Whales
{
    internal class Submarine
    {
        public int Position { get; set; }
        public int[] FuelCost { get; set; }

        public Submarine(int position, int maxPosition)
        {
            FuelCost = new int[maxPosition+1];
            for(int i = 0; i <= maxPosition; i++)
            {
                FuelCost[i] = Math.Abs(position - i);
            }
        }
    }
}
