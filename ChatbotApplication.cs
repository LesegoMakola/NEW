using System.Globalization;
using CybersecurityAwarenessChatbot.Models;
using CybersecurityAwarenessChatbot.Services;

namespace CybersecurityAwarenessChatbot;

internal sealed class ChatbotApplication
{
    private readonly ConsoleUiService _consoleUiService;
    private readonly AsciiArtService _asciiArtService;
    private readonly AudioGreetingService _audioGreetingService;
    private readonly InputNormalizer _inputNormalizer;
    private readonly ResponseService _responseService;

    public ChatbotApplication(
        ConsoleUiService consoleUiService,
        AsciiArtService asciiArtService,
        AudioGreetingService audioGreetingService,
        InputNormalizer inputNormalizer,
        ResponseService responseService)
    {
        _consoleUiService = consoleUiService;
        _asciiArtService = asciiArtService;
        _audioGreetingService = audioGreetingService;
        _inputNormalizer = inputNormalizer;
        _responseService = responseService;
    }

    public void Run()
    {
        _consoleUiService.ConfigureWindow();
        _audioGreetingService.PlayWelcomeMessage();
        _consoleUiService.ShowHeader(_asciiArtService.CreateBanner());

        UserProfile user = GetUserProfile();

        _consoleUiService.WriteBotMessage(
            $"Hello, {user.Name}. I am your Cybersecurity Awareness Assistant. Ask me about passwords, phishing, or safe browsing or anything about cybersecurity.");
        _consoleUiService.WriteInfo("Type 'exit' whenever you want to close the chatbot.");

        StartConversation(user);
    }

    private UserProfile GetUserProfile()
    {
        // Keep asking until the user gives a usable name.
        while (true)
        {
            string nameInput = _consoleUiService.ReadPrompt("Enter your name");

            if (!string.IsNullOrWhiteSpace(nameInput))
            {
                return new UserProfile
                {
                    Name = FormatName(nameInput)
                };
            }

            _consoleUiService.WriteWarning("Please enter your name before continuing.");
        }
    }

    private void StartConversation(UserProfile user)
    {
        // This is the starter conversation loop for the first project milestone.
        while (true)
        {
            string question = _consoleUiService.ReadPrompt($"{user.Name}, ask a cybersecurity question");
            string normalizedQuestion = _inputNormalizer.Normalize(question);

            if (string.IsNullOrWhiteSpace(normalizedQuestion))
            {
                _consoleUiService.WriteWarning("I didn't quite understand that. Could you rephrase?");
                continue;
            }

            if (normalizedQuestion == "exit")
            {
                _consoleUiService.WriteBotMessage($"Goodbye, {user.Name}. Stay safe online.");
                return;
            }

            if (_responseService.TryGetResponse(normalizedQuestion, user.Name, out string response))
            {
                _consoleUiService.WriteBotMessage(response);
                continue;
            }

            _consoleUiService.WriteWarning("I didn't quite understand that. Could you rephrase?");
        }
    }

    private static string FormatName(string nameInput)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(nameInput.Trim().ToLowerInvariant());
    }
}
