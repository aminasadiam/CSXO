public class Events
{
    public void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void BlueMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(message);
        Console.ResetColor();
    }
}