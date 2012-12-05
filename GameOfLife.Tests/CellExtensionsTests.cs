using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    [TestClass]
    public class CellExtensionsTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void ThatGetNeighborsReturnsAdjacentAndDiagonalCells()
        {
            var cell = new Cell { X = 1, Y = 0 };

            var neighbors = cell.GetNeighbors(Patterns.Glider[0]);

            Assert.AreEqual(1, neighbors.Count());
            Assert.AreEqual(new Cell { X = 2, Y = 1 }, neighbors.First());
        }

        [TestMethod]
        public void ThatCellWithTwoNeighborsSurvives()
        {
            var cell = new Cell { X = 2, Y = 2 }; // Has 2 neighbors, (1,2) and (2,1)

            Assert.IsTrue(cell.Lives(Patterns.Glider[0]));
        }

        [TestMethod]
        public void ThatCellWithThreeNeighborsSurvives()
        {
            var cell = new Cell { X = 1, Y = 2 }; // Has 3 neighbors, (1,0), (1,2), and (2,2)

            Assert.IsTrue(cell.Lives(Patterns.Glider[0]));
        }

        [TestMethod]
        public void ThatCellWithFewerThanTwoNeighborsDies()
        {
            var cell = new Cell { X = 1, Y = 0 }; // Has 1 neighbor, (2, 1)

            Assert.IsFalse(cell.Lives(Patterns.Glider[0]));
        }

        [TestMethod]
        public void ThatCellWithMoreThanThreeNeighborsDies()
        {
            var cell = new Cell { X = 1, Y = 2 }; // Has 4 neighbors, (0, 1), (2, 1), (2, 2), and (1, 3)

            Assert.IsFalse(cell.Lives(Patterns.Glider[1]));
        }

        [TestMethod]
        public void ThatCellSpawnsNewLifeIfEmptyNeighborHasThreeNeighbors()
        {
            var cell = new Cell { X = 0, Y = 2 };

            ISet<Cell> newLife;
            var createsNewLife = cell.CreatesNewLife(Patterns.Glider[0], out newLife);
        }
    }
}
