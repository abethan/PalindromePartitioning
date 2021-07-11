using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PalindromePartitioning.Service;
using System;
using Xunit;

namespace PalindromePartitioning.Test
{
    public class PalindromePartitioningServiceTest
    {
        private readonly Mock<ILogger<PalindromePartitioningService>> _moqLogger;
        private readonly PalindromePartitioningService _palindromePartitionService;

        public PalindromePartitioningServiceTest()
        {
            _moqLogger = new Mock<ILogger<PalindromePartitioningService>>();
            _palindromePartitionService = new PalindromePartitioningService(_moqLogger.Object);
        }

        [Theory]
        [InlineData("racecar", new string[] { "r,a,c,e,c,a,r", "r,a,cec,a,r", "r,aceca,r", "racecar" })]
        [InlineData("AAA", new string[] { "A,A,A", "AA,A", "AAA" })]
        [InlineData("ABC", new string[] { "A,B,C" })]
        [InlineData("AbB", new string[] { "A,b,B", "A,bB" })]
        [InlineData("AAAAA", new string[] { "A,A,A,A,A", "AA,AA,A", "AAA,A,A", "AAAA,A", "AAAAA" })]
        public void GetPalindromePartitions_RandomWords_ReturnsPalindromePartitions(string input, string[] results)
        {
            var palindromes = _palindromePartitionService.GetPalindromePartitions(input);
            results.Should().Equal(palindromes);
        }

        [Fact]
        public void GetPalindromePartitions_ByPassingNull_ReturnsPalindromePartitions()
        {
            Action getPalindromePartitionsAction = () => _palindromePartitionService.GetPalindromePartitions(null);
            getPalindromePartitionsAction.Should().Throw<ArgumentException>().WithMessage("Input shouldn't be null or empty.");

            Assert.Equal(LogLevel.Error, _moqLogger.Invocations[0].Arguments[0]);
        }

        [Fact]
        public void GetPalindromePartitions_ByPassingEmptyString_ReturnsPalindromePartitions()
        {
            Action getPalindromePartitionsAction = () => _palindromePartitionService.GetPalindromePartitions(string.Empty);
            getPalindromePartitionsAction.Should().Throw<ArgumentException>().WithMessage("Input shouldn't be null or empty.");

            Assert.Equal(LogLevel.Error, _moqLogger.Invocations[0].Arguments[0]);
        }
    }
}
