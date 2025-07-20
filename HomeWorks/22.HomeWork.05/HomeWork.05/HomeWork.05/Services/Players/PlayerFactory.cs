using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork._05.Services.Players;

/// <summary>
/// Фабрика для создания игроков по ролям
/// </summary>
public sealed class PlayerFactory(IServiceProvider serviceProvider) : IPlayerFactory
{
    /// <summary>
    /// Создать загадывающего игрока для указанного режима
    /// </summary>
    /// <param name="mode">Режим игры</param>
    /// <returns>Игрок, который загадывает число</returns>
    public INumberRiddler CreateRiddler(GameMode mode)
    {
        return mode switch
        {
            GameMode.ComputerAsRiddlerVsPlayer => serviceProvider.GetRequiredService<ComputerPlayer>(),
            GameMode.PlayerAsRiddlerVsComputer or GameMode.PlayerVsPlayer => 
                serviceProvider.GetRequiredService<HumanPlayer>(),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "Неподдерживаемый режим игры")
        };
    }

    /// <summary>
    /// Создать угадывающего игрока для указанного режима
    /// </summary>
    /// <param name="mode">Режим игры</param>
    /// <returns>Игрок, который угадывает число</returns>
    public INumberGuesser CreateGuesser(GameMode mode)
    {
        return mode switch
        {
            GameMode.ComputerAsRiddlerVsPlayer or GameMode.PlayerVsPlayer => 
                serviceProvider.GetRequiredService<HumanPlayer>(),
            GameMode.PlayerAsRiddlerVsComputer => serviceProvider.GetRequiredService<ComputerPlayer>(),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "Неподдерживаемый режим игры")
        };
    }
}