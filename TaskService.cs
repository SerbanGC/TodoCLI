using System.Text.Json;

public class TaskService
{

    private string FileLocation;
    public TaskService(string FileLocation)
    {
        this.FileLocation = FileLocation;
    }

    public void AddTask()
    {
        System.Console.WriteLine("Please add the description for the new task:");
        string description = Console.ReadLine();
        List<Task> tasks = GetTaskList();
        int id = this.GenerateId(tasks);
        tasks.Add(new Task(id, description, false));
        SaveTaksList(tasks);
    }

    private int GenerateId(List<Task> tasks)
    {
        Random random = new Random();
        int id;
        do
        {
            id = random.Next(1, 300);
        } while (tasks.Any(x => x.Id == id));
        return id;
    }

    public List<Task> GetTaskList()
    {
        string text = File.ReadAllText(FileLocation);
        return JsonSerializer.Deserialize<List<Task>>(text);
    }

    private void SaveTaksList(List<Task> tasks)
    {
        string text = JsonSerializer.Serialize(tasks);
        File.WriteAllText(FileLocation, text);
    }

}