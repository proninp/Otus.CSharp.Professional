using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Players;

/// <summary>
/// Фабрика для создания игроков по ролям
/// </summary>
public interface IPlayerFactory
{
    /// <summary>
    /// Создать загадывающего игрока для указанного режима
    /// </summary>
    /// <param name="mode">Режим игры</param>
    /// <returns>Игрок, который загадывает число</returns>
    INumberRiddler CreateRiddler(GameMode mode);

    /// <summary>
    /// Создать угадывающего игрока для указанного режима
    /// </summary>
    /// <param name="mode">Режим игры</param>
    /// <returns>Игрок, который угадывает число</returns>
    INumberGuesser CreateGuesser(GameMode mode);
}