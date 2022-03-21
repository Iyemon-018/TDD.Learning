using System;
using Xunit;

namespace BowlingGame.Tests
{
    public class GameTest
    {
        [Fact]
        public void GutterGameTest()
        {
            // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/18
            // Ç±Ç±Ç‹Ç≈äÆóπÇµÇΩÅB
            var g = new Game();

            for (int i = 0; i < 20; i++)
            {
                g.Roll(0);
            }

            Assert.Equal(g.Score(), 0);
        }
    }
}
