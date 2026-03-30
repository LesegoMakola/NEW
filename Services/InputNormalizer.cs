using System.Text;

namespace CybersecurityAwarenessChatbot.Services;

internal sealed class InputNormalizer
{
    public string Normalize(string input)
    {
        // Remove punctuation so similar questions match the same response rules.
        var builder = new StringBuilder(input.Length);
        bool previousCharacterWasSpace = false;

        foreach (char character in input.Trim().ToLowerInvariant())
        {
            if (char.IsLetterOrDigit(character))
            {
                builder.Append(character);
                previousCharacterWasSpace = false;
                continue;
            }

            if (char.IsWhiteSpace(character) && !previousCharacterWasSpace)
            {
                builder.Append(' ');
                previousCharacterWasSpace = true;
            }
        }

        return builder.ToString().Trim();
    }
}
