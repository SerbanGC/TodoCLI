using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

enum Options
{
    ADD,
    EDIT,
    DELETE,
    UPDATE,
    LIST
}

class Meniu
{
    private Db db;

    public Meniu(Db db)
    {
        this.db = db;
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
                        List<Task> tasks = db.ReadFile();
                        PrintAllTasks(tasks);
                        break;
                    case "ADD":
                        db.AddTask();
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