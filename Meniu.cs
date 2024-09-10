using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

enum Options
{
    ADD,
    EDIT,
    DELETE,
    UPDATE,
    LIST,
    EXIT
}

class Meniu
{
    private Db db;
    private TaskService service;

    public Meniu(TaskService service, Db db)
    {
        this.db = db;
        this.service = service;
    }

    public void OpenMeniu()
    {
        System.Console.WriteLine("Todo App");
        while (true)
        {
            string input = Console.ReadLine();
            bool isValidOption = Enum.IsDefined(typeof(Options), input.ToUpper());
            if (isValidOption)
            {
                switch (input.ToUpper())
                {
                    case "LIST":
                        List<Task> tasks = service.GetTaskList();
                        PrintAllTasks(tasks);
                        break;
                    case "ADD":
                        service.AddTask();
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Not a valid option");
            }
        }
    }

    private void PrintAllTasks(List<Task> tasks)
    {
        Console.WriteLine("{0,-10} {1,-65} {2,-2}", "Id", "Description", "Status");
        Console.WriteLine(new string('-', 83));
        foreach (Task task in tasks)
        {
            System.Console.WriteLine("{0,-10} {1,-65} {2,-2}", task.Id, task.Description, task.Status);
        }

    }
}