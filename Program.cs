using CybersecurityAwarenessChatbot.Services;

namespace CybersecurityAwarenessChatbot;

internal static class Program
{
    private static void Main(string[] args)
    {
        var application = new ChatbotApplication(
            new ConsoleUiService(),
            new AsciiArtService(),
            new AudioGreetingService(),
            new InputNormalizer(),
            new ResponseService());

        application.Run();
    }
}
