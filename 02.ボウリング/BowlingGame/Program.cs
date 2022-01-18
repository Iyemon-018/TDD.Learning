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
        public void Roll(int pins)
        {
            throw new NotImplementedException();
        }

        public int Score()
        {
            throw new NotImplementedException();
        }
    }
}
