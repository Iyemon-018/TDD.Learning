using System;
using Xunit;

namespace TestProject1
{
    using ConsoleApp1;


    [Collection("‰p¬•¶š‚Æ®”’l‚Ì•ÏŠ·‚ÆŒvZ‚ğˆµ‚¤ Calculator ƒNƒ‰ƒX")]
    public class CalculatorTest
    {
        public class •¶š—ñS‚ğ®”’l‚É•ÏŠ·‚µ‚Q”{‚·‚é
        {
            private readonly Calculator _calculator;

            public •¶š—ñS‚ğ®”’l‚É•ÏŠ·‚µ‚Q”{‚·‚é()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void •¶š—ñ100‚ğ“n‚·‚Æ®”’l200‚ğ•Ô‚·()
            {
                Assert.Equal("200", _calculator.Twice("100"));
            }

            [Fact]
            public void •¶š—ñ200‚ğ“n‚·‚Æ®”’l400‚ğ•Ô‚·()
            {
                Assert.Equal("400", _calculator.Twice("200"));
            }

            [Fact]
            public void •¶š—ñ012‚ğ“n‚·‚Æ®”’l24‚ğ•Ô‚·()
            {
                Assert.Equal("24", _calculator.Twice("012"));
            }
        }

        public class •¶š—ñS‚ª‰p¬•¶š‚ğŠÜ‚Şê‡‚Íerror‚É•ÏŠ·‚·‚é
        {
            private readonly Calculator _calculator;

            public •¶š—ñS‚ª‰p¬•¶š‚ğŠÜ‚Şê‡‚Íerror‚É•ÏŠ·‚·‚é()
            {
                _calculator = new Calculator();
            }

            [Fact]
            public void •¶š—ñabc‚ğ“n‚·‚Æerror‚ğ•Ô‚·()
            {
                Assert.Equal("error", _calculator.Twice("abc"));
            }


            [Fact]
            public void •¶š—ñ00a‚ğ“n‚·‚Æerror‚ğ•Ô‚·()
            {
                Assert.Equal("error", _calculator.Twice("00a"));
            }
        }
    }
}
