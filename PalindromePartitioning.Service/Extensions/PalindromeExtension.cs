using System;
using System.Linq;

namespace PalindromePartitioning.Service.Extensions
{
    public static class PalindromeExtension
    {
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return string.Equals(input, new string(input.ToArray().Reverse().ToArray()), StringComparison.OrdinalIgnoreCase);
        }
    }
}
