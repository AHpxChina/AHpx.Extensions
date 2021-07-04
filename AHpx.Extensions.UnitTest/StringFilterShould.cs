using AHpx.Extensions.StringExtensions;
using Xunit;

namespace AHpx.Extensions.UnitTest
{
    public class StringFilterShould
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void BeFalseIfNullOrEmpty(string s)
        {
            Assert.False(s.IsNotNullOrEmpty());
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void BeTrueIfNullOrEmpty(string s)
        {
            Assert.True(s.IsNullOrEmpty());
        }
    }
}