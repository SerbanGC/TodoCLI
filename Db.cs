using System.Text.Json;
public class Db
{
    public string FileLocation { get; set; }

    public Db()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fileName = "TodoList.json";
        FileLocation = Path.Combine(currentDirectory, fileName);
    }

    public List<Task> readFile()
    {
        string text = File.ReadAllText(FileLocation);
        return JsonSerializer.Deserialize<List<Task>>(text);
    }


}