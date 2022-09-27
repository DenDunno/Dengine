
public static class Logger
{
    public static void ShowError(string error)
    {
        ShowText(error, ConsoleColor.Red);
    }
    
    public static void Show(string text)
    {
        ShowText(text, ConsoleColor.Yellow);
    }

    private static void ShowText(string text, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}