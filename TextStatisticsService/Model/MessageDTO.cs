namespace TextStatisticsService;

public class MessageDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string From { get; set; } = String.Empty;
    public string Body { get; set; } = String.Empty;
}