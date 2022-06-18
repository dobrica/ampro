using System.Linq;

namespace TextStatisticsService.BLL;

public static class TextStatisticsBL
{
    private readonly static List<char> Interpunction = new List<char> { '.', ',', '!', '?', ';', ':', ' ', '(', ')', '[', ']', '{', '}' };

    public static MessageStatsDTO GetStats(this MessageDTO messageDTO)
    {
        var words = GetListOfWordsInText(messageDTO);
        var distinctWords = GetListOfDistinctWords(words);

        return new MessageStatsDTO
        {
            MessageId = messageDTO.Id,
            CharactersCount = messageDTO.Body.Length,
            WordsCount = words.Count(),
            DistinctWordsCount = distinctWords.Count(),
            MostFreqWord = distinctWords.Select(g => g.Key).First()
        };
    }

    private static IOrderedEnumerable<IGrouping<string, string>> GetListOfDistinctWords(List<string> words)
    {
        return words.GroupBy(word => word,
            StringComparer.InvariantCultureIgnoreCase).OrderByDescending(group => group.Count());
    }

    private static List<string> GetListOfWordsInText(MessageDTO messageDTO)
    {
        var index = 0;
        var currentWord = "";
        var text = messageDTO.Body;
        var usedWords = new List<string>();

        while (index < text.Length)
        {
            while (index < text.Length && !Interpunction.Contains(text[index]))
            {
                currentWord += text[index];
                index++;
            }

            if (currentWord != "")
                usedWords.Add(currentWord);
            currentWord = "";

            while (index < text.Length && Interpunction.Contains(text[index]))
            {
                index++;
            }
        }
        return usedWords;
    }
}