using System;
using Xunit;

namespace TestProject1
{
    using ConsoleApp1;


    [Collection("�p�������Ɛ����l�̕ϊ��ƌv�Z������ Calculator �N���X")]
    public class CalculatorTest
    {
        public class ������S�𐮐��l�ɕϊ����Q�{����
        {
            private readonly Calculator _calculator;

            public ������S�𐮐��l�ɕϊ����Q�{����()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void ������100��n���Ɛ����l200��Ԃ�()
            {
                Assert.Equal("200", _calculator.Twice("100"));
            }

            [Fact]
            public void ������200��n���Ɛ����l400��Ԃ�()
            {
                Assert.Equal("400", _calculator.Twice("200"));
            }

            [Fact]
            public void ������012��n���Ɛ����l24��Ԃ�()
            {
                Assert.Equal("24", _calculator.Twice("012"));
            }
        }

        public class ������S���p���������܂ޏꍇ��error�ɕϊ�����
        {
            private readonly Calculator _calculator;

            public ������S���p���������܂ޏꍇ��error�ɕϊ�����()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void ������abc��n����error��Ԃ�()
            {
                Assert.Equal("error", _calculator.Twice("abc"));
            }


            [Fact]
            public void ������00a��n����error��Ԃ�()
            {
                Assert.Equal("error", _calculator.Twice("00a"));
            }
        }
    }
}
