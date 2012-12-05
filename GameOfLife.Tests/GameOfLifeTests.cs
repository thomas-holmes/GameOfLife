using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Tests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void ThatAdvancingGliderByOneGenerationAdvancesGliderToSecondStage()
        {
            var game = new GameOfLife(10, 10, Patterns.Glider[0]);

            CollectionAssert.AreEquivalent(Patterns.Glider[0].ToList(), game.Cells.ToList());

            game.AdvanceGeneration(1);

            CollectionAssert.AreEquivalent(Patterns.Glider[1].ToList(), game.Cells.ToList());
        }

        [TestMethod]
        public void ThatAdvancingGliderByTwoGenerationsAdvancesGliderToThirdStage()
        {
            var game = new GameOfLife(10, 10, Patterns.Glider[0]);

            CollectionAssert.AreEquivalent(Patterns.Glider[0].ToList(), game.Cells.ToList());

            game.AdvanceGeneration(2);

            CollectionAssert.AreEquivalent(Patterns.Glider[2].ToList(), game.Cells.ToList());
        }
    }
}
