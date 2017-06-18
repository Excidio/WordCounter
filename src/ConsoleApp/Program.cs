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
        private static readonly LineParser LineParser = new LineParser();

        public static void Main(string[] args)
        {
            var taskList = new LinkedList<Task>();

            foreach (var line in File.ReadLines(@"D:\Test\1.txt"))
            {
                taskList.AddLast(Task.Factory.StartNew(() => ProcessLine(line)));
            }

            Task.WaitAll(taskList.ToArray());

            File.WriteAllLines(@"D:\Test\res.txt", Dictionary.OrderByDescending(p => p.Value).Select(p => $"{p.Key},{p.Value}\n"));
        }

        private static void ProcessLine(string value)
        {
            foreach (var val in LineParser.Parse(value))
            {
                Dictionary.Add(val.ToLower());
            }
        }
    }
}
