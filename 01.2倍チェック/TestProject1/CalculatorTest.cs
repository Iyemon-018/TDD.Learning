using System;
using Xunit;

namespace TestProject1
{
    using ConsoleApp1;


    [Collection("英小文字と整数値の変換と計算を扱う Calculator クラス")]
    public class CalculatorTest
    {
        public class 文字列Sを整数値に変換し２倍する
        {
            private readonly Calculator _calculator;

            public 文字列Sを整数値に変換し２倍する()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void 文字列100を渡すと整数値200を返す()
            {
                Assert.Equal("200", _calculator.Twice("100"));
            }

            [Fact]
            public void 文字列200を渡すと整数値400を返す()
            {
                Assert.Equal("400", _calculator.Twice("200"));
            }

            [Fact]
            public void 文字列012を渡すと整数値24を返す()
            {
                Assert.Equal("24", _calculator.Twice("012"));
            }
        }

        public class 文字列Sが英小文字を含む場合はerrorに変換する
        {
            private readonly Calculator _calculator;

            public 文字列Sが英小文字を含む場合はerrorに変換する()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void 文字列abcを渡すとerrorを返す()
            {
                Assert.Equal("error", _calculator.Twice("abc"));
            }


            [Fact]
            public void 文字列00aを渡すとerrorを返す()
            {
                Assert.Equal("error", _calculator.Twice("00a"));
            }
        }
    }
}
