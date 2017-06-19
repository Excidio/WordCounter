using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.BusinessLayer.LineParsers;

namespace WordCounter.BusinessLayer
{
    public class WordCounter
    {
        private static readonly ILineParser LineParser = new RegexLineParser();
        
        public IDictionary<string, int> Calculate(string fileName)
        {
            var taskList = new LinkedList<Task>();
            var dictionary = new FrequencyDictionary<string>();

            foreach (var line in File.ReadLines(fileName))
            {
                taskList.AddLast(Task.Factory.StartNew(() => ProcessLine(dictionary, line)));
            }

            Task.WaitAll(taskList.ToArray());

            return dictionary;
        }

        private static void ProcessLine(FrequencyDictionary<string> dictionary, string value)
        {
            foreach (var val in LineParser.Parse(value))
            {
                dictionary.Add(val.ToLower());
            }
        }
    }
}
