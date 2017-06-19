using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter.BusinessLayer.LineParsers
{
    public class RegexLineParser : ILineParser
    {
        /// <summary>
        /// Get words from the line.
        /// </summary>
        /// <param name="line">Input line</param>
        /// <returns>Array of words</returns>
        public string[] Parse(string line)
        {
            return Regex
                .Matches(line, "\\w+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}
