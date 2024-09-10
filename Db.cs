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

}