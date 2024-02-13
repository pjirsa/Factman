[![.NET](https://github.com/pjirsa/Factman/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pjirsa/Factman/actions/workflows/dotnet.yml)
# Factman
A sample Semantic Kernel application built while following the [SKDemo](https://www.gettingstarted.ai/using-semantic-kernel-add-ai-capabilities-to-csharp-app-microsoft-part-1/) tutorial written by [jeff](https://twitter.com/gswithai) on gettingstarted.ai.

## Run it
1. Update [appsettings.json](./appsettings.json) with your own values for Azure OpenAI:
```JSON
{
  "deployment": "<your deployment name here>",
  "endpoint": "<your Azure OpenAI endpoint here>"
}
```
2. Add a setting called "apiKey" to either appsettings.json or usersecrets.
1. Build and run the code.
