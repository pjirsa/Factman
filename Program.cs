// Import the Kernel class from the Microsoft.SemanticKernel namespace
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Plugins;

// Add configuration
var config = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.AddUserSecrets<Program>()
			.Build();

// Create a new Kernel Builder
var builder = Kernel.CreateBuilder();

// Add OpenAI Chat Completion to the builder
builder.AddAzureOpenAIChatCompletion(
    config["deployment"],
    config["endpoint"],
    config["apiKey"]
);

builder.Plugins.AddFromType<SocialPlugin>();
builder.Plugins.AddFromPromptDirectory("./Plugins/FactmanPlugin");

// Build the kernel using the configured builder
var kernel = builder.Build();

var commonMyth = await kernel.InvokeAsync("FactmanPlugin", "FindMyth");

var bustedMyth = await kernel.InvokeAsync("FactmanPlugin", "BustMyth", new() {
    { "myth", commonMyth }
});

var optimizeResponse = await kernel.InvokeAsync("FactmanPlugin", "AdaptMessage", new() {
    { "input", bustedMyth },
    { "platform", "twitter" }
});

var socialMediaPost = await kernel.InvokeAsync("SocialPlugin", "Post", new() {
    { "platform", "x" },
    { "message", optimizeResponse }
});

Console.WriteLine(socialMediaPost);