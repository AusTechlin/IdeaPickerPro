using SQLite;

namespace IdeaPickerPro.Models;

public class Idea
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Description { get; set; }
}