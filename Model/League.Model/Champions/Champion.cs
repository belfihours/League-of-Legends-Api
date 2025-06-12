namespace League.Model.Champions;

public class Champion
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Info Info { get; set; } = new();
    public IEnumerable<string> Classes = [];
    public string SecondaryBarType { get; set; } = string.Empty;
    public Stats Stats { get; set; } = new();
}
