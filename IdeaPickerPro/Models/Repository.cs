using SQLite;

namespace IdeaPickerPro.Models;

public class Repository
{
    private readonly SQLiteConnection _database;

    public Repository()
    {
        var dbPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "ideas.db");
        
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<Idea>();
    }

    public List<Idea> GetIdeas()
    {
        return _database.Table<Idea>().ToList();
    }
    
    public void SaveIdea(Idea idea)
    {
        _database.Insert(idea); 
    }
    
    public void DeleteIdea(int id)
    {
        var idea = GetIdeaById(id);
        _database.Delete(idea);
    }

    public Idea GetIdeaById(int id)
    {
        return _database.Table<Idea>().FirstOrDefault(i => i.Id == id);
    }
}