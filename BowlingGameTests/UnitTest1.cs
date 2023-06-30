using BowlingGameNS;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        public GameTests()
        {  
            game = new BowlingGame();
        }

        
        private BowlingGame game;

        [TestMethod]
        public void CanRollGutterGame()
        {
            RollAmount(0, 20);
            Assert.AreEqual(0, game.Score);
        }

        [TestMethod]
        public void CanRollAllOnes()
        {
            RollAmount(1, 20);
            Assert.AreEqual(20, game.Score);
        }

        [TestMethod]
        public void CanRollSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollAmount(0, 17);
            Assert.AreEqual(16, game.Score);
        }

        [TestMethod]
        public void CanRollStrike()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollAmount(0, 16);
            Assert.AreEqual(24, game.Score);
        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            RollAmount(10, 12);
            Assert.AreEqual(300, game.Score);
        }

        private void RollAmount(int pins, int rolls)
        {
            for (var i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}