using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WordCounter.BusinessLayer;

namespace WordCounter.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new FrequencyDictionary<string>();

            foreach (var line in File.ReadLines(@"D:\Test\1.txt"))
            {
                var values = Regex
                    .Matches(line, "\\w+")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();

                foreach (var val in values)
                {
                    dictionary.Add(val.ToLower());
                }
            }
        }
    }
}
