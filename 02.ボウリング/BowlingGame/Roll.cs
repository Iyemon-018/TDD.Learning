using System;

namespace BowlingGame
{
    public sealed class Roll
    {
        private int _pins;

        public int Pins => _pins;

        public void KnockedDown(int pins)
        {
            _pins = pins;
        }
    }
}