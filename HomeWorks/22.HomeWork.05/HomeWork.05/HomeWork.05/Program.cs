using HomeWork._05;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
    .ConfigureServices((context, services) =>
    {
        services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
    })
    .UseConsoleLifetime();

Console.WriteLine("Hello, World!");