using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    [DebuggerDisplay("Cell ({X},{Y})")]
    public struct Cell
    {
        public int X;
        public int Y;


        public static Cell operator +(Cell p1, Cell p2)
        {
            return new Cell { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static Cell operator -(Cell p1, Cell p2)
        {
            return new Cell { X = p1.X - p2.X, Y = p1.Y - p2.Y };
        }
    }
}
