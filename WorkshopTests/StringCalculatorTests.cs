using Workshop2023Gr6;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("42", 42)]
        public void StringWithNumberReturnsItsValue(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0,1", 1)]
        [InlineData("3,1", 4)]
        [InlineData("72,20", 92)]
        public void TwoNumbersWithCommaSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0\n1", 1)]
        [InlineData("3\n1", 4)]
        [InlineData("72\n20", 92)]
        public void TwoNumbersWithNewLineSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0\n1,3", 4)]
        [InlineData("72\n20", 92)]
        public void MultipleNumbersWithNewLineOrCommaSeparatorsReturnsSum(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0\n1001,3", 3)]
        [InlineData("72\n1000", 1072)]
        [InlineData("5000", 0)]
        public void NumbersBiggerThanThousandIgnored(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-5\n5001,0")]
        [InlineData("3,-1,1\n1")]
        [InlineData("123\n30,-120")]
        [InlineData("-120")]
        public void NegativeNumbersThrowsException(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//X\n0\n1001,3X12", 15)]
        [InlineData("//#\n12,5,6\n8", 31)]
        [InlineData("//X\n1", 1)]
        [InlineData("// \n1 2,3", 6)]
        public void ShouldUseCustomNumberSeparatorIfSpecified(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(expected, result);
        }
    }
}