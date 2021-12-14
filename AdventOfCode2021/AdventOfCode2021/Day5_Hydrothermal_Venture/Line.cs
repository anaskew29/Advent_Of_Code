using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Hydrothermal_Venture
{
    public class Line
    {
        public List<Point> Points;

        public Line (int x1, int y1, int x2, int y2, bool includeDiagonal)
        {
            Points = new List<Point>();
            // Horizontal
            if (x1 == x2)
            {
                if (y1 <= y2)
                {
                    for (int i = y1; i <= y2; i++)
                    {
                        Point p = new Point(x1, i);
                        Points.Add(p);
                    }
                }
                else
                {
                    for (int i = y2; i <= y1; i++)
                    {
                        Point p = new Point(x1, i);
                        Points.Add(p);
                    }
                }
            }
            // Vertical
            else if (y1 == y2)
            {
                if (x1 <= x2)
                {
                    for (int i = x1; i <= x2; i++)
                    {
                        Point p = new Point(i, y1);
                        Points.Add(p);
                    }
                }
                else
                {
                    for (int i = x2; i <= x1; i++)
                    {
                        Point p = new Point(i, y1);
                        Points.Add(p);
                    }
                }
            }
            // Diagonal
            else if (includeDiagonal)
            {
                //int startX = x1;
                //int endX = x2;
                //int startY = y1;
                //int endY = y2;
                if (x1 <= x2 && y1 <= y2)
                {
                    while (x1 <= x2 && y1 <= y2)
                    {
                        Point p = new Point(x1, y1);
                        Points.Add(p);
                        x1++;
                        y1++;
                    }
                }
                else if (x1 >= x2 && y1 <= y2)
                {
                    while (x1 >= x2 && y1 <= y2)
                    {
                        Point p = new Point(x1, y1);
                        Points.Add(p);
                        x1--;
                        y1++;
                    }
                }
                else if (x1 <= x2 && y1 >= y2)
                {
                    while (x1 <= x2 && y1 >= y2)
                    {
                        Point p = new Point(x1, y1);
                        Points.Add(p);
                        x1++;
                        y1--;
                    }
                }
                else if (x1 >= x2 && y1 >= y2)
                {
                    while (x1 >= x2 && y1 >= y2)
                    {
                        Point p = new Point(x1, y1);
                        Points.Add(p);
                        x1--;
                        y1--;
                    }
                }
            }
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
