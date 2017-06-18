using System.Collections.Concurrent;

namespace WordCounter.BusinessLayer
{
    public class FrequencyDictionary<T>
    {
        private readonly ConcurrentDictionary<T, int> _dictionary = new ConcurrentDictionary<T, int>();

        public void Add(T key)
        {
            _dictionary.AddOrUpdate(key, 1, (v, i) => ++i);
        }

        public int GetValue(T key)
        {
            _dictionary.TryGetValue(key, out int result);

            return result;
        }
    }
}
