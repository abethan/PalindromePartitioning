using Microsoft.Extensions.Logging;
using PalindromePartitioning.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromePartitioning.Service
{
    public interface IPalindromePartitioningService
    {
        List<string> GetPalindromePartitions(string input);
    }

    public class PalindromePartitioningService : IPalindromePartitioningService
    {
        private readonly ILogger<PalindromePartitioningService> _logger;

        public PalindromePartitioningService(ILogger<PalindromePartitioningService> logger)
        {
            _logger = logger;
        }

        public List<string> GetPalindromePartitions(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentException("Input shouldn't be null or empty.");
                }

                var results = new List<string>();
                for (int cutLength = 1; cutLength <= input.Length; cutLength++)
                {
                    var loopWIthCutStringCountResuts = LoopInputWithCutLength(input, cutLength);

                    if (loopWIthCutStringCountResuts != null)
                    {
                        var concaternatedloopWithCutLengthResuts = loopWIthCutStringCountResuts.Aggregate((i, j) => $"{i},{j}");

                        if (!results.Contains(concaternatedloopWithCutLengthResuts))
                        {
                            results.Add(concaternatedloopWithCutLengthResuts);
                        }
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        private List<string> LoopInputWithCutLength(string input, int cutStringCount)
        {
            var resultsList = new List<string>();
            var isPalindromeFound = false;

            for (int leftIndex = 0; leftIndex <= input.Length - 1; leftIndex++)
            {
                if (input.Length - leftIndex < cutStringCount)
                {
                    var leftOverText = input[leftIndex..];
                    leftOverText.ToCharArray().ToList().ForEach(x => resultsList.Add(x.ToString()));
                    break;
                }
                else
                {
                    var palindromeCheckTest = input.Substring(leftIndex, cutStringCount);
                    var isPalindrome = palindromeCheckTest.IsPalindrome();
                    if (isPalindrome)
                    {
                        resultsList.Add(palindromeCheckTest);
                        leftIndex += cutStringCount - 1;

                        isPalindromeFound = true;
                    }
                    else
                    {
                        resultsList.Add(palindromeCheckTest[0].ToString());
                    }
                }
            }

            return isPalindromeFound ? resultsList : null;
        }
    }
}