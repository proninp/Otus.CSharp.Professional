using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Extensions;
using HomeWork._05.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
        config.AddJsonFile(Path.Combine("Configuration", "appsettings.json"), optional: false, reloadOnChange: true))
    .ConfigureServices((context, services) =>
    {
        services.InstallGameServices(context.Configuration);
    })
    .UseConsoleLifetime()
    .Build();
    
var gameMenu = host.Services.GetRequiredService<IGameMenu>();
gameMenu.Run();