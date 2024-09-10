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
    public void OpenMeniu()
    {
        while (true)
        {
            System.Console.WriteLine("Todo App");
            string input = Console.ReadLine();
            bool isValidOption = Enum.IsDefined(typeof(Options), input.ToUpper());
            if (isValidOption)
            {
                System.Console.WriteLine("Valid option");
            }
            else
            {
                System.Console.WriteLine("Not a valid option");
            }
        }
    }
}