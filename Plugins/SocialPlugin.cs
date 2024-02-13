using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Plugins;
public class SocialPlugin
{
    [KernelFunction]
    [Description("Simulate posting to a social media platform.")]
    public async Task Post(
    Kernel kernel,
    [Description("The name of the social media platform")] string platform,
    [Description("The original message to adapt to the given platform")] string message
)
    {
        await Task.Delay(1000);

        Console.WriteLine("Posting: " + message);
        switch (platform.ToLower())
        {
            case "x":
            case "twitter":
                Console.WriteLine("Simulating post to X/twitter...");
                break;
            case "linkedin":
                Console.WriteLine("Simulating post to LinkedIn...");
                break;
            case "facebook":
                Console.WriteLine("Simulating post to Facebook...");
                break;
            default:
                Console.WriteLine($"Unknown platform: {platform}");
                break;
        }
    }
}