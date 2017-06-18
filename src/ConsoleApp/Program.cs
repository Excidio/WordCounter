using System.IO;
using System.Linq;

namespace WordCounter.ConsoleApp
{
    public class Program
    {
        private static readonly BusinessLayer.WordCounter WordCounter = new BusinessLayer.WordCounter();

        public static void Main(string[] args)
        {
            var result = WordCounter.Calculate(@"D:\Test\1.txt");

            File.WriteAllLines(@"D:\Test\res.txt", result.OrderByDescending(p => p.Value).Select(p => $"{p.Key},{p.Value}\n"));
        }
    }
}
