using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PalindromePartitioning.Service;
using System;

namespace PalindromePartitioning
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging(loggingBuilder => loggingBuilder.AddConsole().SetMinimumLevel(LogLevel.Debug))
                                    .AddSingleton<IPalindromePartitioningService, PalindromePartitioningService>()
                                    .BuildServiceProvider();

            serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();

            do
            {
                Console.WriteLine("Enter text:");
                var enteredText = Console.ReadLine();

                var palindromePartitionService = serviceProvider.GetRequiredService<IPalindromePartitioningService>();
                var palindromePartitions = palindromePartitionService.GetPalindromePartitions(enteredText);

                if (palindromePartitions != null)
                {
                    foreach (string palindromePartition in palindromePartitions)
                    {
                        Console.WriteLine(palindromePartition);
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Press ESC to exit or press any keys to retry.\r\n");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
