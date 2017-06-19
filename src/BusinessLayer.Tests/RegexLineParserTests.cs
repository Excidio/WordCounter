using NUnit.Framework;
using WordCounter.BusinessLayer.LineParsers;

namespace WordCounter.BusinessLayer.Tests
{
    public class RegexLineParserTests
    {
        [TestCase("")]
        [TestCase("hello", "hello")]
        [TestCase("Hello world!", "Hello", "world")]
        [TestCase("HELLO WORLD!", "HELLO", "WORLD")]
        public void ParseTest(string line, params string[] expectedResult)
        {
            var parser = new RegexLineParser();

            var actualResult = parser.Parse(line);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
