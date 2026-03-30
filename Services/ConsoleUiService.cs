namespace CybersecurityAwarenessChatbot.Services;

internal sealed class ConsoleUiService
{
    private const int TypingDelayMilliseconds = 12;

    public void ConfigureWindow()
    {
        Console.Title = "Cybersecurity Awareness Chatbot";
        Console.Clear();
    }

    public void ShowHeader(string banner)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('=', 90));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(banner);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(new string('=', 90));
        Console.ResetColor();
        Console.WriteLine();
    }

    public void WriteBotMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Bot: ");
        Console.ResetColor();
        WriteTypedLine(message, ConsoleColor.White);
        Console.WriteLine();
    }

    public void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    public string ReadPrompt(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{prompt}: ");
        Console.ResetColor();
        return Console.ReadLine() ?? string.Empty;
    }

    private static void WriteTypedLine(string message, ConsoleColor textColor)
    {
        Console.ForegroundColor = textColor;

        foreach (char letter in message)
        {
            Console.Write(letter);
            Thread.Sleep(TypingDelayMilliseconds);
        }

        Console.ResetColor();
        Console.WriteLine();
    }
}
