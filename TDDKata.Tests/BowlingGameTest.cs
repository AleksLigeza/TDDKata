using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CodeKata;

namespace TDDKata.Tests {
    [TestFixture]
    class BowlingGameTest {

        #region privateFields
        private BowlingGame _game;
        private int _frames = 10;
        #endregion

        #region Tests
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [Test]
        public void CanHandleSimilarLowScoreGame(int score) {
            _game = new BowlingGame();
            RollManySameScores(score, _frames * 2);
            Assert.AreEqual(score * _frames * 2, _game.Score());
        }

        [Test]
        public void CanHandleSpares() {
            _game = new BowlingGame();
            RollSpare();
            _game.Roll(3);
            RollManySameScores(0, 17);
            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void CanHandleStrike() {
            _game = new BowlingGame();
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(4);
            RollManySameScores(16, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [Test]
        public void CanHandlePerfectGame() {
            _game = new BowlingGame();
            RollManySameScores(10, 12);
            Assert.AreEqual(300, _game.Score());
        }
        #endregion

        #region TestHelpers

        public void RollManySameScores(int score, int rollsCount) {
            for (int i = 0; i < rollsCount; i++) {
                _game.Roll(score);
            }
        }

        public void RollSpare() {
            _game.Roll(5);
            _game.Roll(5);
        }

        #endregion
    }
}
