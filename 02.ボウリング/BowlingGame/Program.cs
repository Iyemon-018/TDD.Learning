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
        // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/29
        // ここまで完了した。
        private int _score;

        public void Roll(int pins)
        {
            // 現状の Roll メソッドは内部でスコア計算をしている。
            // しかし、メソッド名からスコア計算を行うことを推測するのは難しい。
            _score += pins;
        }

        public int Score()
        {
            // 現状の Score メソッドは内部でスコア計算をしていない。
            // しかし、メソッド名はスコア計算を行うことを明示している。
            return _score;
        }

        // つまりそれぞれのメソッド名とメソッドが実行していること（＝責務）がちぐはぐになっている。
        // これは設計が間違っていることを表している。
    }
}
