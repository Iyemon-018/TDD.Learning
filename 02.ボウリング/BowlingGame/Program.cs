using System;
using System.Linq;

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
        private Frame _frame;

        private Frame _currentFrame;

        private int _frameCount = 1;

        public Game()
        {
            _frame = new Frame(_frameCount);
            _currentFrame = _frame;
        }

        public bool Finish => _frameCount > 10;

        public void Roll(int pins)
        {
            _currentFrame.KnockedDown(pins);

            if (_currentFrame.Finish())
            {
                _frameCount++;
                _currentFrame = _currentFrame.Next(_frameCount);
            }
        }

        public int Score()
        {
            var score = 0;
            var frame = _frame;

            for (int frameCount = 1; frameCount <= 10; frameCount++)
            {
                score += frame.Score();
                frame = frame.Next(frameCount);
            }

            return score;
        }
    }

    public sealed class Frame
    {
        private readonly Roll[] _rolls;

        private int _currentRoll = 0;

        private Frame _next;

        public Frame(int count)
        {
            var rollCount = count == 10 ? 3 : 2;
            _rolls = Enumerable.Range(1, rollCount).Select(x => new Roll()).ToArray();
        }

        public Frame Next(int count) => count > 10 ? null : _next ??= new Frame(count);

        public bool Finish()
        {
            if (_currentRoll == _rolls.Count()) return true;
            if (_rolls.Count() == 2 && (_rolls.Strike() || _rolls.Spare())) return true;
            return false;
        }


        public void KnockedDown(int pins)
        {
            _rolls[_currentRoll].KnockedDown(pins);
            _currentRoll++;
        }

        private int KnockedDownPins() => _rolls.Sum(x => x.Pins);

        public int Score()
        {
            if (_rolls.Strike())
            {
                if (_next is null)
                {
                    // 10フレーム目
                    if (_rolls[1].Pins == 10)
                    {
                        return 10 + 10 + _rolls[2].Pins
                            + 10 + _rolls[2].Pins
                            + _rolls[2].Pins;
                    }
                    var pins = _rolls.Skip(1).Sum(x => x.Pins);
                    return 10 + pins + pins;
                }

                if (!_next._rolls.Strike()) return 10 + _next.KnockedDownPins();// ストライク
                if (!_next._next._rolls.Strike()) return 10 + 10 + _next._next.KnockedDownPins(); // ダブル
                return 10 + 10 + 10;  // ターキー
            }

            if (_rolls.Spare())
            {
                if (_next is null) return 10 + _rolls[2].Pins + _rolls[2].Pins; //10フレーム目

                return 10 + _next._rolls[0].Pins;   // スペア
            }

            return KnockedDownPins();
        }
    }

    internal static class RollsExtensions
    {
        public static bool Strike(this Roll[] self) => self[0].Pins == 10;

        public static bool Spare(this Roll[] self) => !self.Strike() && (self[0].Pins + self[1].Pins == 10);
    }
}
