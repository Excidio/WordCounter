using System;
using System.IO;
using System.Linq;
using CommandLine;

namespace WordCounter.ConsoleApp
{
    public class Program
    {
        private static readonly BusinessLayer.WordCounter WordCounter = new BusinessLayer.WordCounter();

        public static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            var parser = new Parser(s =>
            {
                s.CaseSensitive = false;
                s.IgnoreUnknownArguments = false;
                s.MutuallyExclusive = true;
            });

            if (parser.ParseArguments(args, options))
            {
                try
                {
                    var result = WordCounter.Calculate(options.SourceFileName);

                    File.WriteAllLines(options.ResultFileName,
                        result.OrderByDescending(p => p.Value).Select(p => $"{p.Key},{p.Value}\n"));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e}");
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
                Console.ReadKey();
            }
        }
    }
}
