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
        public void Test_���ׂĂ̓�����0�{��|���ƃX�R�A��0�ƂȂ邱��()
        {
            RollMany(20, 0);
            
            _game.Score().Is(0);
        }

        [Fact]
        public void Test_���ׂĂ̓�����1�{�|���ƃX�R�A��20�ƂȂ邱��()
        {
            RollMany(20, 1);

            _game.Score().Is(20);
        }

        [Fact]
        public void Test_1�t���[���ڂŃX�y�A���Ƃ��Ď��̓�����3�{�|���ƃX�R�A��16�ƂȂ邱��()
        {
            _game.Roll(6);
            _game.Roll(4);  // �X�y�A
            _game.Roll(3);

            RollMany(17, 0);        // �c��17�񂷂ׂ�0�Ƃ��邱�Ƃł����܂œ��������X�R�A�������v�Z����B

            _game.Score().Is(16);
        }

        [Fact]
        public void Test_1�t���[���ڂŃX�g���C�N���Ƃ��Ď��̃t���[����8�{�|���ƃX�R�A��26�ƂȂ邱��()
        {
            _game.Roll(10); // �X�g���C�N
            _game.Roll(5);
            _game.Roll(3);  // ����łP�t���[���ڂ�18�_�A�Q�t���[���ڂ�8�_�A���v26�_�ƂȂ�B

            RollMany(16, 0);        // �c��16�񂷂ׂ�0�Ƃ��邱�Ƃł����܂œ��������X�R�A�������v�Z����B

            _game.Score().Is(26);
        }

        [Fact]
        public void Test_�_�u�����Ƃ��Ď��̃t���[����2�{�|���ƃX�R�A��36�ƂȂ邱��()
        {
            _game.Roll(10); // �X�g���C�N
            _game.Roll(10); // �_�u��
            _game.Roll(2);  // ����łP�t���[���ڂ�22�_�A�Q�t���[���ڂ�12�_�A�R�t���[���ڂ�2�_�A���v36�_�ƂȂ�B

            RollMany(15, 0);        // �c��16�񂷂ׂ�0�Ƃ��邱�Ƃł����܂œ��������X�R�A�������v�Z����B

            _game.Score().Is(36);
        }

        [Fact]
        public void Test_10�t���[���ڂ�2��ō��v9�{�|���ƃX�R�A��9�ƂȂ邱��()
        {
            RollMany(18, 0);

            _game.Roll(3);
            _game.Roll(6);

            _game.Score().Is(9);
        }

        [Fact]
        public void Test_10�t���[���ڂŃX�y�A��4�{�|���ƃX�R�A��18�ƂȂ邱��()
        {
            RollMany(18, 0);

            _game.Roll(3);
            _game.Roll(7);  // �X�y�A
            _game.Roll(4);

            _game.Score().Is(18);
        }

        [Fact]
        public void Test_10�t���[���ڂŃX�g���C�N��7�{�|���ƃX�R�A��24�ƂȂ邱��()
        {
            RollMany(18, 0);

            _game.Roll(10); // �X�g���C�N
            _game.Roll(4);
            _game.Roll(3);

            _game.Score().Is(24);
        }

        [Fact]
        public void Test_10�t���[���ڂŃ_�u����6�{�|���ƃX�R�A��48�ƂȂ邱��()
        {
            RollMany(18, 0);

            _game.Roll(10); // �X�g���C�N
            _game.Roll(10); // �_�u��
            _game.Roll(6);

            _game.Score().Is(48);
        }

        [Fact]
        public void Test_10�t���[���ڂŃg���v�����ƃX�R�A��60�ƂȂ邱��()
        {
            RollMany(18, 0);

            _game.Roll(10); // �X�g���C�N
            _game.Roll(10); // �_�u��
            _game.Roll(10); // �^�[�L�[

            _game.Score().Is(60);
        }

        [Fact]
        public void Test_10�t���[�����ׂăX�g���C�N�����ƃX�R�A��300�ƂȂ邱��()
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
        public void Test_1��ڂ�1�{_2��ڂ�3�{�s����|���ƃX�R�A��4�ɂȂ�()
        {
            _frame.KnockedDown(1);
            _frame.KnockedDown(3);
            _frame.Next(2);

            _frame.Score().Is(4);
        }

        [Fact]
        public void Test_1��ڂ�7�{_2��ڂ�3�{�s����|���ƃX�R�A��10�ɂȂ�()
        {
            _frame.KnockedDown(7);
            _frame.KnockedDown(3);
            _frame.Next(2);

            _frame.Score().Is(10);
        }

        [Fact]
        public void Test_1��ڂ�1�{_2��ڂ�3�{�s����|���ƏI���ƂȂ�()
        {
            _frame.KnockedDown(1);
            _frame.Finish().IsFalse();

            _frame.KnockedDown(3);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_1��ڂ�7�{_2��ڂ�3�{�s����|���ƏI���ƂȂ�()
        {
            _frame.KnockedDown(7);
            _frame.Finish().IsFalse();

            _frame.KnockedDown(3);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_1��ڂ�10�{�s����|���ƏI���ƂȂ�()
        {
            _frame.KnockedDown(10);
            _frame.Finish().IsTrue();
        }

        [Fact]
        public void Test_�X�y�A���Ƃ�������3�{�s����|���Ə���̃t���[���̃X�R�A��13�ƂȂ�()
        {
            var frame = _frame;
            frame.KnockedDown(6);
            frame.KnockedDown(4);

            frame = _frame.Next(2);
            frame.KnockedDown(3);

            _frame.Score().Is(13);
        }

        [Fact]
        public void Test_�X�g���C�N���Ƃ������̃t���[���ō��v5�{�s����|���Ə���̃t���[���̃X�R�A��15�ƂȂ�()
        {
            var frame = _frame;
            frame.KnockedDown(10);

            frame = _frame.Next(2);
            frame.KnockedDown(1);
            frame.KnockedDown(4);

            _frame.Score().Is(15);
        }

        [Fact]
        public void Test_�_�u�����Ƃ���3�t���[���ڂ�1��ڂ�5�{�s����|���Ə���t���[���̃X�R�A��25�ƂȂ�()
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
