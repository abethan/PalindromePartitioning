using PalindromePartitioning.Service.Extensions;
using Xunit;

namespace PalindromePartitioning.Test
{
    public class PalindromeExtensionTest
    {
        [Fact]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            var input = "AABBAA";
            var isPalindrome = input.IsPalindrome();

            Assert.True(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            var input = "AABBAAB";
            var isPalindrome = input.IsPalindrome();

            Assert.False(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_EmptyString_ReturnsFalse()
        {
            var input = string.Empty;
            var isPalindrome = input.IsPalindrome();

            Assert.False(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_NullString_ReturnsFalse()
        {
            string input = null;
            var isPalindrome = input.IsPalindrome();

            Assert.False(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_SingleString_ReturnsTrue()
        {
            var input = "A";
            var isPalindrome = input.IsPalindrome();

            Assert.True(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_PalindromeStringWithUpperAndLowerCaseLetters_ReturnsTrue()
        {
            var input = "RaceCar";
            var isPalindrome = input.IsPalindrome();

            Assert.True(isPalindrome);
        }
    }
}
