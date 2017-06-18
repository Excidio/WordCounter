using System.Linq;
using NUnit.Framework;

namespace WordCounter.BusinessLayer.Tests
{
    [TestFixture]
    public class FrequencyDictionaryTests
    {
        [TestCase(1, "aaa")]
        [TestCase(1, "a", "aa", "aaa")]
        [TestCase(3, "aaa", "aaa", "aaa")]
        [TestCase(3, "aaa", "aba", "aaa", "aaa")]
        [TestCase(5, "aaa", "aaa", "aaa", "aaa", "aaa")]
        public void AddTest(int result, params string[] values)
        {
            var frequencyDictionary = new FrequencyDictionary<string>();

            foreach (var value in values)
            {
                frequencyDictionary.Add(value);
            }

            Assert.AreEqual(result, frequencyDictionary.GetValue(values.First()));
        }

        [TestCase(0, "aaa")]
        [TestCase(0, "a")]
        [TestCase(0, "ccc")]
        public void GetTest(int result, string value)
        {
            var frequencyDictionary = new FrequencyDictionary<string>();

            Assert.AreEqual(result, frequencyDictionary.GetValue(value));
        }
    }
}
