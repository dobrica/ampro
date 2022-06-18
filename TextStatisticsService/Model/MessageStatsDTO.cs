namespace TextStatisticsService;

public class MessageStatsDTO
{
    public int MessageId { get; set; }
    public int CharactersCount { get; set; }
    public int WordsCount { get; set; }
    public int DistinctWordsCount { get; set; }
    public string MostFreqWord { get; set; } = String.Empty;
}