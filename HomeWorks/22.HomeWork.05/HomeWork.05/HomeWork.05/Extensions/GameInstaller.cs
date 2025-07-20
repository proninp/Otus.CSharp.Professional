using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.UI;
using HomeWork._05.Core.Abstractions.Utils;
using HomeWork._05.Services.Game;
using HomeWork._05.Services.Players;
using HomeWork._05.Services.UI;
using HomeWork._05.Services.Utils;
using HomeWork._05.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork._05.Extensions;

/// <summary>
/// Расширения для настройки служб игры в контейнере зависимостей
/// </summary>
public static class GameInstaller
{
    
    /// <summary>
    /// Зарегистрировать все службы игры в контейнере зависимостей
    /// </summary>
    /// <param name="services">Коллекция служб</param>
    /// <param name="configuration">Конфигурация приложения</param>
    /// <returns>Коллекция служб для цепочки вызовов</returns>
    public static IServiceCollection InstallGameServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        
        services.Configure<GameSettings>(configuration.GetSection(nameof(GameSettings)));

        services.AddSingleton<INumberGenerator, NumberGenerator>();
        
        services.AddSingleton<IPlayerInterface, SpectreConsoleInterface>();
        
        services.AddSingleton<IPlayerFactory, PlayerFactory>();
        services.AddTransient<ComputerPlayer>();
        services.AddTransient<HumanPlayer>();

        services.AddSingleton<IGameCalculator, GameCalculator>();
        services.AddSingleton<IGameResultEvaluator, GameResultEvaluator>();
        services.AddSingleton<IRoundManager, RoundManager>();
        
        services.AddSingleton<IGameEngine, GameEngine>();
        services.AddSingleton<IGameMenu, GameMenu>();

        return services;
    }
}