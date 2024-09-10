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
    public void AddTask()
    {
        Random random = new Random();
        int id;
        System.Console.WriteLine("Please add the description for the new task:");
        string description = Console.ReadLine();
        List<Task> tasks = ReadFile();
        do
        {
            id = random.Next(1, 300);
        } while (tasks.Any(x => x.Id == id));

        tasks.Add(new Task(id, description, false));
        string text = JsonSerializer.Serialize(tasks);
        File.WriteAllText(FileLocation, text);



    }

    public List<Task> ReadFile()
    {
        string text = File.ReadAllText(FileLocation);
        return JsonSerializer.Deserialize<List<Task>>(text);
    }


}