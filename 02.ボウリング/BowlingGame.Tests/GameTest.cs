namespace BowlingGame.Tests
{
    using ChainingAssertion;
    using Xunit;

    public class GameTest
    {
        private readonly Game _game;

        public GameTest()
        {
            _game = new Game();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }

        [Fact]
        public void Test_すべての投球で0本を倒すとスコアは0となること()
        {
            RollMany(20, 0);
            
            _game.Score().Is(0);
        }

        [Fact]
        public void Test_すべての投球で1本倒すとスコアは20となること()
        {
            RollMany(20, 1);

            _game.Score().Is(20);
        }

        [Fact]
        public void Test_1フレーム目でスペアをとって次の投球で3本倒すとスコアは16となること()
        {
            _game.Roll(6);
            _game.Roll(4);  // スペア
            _game.Roll(3);

            RollMany(17, 0);        // 残り17回すべて0とすることでここまで投球したスコアだけを計算する。

            _game.Score().Is(16);
        }

        [Fact]
        public void Test_1フレーム目でストライクをとって次のフレームで8本倒すとスコアは26となること()
        {
            _game.Roll(10); // ストライク
            _game.Roll(5);
            _game.Roll(3);  // これで１フレーム目は18点、２フレーム目は8点、合計26点となる。

            RollMany(16, 0);        // 残り16回すべて0とすることでここまで投球したスコアだけを計算する。

            _game.Score().Is(26);
        }

        [Fact]
        public void Test_ダブルをとって次のフレームで2本倒すとスコアは36となること()
        {
            _game.Roll(10); // ストライク
            _game.Roll(10); // ダブル
            _game.Roll(2);  // これで１フレーム目は22点、２フレーム目は12点、３フレーム目は2点、合計36点となる。

            RollMany(15, 0);        // 残り16回すべて0とすることでここまで投球したスコアだけを計算する。

            _game.Score().Is(36);
        }

        [Fact]
        public void Test_10フレーム目の2回で合計9本倒すとスコアは9となること()
        {
            RollMany(18, 0);

            _game.Roll(3);
            _game.Roll(6);

            _game.Score().Is(9);
        }

        [Fact]
        public void Test_10フレーム目でスペアと4本倒すとスコアは18となること()
        {
            RollMany(18, 0);

            _game.Roll(3);
            _game.Roll(7);  // スペア
            _game.Roll(4);

            _game.Score().Is(18);
        }

        [Fact]
        public void Test_10フレーム目でストライクと7本倒すとスコアは24となること()
        {
            RollMany(18, 0);

            _game.Roll(10); // ストライク
            _game.Roll(4);
            _game.Roll(3);

            _game.Score().Is(24);
        }

        [Fact]
        public void Test_10フレーム目でダブルと6本倒すとスコアは48となること()
        {
            RollMany(18, 0);

            _game.Roll(10); // ストライク
            _game.Roll(10); // ダブル
            _game.Roll(6);

            _game.Score().Is(48);
        }

        [Fact]
        public void Test_10フレーム目でトリプルだとスコアは60となること()
        {
            RollMany(18, 0);

            _game.Roll(10); // ストライク
            _game.Roll(10); // ダブル
            _game.Roll(10); // ターキー

            _game.Score().Is(60);
        }

        [Fact]
        public void Test_10フレームすべてストライクを取るとスコアは300となること()
        {
            RollMany(12, 10);
            _game.Score().Is(300);
        }
    }

    public class FrameTest
    {
        private readonly Frame _frame;

        public FrameTest()
        {
            _frame = new Frame(1);
        }

        [Fact]
        public void Test_1回目に1本_2回目に3本ピンを倒すとスコアは4になる()
        {
            _frame.KnockedDown(1);
            _frame.KnockedDown(3);
            _frame.Next(2);

            _frame.Score().Is(4);
        }

        [Fact]
        public void Test_1回目に7本_2回目に3本ピンを倒すとスコアは10になる()
        {
            _frame.KnockedDown(7);
            _frame.KnockedDown(3);
            _frame.Next(2);

            _frame.Score().Is(10);
        }

        [Fact]
        public void Test_1回目に1本_2回目に3本ピンを倒すと終了となる()
        {
            _frame.KnockedDown(1);
            _frame.Finish().IsFalse();

            _frame.KnockedDown(3);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_1回目に7本_2回目に3本ピンを倒すと終了となる()
        {
            _frame.KnockedDown(7);
            _frame.Finish().IsFalse();

            _frame.KnockedDown(3);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_1回目に10本ピンを倒すと終了となる()
        {
            _frame.KnockedDown(10);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_スペアをとった次に3本ピンを倒すと初回のフレームのスコアは13となる()
        {
            var frame = _frame;
            frame.KnockedDown(6);
            frame.KnockedDown(4);

            frame = _frame.Next(2);
            frame.KnockedDown(3);

            _frame.Score().Is(13);
        }

        [Fact]
        public void Test_ストライクをとった次のフレームで合計5本ピンを倒すと初回のフレームのスコアは15となる()
        {
            var frame = _frame;
            frame.KnockedDown(10);

            frame = _frame.Next(2);
            frame.KnockedDown(1);
            frame.KnockedDown(4);

            _frame.Score().Is(15);
        }

        [Fact]
        public void Test_ダブルをとった3フレーム目の1回目で5本ピンを倒すと初回フレームのスコアは25となる()
        {
            var frame = _frame;
            frame.KnockedDown(10);

            frame = frame.Next(2);
            frame.KnockedDown(10);

            frame = frame.Next(3);
            frame.KnockedDown(5);

            _frame.Score().Is(25);
        }
    }
}
