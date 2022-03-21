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

        private void RollStrike()
        {
            _g.Roll(10); // strike
        }

        [Fact]
        public void GutterGameTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/18
            // ‚±‚±‚Ü‚ÅŠ®—¹‚µ‚½B
            RollMany(20, 0);

            Assert.Equal(_g.Score(), 0);
        }

        [Fact]
        public void AllOnesTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/26
            // ‚±‚±‚Ü‚ÅŠ®—¹‚µ‚½B
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

        [Fact]
        public void OneStrikeTest()
        {
            RollStrike();
            _g.Roll(3);
            _g.Roll(4);
            RollMany(16, 0);

            Assert.Equal(_g.Score(), 24);
        }

        [Fact]
        public void PerfectGameTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/47
            // ŽÀ‘•‚ÍŠ®—¹‚µ‚½B
            RollMany(12, 10);

            Assert.Equal(_g.Score(), 300);
        }
    }
}
