namespace WordCounter.BusinessLayer.LineParsers
{
    public interface ILineParser
    {
        string[] Parse(string line);
    }
}
