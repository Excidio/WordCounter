using System.Collections.Concurrent;

namespace WordCounter.BusinessLayer
{
    public class FrequencyDictionary<T> : ConcurrentDictionary<T, int>
    {
        public void Add(T key)
        {
            AddOrUpdate(key, 1, (v, i) => ++i);
        }

        public int GetValue(T key)
        {
            TryGetValue(key, out int result);

            return result;
        }
    }
}
