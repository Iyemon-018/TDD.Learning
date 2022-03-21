using System;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public sealed class Game
    {
        private int _score;

        public void Roll(int pins)
        {
        }

        public int Score()
        {
            return _score;
        }
    }
}
