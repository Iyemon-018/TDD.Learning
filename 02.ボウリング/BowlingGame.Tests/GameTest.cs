using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class GameTest
    {
        private readonly Game _g;

        public GameTest()
        {
            _g = new Game();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _g.Roll(6);
            _g.Roll(4); // Spare
        }

        [Fact]
        public void GutterGameTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/18
            // ここまで完了した。
            RollMany(20, 0);

            Assert.Equal(_g.Score(), 0);
        }

        [Fact]
        public void AllOnesTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/26
            // ここまで完了した。
            RollMany(20, 1);

            Assert.Equal(_g.Score(), 20);
        }

        [Fact]
        public void OneSpareTest()
        {
            RollSpare();
            _g.Roll(3);
            RollMany(17, 0);

            Assert.Equal(_g.Score(), 16);
        }
    }
}
