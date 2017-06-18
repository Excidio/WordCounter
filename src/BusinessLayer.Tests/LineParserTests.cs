using NUnit.Framework;

namespace WordCounter.BusinessLayer.Tests
{
    public class LineParserTests
    {
        [TestCase("")]
        [TestCase("hello", "hello")]
        [TestCase("Hello world!", "Hello", "world")]
        [TestCase("HELLO WORLD!", "HELLO", "WORLD")]
        public void ParseTest(string line, params string[] expectedResult)
        {
            var parser = new LineParser();

            var actualResult = parser.Parse(line);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
