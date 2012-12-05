using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameOfLife
{
    public static class CellExtensions
    {
        static Cell[] cellTransform = new[]
            {
                new Cell { X = -1, Y = -1},
                new Cell { X = 0, Y = -1},
                new Cell { X = 1, Y = -1},
                new Cell { X = -1, Y = 0},
                new Cell { X = 1, Y = 0},
                new Cell { X = -1, Y = 1},
                new Cell { X = 0, Y = 1},
                new Cell { X = 1, Y = 1},
            };

        public static bool Lives(this Cell cell, ISet<Cell> cells)
        {
            var neighbors = cell.GetNeighbors(cells).Count();
            return neighbors == 3 || neighbors == 2;
        }

        public static bool CreatesNewLife(this Cell cell, ISet<Cell> cells, out ISet<Cell> newLife)
        {
            var emptyNeighbors = cellTransform.Select(t => cell + t).Where(c => !cells.Contains(c));
            newLife = new HashSet<Cell>(emptyNeighbors.Where(n => GetNeighbors(n, cells).Count() == 3));

            return newLife.Any();
        }

        public static ISet<Cell> GetNeighbors(this Cell cell, ISet<Cell> cells)
        {
            return new HashSet<Cell>(cellTransform.Select(t => cell + t).Where(c => cells.Contains(c)).Select(c => c));
        }
    }
}
