using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void ThatCellsAreEquivalentByContentNotReference()
        {
            var cell1 = new Cell { X = 1, Y = 2 };
            var cell2 = new Cell { X = 1, Y = 2 };

            Assert.AreEqual(cell1, cell2);
        }

        [TestMethod]
        public void ThatAdditionAddsXandYValues()
        {
            var cell1 = new Cell { X = 2, Y = 5 };
            var cell2 = new Cell { X = 1, Y = 4 };

            var cell3 = cell1 + cell2;

            Assert.AreEqual(new Cell { X = 3, Y = 9 }, cell3);
            Assert.AreEqual(3, cell3.X);
            Assert.AreEqual(9, cell3.Y);
        }
    }
}
