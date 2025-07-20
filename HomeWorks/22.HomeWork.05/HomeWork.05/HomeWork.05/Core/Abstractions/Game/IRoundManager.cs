using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Game;

/// <summary>
/// Сервис для управления раундом игры
/// </summary>
public interface IRoundManager
{
    /// <summary>
    /// Провести раунд игры между загадывающим и угадывающим
    /// </summary>
    /// <param name="riddler">Игрок, который загадывает число</param>
    /// <param name="guesser">Игрок, который угадывает число</param>
    /// <param name="maxAttempts">Максимальное количество попыток</param>
    /// <returns>Результат раунда</returns>
    GameRoundResult PlayRound(INumberRiddler riddler, INumberGuesser guesser, int maxAttempts);
}