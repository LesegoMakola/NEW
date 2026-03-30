using System.Media;

namespace CybersecurityAwarenessChatbot.Services;

internal sealed class AudioGreetingService
{
    public void PlayWelcomeMessage()
    {
        // The WAV file is expected in the copied project assets folder.
        string audioPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Audio", "welcome.wav");

        if (!File.Exists(audioPath))
        {
            return;
        }

        try
        {
            using SoundPlayer player = new(audioPath);
            player.Load();
            player.PlaySync();
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Audio warning: {exception.Message}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
