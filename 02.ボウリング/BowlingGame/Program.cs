using System;

namespace BowlingGame
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public sealed class Game
    {
        // cf. https://www.slideshare.net/mdclement/bowling-game-kata-in-c-adapted/41
        // ここまで完了した。

        /// <summary>
        /// 投球ごとに倒したピンの数を記録します。
        /// </summary>
        private readonly int[] _rolls = new int[21];

        /// <summary>
        /// 現在の投球回数です。
        /// </summary>
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;          // 最終的なスコアの計算結果はここに格納されます。
            var roll  = 0;          // 投球回数の参照用インデックスです。

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(roll))
                {
                    // スペア発生時の得点数を計算する。
                    score += 10 + _rolls[roll + 2];
                }
                else
                {
                    // いずれの条件にも一致しなかったので、ボーナス無しの得点数を計算する。
                    score += _rolls[roll] + _rolls[roll + 1];
                }
                roll += 2;
            }

            return score;
        }

        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }
    }
}
