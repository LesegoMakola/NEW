using Figgle;
using Figgle.Fonts;

namespace CybersecurityAwarenessChatbot.Services;

internal sealed class AsciiArtService
{
    public string CreateBanner()
    {
        var font = FiggleFonts.Standard;
        string banner = font.Render("CYBER SAFE");
        return $"{banner}\nSouth African Cybersecurity Awareness Bot";
    }
}