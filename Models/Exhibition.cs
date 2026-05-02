public class Exhibition
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public DateTime Date { get; set; }
    public List<string> Tags { get; set; } = new();
}