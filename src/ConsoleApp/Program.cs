using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordCounter.BusinessLayer;

namespace WordCounter.ConsoleApp
{
    public class Program
    {
        private static readonly FrequencyDictionary<string> Dictionary = new FrequencyDictionary<string>();

        public static void Main(string[] args)
        {
            var taskList = new LinkedList<Task>();

            foreach (var line in File.ReadLines(@"D:\Test\1.txt"))
            {
                taskList.AddLast(Task.Factory.StartNew(() => Process(line)));
            }

            Task.WaitAll(taskList.ToArray());

            File.WriteAllLines(@"D:\Test\res.txt", Dictionary.OrderByDescending(p => p.Value).Select(p => $"{p.Key},{p.Value}\n"));
        }

        private static void Process(string value)
        {
            var values = Regex
                .Matches(value, "\\w+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

            foreach (var val in values)
            {
                Dictionary.Add(val.ToLower());
            }
        }
    }
}
