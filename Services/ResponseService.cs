namespace CybersecurityAwarenessChatbot.Services;

internal sealed class ResponseService
{
    public bool TryGetResponse(string normalizedQuestion, string userName, out string response)
    {
        if (normalizedQuestion.Contains("how are you"))
        {
            response = $"I am doing well, {userName}, and I am ready to help you stay safe online.";
            return true;
        }

        if (normalizedQuestion.Contains("what is your purpose") ||
            normalizedQuestion.Contains("whats your purpose") ||
            normalizedQuestion == "purpose")
        {
            response = "My purpose is to teach you how to spot cyber threats and protect your personal information.";
            return true;
        }

        if (normalizedQuestion.Contains("what can i ask you about") ||
            normalizedQuestion == "help" ||
            normalizedQuestion == "topics")
        {
            response = "You can ask me about password safety, phishing scams, suspicious links, and safe browsing habits.";
            return true;
        }

        if (normalizedQuestion.Contains("password"))
        {
            response = "Use a strong password with a mix of words, numbers, and symbols, and never reuse the same password everywhere.";
            return true;
        }

        if (normalizedQuestion.Contains("phishing"))
        {
            response = "Phishing messages try to trick you into giving away personal information. Always check the sender, links, and spelling before you click.";
            return true;
        }

        if (normalizedQuestion.Contains("safe browsing") ||
            normalizedQuestion.Contains("suspicious link") ||
            normalizedQuestion.Contains("links"))
        {
            response = "Before opening a link, hover over it if possible, check the web address carefully, and avoid websites that ask for sensitive information unexpectedly.";
            return true;
        }

        response = string.Empty;
        return false;
    }
}
