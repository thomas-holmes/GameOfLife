using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Patterns
    {
        #region Glider
        public static readonly ISet<Cell>[] Glider = new[] 
        {
            new HashSet<Cell>
            {
                new Cell {X=1, Y=0},
                new Cell {X=2, Y=1},
                new Cell {X=0, Y=2},
                new Cell {X=1, Y=2},
                new Cell {X=2, Y=2},
            },
            new HashSet<Cell>
            {
                new Cell {X=0, Y=1},
                new Cell {X=2, Y=1},
                new Cell {X=1, Y=2},
                new Cell {X=2, Y=2},
                new Cell {X=1, Y=3},
            },
            new HashSet<Cell>
            {
                new Cell {X=2, Y=1},
                new Cell {X=0, Y=2},
                new Cell {X=2, Y=2},
                new Cell {X=1, Y=3},
                new Cell {X=2, Y=3},
            },
        };
        #endregion
    }
}
