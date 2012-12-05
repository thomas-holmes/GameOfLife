using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameOfLife
{
    public class GameOfLife
    {
        private long _generation = 0L;


        public GameOfLife(int viewportX, int viewportY, ISet<Cell> initialState=null)
        {
            ViewportX = viewportX;
            ViewportY = viewportY;
            if (initialState != null)
                Cells = initialState;
            else
                Cells = GetDefaultState();
        }

        private ISet<Cell> GetDefaultState()
        {
            var glider = new[] {
                new Cell {X=1, Y=0},
                new Cell {X=2, Y=1},
                new Cell {X=0, Y=2},
                new Cell {X=1, Y=2},
                new Cell {X=2, Y=2},
            };

            return new HashSet<Cell>(glider);
        }
        public int ViewportX { get; private set; }
        public int ViewportY { get; private set; }

        public ISet<Cell> Cells { get; private set; }

        /// <summary>
        /// Advance generations
        /// </summary>
        /// <param name="step">Number of generations to advance</param>
        /// <returns>Resulting generation</returns>
        public long AdvanceGeneration(int step=1)
        {
            for (int i = 0; i < step; i++)
            {
                AdvanceOneGeneration();
            }

            return _generation;
        }

        private void AdvanceOneGeneration()
        {
            _generation++;

            var newCells = new HashSet<Cell>();

            foreach (var cell in Cells)
            {
                if (cell.Lives(Cells))
                    newCells.Add(cell);
                ISet<Cell> newLife;
                if (cell.CreatesNewLife(Cells, out newLife))
                    foreach (var newCell in newLife)
                        newCells.Add(newCell);
            }
            Cells = newCells;
        }
        #region Cell Testing


        #endregion

        #region Drawing
        public void DrawBoard()
        {

            var sb = new StringBuilder();
            for (int y = 0; y < ViewportY; y++)
            {
                for (int x = 0; x < ViewportX; x++)
                {
                    var c = new Cell { X = x, Y = y };
                    sb.Append(Cells.Contains(c) ? "X " : "  ");
                }
                sb.AppendLine();
            }
            System.Console.Clear();
            System.Console.Write(sb);
        }
        #endregion
    }
}