using System.Text;

public class Task
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }


    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        return builder.Append($"Task id '{Id}' with description of '{Description}' and status of '{Status}' ").ToString();
    }
}